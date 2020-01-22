using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Core.Synapses
{
    public interface ISynapse
    {
        string Name { get; set; }
        double Weight { get; set; }
        //double PreviousWeight { get; set; }
        double GetOutput();

        bool IsFromNeuron(Guid fromNeuronId);
        void UpdateWeight(double adjustment);
    }
}
