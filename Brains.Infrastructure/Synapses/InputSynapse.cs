using Brains.Core.Neurons;
using Brains.Core.Synapses;
using Brains.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Infrastructure.Synapses
{
    public class InputSynapse : ISynapse
    {
        internal INeuron toNeuron;
        public double Weight { get; set; }
        public double Output { get; set; }

        public string Name { get; set; }

        public InputSynapse(INeuron toNeuron, double? weight = null)
        {
            this.toNeuron = toNeuron;
            this.Weight = weight ?? CryptoRandom.RandomValue;
        }

        public double GetOutput()
        {
            return Output;
        }

        public bool IsFromNeuron(Guid fromNeuronId)
        {
            return false;
        }

        public void UpdateWeight(double adjustment)
        {
            if (Output == 0) return;
            Weight += adjustment;
        }
    }
}
