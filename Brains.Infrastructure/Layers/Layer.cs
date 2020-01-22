using Brains.Core.Layers;
using Brains.Core.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brains.Infrastructure.Layers
{
    public abstract class Layer : ILayer
    {
        public IList<INeuron> Neurons { get; set; } = new List<INeuron>();

        public virtual void ConnectTo(ILayer inputLayer)
        {
            var combos = Neurons.SelectMany(neuron => inputLayer.Neurons, (neuron, input) => new { neuron, input });
            combos.ToList().ForEach(x => x.neuron.AddInputNeuron(x.input));
        }
    }
}
