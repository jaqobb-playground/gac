namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactSubStatRarityData
    {
        public readonly double[] PossibleValues;

        public ArtifactSubStatRarityData(params double[] possibleValues)
        {
            PossibleValues = possibleValues;
        }
    }
}
