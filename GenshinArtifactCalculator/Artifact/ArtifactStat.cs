using System.Collections.Generic;

namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactStat
    {
        public readonly string                   Name;
        public readonly char?                    SpecialCharacter;
        public readonly List<ArtifactStatRarity> Rarities;

        public ArtifactStat(string name, char? specialCharacter, List<ArtifactStatRarity> rarities)
        {
            Name             = name;
            SpecialCharacter = specialCharacter;
            Rarities         = rarities;
        }

        public ArtifactStatRarity GetRarityByLevel(int level)
        {
            return Rarities[level - 1];
        }
    }
}
