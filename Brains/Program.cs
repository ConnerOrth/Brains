using Brains.Core.TrainingSets;
using Brains.Infrastructure.ActivationFunctions;
using Brains.Infrastructure.InputFunctions;
using Brains.Infrastructure.NeuralNetworks;
using Brains.Infrastructure.Neurons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Environment;

namespace Brains
{
    class Program
    {
        static void Test()
        {
            var arr = new double[][] { new double[] { 5.1, 3.5, 1.4, 0.2, 0, 0, 1 } };
            string arrjson = JsonConvert.SerializeObject(arr, Formatting.Indented);
            string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(SpecialFolder.UserProfile),@"source\repos\Brains\Brains\Datasets\irisdataset.json"));
            var result = JsonConvert.DeserializeObject<double[][]>(json);
        }
        static void Main(string[] args)
        {
            //Test();
            ////return;
            ////IrisDataSetTest();
            ////return;
            IrisTest2();
            return;
            ////var neuronOld = new NeuronOld(new double[] { 0.2, -0.5 }, 0.1, new ReLu(), new WeightedSum());

            ////for (int i = 0; i < 18; i++)
            //    //neuronOld.Learn(new double[] { 1, 0 }, expectedOutput: 1);

            ////Console.WriteLine(neuronOld.Output);
            ////Console.WriteLine(neuronOld.GetOutput());
            ////Console.WriteLine(neuronOld.Output == 0.50347476367354782d);

            //var trainingSet = new TrainingSet(new double[] { 1, 0 }, 1);
            //var trainingSet2 = new TrainingSet(new double[] { 1, 0, 1, 1 },
            //    new double[][]
            //    {
            //        new double[] { 1 },
            //        new double[] { 1 , 0 },
            //        new double[] { 1 , 0, 1 }
            //    });

            //var network = new NeuralNetwork();
            //network.CreateInputLayer(0);
            //var inputLayer = network.InputLayer;// new InputLayer(0, new ReLu(), new WeightedSum());
            //var i1 = new InputNeuron(new ReLu(), new WeightedSum(), 0.2);
            //var i2 = new InputNeuron(new ReLu(), new WeightedSum(), -0.5);
            //var i3 = new InputNeuron(new ReLu(), new WeightedSum(), 0.5);
            //var i4 = new InputNeuron(new ReLu(), new WeightedSum(), 0.4675);
            //inputLayer.Neurons.Add(i1);
            //inputLayer.Neurons.Add(i2);
            //inputLayer.Neurons.Add(i3);
            //inputLayer.Neurons.Add(i4);
            ////network.PushInputValues(trainingSet2.InputValues);
            ////network.Layers.Add(inputLayer);

            //network.CreateHiddenLayer(1, new ReLu(), new WeightedSum());
            //network.CreateHiddenLayer(2, new ReLu(), new WeightedSum());
            //network.CreateHiddenLayer(3, new ReLu(), new WeightedSum());

            //var hiddenlayer = network.Layers[0];// new Layer(0, new ReLu(), new WeightedSum());
            //                                    //var neuron = new Neuron(new ReLu(), new WeightedSum(), 0.1);
            //                                    //hiddenlayer.Neurons.Add(neuron);

            ////network.AddLayer(hiddenlayer);
            ////Console.WriteLine(network.GetOutput().First());

            //network.Train(trainingSet2, 20, 0.01);

            //Console.WriteLine("=====Outputs from final layer=====");
            //var result = network.GetOutput();
            //for (int i = 0; i < result.Count; i++)
            //{
            //    Console.WriteLine($"Neuron_{i}:{result[i]}");
            //}
            //Console.WriteLine("=====Softmax from final layer=====");
            //var resultSoftmax = network.GetOutputSoftMax();
            //for (int i = 0; i < result.Count; i++)
            //{
            //    Console.WriteLine($"Neuron_{i}:{resultSoftmax[i]}");
            //}

            //Console.Read();
        }

        static void IrisTest2()
        {
            var trainingSet = new TrainingSet(new double[] { 1, 0 }, 1);
            var trainingSet2 = new TrainingSet(new double[] { 1, 0, 1, 1 },
                new double[][]
                {
                        new double[] { 1 },
                        new double[] { 1 , 0 },
                        new double[] { 1 , 0, 1 }
                });

            var irisTrainingSetSample = new TrainingSet(new double[] { 5.1, 3.5, 1.4, 0.2 }, new double[] { 0, 0, 1 });

            //4,5,3
            var network = new NeuralNetwork();
            //network.CreateInputLayer(4);
            network.CreateInputLayer(0);
            var inputLayer = network.InputLayer;// new InputLayer(0, new ReLu(), new WeightedSum());
            var i1 = new InputNeuron(new ReLu(), new WeightedSum(), 0.2);
            var i2 = new InputNeuron(new ReLu(), new WeightedSum(), -0.5);
            var i3 = new InputNeuron(new ReLu(), new WeightedSum(), 0.5);
            var i4 = new InputNeuron(new ReLu(), new WeightedSum(), 0.4675);
            inputLayer.Neurons.Add(i1);
            inputLayer.Neurons.Add(i2);
            inputLayer.Neurons.Add(i3);
            inputLayer.Neurons.Add(i4);
            network.CreateHiddenLayer(5, new ReLu(), new WeightedSum());
            network.CreateHiddenLayer(3, new ReLu(), new WeightedSum());

            for (int i = 0; i < network.Layers.Count; i++)
            {
                for (int j = 0; j < network.Layers[i].Neurons.Count; j++)
                {
                    for (int k = 0; k < network.Layers[i].Neurons[j].Inputs.Count; k++)
                    {
                        network.Layers[i].Neurons[j].Inputs[k].Name = $"L{i}:N{j}:IS{k}";
                    }
                    for (int k = 0; k < network.Layers[i].Neurons[j].Outputs.Count; k++)
                    {
                        network.Layers[i].Neurons[j].Outputs[k].Name = $"L{i}:N{j}:OS{k}";
                    }
                }
            }

            network.Train(irisTrainingSetSample, 20, 0.01);

            Console.WriteLine("=====Outputs from final layer=====");
            var result = network.GetOutput();
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"Neuron_{i}:{result[i]}");
            }
            Console.WriteLine("=====Softmax from final layer=====");
            var resultSoftmax = network.GetOutputSoftMax();
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"Neuron_{i}:{resultSoftmax[i]}");
            }
            Console.Read();
        }
    }
}
