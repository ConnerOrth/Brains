using Brains.Core.InputFunctions;
using Brains.Core.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brains.Infrastructure.InputFunctions
{
    public class WeightedSum : IInputFunction
    {
        public double CalculateInput(IList<ISynapse> inputs)
        {
            double weightedInput = 0;
            int count = inputs.Count;
            for (int i = 0; i < count; i++)
            {
                weightedInput += inputs[i].Weight * inputs[i].GetOutput();
            }
            return weightedInput;
        }
    }
}
