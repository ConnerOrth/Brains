using Brains.Core.Neurons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Core.Layers
{
    public interface ILayer
    {
        IList<INeuron> Neurons { get; set; }
        void ConnectTo(ILayer inputLayer);
    }
}
