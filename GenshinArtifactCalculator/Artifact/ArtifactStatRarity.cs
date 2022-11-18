namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactStatRarity
    {
        public readonly int Level;
        public readonly ArtifactStatRarityData? MainStatData;
        public readonly ArtifactStatRarityData? SubStatData;

        public ArtifactStatRarity(int level, ArtifactStatRarityData? mainStatData, ArtifactStatRarityData? subStatData)
        {
            Level = level;
            MainStatData = mainStatData;
            SubStatData = subStatData;
        }
    }
}
