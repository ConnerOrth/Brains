//using Brains.Activators;
//using Brains.InputFunctions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Brains
//{
//    public class NeuralNetwork
//    {
//        public InputLayer InputLayer { get; set; }
//        public IList<Layer> Layers { get; set; } = new List<Layer>();
//        public double[] ExpectedOutput;

//        public void CreateInputLayer(int numberOfNeurons)
//        {
//            InputLayer = new InputLayer(numberOfNeurons, new ReLu(), new WeightedSum());
//            foreach (InputNeuron neuron in InputLayer.Neurons)
//            {
//                //neuron.AddInputSynapse(0);
//            }
//        }

//        public void CreateHiddenLayer(int numberOfNeurons, IActivationFunction activationFunction, IInputFunction inputFunction)
//        {
//            var layer = new Layer(numberOfNeurons, activationFunction, inputFunction);
//            AddLayer(layer);
//        }

//        public void AddLayer(Layer newLayer)
//        {
//            if (Layers.Any())
//            {
//                Layer lastLayer = Layers.Last();
//                newLayer.ConnectTo(lastLayer);
//            }
//            else
//            {
//                newLayer.ConnectTo(InputLayer);
//            }

//            Layers.Add(newLayer);
//            //_neuronErrors.Add(_layers.Count - 1, new double[newLayer.Neurons.Count]);
//        }

//        public void Train(TrainingSet trainingSet, int trainingEpochs, double learningRate)
//        {
//            PushInputValues(trainingSet.InputValues);
//            PushExpectedValues(trainingSet.ExpectedOutput);

//            for (int i = 0; i < trainingEpochs; i++)
//            {
//                int index = 0;
//                //for (int j = Layers.Count - 1; j >= 0; j--)
//                //{
//                //    int layerIndex = 0;
//                //    for (int k = 0; k < Layers[j].Neurons.Count; k++)
//                //    {
//                //        Layers[j].Neurons[k].Train(trainingSet.ExpectedOutputMatrix[index][layerIndex++], learningRate);
//                //    }
//                //    index++;
//                //}
//                foreach (Layer layer in Layers)
//                {
//                    int j = 0;
//                    foreach (Neuron neuron in layer.Neurons)
//                    {
//                        neuron.Train(trainingSet.ExpectedOutputMatrix[index][j++], learningRate);
//                    }
//                    index++;
//                }
//            }
//        }

//        /// <summary>
//        /// Push input values to the neural network.
//        /// </summary>
//        public void PushInputValues(double[] inputs)
//        {
//            int count = InputLayer.Neurons.Count;
//            for (int i = 0; i < count; i++)
//            {
//                InputLayer.Neurons[i].PushValueOnOutput(inputs[i]);
//            }
//        }

//        /// <summary>
//        /// Set expected values for the outputs.
//        /// </summary>
//        public void PushExpectedValues(double[] expectedOutputs)
//        {
//            ExpectedOutput = expectedOutputs;
//        }

//        public List<double> GetOutput()
//        {
//            var returnValue = new List<double>();
//            foreach (Neuron neuron in Layers.Last().Neurons)
//            {
//                returnValue.Add(neuron.CalculateOutput());
//            }
//            return returnValue;
//        }

//        public double[] GetOutputSoftMax()
//        {
//            var returnValue = new List<double>();
//            foreach (Neuron neuron in Layers.Last().Neurons)
//            {
//                returnValue.Add(neuron.CalculateOutput());
//            }
//            return SoftmaxActivationFunction.Softmax(returnValue.ToArray());
//        }
//    }
//}
