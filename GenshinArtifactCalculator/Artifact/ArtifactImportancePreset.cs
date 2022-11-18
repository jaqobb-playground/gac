using System.Collections.Generic;

namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactImportancePreset
    {
        public readonly string Id;
        public readonly Dictionary<ArtifactType, Dictionary<ArtifactStat, ArtifactImportanceFactor>> MainStatFactors;
        public readonly Dictionary<ArtifactType, Dictionary<ArtifactStat, ArtifactImportanceFactor>> SubStatFactors;

        public ArtifactImportancePreset(
            string id,
            Dictionary<ArtifactType, Dictionary<ArtifactStat, ArtifactImportanceFactor>> mainStatFactors,
            Dictionary<ArtifactType, Dictionary<ArtifactStat, ArtifactImportanceFactor>> subStatFactors
        )
        {
            Id = id;
            MainStatFactors = mainStatFactors;
            SubStatFactors = subStatFactors;
        }
    }
}
