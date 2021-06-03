using System.Collections.Immutable;

namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactImportanceFactor
    {
        public readonly ImmutableArray<double> Values;

        public ArtifactImportanceFactor(params double[] values)
        {
            Values = ImmutableArray.Create(values);
        }
    }
}
