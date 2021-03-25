using System;

namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactMainStatRarityData
    {
        public readonly double InitialValue;
        public readonly double MaximumValue;
        public readonly double ValueIncrease;

        public ArtifactMainStatRarityData(double initialValue, double maximumValue, int upgradeLevel) : this(initialValue, maximumValue, (maximumValue - initialValue) / upgradeLevel)
        {
        }

        public ArtifactMainStatRarityData(double initialValue, double maximumValue, double valueIncrease)
        {
            InitialValue  = initialValue;
            MaximumValue  = maximumValue;
            ValueIncrease = valueIncrease;
        }

        public double GetForLevelAsDouble(int level)
        {
            return InitialValue + level * ValueIncrease;
        }
        
        public int GetForLevelAsInt(int level)
        {
            return (int) Math.Round(InitialValue + level * ValueIncrease);
        }
    }
}
