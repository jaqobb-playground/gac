using System.Collections.Generic;

namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactStat
    {
        public readonly string Name;
        public readonly char? Symbol;
        public readonly List<ArtifactStatRarity> Rarities;

        public ArtifactStat(string name, char? symbol, List<ArtifactStatRarity> rarities)
        {
            Name = name;
            Symbol = symbol;
            Rarities = rarities;
        }

        public ArtifactStatRarity GetRarityByLevel(int level)
        {
            return Rarities[level - 1];
        }
    }
}
