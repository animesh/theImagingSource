using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GrabSingleImage
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private TIS.Imaging.ICImagingControl icImagingControl1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.icImagingControl1 = new TIS.Imaging.ICImagingControl();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.icImagingControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// icImagingControl1
			// 
			this.icImagingControl1.DeBayerMode = TIS.Imaging.DeBayerModes.Edgesensing;
			this.icImagingControl1.DeBayerStartPattern = TIS.Imaging.DeBayerStartPatterns.BG;
			this.icImagingControl1.ImageRingBufferSize = 5;
			this.icImagingControl1.LiveDisplayHeight = 480;
			this.icImagingControl1.LiveDisplayWidth = 640;
			this.icImagingControl1.LiveShowLastBuffer = true;
			this.icImagingControl1.Location = new System.Drawing.Point(8, 32);
			this.icImagingControl1.Name = "icImagingControl1";
			this.icImagingControl1.OverlayBitmapPosition = TIS.Imaging.PathPositions.Device;
			this.icImagingControl1.Size = new System.Drawing.Size(280, 192);
			this.icImagingControl1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "IC Imaging Control Live Video";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 272);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Grabbed Image";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(8, 288);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(280, 192);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(96, 232);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "Capture";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 488);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.icImagingControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Grabbing a Single Image";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.icImagingControl1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		
		private void Form1_Load(object sender, System.EventArgs e)
		{
			icImagingControl1.ShowDeviceSettingsDialog();

			if( icImagingControl1.DeviceValid )
			{
				icImagingControl1.LiveStart();
			}
			else
			{
				Close();
			}
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			icImagingControl1.MemorySnapImage();
			pictureBox1.Image = icImagingControl1.ImageActiveBuffer.Bitmap;
		}
	}
}
