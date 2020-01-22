using Brains.Core.ActivationFunctions;
using Brains.Core.InputFunctions;
using Brains.Core.Layers;
using Brains.Infrastructure.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brains.Infrastructure.Layers
{
    public class InputLayer : Layer, IInputLayer
    {
        public InputLayer(int numberOfNeurons, IActivationFunction activationFunction, IInputFunction inputFunction)
        {
            for (int i = 0; i < numberOfNeurons; i++)
            {
                Neurons.Add(new InputNeuron(activationFunction, inputFunction));
            }
        }
    }
}
