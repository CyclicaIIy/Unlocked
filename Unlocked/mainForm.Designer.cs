
namespace Unlocked
{
    partial class mainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.activatedBox = new System.Windows.Forms.CheckBox();
            this.keybindLabel = new System.Windows.Forms.Label();
            this.fpsBox = new System.Windows.Forms.NumericUpDown();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.keybindBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.fpsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // activatedBox
            // 
            this.activatedBox.AutoSize = true;
            this.activatedBox.Checked = true;
            this.activatedBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activatedBox.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.activatedBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.activatedBox.Location = new System.Drawing.Point(16, 146);
            this.activatedBox.Name = "activatedBox";
            this.activatedBox.Size = new System.Drawing.Size(95, 23);
            this.activatedBox.TabIndex = 14;
            this.activatedBox.Text = "Activated";
            this.activatedBox.UseVisualStyleBackColor = true;
            this.activatedBox.CheckedChanged += new System.EventHandler(this.activatedBox_CheckedChanged);
            // 
            // keybindLabel
            // 
            this.keybindLabel.AutoSize = true;
            this.keybindLabel.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold);
            this.keybindLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keybindLabel.Location = new System.Drawing.Point(13, 77);
            this.keybindLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.keybindLabel.Name = "keybindLabel";
            this.keybindLabel.Size = new System.Drawing.Size(73, 18);
            this.keybindLabel.TabIndex = 12;
            this.keybindLabel.Text = "KEYBIND:";
            // 
            // fpsBox
            // 
            this.fpsBox.DecimalPlaces = 1;
            this.fpsBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fpsBox.Location = new System.Drawing.Point(16, 31);
            this.fpsBox.Margin = new System.Windows.Forms.Padding(4);
            this.fpsBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.fpsBox.Name = "fpsBox";
            this.fpsBox.Size = new System.Drawing.Size(346, 27);
            this.fpsBox.TabIndex = 11;
            this.fpsBox.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.fpsBox.ValueChanged += new System.EventHandler(this.fpsBox_ValueChanged);
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold);
            this.fpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fpsLabel.Location = new System.Drawing.Point(13, 9);
            this.fpsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(41, 18);
            this.fpsLabel.TabIndex = 10;
            this.fpsLabel.Text = "FPS: ";
            // 
            // keybindBox
            // 
            this.keybindBox.DisplayMember = "Text";
            this.keybindBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keybindBox.FormattingEnabled = true;
            this.keybindBox.Location = new System.Drawing.Point(16, 98);
            this.keybindBox.Name = "keybindBox";
            this.keybindBox.Size = new System.Drawing.Size(346, 27);
            this.keybindBox.TabIndex = 15;
            this.keybindBox.ValueMember = "Value";
            this.keybindBox.SelectedIndexChanged += new System.EventHandler(this.keybindBox_SelectedIndexChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 187);
            this.Controls.Add(this.keybindBox);
            this.Controls.Add(this.activatedBox);
            this.Controls.Add(this.keybindLabel);
            this.Controls.Add(this.fpsBox);
            this.Controls.Add(this.fpsLabel);
            this.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unlocked";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpsBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox activatedBox;
        private System.Windows.Forms.Label keybindLabel;
        private System.Windows.Forms.NumericUpDown fpsBox;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.ComboBox keybindBox;
    }
}

