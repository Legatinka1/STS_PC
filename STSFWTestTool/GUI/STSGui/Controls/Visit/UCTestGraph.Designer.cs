
namespace STSGui
{
    partial class UCTestGraph
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
            this.components = new System.ComponentModel.Container();
            this.ZGraphData = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // ZGraphData
            // 
            this.ZGraphData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZGraphData.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZGraphData.Location = new System.Drawing.Point(0, 0);
            this.ZGraphData.Name = "ZGraphData";
            this.ZGraphData.ScrollGrace = 0D;
            this.ZGraphData.ScrollMaxX = 0D;
            this.ZGraphData.ScrollMaxY = 0D;
            this.ZGraphData.ScrollMaxY2 = 0D;
            this.ZGraphData.ScrollMinX = 0D;
            this.ZGraphData.ScrollMinY = 0D;
            this.ZGraphData.ScrollMinY2 = 0D;
            this.ZGraphData.Size = new System.Drawing.Size(389, 331);
            this.ZGraphData.TabIndex = 0;
            this.ZGraphData.UseExtendedPrintDialog = true;
            // 
            // UCTestGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ZGraphData);
            this.DoubleBuffered = true;
            this.Name = "UCTestGraph";
            this.Size = new System.Drawing.Size(389, 331);
            this.Load += new System.EventHandler(this.UCTestGraph_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl ZGraphData;
    }
}
