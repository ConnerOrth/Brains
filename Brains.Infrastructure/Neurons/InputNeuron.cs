using Brains.Core.ActivationFunctions;
using Brains.Core.InputFunctions;
using Brains.Core.Neurons;
using Brains.Infrastructure.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brains.Infrastructure.Neurons
{
    public class InputNeuron : Neuron
    {
        public InputNeuron(IActivationFunction activationFunction, IInputFunction inputFunction) : base(activationFunction, inputFunction)
        {
            this.activationFunction = activationFunction;
            this.inputFunction = inputFunction;
        }

        public InputNeuron(IActivationFunction activationFunction, IInputFunction inputFunction, double inputWeight)
        {
            this.activationFunction = activationFunction;
            this.inputFunction = inputFunction;
            AddOutputSynapse(inputWeight);
        }

        public override void AddInputNeuron(INeuron neuron)
        {
            //
        }

        public void AddOutputSynapse(double? outputWeight = null)
        {
            var inputSynapse = new InputSynapse(this, outputWeight);
            Outputs.Add(inputSynapse);
        }

        public void PushValueOnOutput(double outputValue)
        {
            if (!Outputs.Any())
            {
                AddOutputSynapse(outputValue);
            }
            ((InputSynapse)Outputs.First()).Output = outputValue;
        }

        public override double CalculateOutput()
        {
            return Outputs.First().GetOutput();
        }
    }
}
