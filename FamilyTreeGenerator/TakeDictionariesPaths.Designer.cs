namespace FamilyTreeGenerator
{
    partial class TakeDictionariesPaths
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMaleNamesAndPathronic = new System.Windows.Forms.TextBox();
            this.textBoxFemaleNames = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Словарь мужских имён и отчеств";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Словарь фамилий";
            // 
            // textBoxMaleNamesAndPathronic
            // 
            this.textBoxMaleNamesAndPathronic.Location = new System.Drawing.Point(195, 13);
            this.textBoxMaleNamesAndPathronic.Name = "textBoxMaleNamesAndPathronic";
            this.textBoxMaleNamesAndPathronic.ReadOnly = true;
            this.textBoxMaleNamesAndPathronic.Size = new System.Drawing.Size(264, 20);
            this.textBoxMaleNamesAndPathronic.TabIndex = 2;
            // 
            // textBoxFemaleNames
            // 
            this.textBoxFemaleNames.Location = new System.Drawing.Point(195, 39);
            this.textBoxFemaleNames.Name = "textBoxFemaleNames";
            this.textBoxFemaleNames.ReadOnly = true;
            this.textBoxFemaleNames.Size = new System.Drawing.Size(264, 20);
            this.textBoxFemaleNames.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Путь к файлу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.TakeFileMaleNamesAndPathronic);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(486, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 20);
            this.button2.TabIndex = 5;
            this.button2.Text = "Путь к файлу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.TakeFileSurname);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(149, 98);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCansel
            // 
            this.buttonCansel.Location = new System.Drawing.Point(279, 98);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(75, 23);
            this.buttonCansel.TabIndex = 7;
            this.buttonCansel.Text = "Отмена";
            this.buttonCansel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Словарь женских имён";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(195, 65);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.ReadOnly = true;
            this.textBoxSurname.Size = new System.Drawing.Size(264, 20);
            this.textBoxSurname.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(486, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 20);
            this.button3.TabIndex = 10;
            this.button3.Text = "Путь к файлу";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.TakeFileFemalеNames);
            // 
            // TakeDictionariesPaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 133);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxFemaleNames);
            this.Controls.Add(this.textBoxMaleNamesAndPathronic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TakeDictionariesPaths";
            this.Text = "Пути к словарям";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMaleNamesAndPathronic;
        private System.Windows.Forms.TextBox textBoxFemaleNames;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Button button3;
    }
}