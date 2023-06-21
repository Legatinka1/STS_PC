
namespace STSGui
{
    partial class VisitFullControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commentsButtonPictureBox = new STSGui.ButtonPictureBox();
            this.printButtonPictureBox = new STSGui.ButtonPictureBox();
            this.pressureButtonPictureBox = new STSGui.ButtonPictureBox();
            this.vistTestsControl1 = new STSGui.Controls.Visit.VistTestsControl();
            this.ucTestGraphExhFlow = new STSGui.UCTestGraph();
            this.ucTestGraphFVC = new STSGui.UCTestGraph();
            this.printVectorButtonPictureBox = new STSGui.ButtonPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.commentsButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printVectorButtonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // commentsButtonPictureBox
            // 
            this.commentsButtonPictureBox.BackgroundImage = global::STSGui.Properties.Resources.patients_details_button_background_img;
            this.commentsButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_comments_disable;
            this.commentsButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.commentsButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_comments_normal;
            this.commentsButtonPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.commentsButtonPictureBox.IsTextColorMouseChanged = false;
            this.commentsButtonPictureBox.Location = new System.Drawing.Point(1311, 75);
            this.commentsButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_comments_down;
            this.commentsButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.commentsButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_comments_over;
            this.commentsButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.commentsButtonPictureBox.Name = "commentsButtonPictureBox";
            this.commentsButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_comments_normal;
            this.commentsButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.commentsButtonPictureBox.Size = new System.Drawing.Size(52, 44);
            this.commentsButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.commentsButtonPictureBox.TabIndex = 119;
            this.commentsButtonPictureBox.TabStop = false;
            this.commentsButtonPictureBox.Text = null;
            this.commentsButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.commentsButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentsButtonPictureBox.Visible = false;
            this.commentsButtonPictureBox.XTextOffset = 0;
            this.commentsButtonPictureBox.YTextOffset = 0;
            this.commentsButtonPictureBox.Click += new System.EventHandler(this.commentsButtonPictureBox_Click);
            // 
            // printButtonPictureBox
            // 
            this.printButtonPictureBox.BackColor = System.Drawing.Color.White;
            this.printButtonPictureBox.BackgroundImage = global::STSGui.Properties.Resources.patients_details_button_background_img;
            this.printButtonPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.printButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_printer_items_disable;
            this.printButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.printButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_printer_items_normal;
            this.printButtonPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.printButtonPictureBox.IsTextColorMouseChanged = false;
            this.printButtonPictureBox.Location = new System.Drawing.Point(1435, 75);
            this.printButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_printer_items_down;
            this.printButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.printButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_printer_items_over;
            this.printButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.printButtonPictureBox.Name = "printButtonPictureBox";
            this.printButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_printer_items_normal;
            this.printButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.printButtonPictureBox.Size = new System.Drawing.Size(52, 44);
            this.printButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.printButtonPictureBox.TabIndex = 118;
            this.printButtonPictureBox.TabStop = false;
            this.printButtonPictureBox.Text = null;
            this.printButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.printButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButtonPictureBox.XTextOffset = 0;
            this.printButtonPictureBox.YTextOffset = 0;
            this.printButtonPictureBox.Click += new System.EventHandler(this.printButtonPictureBox_Click);
            // 
            // pressureButtonPictureBox
            // 
            this.pressureButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disable;
            this.pressureButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.pressureButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.pressureButtonPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pressureButtonPictureBox.IsTextColorMouseChanged = false;
            this.pressureButtonPictureBox.Location = new System.Drawing.Point(1559, 75);
            this.pressureButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_down;
            this.pressureButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.pressureButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_;
            this.pressureButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.pressureButtonPictureBox.Name = "pressureButtonPictureBox";
            this.pressureButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.pressureButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.pressureButtonPictureBox.Size = new System.Drawing.Size(141, 44);
            this.pressureButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pressureButtonPictureBox.TabIndex = 117;
            this.pressureButtonPictureBox.TabStop = false;
            this.pressureButtonPictureBox.Text = "Pressure";
            this.pressureButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.pressureButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pressureButtonPictureBox.XTextOffset = 0;
            this.pressureButtonPictureBox.YTextOffset = 0;
            this.pressureButtonPictureBox.Click += new System.EventHandler(this.pressureButtonPictureBox_Click);
            // 
            // vistTestsControl1
            // 
            this.vistTestsControl1.BackColor = System.Drawing.Color.White;
            this.vistTestsControl1.Location = new System.Drawing.Point(74, 75);
            this.vistTestsControl1.Name = "vistTestsControl1";
            this.vistTestsControl1.Size = new System.Drawing.Size(1078, 770);
            this.vistTestsControl1.TabIndex = 0;
            // 
            // ucTestGraphExhFlow
            // 
            this.ucTestGraphExhFlow.Location = new System.Drawing.Point(1435, 163);
            this.ucTestGraphExhFlow.Name = "ucTestGraphExhFlow";
            this.ucTestGraphExhFlow.Size = new System.Drawing.Size(389, 331);
            this.ucTestGraphExhFlow.TabIndex = 120;
            this.ucTestGraphExhFlow.Title = "Exh_Flow";
            // 
            // ucTestGraphFVC
            // 
            this.ucTestGraphFVC.Location = new System.Drawing.Point(1435, 514);
            this.ucTestGraphFVC.Name = "ucTestGraphFVC";
            this.ucTestGraphFVC.Size = new System.Drawing.Size(389, 331);
            this.ucTestGraphFVC.TabIndex = 121;
            this.ucTestGraphFVC.Title = "FVC";
            // 
            // printVectorButtonPictureBox
            // 
            this.printVectorButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disable;
            this.printVectorButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.printVectorButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.printVectorButtonPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.printVectorButtonPictureBox.IsTextColorMouseChanged = false;
            this.printVectorButtonPictureBox.Location = new System.Drawing.Point(1718, 75);
            this.printVectorButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_down;
            this.printVectorButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.printVectorButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_;
            this.printVectorButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.printVectorButtonPictureBox.Name = "printVectorButtonPictureBox";
            this.printVectorButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.printVectorButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.printVectorButtonPictureBox.Size = new System.Drawing.Size(106, 44);
            this.printVectorButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.printVectorButtonPictureBox.TabIndex = 122;
            this.printVectorButtonPictureBox.TabStop = false;
            this.printVectorButtonPictureBox.Text = "Vector";
            this.printVectorButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.printVectorButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printVectorButtonPictureBox.XTextOffset = 0;
            this.printVectorButtonPictureBox.YTextOffset = 0;
            this.printVectorButtonPictureBox.Click += new System.EventHandler(this.printVectorButtonPictureBox_Click);
            // 
            // VisitFullControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::STSGui.Properties.Resources.visit_background_img;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.printVectorButtonPictureBox);
            this.Controls.Add(this.ucTestGraphFVC);
            this.Controls.Add(this.ucTestGraphExhFlow);
            this.Controls.Add(this.commentsButtonPictureBox);
            this.Controls.Add(this.printButtonPictureBox);
            this.Controls.Add(this.pressureButtonPictureBox);
            this.Controls.Add(this.vistTestsControl1);
            this.DoubleBuffered = true;
            this.Name = "VisitFullControl";
            this.Size = new System.Drawing.Size(1920, 913);
            this.Load += new System.EventHandler(this.VisitFullControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.commentsButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pressureButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printVectorButtonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Visit.VistTestsControl vistTestsControl1;
        private ButtonPictureBox pressureButtonPictureBox;
        private ButtonPictureBox printButtonPictureBox;
        private ButtonPictureBox commentsButtonPictureBox;
        private UCTestGraph ucTestGraphExhFlow;
        private UCTestGraph ucTestGraphFVC;
        private ButtonPictureBox printVectorButtonPictureBox;
    }
}
