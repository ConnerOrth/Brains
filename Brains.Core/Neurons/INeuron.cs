using Brains.Core.Synapses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Core.Neurons
{
    public interface INeuron
    {
        Guid Id { get; }
        IList<ISynapse> Inputs { get; set; }
        IList<ISynapse> Outputs { get; set; }
        void AddInputNeuron(INeuron neuron);
        void AddOutputNeuron(INeuron neuron);
        double CalculateOutput();
    }
}
