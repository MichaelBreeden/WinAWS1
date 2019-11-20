namespace WinAWS1
{
    partial class FormInput
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
            this.Input_panel = new System.Windows.Forms.Panel();
            this.InputSave_button = new System.Windows.Forms.Button();
            this.Input_textBox = new System.Windows.Forms.TextBox();
            this.Input_label = new System.Windows.Forms.Label();
            this.InputClose_button = new System.Windows.Forms.Button();
            this.Input_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Input_panel
            // 
            this.Input_panel.BackColor = System.Drawing.SystemColors.Info;
            this.Input_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input_panel.Controls.Add(this.InputClose_button);
            this.Input_panel.Controls.Add(this.InputSave_button);
            this.Input_panel.Controls.Add(this.Input_textBox);
            this.Input_panel.Controls.Add(this.Input_label);
            this.Input_panel.Location = new System.Drawing.Point(8, 9);
            this.Input_panel.Name = "Input_panel";
            this.Input_panel.Size = new System.Drawing.Size(200, 72);
            this.Input_panel.TabIndex = 5;
            // 
            // InputSave_button
            // 
            this.InputSave_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputSave_button.Location = new System.Drawing.Point(13, 44);
            this.InputSave_button.Name = "InputSave_button";
            this.InputSave_button.Size = new System.Drawing.Size(80, 23);
            this.InputSave_button.TabIndex = 4;
            this.InputSave_button.Text = "Create";
            this.InputSave_button.UseVisualStyleBackColor = true;
            this.InputSave_button.Click += new System.EventHandler(this.InputSave_button_Click);
            // 
            // Input_textBox
            // 
            this.Input_textBox.Location = new System.Drawing.Point(6, 20);
            this.Input_textBox.Name = "Input_textBox";
            this.Input_textBox.Size = new System.Drawing.Size(186, 20);
            this.Input_textBox.TabIndex = 3;
            // 
            // Input_label
            // 
            this.Input_label.AutoSize = true;
            this.Input_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_label.Location = new System.Drawing.Point(6, 4);
            this.Input_label.Name = "Input_label";
            this.Input_label.Size = new System.Drawing.Size(87, 13);
            this.Input_label.TabIndex = 2;
            this.Input_label.Text = "Bucket Name:";
            // 
            // InputClose_button
            // 
            this.InputClose_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputClose_button.Location = new System.Drawing.Point(99, 44);
            this.InputClose_button.Name = "InputClose_button";
            this.InputClose_button.Size = new System.Drawing.Size(80, 23);
            this.InputClose_button.TabIndex = 5;
            this.InputClose_button.Text = "Cancel";
            this.InputClose_button.UseVisualStyleBackColor = true;
            this.InputClose_button.Click += new System.EventHandler(this.InputClose_button_Click);
            // 
            // FormInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 90);
            this.Controls.Add(this.Input_panel);
            this.Location = new System.Drawing.Point(99, 99);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInput";
            this.Text = "Input";
            this.Input_panel.ResumeLayout(false);
            this.Input_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Input_panel;
        private System.Windows.Forms.Button InputSave_button;
        private System.Windows.Forms.TextBox Input_textBox;
        private System.Windows.Forms.Label Input_label;
        private System.Windows.Forms.Button InputClose_button;
    }
}