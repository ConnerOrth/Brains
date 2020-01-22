using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Core.Neurons
{
    public interface IInputNeuron : INeuron
    {
        void AddInputSynapse(double inputValue);
        void PushValueOnInput(double inputValue);
    }
}
