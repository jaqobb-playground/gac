using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenshinArtifactCalculator.Artifact;
using Newtonsoft.Json;

namespace GenshinArtifactCalculator
{
    internal static class Program
    {
        private static readonly HttpClient Client = new();

        [STAThread]
        private static void Main(string[] arguments)
        {
            if (arguments.Length < 1)
            {
                MessageBox.Show("API key was not provided.", "Error", MessageBoxButtons.OK);
                return;
            }
            string presetToUse = "default";
            if (arguments.Length > 1)
            {
                presetToUse = arguments[1];
            }
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            string presetsFile = Path.Combine(directory, "importance-presets.txt");
            if (!File.Exists(presetsFile))
            {
                MessageBox.Show($"Could not find importance-presets.txt file at the provided location: {presetsFile}.", "Error", MessageBoxButtons.OK);
                return;
            }
            Dictionary<string, ArtifactImportancePreset> presets = new();
            foreach (string line in File.ReadAllLines(presetsFile))
            {
                string[] presetData = line.Split(";");
                string presetId = presetData[0];
                Dictionary<ArtifactType, Dictionary<ArtifactStat, ArtifactImportanceFactor>> mainStatFactors = new();
                Dictionary<ArtifactType, Dictionary<ArtifactStat, ArtifactImportanceFactor>> subStatFactors = new();
                for (int i = 1; i < presetData.Length; i++)
                {
                    string statFactorData = presetData[i];
                    ArtifactType? statFactorArtifactType = ArtifactTypes.Parse(statFactorData.Split("@")[0]);
                    if (statFactorArtifactType == null)
                    {
                        continue;
                    }
                    Dictionary<ArtifactStat, ArtifactImportanceFactor> mainStatFactorDictionary = new();
                    for (int j = 1; j < statFactorData.Split("@").Length; j++)
                    {
                        string mainStatFactorData = statFactorData.Split("@")[j];
                        ArtifactStat? artifactStat = ArtifactStats.ParseExact(mainStatFactorData.Split(":")[0]);
                        if (artifactStat == null)
                        {
                            continue;
                        }
                        double value = double.Parse(mainStatFactorData.Split(":")[1]);
                        mainStatFactorDictionary.Add(artifactStat, new ArtifactImportanceFactor(value));
                    }
                    Dictionary<ArtifactStat, ArtifactImportanceFactor> subStatFactorDictionary = new();
                    for (int j = 1; j < statFactorData.Split("&").Length; j++)
                    {
                        string subStatFactorData = statFactorData.Split("&")[j];
                        ArtifactStat? artifactStat = ArtifactStats.ParseExact(subStatFactorData.Split(":")[0]);
                        if (artifactStat == null)
                        {
                            continue;
                        }
                        double[] values = new double[4];
                        for (int k = 0; k < 4; k++)
                        {
                            values[k] = double.Parse(subStatFactorData.Split(":")[1].Split(",")[k]);
                        }
                        subStatFactorDictionary.Add(artifactStat, new ArtifactImportanceFactor(values));
                    }
                    mainStatFactors.Add(statFactorArtifactType, mainStatFactorDictionary);
                    subStatFactors.Add(statFactorArtifactType, subStatFactorDictionary);
                }
                presets.Add(presetId.ToLower(), new ArtifactImportancePreset(presetId, mainStatFactors, subStatFactors));
            }
            if (!presets.ContainsKey(presetToUse.ToLower()))
            {
                MessageBox.Show($"Could not find an importance preset with the provided name: {presetToUse}.", "Error", MessageBoxButtons.OK);
                return;
            }
            ArtifactImportancePreset preset = presets[presetToUse.ToLower()];
            string filePath = string.Empty;
            string fileExtension = string.Empty;
            using (OpenFileDialog dialog = new())
            {
                dialog.InitialDirectory = "C:\\";
                dialog.Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All image files (*.jpg;*.png)|*.jpg;*.png";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                    fileExtension = Path.GetExtension(filePath)[1..];
                }
            }
            if (filePath.Length == 0 || fileExtension.Length == 0)
            {
                MessageBox.Show("Could not determine file path or extension.", "Error", MessageBoxButtons.OK);
                return;
            }
            Dictionary<string, string> content = new()
            {
                { "apikey", arguments[0] },
                { "base64Image", $"data:image/{fileExtension};base64,{Convert.ToBase64String(File.ReadAllBytes(filePath))}" },
                { "detectOrientation", "true" },
                { "scale", "true" },
                { "isTable", "true" },
                { "OCREngine", "2" }
            };
#pragma warning disable 8620
            FormUrlEncodedContent encodedContent = new(content);
#pragma warning restore 8620
            Task<HttpResponseMessage> response = Client.PostAsync("https://api.ocr.space/parse/image", encodedContent);
            Task<string> responseString = response.Result.Content.ReadAsStringAsync();
            JsonSerializer serializer = new();
            IDictionary<object, object>? data = serializer.Deserialize<IDictionary<object, object>>(new JsonTextReader(new StringReader(responseString.Result)));
            if (data == null)
            {
                MessageBox.Show("Could not deserialize response.", "Error", MessageBoxButtons.OK);
                return;
            }
            long exitCode = (long)data["OCRExitCode"];
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
            ShowArtifactBox(new ArtifactData(data), preset);
        }

        private static void ShowArtifactBox(ArtifactData artifact, ArtifactImportancePreset preset)
        {
            string name = artifact.Name;
            string type = artifact.Type.Name;
            string upgradeLevel = artifact.GetBetterUpgradeLevel();
            string rarity = artifact.GetBetterRarityLevel();
            string mainStat = artifact.MainStat.Name;
            string mainStatValue = artifact.GetBetterMainStatValue();
            string mainStatImportanceValue = artifact.GetBetterMainStatImportanceValue(preset);
            string subStats = artifact.GetBetterSubStats(preset);
            string importanceValue = artifact.GetBetterImportanceValue(preset);
            MessageBox.Show($"Name: {name}\nType: {type}\nUpgrade Level: {upgradeLevel}\nRarity: {rarity}\nMain Stat: {mainStat}{mainStatValue} {mainStatImportanceValue}\nSub Stats: {subStats}\n\nImportance Value: {importanceValue}", $"Artifact Data ({preset.Id})", MessageBoxButtons.OK);
        }
    }
}
