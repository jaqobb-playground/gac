using System;

namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactStatRarityData
    {
        public readonly double[] PossibleValues;

        public ArtifactStatRarityData(params double[] possibleValues)
        {
            PossibleValues = possibleValues;
        }

        public double GetIndexByValue(double value)
        {
            for (int valueIndex = 0; valueIndex < PossibleValues.Length; valueIndex++)
            {
                if (PossibleValues[valueIndex].CompareTo(value) == 0)
                {
                    return valueIndex;
                }
            }
            return -1;
        }

        public double[] GetValues(double value, int iterations)
        {
            for (int iteration = 0; iteration < iterations; iteration++)
            {
                for (int currentInnerIteration = 0; currentInnerIteration <= iteration; currentInnerIteration++)
                {
                    double[] currentValues = Array.Empty<double>();
                    for (int possibleValueIndex = currentInnerIteration; possibleValueIndex < PossibleValues.Length; possibleValueIndex++)
                    {
                        double   possibleValue       = PossibleValues[possibleValueIndex];
                        double[] currentValuesNew    = new double[currentValues.Length + 1];
                        double   currentValuesNewSum = 0.0D;
                        for (int currentValueIndex = 0; currentValueIndex < currentValues.Length; currentValueIndex++)
                        {
                            currentValuesNew[currentValueIndex] =  currentValues[currentValueIndex];
                            currentValuesNewSum                 += currentValues[currentValueIndex];
                        }
                        currentValuesNew[^1] =  possibleValue;
                        currentValuesNewSum  += possibleValue;
                        int compareResult = Math.Round(currentValuesNewSum, 1).CompareTo(value);
                        //Console.WriteLine(Math.Round(currentValuesNewSum, 1) + " (" + possibleValue + ") == " + value + " (" + compareResult + ")");
                        if (compareResult == 0)
                        {
                            return currentValuesNew;
                        }
                        if (compareResult > 0)
                        {
                            break;
                        }
                        currentValues = currentValuesNew;
                    }
                }
            }
            return Array.Empty<double>();
        }
    }
}
