﻿using Brains.Core.ActivationFunctions;
using Brains.Core.InputFunctions;
using Brains.Core.Layers;
using Brains.Core.Neurons;
using Brains.Infrastructure.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brains.Infrastructure.Layers
{
    public class OutputLayer : Layer, IOutputLayer
    {
        public OutputLayer(int numberOfNeurons, IActivationFunction activationFunction, IInputFunction inputFunction)
        {
            for (int i = 0; i < numberOfNeurons; i++)
            {
                Neurons.Add(new Neuron(activationFunction, inputFunction));
            }
        }
    }
}
