using Brains.Core.ActivationFunctions;
using Brains.Core.InputFunctions;
using Brains.Core.Layers;
using Brains.Core.TrainingSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Core.NeuralNetworks
{
    public interface INeuralNetwork
    {
        IInputLayer InputLayer { get; set; }
        IList<ILayer> Layers { get; set; }
        IOutputLayer OutputLayer { get; }

        double[] ExpectedOutput { get; }

        void CreateInputLayer(int numberOfNeurons);


        void CreateHiddenLayer(int numberOfNeurons, IActivationFunction activationFunction, IInputFunction inputFunction);

        void AddLayer(ILayer newLayer);

        void Train(TrainingSet trainingSet, int trainingEpochs, double learningRate);

        /// <summary>
        /// Push input values to the neural network.
        /// </summary>
        void PushInputValues(double[] inputs);

        /// <summary>
        /// Set expected values for the outputs.
        /// </summary>
        void PushExpectedValues(double[] expectedOutputs);

        List<double> GetOutput();

        double[] GetOutputSoftMax();
    }
}
