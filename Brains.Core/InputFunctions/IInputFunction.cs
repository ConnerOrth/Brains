using Brains.Core.Synapses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Core.InputFunctions
{
    public interface IInputFunction
    {
        double CalculateInput(IList<ISynapse> inputs);
    }
}
