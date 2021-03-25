using GenshinArtifactCalculator.Util;
using System;

namespace GenshinArtifactCalculator.Artifact
{
    public static class ArtifactTypes
    {
        public static readonly ArtifactType FlowerOfLife     = new ArtifactType("Flower of Life");
        public static readonly ArtifactType PlumeOfDeath     = new ArtifactType("Plume of Death");
        public static readonly ArtifactType SandsOfEon       = new ArtifactType("Sands of Eon");
        public static readonly ArtifactType GobletOfEonothem = new ArtifactType("Goblet of Eonothem");
        public static readonly ArtifactType CircletOfLogos   = new ArtifactType("Circlet of Logos");

        private static readonly ArtifactType[] Values = {FlowerOfLife, PlumeOfDeath, SandsOfEon, GobletOfEonothem, CircletOfLogos};

        public static ArtifactType? Parse(string? name)
        {
            if (name == null)
            {
                return null;
            }
            foreach (ArtifactType value in Values)
            {
                if (name.StartsWith(value.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return value;
                }
                int levenshteinDistance = Utils.ComputeLevenshteinDistance(name, value.Name);
                if (levenshteinDistance <= 2)
                {
                    return value;
                }
            }
            return null;
        }
    }
}
