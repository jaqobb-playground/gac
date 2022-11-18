using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactData
    {
        public readonly string Name;
        public readonly ArtifactType Type;
        public readonly int UpgradeLevel;
        public readonly int RarityLevel;
        public readonly ArtifactStat MainStat;
        public readonly double MainStatValue;
        public readonly Dictionary<ArtifactStat, double>? SubStats;

        public ArtifactData(IDictionary<object, object> data)
        {
            JArray results = (JArray) data["ParsedResults"];
            foreach (JToken result in results)
            {
                JObject obj = result.Value<JObject>()!;
                long exitCode = obj["FileParseExitCode"]!.Value<long>();
                if (exitCode != 1L)
                {
                    continue;
                }
                JObject textOverlay = obj["TextOverlay"]!.Value<JObject>()!;
                JArray lines = textOverlay["Lines"]!.Value<JArray>()!;
                string mainStat = string.Empty;
                for (int i = 0; i < lines.Count; i++)
                {
                    JObject line = lines[i].Value<JObject>()!;
                    string lineText = line["LineText"]!.Value<string>()!;
                    switch (i)
                    {
                        case 0:
                            Name = lineText;
                            break;
                        case 1:
                            Type = ArtifactTypes.Parse(lineText) ?? throw new Exception($"{lineText} is not a valid artifact type");
                            break;
                        case 2:
                            mainStat += $"{lineText}+";
                            break;
                        case 3:
                            mainStat += lineText;
                            MainStat = ArtifactStats.Parse(mainStat) ?? throw new Exception($"{mainStat} is not a valid artifact stat");
                            MainStatValue = double.Parse(mainStat.Split("+")[1].Replace(",", "").Replace("%", ""));
                            break;
                        case 4:
                            UpgradeLevel = int.Parse(lineText.StartsWith("+") ? lineText.Substring(1) : lineText);
                            break;
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            SubStats ??= new Dictionary<ArtifactStat, double>(4);
                            ArtifactStat? stat = ArtifactStats.Parse(lineText);
                            if (stat == null)
                            {
                                throw new Exception($"{lineText} is not a valid artifact stat");
                            }
                            SubStats[stat] = double.Parse(lineText.Split("+")[1].Replace(",", "").Replace("%", ""));
                            break;
                    }
                }
            }
            if (Name == null || Type == null || MainStat == null)
            {
                throw new Exception("Could not fully deserialize artifact data");
            }
            if (UpgradeLevel > 16)
            {
                RarityLevel = 5;
            }
            else
            {
                foreach (ArtifactStatRarity rarity in MainStat.Rarities)
                {
                    ArtifactStatRarityData rarityData = rarity.MainStatData!;
                    if (rarityData.PossibleValues.Length > UpgradeLevel && rarityData.PossibleValues[UpgradeLevel].CompareTo(MainStatValue) == 0)
                    {
                        RarityLevel = rarity.Level;
                        break;
                    }
                }
            }
        }

        public string GetBetterUpgradeLevel()
        {
            return $"+{UpgradeLevel}";
        }

        public string GetBetterRarityLevel()
        {
            string result = string.Empty;
            for (int rarityLevel = 1; rarityLevel <= RarityLevel; rarityLevel++)
            {
                result += "\u2605"; // ★
            }
            return result;
        }

        public string GetBetterMainStatValue()
        {
            if (MainStat.Symbol is '%')
            {
                return $"+{MainStatValue:0.0}%";
            }
            return $"+{MainStatValue}";
        }

        public string GetBetterMainStatImportanceValue(ArtifactImportancePreset importancePreset)
        {
            if (!importancePreset.MainStatFactors.ContainsKey(Type))
            {
                return "(Could not calculate IV)";
            }
            Dictionary<ArtifactStat, ArtifactImportanceFactor> mainStatFactor = importancePreset.MainStatFactors[Type];
            if (!mainStatFactor.ContainsKey(MainStat))
            {
                return "(Could not calcualte IV)";
            }
            ArtifactImportanceFactor importanceFactor = mainStatFactor[MainStat];
            double importanceValueMaximum = importanceFactor.Values[0];
            double importanceValueActualMaximum = importanceValueMaximum;
            double importanceValue = UpgradeLevel * importanceValueMaximum / 20;
            foreach (KeyValuePair<ArtifactStat, ArtifactImportanceFactor> mainStatFactorEntry in mainStatFactor)
            {
                if (mainStatFactorEntry.Value.Values[0].CompareTo(importanceValueActualMaximum) > 0)
                {
                    importanceValueActualMaximum = mainStatFactorEntry.Value.Values[0];
                }
            }
            return $"({importanceValue}/{importanceValueMaximum} [{Math.Round(importanceValue / importanceValueMaximum * 100, 1)}%] | {importanceValue}/{importanceValueActualMaximum} [{Math.Round(importanceValue / importanceValueActualMaximum * 100, 1)}%] IV)";
        }

        public string GetBetterImportanceValue(ArtifactImportancePreset importancePreset)
        {
            if (!importancePreset.MainStatFactors.ContainsKey(Type))
            {
                return "(Could not calculate IV)";
            }
            Dictionary<ArtifactStat, ArtifactImportanceFactor> mainStatFactor = importancePreset.MainStatFactors[Type];
            if (!mainStatFactor.ContainsKey(MainStat))
            {
                return "(Could not calculate IV)";
            }
            double importanceValueMaximum = 0.0D;
            double importanceValueActualMaximum = 0.0D;
            double importanceValue = 0.0D;
            {
                ArtifactImportanceFactor importanceFactor = mainStatFactor[MainStat];
                importanceValueMaximum += importanceFactor.Values[0];
                double importanceValueActualMaximumTemporary = 0.0D;
                foreach (KeyValuePair<ArtifactStat, ArtifactImportanceFactor> mainStatFactorEntry in mainStatFactor)
                {
                    if (mainStatFactorEntry.Value.Values[0].CompareTo(importanceValueActualMaximumTemporary) > 0)
                    {
                        importanceValueActualMaximumTemporary = mainStatFactorEntry.Value.Values[0];
                    }
                }
                importanceValueActualMaximum += importanceValueActualMaximumTemporary;
                importanceValue += UpgradeLevel * importanceValueMaximum / 20;
            }
            {
                if (SubStats != null)
                {
                    foreach ((ArtifactStat subStatKey, double subStatValue) in SubStats)
                    {
                        ArtifactStatRarityData subStatKeyData = subStatKey.GetRarityByLevel(RarityLevel).SubStatData!;
                        foreach (double subStatKeyDataValue in subStatKeyData.GetValues(subStatValue, UpgradeLevel / 4 + 1))
                        {
                            if (!importancePreset.SubStatFactors.ContainsKey(Type))
                            {
                                return "(Could not calculate IV)";
                            }
                            Dictionary<ArtifactStat, ArtifactImportanceFactor> subStatFactor = importancePreset.SubStatFactors[Type];
                            if (!subStatFactor.ContainsKey(subStatKey))
                            {
                                return "(Could not calculate IV)";
                            }
                            ArtifactImportanceFactor importanceFactor = subStatFactor[subStatKey];
                            importanceValueMaximum += importanceFactor.Values[3];
                            importanceValue += importanceFactor.Values[subStatKeyData.GetIndexByValue(subStatKeyDataValue)];
                        }
                    }
                    if (!importancePreset.SubStatFactors.ContainsKey(Type))
                    {
                        return "(Could not calculate IV)";
                    }
                    {
                        Dictionary<ArtifactStat, ArtifactImportanceFactor> subStatFactor = importancePreset.SubStatFactors[Type];
                        List<ArtifactStat> excludedArtifactStats = new() { MainStat };
                        while (excludedArtifactStats.Count != 5)
                        {
                            ArtifactStat? subStatFactorStat = null;
                            double subStatFactorValue = 0.0D;
                            foreach (KeyValuePair<ArtifactStat, ArtifactImportanceFactor> subStatFactorEntry in subStatFactor)
                            {
                                if (excludedArtifactStats.Contains(subStatFactorEntry.Key))
                                {
                                    continue;
                                }
                                if (subStatFactorValue.CompareTo(subStatFactorEntry.Value.Values[3]) < 0)
                                {
                                    subStatFactorStat = subStatFactorEntry.Key;
                                    subStatFactorValue = subStatFactorEntry.Value.Values[3];
                                }
                            }
                            if (subStatFactorStat == null || subStatFactorValue.CompareTo(0.0D) == 0)
                            {
                                break;
                            }
                            excludedArtifactStats.Add(subStatFactorStat);
                            if (excludedArtifactStats.Count == 2)
                            {
                                importanceValueActualMaximum += subStatFactorValue * 6;
                            }
                            else
                            {
                                importanceValueActualMaximum += subStatFactorValue;
                            }
                        }
                    }
                }
            }
            return $"{importanceValue}/{importanceValueMaximum} [{Math.Round(importanceValue / importanceValueMaximum * 100, 1)}%] ({importanceValue}/{importanceValueActualMaximum} [{Math.Round(importanceValue / importanceValueActualMaximum * 100, 1)}%])";
        }

        public string GetBetterSubStats(ArtifactImportancePreset importancePreset)
        {
            if (SubStats == null)
            {
                return "none";
            }
            string result = string.Empty;
            foreach ((ArtifactStat subStatKey, double subStatValue) in SubStats)
            {
                result += "\n";
                result += $" - {subStatKey.Name}+";
                if (subStatKey.Symbol is '%')
                {
                    result += $"{subStatValue:0.0}%";
                }
                else
                {
                    result += $"{subStatValue}";
                }
                ArtifactStatRarityData subStatKeyData = subStatKey.GetRarityByLevel(RarityLevel).SubStatData!;
                foreach (double subStatKeyDataValue in subStatKeyData.GetValues(subStatValue, UpgradeLevel / 4 + 1))
                {
                    result += "\n";
                    if (subStatKey.Symbol is '%')
                    {
                        result += $"    - +{subStatKeyDataValue:0.0}/{subStatKeyData.PossibleValues[^1]:0.0}% ({subStatKeyData.GetIndexByValue(subStatKeyDataValue) + 1}/{subStatKeyData.PossibleValues.Length})";
                    }
                    else
                    {
                        result += $"    - +{subStatKeyDataValue}/{subStatKeyData.PossibleValues[^1]} ({subStatKeyData.GetIndexByValue(subStatKeyDataValue) + 1}/{subStatKeyData.PossibleValues.Length})";
                    }
                    if (!importancePreset.MainStatFactors.ContainsKey(Type))
                    {
                        result += " (Could not calculate IV)";
                    }
                    else
                    {
                        Dictionary<ArtifactStat, ArtifactImportanceFactor> subStatFactor = importancePreset.SubStatFactors[Type];
                        if (!subStatFactor.ContainsKey(subStatKey))
                        {
                            result += " (Could not calculate IV)";
                        }
                        else
                        {
                            ArtifactImportanceFactor importanceFactor = subStatFactor[subStatKey];
                            double importanceValueMaximum = importanceFactor.Values[3];
                            double importanceValue = importanceFactor.Values[subStatKeyData.GetIndexByValue(subStatKeyDataValue)];
                            result += $" ({importanceValue}/{importanceValueMaximum} IV)";
                        }
                    }
                }
            }
            return result;
        }
    }
}
