using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Infrastructure.ActivationFunctions
{
    public class Softmax //: IActivationFunction
    {
        /// <summary>
        ///   Computes the Softmax function (also known as normalized Exponencial
        ///   function) that "squashes"a vector or arbitrary real values into a 
        ///   vector of real values in the range (0, 1) that add up to 1.
        /// </summary>
        /// 
        /// <param name="input">The real values to be converted into the unit interval.</param>
        /// 
        /// <returns>A vector with the same number of dimensions as <paramref name="input"/>
        ///   but where values lie between 0 and 1.</returns>
        ///   
        public static double[] CalculateOutput(double[] input)
        {
            // determine max output sum
            // does all output nodes at once so scale doesn't have to be re-computed each time
            double max = input[0];
            for (int i = 0; i < input.Length; ++i)
                if (input[i] > max) max = input[i];

            // determine scaling factor -- sum of exp(each val - max)
            double scale = 0.0;
            for (int i = 0; i < input.Length; ++i)
                scale += Math.Exp(input[i] - max);

            double[] result = new double[input.Length];
            for (int i = 0; i < input.Length; ++i)
                result[i] = Math.Exp(input[i] - max) / scale;

            return result; // now scaled so that xi sum to 1.0
        }

        public double CalculateSlope(double input)
        {
            return input * (1 - input);
        }
    }
}
