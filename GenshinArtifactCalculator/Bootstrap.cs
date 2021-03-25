using GenshinArtifactCalculator.Artifact;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenshinArtifactCalculator
{
    internal static class Program
    {
        private static readonly HttpClient Client = new HttpClient();

        [STAThread]
        private static void Main(string[] arguments)
        {
            if (arguments.Length != 1)
            {
                MessageBox.Show("API key was not provided.", "Error", MessageBoxButtons.OK);
                return;
            }
            string filePath      = string.Empty;
            string fileExtension = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter           = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All image files (*.jpg;*.png)|*.jpg;*.png";
                openFileDialog.FilterIndex      = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath      = openFileDialog.FileName;
                    fileExtension = Path.GetExtension(filePath).Substring(1);
                }
            }
            if (filePath.Length == 0 || fileExtension.Length == 0)
            {
                MessageBox.Show("Could not determine file path or extension.", "Error", MessageBoxButtons.OK);
                return;
            }
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                {"apikey", arguments[0]},
                {"base64Image", $"data:image/{fileExtension};base64,{Convert.ToBase64String(File.ReadAllBytes(filePath))}"},
                {"detectOrientation", "true"},
                {"scale", "true"},
                {"isTable", "true"},
                {"OCREngine", "2"}
            };
            #pragma warning disable 8620
            FormUrlEncodedContent        content        = new FormUrlEncodedContent(values);
            #pragma warning restore 8620
            Task<HttpResponseMessage>    response       = Client.PostAsync("https://api.ocr.space/parse/image", content);
            Task<string>                 responseString = response.Result.Content.ReadAsStringAsync();
            JsonSerializer               serializer     = new JsonSerializer();
            IDictionary<object, object>? data           = serializer.Deserialize<IDictionary<object, object>>(new JsonTextReader(new StringReader(responseString.Result)));
            if (data == null)
            {
                MessageBox.Show("Could not deserialize response.", "Error", MessageBoxButtons.OK);
                return;
            }
            long exitCode = (long) data["OCRExitCode"];
            if (exitCode != 1L)
            {
                switch (exitCode)
                {
                    case 2:
                        MessageBox.Show("The provided image could not be fully parsed.", "Error", MessageBoxButtons.OK);
                        return;
                    case 3:
                        MessageBox.Show("The OCR engine failed to parse the provided image.", "Error", MessageBoxButtons.OK);
                        return;
                    case 4:
                        MessageBox.Show("A fatal error occured when attempting to parse the provided image.", "Error", MessageBoxButtons.OK);
                        return;
                }
            }
            ArtifactData artifact = new ArtifactData(data);
            MessageBox.Show($"Name: {artifact.Name}\nType: {artifact.Type.Name}\nUpgrade level: {artifact.GetBetterUpgradeLevel()}\nRarity: {artifact.GetBetterRarityLevel()}\nMain stat: {artifact.MainStat.Name} {artifact.GetBetterMainStatValue()}\nSub stats: {artifact.GetBetterSubStats()}", "Artifact data", MessageBoxButtons.OK);
        }
    }
}
