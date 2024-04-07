using NeuralNet.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace NeuralNet
{
    public partial class MainWindow : Form
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine("MainWindow constructor called");

        }

        const int SIZE = 28;
        Network network;
        double[] input = new double[SIZE * SIZE];
        double[,] colors = new double[SIZE, SIZE];

        bool mouse = false;
        Graphics graphics;

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("MainWindow_Load called");

            network = new Network(new int[] { 784, 100, 100, 10 });
            network.LoadWeightsFromFile("weights.txt");
            graphics = pictureBoxPaint.CreateGraphics();
        }

        private void Clear()
        {
            Debug.WriteLine("Clear called");

            graphics.Clear(Color.Black);
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    colors[i, j] = 0.0;
                    input[i + j * SIZE] = 0.0;
                }
            }
            label1.Text = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("buttonClear_Click called");

            Clear();
        }

        private void pictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("pictureBoxPaint_MouseDown called");

            mouse = true;
            label1.Text = "";
        }

        private void pictureBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("pictureBoxPaint_MouseUp called");

            mouse = false;
            int k = 0;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    input[k] = colors[j, i];
                    k++;
                }
            }

            Debug.WriteLine("Input array: " + string.Join(", ", input));

            network.SetInput(input);
            network.ForwardFeed();
            int result = network.GetMaxNeuronIndex(network.Layers - 1);
            label1.Text = result + "";

            VisualizeInputArray(input);
        }

        private void VisualizeInputArray(double[] input)
        {
            Bitmap bmp = new Bitmap(SIZE, SIZE);
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    int pixelValue = (int)(input[i * SIZE + j] * 255);
                    bmp.SetPixel(j, i, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                }
            }
            bmp.Save("input_visualization.png"); // Save the visualization to a file
        }


        private void pictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse)
            {
                Debug.WriteLine("pictureBoxPaint_MouseMove called");

                int mx = ((int)(e.X / 10)), my = ((int)(e.Y / 10));
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        double dist = (i - mx) * (i - mx) + (j - my) * (j - my);
                        if (dist < 1) dist = 1;
                        dist *= dist;
                        colors[i, j] += (0.2 / dist) * 3;
                        if (colors[i, j] > 1) colors[i, j] = 1.0;
                        if (colors[i, j] < 0.035) colors[i, j] = 0.0;

                        int color = (int)(colors[i, j] * 255);
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(color, color, color)), i * 10, j * 10, 10, 10);
                    }
                }
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Debug.WriteLine("MainWindow_KeyDown called with Keys.Delete");

                Clear();
            }
        }

       private void Train_Click(object sender, EventArgs e)
        {
           /* Debug.WriteLine("Train_Click called");

            // Disable the button to prevent multiple clicks during training
            TrainNetwork.Enabled = false;

            // Maybe show a message to indicate that training is starting
            MessageBox.Show("Training started...");

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dataDirectory = Path.Combine(baseDirectory, "Data");
            string pixelFile = Path.Combine(dataDirectory, "train-images.idx3-ubyte");
            string labelFile = Path.Combine(dataDirectory, "train-labels.idx1-ubyte");
            int numImages = 60000; // Number of images in the dataset
            var stopWatch = new System.Diagnostics.Stopwatch();

            // Load training data
            DigitImage[] trainingData = DigitImage.LoadData(pixelFile, labelFile, numImages);

            // Initialize network
            int[] layers = { 784, 100, 100, 10 }; // Example: 784 input neurons (for 28x28 images), 250 hidden neurons, 100 hidden neurons, 10 output neurons (for digits 0-9)
            Network network = new Network(layers);
            network.SetRandomWeights();

            // Training parameters
            double learningRate = 0.1;
            int epochs = 10;

            stopWatch.Start();
            // Training loop
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                foreach (DigitImage image in trainingData)
                {
                    // Set input
                    double[] input = DigitImage.GetInput(image);
                    network.SetInput(input);

                    // Forward propagation
                    network.ForwardFeed();

                    // Backpropagation
                    network.BackPropogation(image.label, learningRate);
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Training time: {stopWatch.Elapsed} s");

            // Save trained weights
            network.SaveWeightsToFile("weights.txt");

            // Re-enable the button after training completes
            TrainNetwork.Enabled = true;

            // Update the status message
            MessageBox.Show("Training completed.");
           */
        }

        private void trainNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Train_Click called");

            // Disable the button to prevent multiple clicks during training
            trainNetworkToolStripMenuItem.Enabled = false;

            // Maybe show a message to indicate that training is starting
            MessageBox.Show("Training started...");

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dataDirectory = Path.Combine(baseDirectory, "Data");
            string pixelFile = Path.Combine(dataDirectory, "train-images.idx3-ubyte");
            string labelFile = Path.Combine(dataDirectory, "train-labels.idx1-ubyte");
            int numImages = 60000; // Number of images in the dataset
            var stopWatch = new System.Diagnostics.Stopwatch();

            // Load training data
            DigitImage[] trainingData = DigitImage.LoadData(pixelFile, labelFile, numImages);

            // Initialize network
            int[] layers = { 784, 100, 100, 10 }; // Example: 784 input neurons (for 28x28 images), 250 hidden neurons, 100 hidden neurons, 10 output neurons (for digits 0-9)
            Network network = new Network(layers);
            network.SetRandomWeights();

            // Training parameters
            double learningRate = 0.1;
            int epochs = 10;

            stopWatch.Start();
            // Training loop
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                foreach (DigitImage image in trainingData)
                {
                    // Set input
                    double[] input = DigitImage.GetInput(image);
                    network.SetInput(input);

                    // Forward propagation
                    network.ForwardFeed();

                    // Backpropagation
                    network.BackPropogation(image.label, learningRate);
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Training time: {stopWatch.Elapsed} s");

            // Save trained weights
            network.SaveWeightsToFile("weights.txt");

            // Re-enable the button after training completes
            trainNetworkToolStripMenuItem.Enabled = true;

            // Update the status message
            MessageBox.Show("Training completed.");

        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the file dialog to select an image
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image
                Bitmap image = new Bitmap(openFileDialog.FileName);

                // Preprocess the image (resize to 28x28, grayscale, etc.)
                Bitmap preprocessedImage = PreprocessImage(image);

                // Convert the image to the input format expected by the neural network
                double[] input = ImageToInputArray(preprocessedImage);

                // Feed the input to the neural network and get the prediction
                network.SetInput(input);
                network.ForwardFeed();
                int prediction = network.GetMaxNeuronIndex(network.Layers - 1);

                // Display the prediction
                label1.Text = $"{prediction}";

                // Optional: Display the preprocessed image
                pictureBoxPaint.Image = preprocessedImage;
            }

        }

        private Bitmap PreprocessImage(Bitmap image)
        {
            // Resize the image to 28x28
            Bitmap resizedImage = new Bitmap(image, new Size(SIZE, SIZE));

            // Convert to grayscale
            for (int i = 0; i < resizedImage.Width; i++)
            {
                for (int j = 0; j < resizedImage.Height; j++)
                {
                    Color originalColor = resizedImage.GetPixel(i, j);
                    int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    resizedImage.SetPixel(i, j, newColor);
                }
            }

            return resizedImage;
        }

        private double[] ImageToInputArray(Bitmap image)
        {
            double[] input = new double[SIZE * SIZE];
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color color = image.GetPixel(i, j);
                    input[i + (j * SIZE)] = color.R / 255.0; // Assuming grayscale, so R, G, and B should be equal
                }
            }
            return input;
        }

    }
}
