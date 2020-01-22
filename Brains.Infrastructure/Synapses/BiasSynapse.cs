using Brains.Core.Synapses;
using Brains.Core.Neurons;
using System;
using System.Collections.Generic;
using System.Text;
using Brains.Infrastructure.Helpers;

namespace Brains.Infrastructure.Synapses
{
    public class BiasSynapse : ISynapse
    {
        internal INeuron toNeuron;
        public double Weight { get; set; }
        public string Name { get; set; }

        public BiasSynapse(INeuron toNeuron, double? weight)
        {
            this.toNeuron = toNeuron;
            this.Weight = weight ?? CryptoRandom.RandomValue;
        }

        public double GetOutput()
        {
            return 1;
        }

        public bool IsFromNeuron(Guid fromNeuronId)
        {
            return false;
        }

        public void UpdateWeight(double adjustment)
        {
            Weight += adjustment;
        }
    }
}
