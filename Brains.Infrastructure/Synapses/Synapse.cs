using Brains.Core.Neurons;
using Brains.Core.Synapses;
using Brains.Infrastructure.Helpers;
using Brains.Infrastructure.Neurons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Infrastructure.Synapses
{
    public class Synapse : ISynapse
    {
        internal INeuron fromNeuron;
        internal INeuron toNeuron;
        public double Weight { get; set; }
        public string Name { get; set; }

        public Synapse(INeuron fromNeuron, INeuron toNeuron, double? weight = null)
        {
            this.fromNeuron = fromNeuron;
            this.toNeuron = toNeuron;
            this.Weight = weight ?? CryptoRandom.RandomValue;
        }

        public double GetOutput()
        {
            return fromNeuron.CalculateOutput();
        }
        public bool IsFromNeuron(Guid fromNeuronId)
        {
            return fromNeuron.Id.Equals(fromNeuronId);
        }

        public void UpdateWeight(double adjustment)
        {
            if ((fromNeuron as InputNeuron)?.Outputs[0].GetOutput() == 0) return;
            Weight += adjustment;
        }
    }
}
