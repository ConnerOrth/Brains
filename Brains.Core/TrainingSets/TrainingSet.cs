using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Core.TrainingSets
{
    public class TrainingSet
    {
        public double[] InputValues;
        public double[] ExpectedOutput;
        public double[][] InputValuesMatrix;
        public double[][] ExpectedOutputMatrix;

        public TrainingSet(double[] inputs, params double[] output)
        {
            InputValues = inputs;
            ExpectedOutput = output;
        }
        public TrainingSet(double[] inputs, params double[][] outputMatrix)
        {
            InputValues = inputs;
            ExpectedOutputMatrix = outputMatrix;
        }
        public TrainingSet(double[][] inputsMatrix, params double[][] outputMatrix)
        {
            InputValuesMatrix = inputsMatrix;
            ExpectedOutputMatrix = outputMatrix;
        }
    }
}
