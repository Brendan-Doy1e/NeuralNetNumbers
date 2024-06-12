# Neural Network Project

This project implements a basic neural network in C# designed to recognize handwritten digits from the MNIST dataset. It includes functionalities such as training the network, saving/loading trained weights, and adjusting network parameters dynamically.

## Features

- **Network Initialization**: Configurable network with customizable layers and neurons.
- **Training**: Train the network using provided MNIST data.
- **Forward Propagation**: Utilize trained data to predict outputs.
- **Backpropagation**: Adjust weights based on the error rates.
- **Weight Management**: Save and load trained weights to/from files.
- **GUI**: Interactive Windows Forms application to display predictions and train the network.

## Prerequisites

To run this project, you need:
- .NET Framework (Version 4.7.2 or later)
- Visual Studio 2019 or later (recommended for best experience)

## Installation

Clone the repository to your local machine using the following command:

```bash
git clone https://github.com/Brendan-Doy1e/NeuralNetNumbers
```

Open the solution file in Visual Studio and build the project to resolve dependencies.

## Usage

Run the application directly from Visual Studio using Ctrl+F5 (Start without debugging) to launch the GUI. Interact with the application through the graphical interface to train the network, adjust parameters, or make predictions.

### Training the Network

1. Go to `Train Network` in the menu.
2. Follow the on-screen instructions to load training data and begin the training process.
3. Monitor the training progress via debug outputs in the Visual Studio console.

### Making Predictions

1. Use the `Load Image` menu option to open an image of a handwritten digit.
2. The network will process the image and display the predicted digit.

### Adjusting Network Parameters

1. Select `Adjust Network` from the menu to open the network adjustment form.
2. Set the desired number of layers and neurons per layer.
3. Save the adjustments and retrain the network as needed.

## File Structure

- `Network.cs`: Contains the neural network's logic for initialization, forward and backward propagation, and weight management.
- `Neuron.cs`: Defines the neuron behavior including activation functions.
- `DigitImage.cs`: Handles loading and preprocessing of MNIST image data.
- `MainWindow.cs`: Contains all GUI interactions and event handlers.

## Acknowledgments

- MNIST dataset for providing sample handwritten digit images.
- .NET community for continuous support and guidance.
