namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactStat
    {
        public string Name
        {
            get;
        }

        public char? SpecialCharacter
        {
            get;
        }

        public ArtifactStat(string name, char? specialCharacter = null)
        {
            Name             = name;
            SpecialCharacter = specialCharacter;
        }
    }
}
