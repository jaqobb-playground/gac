using GenshinArtifactCalculator.Util;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace GenshinArtifactCalculator.Artifact
{
    public class ArtifactStatRarityData
    {
        public readonly ImmutableArray<double> PossibleValues;

        public ArtifactStatRarityData(params double[] possibleValues)
        {
            PossibleValues = ImmutableArray.Create(possibleValues);
        }

        public int GetIndexByValue(double value)
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

        public double[] GetValues(double currentValue, int iterations)
        {
            double currentValueRounded = Math.Round(currentValue, 1);
            for (int iteration = 0; iteration < iterations; iteration++)
            {
                double[] values         = new double[iteration + 1];
                int      valueIndexFill = 0;
                ComputationLoop:
                foreach (double possibleValue in PossibleValues)
                {
                    values[valueIndexFill] = possibleValue;
                    double  valuesSum              = Math.Round(values.Sum(), 1);
                    decimal valuesSumDecimalPlaces = Utils.CountDecimalPlaces((decimal) valuesSum);
                    if (valuesSum.CompareTo(currentValueRounded) == 0)
                    {
                        return values;
                    }
                    if (valuesSumDecimalPlaces > 0)
                    {
                        // +/- 0.1 difference because of potential rounding issues on miHoYo's side.
                        if (Math.Round(valuesSum + 0.1D, 1).CompareTo(currentValueRounded) == 0 || Math.Round(valuesSum - 0.1D, 1).CompareTo(currentValueRounded) == 0)
                        {
                            return values;
                        }
                    }
                    else
                    {
                        // +/- 1 difference because of potential rounding issues on miHoYo's side.
                        if (Math.Round(valuesSum + 1.0D, 1).CompareTo(currentValueRounded) == 0 || Math.Round(valuesSum - 1.0D, 1).CompareTo(currentValueRounded) == 0)
                        {
                            return values;
                        }
                    }
                }
                if (values.Length is > 1 and < 7)
                {
                    bool continueComputation = values.Any(value => value.CompareTo(PossibleValues[^1]) != 0);
                    if (continueComputation)
                    {
                        if (valueIndexFill == 0)
                        {
                            values[0]      = PossibleValues[0];
                            valueIndexFill = values.Length - 1;
                            goto ComputationLoop;
                        }
                        if (values[valueIndexFill - 1].CompareTo(PossibleValues[^1]) != 0)
                        {
                            values[valueIndexFill - 1] = PossibleValues[GetIndexByValue(values[valueIndexFill - 1]) + 1];
                            goto ComputationLoop;
                        }
                        valueIndexFill -= 1;
                        if (valueIndexFill == 0)
                        {
                            valueIndexFill = values.Length - 1;
                        }
                        goto ComputationLoop;
                    }
                }
            }
            return Array.Empty<double>();
        }
    }
}
