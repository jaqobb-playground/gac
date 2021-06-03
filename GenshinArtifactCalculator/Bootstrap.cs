using GenshinArtifactCalculator.Artifact;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
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
            if (arguments.Length < 1)
            {
                MessageBox.Show("API key was not provided.", "Error", MessageBoxButtons.OK);
                return;
            }
            string importancePresetIdToUse = "default";
            if (arguments.Length > 1)
            {
                importancePresetIdToUse = arguments[1];
            }
            string directoryName         = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            string importancePresetsFile = Path.Combine(directoryName, "importance-presets.txt");
            if (!File.Exists(importancePresetsFile))
            {
                MessageBox.Show($"Could not find importance-presets.txt file at the provided location: {importancePresetsFile}.", "Error", MessageBoxButtons.OK);
                return;
            }
            Dictionary<string, ArtifactImportancePreset> importancePresets = new Dictionary<string, ArtifactImportancePreset>();
            foreach (string line in File.ReadAllLines(importancePresetsFile))
            {
                string[]                                                                     importancePresetData            = line.Split(";");
                string                                                                       importancePresetId              = importancePresetData[0];
                Dictionary<ArtifactType, Dictionary<ArtifactStat, ArtifactImportanceFactor>> importancePresetMainStatFactors = new Dictionary<ArtifactType, Dictionary<ArtifactStat, ArtifactImportanceFactor>>();
                Dictionary<ArtifactType, Dictionary<ArtifactStat, ArtifactImportanceFactor>> importancePresetSubStatFactors  = new Dictionary<ArtifactType, Dictionary<ArtifactStat, ArtifactImportanceFactor>>();
                for (int importancePresetStatFactorDataIndex = 1; importancePresetStatFactorDataIndex < importancePresetData.Length; importancePresetStatFactorDataIndex++)
                {
                    string        importancePresetStatFactorData         = importancePresetData[importancePresetStatFactorDataIndex];
                    ArtifactType? importancePresetStatFactorArtifactType = ArtifactTypes.Parse(importancePresetStatFactorData.Split("@")[0]);
                    if (importancePresetStatFactorArtifactType == null)
                    {
                        continue;
                    }
                    Dictionary<ArtifactStat, ArtifactImportanceFactor> importancePresetMainStatFactor = new Dictionary<ArtifactStat, ArtifactImportanceFactor>();
                    for (int importancePresetMainStatFactorDataIndex = 1; importancePresetMainStatFactorDataIndex < importancePresetStatFactorData.Split("@").Length; importancePresetMainStatFactorDataIndex++)
                    {
                        string        importancePresetMainStatFactorData         = importancePresetStatFactorData.Split("@")[importancePresetMainStatFactorDataIndex];
                        ArtifactStat? importancePresetMainStatFactorArtifactStat = ArtifactStats.ParseExact(importancePresetMainStatFactorData.Split(":")[0]);
                        if (importancePresetMainStatFactorArtifactStat == null)
                        {
                            continue;
                        }
                        double importancePresetMainStatFactorValue = double.Parse(importancePresetMainStatFactorData.Split(":")[1]);
                        importancePresetMainStatFactor.Add(importancePresetMainStatFactorArtifactStat, new ArtifactImportanceFactor(importancePresetMainStatFactorValue));
                    }
                    Dictionary<ArtifactStat, ArtifactImportanceFactor> importancePresetSubStatFactor = new Dictionary<ArtifactStat, ArtifactImportanceFactor>();
                    for (int importancePresetSubStatFactorDataIndex = 1; importancePresetSubStatFactorDataIndex < importancePresetStatFactorData.Split("&").Length; importancePresetSubStatFactorDataIndex++)
                    {
                        string        importancePresetSubStatFactorData         = importancePresetStatFactorData.Split("&")[importancePresetSubStatFactorDataIndex];
                        ArtifactStat? importancePresetSubStatFactorArtifactStat = ArtifactStats.ParseExact(importancePresetSubStatFactorData.Split(":")[0]);
                        if (importancePresetSubStatFactorArtifactStat == null)
                        {
                            continue;
                        }
                        double[] importancePresetSubStatFactorValues = new double[4];
                        for (int importancePresetSubStatFactorValueIndex = 0; importancePresetSubStatFactorValueIndex < 4; importancePresetSubStatFactorValueIndex++)
                        {
                            importancePresetSubStatFactorValues[importancePresetSubStatFactorValueIndex] = double.Parse(importancePresetSubStatFactorData.Split(":")[1].Split(",")[importancePresetSubStatFactorValueIndex]);
                        }
                        importancePresetSubStatFactor.Add(importancePresetSubStatFactorArtifactStat, new ArtifactImportanceFactor(importancePresetSubStatFactorValues));
                    }
                    importancePresetMainStatFactors.Add(importancePresetStatFactorArtifactType, importancePresetMainStatFactor);
                    importancePresetSubStatFactors.Add(importancePresetStatFactorArtifactType, importancePresetSubStatFactor);
                }
                importancePresets.Add(importancePresetId.ToLower(), new ArtifactImportancePreset(importancePresetId, importancePresetMainStatFactors, importancePresetSubStatFactors));
            }
            if (!importancePresets.ContainsKey(importancePresetIdToUse.ToLower()))
            {
                MessageBox.Show($"Could not find an importance preset with the provided name: {importancePresetIdToUse}.", "Error", MessageBoxButtons.OK);
                return;
            }
            ArtifactImportancePreset importancePresetToUse = importancePresets[importancePresetIdToUse.ToLower()];
            string                   filePath              = string.Empty;
            string                   fileExtension         = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter           = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All image files (*.jpg;*.png)|*.jpg;*.png";
                openFileDialog.FilterIndex      = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath      = openFileDialog.FileName;
                    fileExtension = Path.GetExtension(filePath)[1..];
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
            FormUrlEncodedContent content = new FormUrlEncodedContent(values);
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
            ArtifactData artifact                        = new ArtifactData(data);
            string       artifactName                    = artifact.Name;
            string       artifactType                    = artifact.Type.Name;
            string       artifactUpgradeLevel            = artifact.GetBetterUpgradeLevel();
            string       artifactRarity                  = artifact.GetBetterRarityLevel();
            string       artifactMainStat                = artifact.MainStat.Name;
            string       artifactMainStatValue           = artifact.GetBetterMainStatValue();
            string       artifactMainStatImportanceValue = artifact.GetBetterMainStatImportanceValue(importancePresetToUse);
            string       artifactSubStats                = artifact.GetBetterSubStats(importancePresetToUse);
            string       artifactImportanceValue         = artifact.GetBetterImportanceValue(importancePresetToUse);
            MessageBox.Show($"Name: {artifactName}\nType: {artifactType}\nUpgrade Level: {artifactUpgradeLevel}\nRarity: {artifactRarity}\nMain Stat: {artifactMainStat}{artifactMainStatValue} {artifactMainStatImportanceValue}\nSub Stats: {artifactSubStats}\n\nImportance Value: {artifactImportanceValue}", $"Artifact Data ({importancePresetToUse.Id})", MessageBoxButtons.OK);
        }
    }
}
