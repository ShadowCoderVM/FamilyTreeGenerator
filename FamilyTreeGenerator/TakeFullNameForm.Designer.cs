namespace FamilyTreeGenerator
{
    partial class TakeFullNameForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.informationLabel = new System.Windows.Forms.Label();
            this.comboBoxNames = new System.Windows.Forms.ComboBox();
            this.comboBoxPatronymic = new System.Windows.Forms.ComboBox();
            this.comboBoxSurnames = new System.Windows.Forms.ComboBox();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(191, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(110, 130);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informationLabel.Location = new System.Drawing.Point(7, 34);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(51, 13);
            this.informationLabel.TabIndex = 18;
            this.informationLabel.Text = "Фамилия";
            // 
            // comboBoxNames
            // 
            this.comboBoxNames.FormattingEnabled = true;
            this.comboBoxNames.Location = new System.Drawing.Point(68, 58);
            this.comboBoxNames.Name = "comboBoxNames";
            this.comboBoxNames.Size = new System.Drawing.Size(242, 21);
            this.comboBoxNames.TabIndex = 19;
            // 
            // comboBoxPatronymic
            // 
            this.comboBoxPatronymic.FormattingEnabled = true;
            this.comboBoxPatronymic.Location = new System.Drawing.Point(68, 85);
            this.comboBoxPatronymic.Name = "comboBoxPatronymic";
            this.comboBoxPatronymic.Size = new System.Drawing.Size(242, 21);
            this.comboBoxPatronymic.TabIndex = 20;
            // 
            // comboBoxSurnames
            // 
            this.comboBoxSurnames.FormattingEnabled = true;
            this.comboBoxSurnames.Location = new System.Drawing.Point(68, 31);
            this.comboBoxSurnames.Name = "comboBoxSurnames";
            this.comboBoxSurnames.Size = new System.Drawing.Size(242, 21);
            this.comboBoxSurnames.TabIndex = 21;
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Checked = true;
            this.MaleRadioButton.Location = new System.Drawing.Point(4, 19);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(34, 17);
            this.MaleRadioButton.TabIndex = 22;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "М";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            this.MaleRadioButton.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Location = new System.Drawing.Point(4, 42);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(36, 17);
            this.FemaleRadioButton.TabIndex = 23;
            this.FemaleRadioButton.Text = "Ж";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            this.FemaleRadioButton.CheckedChanged += new System.EventHandler(this.Button_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Отчество";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FemaleRadioButton);
            this.groupBox1.Controls.Add(this.MaleRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(326, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(49, 66);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пол";
            // 
            // TakeFullNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 172);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSurnames);
            this.Controls.Add(this.comboBoxPatronymic);
            this.Controls.Add(this.comboBoxNames);
            this.Controls.Add(this.informationLabel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TakeFullNameForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.ComboBox comboBoxNames;
        private System.Windows.Forms.ComboBox comboBoxPatronymic;
        private System.Windows.Forms.ComboBox comboBoxSurnames;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}