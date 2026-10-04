namespace hafta_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblX = new Label();
            txtX = new TextBox();
            lblY = new Label();
            txtY = new TextBox();
            btnStart = new Button();
            btnReset = new Button();
            lblMine = new Label();
            SuspendLayout();
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Font = new Font("Script MT Bold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblX.Location = new Point(27, 25);
            lblX.Name = "lblX";
            lblX.Size = new Size(29, 28);
            lblX.TabIndex = 0;
            lblX.Text = "X";
            lblX.Click += label1_Click;
            // 
            // txtX
            // 
            txtX.Font = new Font("STFangsong", 13.7999992F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            txtX.Location = new Point(77, 24);
            txtX.Name = "txtX";
            txtX.Size = new Size(125, 37);
            txtX.TabIndex = 1;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Font = new Font("Script MT Bold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblY.Location = new Point(27, 68);
            lblY.Name = "lblY";
            lblY.Size = new Size(29, 28);
            lblY.TabIndex = 2;
            lblY.Text = "Y";
            // 
            // txtY
            // 
            txtY.Font = new Font("STFangsong", 13.7999992F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            txtY.Location = new Point(77, 67);
            txtY.Name = "txtY";
            txtY.Size = new Size(125, 37);
            txtY.TabIndex = 3;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(224, 24);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(110, 80);
            btnStart.TabIndex = 4;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Swis721 Blk BT", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.Location = new Point(357, 25);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(110, 80);
            btnReset.TabIndex = 5;
            btnReset.Text = ":)";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // lblMine
            // 
            lblMine.AutoSize = true;
            lblMine.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMine.Location = new Point(473, 39);
            lblMine.Name = "lblMine";
            lblMine.Size = new Size(167, 43);
            lblMine.TabIndex = 6;
            lblMine.Text = "Mines: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1125, 831);
            Controls.Add(lblMine);
            Controls.Add(btnReset);
            Controls.Add(btnStart);
            Controls.Add(txtY);
            Controls.Add(lblY);
            Controls.Add(txtX);
            Controls.Add(lblX);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblX;
        private TextBox txtX;
        private Label lblY;
        private TextBox txtY;
        private Button btnStart;
        private Button btnReset;
        private Label lblMine;
    }
}
