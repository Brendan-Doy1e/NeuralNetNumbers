﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;

namespace NeuralNet.NeuralNetwork
{
    class Network
    {
        public int Layers { get; set; }
        public Neuron[][] Neurons { get; set; }
        public double[][][] Weights { get; set; }

        public Network(int[] numbersOfNeurons)
        {
            //Debug.WriteLine("Initializing network...");

            Layers = numbersOfNeurons.Length;
            Neurons = new Neuron[Layers][];
            Weights = new double[Layers - 1][][];
            for (int i = 0; i < Layers; i++)
            {
                Neurons[i] = new Neuron[numbersOfNeurons[i]];
                for (int j = 0; j < numbersOfNeurons[i]; j++)
                    Neurons[i][j] = new Neuron();
                if (i < Layers - 1)
                {
                    Weights[i] = new double[numbersOfNeurons[i]][];
                    for (int j = 0; j < numbersOfNeurons[i]; j++)
                    {
                        Weights[i][j] = new double[numbersOfNeurons[i + 1]];
                    }
                }
            }
            //Debug.WriteLine("Network initialized.");

        }

        public void SetRandomWeights()
        {
            //Debug.WriteLine("Setting random weights...");

            Random rnd = new Random();
            for (int i = 0; i < Layers - 1; i++)
            {
                for (int j = 0; j < Neurons[i].Length; j++)
                {
                    for (int k = 0; k < Neurons[i + 1].Length; k++)
                    {
                        Weights[i][j][k] = rnd.Next(-100000, 100000) * 0.00002;
                    }
                }
            }
            //Debug.WriteLine("Random weights set.");

        }

        public void SetInput(double[] values)
        {
            //Debug.WriteLine("Setting input values...");

            for (int i = 0; i < Neurons[0].Length; i++)
                Neurons[0][i].Value = values[i];

            //Debug.WriteLine("Input values set.");

        }

        public void ForwardFeed()
        {
            //Debug.WriteLine("Starting forward feed 1...");

            for (int k = 1; k < Layers; k++)
            {
                for (int i = 0; i < Neurons[k].Length; i++)
                {
                    Neurons[k][i].Value = 0;
                    for (int j = 0; j < Neurons[k - 1].Length; j++)
                        Neurons[k][i].Value += Neurons[k - 1][j].Value * Weights[k - 1][j][i];
                    Neurons[k][i].Activation();
                }
            }
           // Debug.WriteLine("Forward feed 2 completed.");

        }

        public void ForwardFeed(int layerNumber)
        {
            //Debug.WriteLine($"Starting forward feed 2 for layer {layerNumber}...");

            for (int i = 0; i < Neurons[layerNumber].Length; i++)
            {
                Neurons[layerNumber][i].Value = 0;
                for (int j = 0; j < Neurons[layerNumber - 1].Length; j++)
                    Neurons[layerNumber][i].Value += Neurons[layerNumber - 1][j].Value * Weights[layerNumber - 1][j][i];
                Neurons[layerNumber][i].Activation();
            }
            //Debug.WriteLine($"Forward feed 2 for layer {layerNumber} completed.");

        }

        public void BackPropogation(int rightResult, double learningRate)
        {
            //Debug.WriteLine("Starting backpropagation...");

            // Error counter
            for (int i = 0; i < Neurons[Layers - 1].Length; i++)
            {
                if (rightResult != i)
                    Neurons[Layers - 1][i].Error = -Math.Pow(Neurons[Layers - 1][i].Value, 2);
            }
            Neurons[Layers - 1][rightResult].Error = Math.Pow(Neurons[Layers - 1][rightResult].Value - 1.0, 2);

            for (int i = Layers - 2; i >= 0; i--)
            {
                for (int j = 0; j < Neurons[i].Length; j++)
                {
                    double error = 0.0;
                    for (int k = 0; k < Neurons[i + 1].Length; k++)
                    {
                        error += Neurons[i + 1][k].Error * Weights[i][j][k];
                    }
                    Neurons[i][j].Error = error;
                }
            }

            // Weights update
            for (int i = 0; i < Layers - 1; i++)
            {
                for (int j = 0; j < Neurons[i].Length; j++)
                {
                    for (int k = 0; k < Neurons[i + 1].Length; k++)
                    {
                        Weights[i][j][k] +=
                            learningRate *
                            Neurons[i + 1][k].Error *
                            SigmoidDerivative(Neurons[i + 1][k].Value * Neurons[i][j].Value);
                    }
                }
            }
            //Debug.WriteLine("Backpropagation completed.");

        }

        public int GetMaxNeuronIndex(int layerNumber)
        {
            //Debug.WriteLine($"Getting max neuron index for layer {layerNumber}...");

            double[] values = new double[Neurons[layerNumber].Length];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Neurons[layerNumber][i].Value;
            }
            double maxValue = values.Max<double>();

            int maxIndex =  Array.IndexOf(values, maxValue);
           // Debug.WriteLine($"Max neuron index for layer {layerNumber} is {maxIndex}.");
            return maxIndex;
        }

        public static double Sigmoid(double x)
        {
            double result = 1 / (1 + Math.Pow(Math.E, -x));
            //Debug.WriteLine($"Sigmoid({x}) = {result}");
            return result;
        }

        public static double SigmoidDerivative(double x)
        {
            if (Math.Abs(x - 1) < 1e-9 || Math.Abs(x) < 1e-9) return 0.0;
            double result = x * (1.0 - x);
            //Debug.WriteLine($"SigmoidDerivative({x}) = {result}");

            return result;
        }

        public void SaveWeightsToFile(string path)
        {
            Debug.WriteLine($"Saving weights to file: {path}");

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < Layers - 1; i++)
            {
                for (int j = 0; j < Neurons[i].Length; j++)
                {
                    for (int k = 0; k < Neurons[i + 1].Length; k++)
                    {
                        text.Append(Weights[i][j][k].ToString(CultureInfo.InvariantCulture) + " ");
                    }
                }
            }

            // Write the weights to the file, creating the file if it doesn't exist
            File.WriteAllText(filePath, text.ToString());
            Debug.WriteLine("Weights saved to file.");

        }


        /*      public void LoadWeightsFromFile(string path)
              {
                  Debug.WriteLine($"Loading weights from file: {path}");

                  string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                  if (!File.Exists(filePath))
                  {
                      // If the file doesn't exist, create it and initialize with random weights
                      Debug.WriteLine("Weights file not found. Initializing with random weights.");

                      SetRandomWeights();
                      SaveWeightsToFile(path);
                      return; // Return after creating the file and initializing weights
                  }

                  // Load weights from the file if it exists
                  string text = File.ReadAllText(filePath);
                  string[] textWeights = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                  NumberFormatInfo formatInfo = CultureInfo.GetCultureInfo("de-DE").NumberFormat;
                  int c = 0;

                  for (int i = 0; i < Layers - 1; i++)
                  {
                      for (int j = 0; j < Neurons[i].Length; j++)
                      {
                          for (int k = 0; k < Neurons[i + 1].Length; k++)
                          {
                              if (!double.TryParse(textWeights[c], NumberStyles.Any, formatInfo, out double weightValue))
                              {
                                  Console.WriteLine($"Error parsing weight: {textWeights[c]} at index {c}");
                                  continue;
                              }
                              Weights[i][j][k] = weightValue;
                              c++;
                          }
                      }
                  }
                  Debug.WriteLine("Weights loaded from file.");

              }*/

        public void LoadWeightsFromFile(string path)
        {
            Debug.WriteLine($"Loading weights from file: {path}");

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            if (!File.Exists(filePath))
            {
                Debug.WriteLine("Weights file not found. Initializing with random weights.");
                SetRandomWeights();
                SaveWeightsToFile(path);
                return;
            }

            string text = File.ReadAllText(filePath);
            string[] textWeights = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<double> weightsList = new List<double>();
            NumberFormatInfo formatInfo = CultureInfo.GetCultureInfo("de-DE").NumberFormat;

            foreach (var weightString in textWeights)
            {
                if (double.TryParse(weightString, NumberStyles.Any, formatInfo, out double weightValue))
                {
                    weightsList.Add(weightValue);
                }
                else
                {
                    Console.WriteLine($"Error parsing weight: {weightString}");
                }
            }

            // Determine the structure of the network based on the number of weights
            int[] newStructure = DetermineNetworkStructure(weightsList);
            AdjustNetworkStructure(newStructure);

            // Load the weights into the network
            int c = 0;
            for (int i = 0; i < Layers - 1; i++)
            {
                for (int j = 0; j < Neurons[i].Length; j++)
                {
                    for (int k = 0; k < Neurons[i + 1].Length; k++)
                    {
                        if (c < weightsList.Count)
                        {
                            Weights[i][j][k] = weightsList[c++];
                        }
                    }
                }
            }

            Debug.WriteLine("Weights loaded from file and network structure adjusted.");
        }

        private int[] DetermineNetworkStructure(List<double> weightsList)
        {
            // Assuming the number of neurons in the input and output layers are fixed
            int inputLayerNeurons = 784; // Example: for a 28x28 image input
            int outputLayerNeurons = 10;  // Example: for a 10-class classification problem

            // Calculate the total number of connections (weights) between the input layer and the first hidden layer
            int totalInputToHiddenWeights = inputLayerNeurons * outputLayerNeurons;

            // Check if the total number of weights is enough for at least one hidden layer
            if (weightsList.Count < totalInputToHiddenWeights + outputLayerNeurons)
            {
                throw new Exception("Not enough weights to determine the network structure.");
            }

            // Calculate the number of neurons in the hidden layers
            // Assuming all hidden layers have the same number of neurons
            int hiddenLayerNeurons = (weightsList.Count - outputLayerNeurons) / (inputLayerNeurons + outputLayerNeurons);

            // Assuming one hidden layer for simplicity, but you can extend this logic for multiple hidden layers
            return new int[] { inputLayerNeurons, hiddenLayerNeurons, outputLayerNeurons };
        }






        public void AdjustNetworkStructure(int[] newNumbersOfNeurons)
        {
            // Reinitialize the network with the new structure
            Layers = newNumbersOfNeurons.Length;
            Neurons = new Neuron[Layers][];
            Weights = new double[Layers - 1][][];
            for (int i = 0; i < Layers; i++)
            {
                Neurons[i] = new Neuron[newNumbersOfNeurons[i]];
                for (int j = 0; j < newNumbersOfNeurons[i]; j++)
                    Neurons[i][j] = new Neuron();
                if (i < Layers - 1)
                {
                    Weights[i] = new double[newNumbersOfNeurons[i]][];
                    for (int j = 0; j < newNumbersOfNeurons[i]; j++)
                    {
                        Weights[i][j] = new double[newNumbersOfNeurons[i + 1]];
                    }
                }
            }

            // Optionally, you can reinitialize the weights here
            SetRandomWeights();
        }

        public double EvaluatePerformance(DigitImage[] testData)
        {
            int correctPredictions = 0;

            foreach (DigitImage image in testData)
            {
                double[] input = DigitImage.GetInput(image);
                SetInput(input);
                ForwardFeed();
                int predictedLabel = GetMaxNeuronIndex(Layers - 1);

                if (predictedLabel == image.label)
                {
                    correctPredictions++;
                }
            }

            return (double)correctPredictions / testData.Length * 100.0; // Return accuracy as a percentage
        }
    }

}
