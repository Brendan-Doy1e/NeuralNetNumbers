using System;
using System.Windows.Forms;

namespace NeuralNet
{
    public partial class NetworkAdjustmentForm : Form
    {
        private NumericUpDown numLayer1;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Label label2;
        private NumericUpDown numNeurons2;
        private Button SaveAdjustments;
        private System.ComponentModel.IContainer components;

        public int[] NewStructure { get; private set; }

        public NetworkAdjustmentForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.numLayer1 = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numNeurons2 = new System.Windows.Forms.NumericUpDown();
            this.SaveAdjustments = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numLayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNeurons2)).BeginInit();
            this.SuspendLayout();
            // 
            // numLayer1
            // 
            this.numLayer1.Location = new System.Drawing.Point(85, 42);
            this.numLayer1.Name = "numLayer1";
            this.numLayer1.Size = new System.Drawing.Size(38, 20);
            this.numLayer1.TabIndex = 0;
            this.numLayer1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLayer1.ValueChanged += new System.EventHandler(this.numLayer1_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Layers";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Neurons";
            // 
            // numNeurons2
            // 
            this.numNeurons2.Location = new System.Drawing.Point(85, 85);
            this.numNeurons2.Name = "numNeurons2";
            this.numNeurons2.Size = new System.Drawing.Size(38, 20);
            this.numNeurons2.TabIndex = 4;
            this.numNeurons2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numNeurons2.ValueChanged += new System.EventHandler(this.numLayer2_ValueChanged);
            // 
            // SaveAdjustments
            // 
            this.SaveAdjustments.Location = new System.Drawing.Point(70, 180);
            this.SaveAdjustments.Name = "SaveAdjustments";
            this.SaveAdjustments.Size = new System.Drawing.Size(75, 23);
            this.SaveAdjustments.TabIndex = 5;
            this.SaveAdjustments.Text = "Save";
            this.SaveAdjustments.UseVisualStyleBackColor = true;
            this.SaveAdjustments.Click += new System.EventHandler(this.SaveAdjustments_Click);
            // 
            // NetworkAdjustmentForm
            // 
            this.ClientSize = new System.Drawing.Size(231, 215);
            this.Controls.Add(this.SaveAdjustments);
            this.Controls.Add(this.numNeurons2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numLayer1);
            this.Name = "NetworkAdjustmentForm";
            this.Load += new System.EventHandler(this.NetworkAdjustmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numLayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNeurons2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NetworkAdjustmentForm_Load(object sender, EventArgs e)
        {

        }

        private void SaveAdjustments_Click(object sender, EventArgs e)
        {
            int numberOfLayers = (int)numLayer1.Value; // Number of hidden layers
            int neuronsPerLayer = (int)numNeurons2.Value; // Number of neurons in each hidden layer

            // Create a new structure array with the input layer, hidden layers, and output layer
            NewStructure = new int[numberOfLayers + 2];
            NewStructure[0] = 784; // Input layer fixed to 784 neurons for 28x28 images

            // Set the number of neurons in each hidden layer
            for (int i = 1; i <= numberOfLayers; i++)
            {
                NewStructure[i] = neuronsPerLayer;
            }

            NewStructure[NewStructure.Length - 1] = 10; // Output layer fixed to 10 neurons for digits 0-9

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void numLayer1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numLayer2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

