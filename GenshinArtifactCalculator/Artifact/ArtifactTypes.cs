using System;
using System.Collections.Immutable;
using System.Linq;
using GenshinArtifactCalculator.Util;

namespace GenshinArtifactCalculator.Artifact
{
    public static class ArtifactTypes
    {
        public static readonly ArtifactType FlowerOfLife = new("Flower of Life");
        public static readonly ArtifactType PlumeOfDeath = new("Plume of Death");
        public static readonly ArtifactType SandsOfEon = new("Sands of Eon");
        public static readonly ArtifactType GobletOfEonothem = new("Goblet of Eonothem");
        public static readonly ArtifactType CircletOfLogos = new("Circlet of Logos");

        public static readonly ImmutableArray<ArtifactType> Values = ImmutableArray.Create(
            FlowerOfLife,
            PlumeOfDeath,
            SandsOfEon,
            GobletOfEonothem,
            CircletOfLogos
        );

        public static ArtifactType? Parse(string? name)
        {
            return name == null ? null : Values.FirstOrDefault(value => name.StartsWith(value.Name, StringComparison.OrdinalIgnoreCase) || Utils.ComputeLevenshteinDistance(name, value.Name) <= 2);
        }
    }
}
