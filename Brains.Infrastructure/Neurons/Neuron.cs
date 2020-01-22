using Brains.Core.ActivationFunctions;
using Brains.Core.InputFunctions;
using Brains.Core.Neurons;
using Brains.Core.Synapses;
using Brains.Infrastructure.Synapses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Infrastructure.Neurons
{
    public class Neuron : INeuron
    {
        protected IActivationFunction activationFunction;
        protected IInputFunction inputFunction;

        public IList<ISynapse> Inputs { get; set; } = new List<ISynapse>();
        public IList<ISynapse> Outputs { get; set; } = new List<ISynapse>();
        //public double TotalInput;
        //public double Error;
        //public double Adjustment;
        public Guid Id { get; private set; } = Guid.NewGuid();
        public bool IsCorrect;

        protected Neuron() { }

        public Neuron(IActivationFunction activationFunction, IInputFunction inputFunction)
        {
            this.activationFunction = activationFunction;
            this.inputFunction = inputFunction;
            AddBiasSynapse();
        }

        public Neuron(IActivationFunction activationFunction, IInputFunction inputFunction, double? bias = null)
        {
            this.activationFunction = activationFunction;
            this.inputFunction = inputFunction;
            AddBiasSynapse(bias);
        }

        public virtual void AddInputNeuron(INeuron neuron)
        {
            ISynapse synapse;
            if (neuron.GetType() == typeof(InputNeuron))
            {
                synapse = new Synapse(neuron, this, neuron.Outputs[0].Weight);
                Inputs.Add(synapse);
            }
            else
            {
                synapse = new Synapse(neuron, this);
                Inputs.Add(synapse);
                neuron.Outputs.Add(synapse);
            }
        }

        public void AddOutputNeuron(INeuron neuron)
        {
            var synapse = new Synapse(this, neuron);
            Outputs.Add(synapse);
            neuron.Inputs.Add(synapse);
        }

        private void AddBiasSynapse(double? bias = null)
        {
            var biasSynapse = new BiasSynapse(this, bias);
            Inputs.Add(biasSynapse);
        }

        public void Train(double expectedOutput, double learningRate)
        {
            //var input = inputFunction.CalculateInput(Inputs);
            var output = CalculateOutput();

            //error = expectedOutput - output;
            var error = CalculateError(output, expectedOutput);
            var slope = activationFunction.CalculateSlope(output);

            //adjustment = (error * slope) * learningrate
            var adjustment = CalculateAdjustment(error, slope, learningRate);

            //UpdateWeightsAndBiases(input);
            for (int i = 0; i < Inputs.Count; i++)
            {
                Inputs[i].UpdateWeight(adjustment);
            }

            var newOutput = CalculateOutput();

            IsCorrect = expectedOutput == Math.Round(output);
        }

        public double CalculateAdjustment(double error, double slope, double learningRate)
        {
            return error * slope * learningRate;
        }

        public virtual double CalculateOutput()
        {
            //apply activation
            return activationFunction.CalculateOutput(inputFunction.CalculateInput(Inputs));
        }

        public double CalculateError(double result, double expectedResult)
        {
            return expectedResult - result;
        }
    }
}
