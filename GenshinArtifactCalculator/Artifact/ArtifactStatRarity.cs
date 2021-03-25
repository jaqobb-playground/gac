namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactStatRarity
    {
        public readonly int                         Level;
        public readonly ArtifactMainStatRarityData? MainStatData;
        public readonly ArtifactSubStatRarityData?  SubStatData;

        public ArtifactStatRarity(int level, ArtifactMainStatRarityData? mainStatData, ArtifactSubStatRarityData? subStatData)
        {
            Level        = level;
            MainStatData = mainStatData;
            SubStatData  = subStatData;
        }
    }
}
