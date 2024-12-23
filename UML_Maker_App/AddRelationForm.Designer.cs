namespace UML_Maker_App
{
    partial class AddRelationForm
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
            label1 = new Label();
            textBoxInitialClass = new TextBox();
            label2 = new Label();
            comboBoxOtherClass = new ComboBox();
            label3 = new Label();
            comboBoxRelationType = new ComboBox();
            label4 = new Label();
            textBoxPropertyName = new TextBox();
            radioButton1InitialClass = new RadioButton();
            radioButtonInitialClass = new RadioButton();
            label5 = new Label();
            button3 = new Button();
            panelForSecondMultiplicity = new Panel();
            radioButtonNOtherClass = new RadioButton();
            radioButton1OtherClass = new RadioButton();
            label6 = new Label();
            panelForSecondMultiplicity.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "First Class:";
            // 
            // textBoxInitialClass
            // 
            textBoxInitialClass.Location = new Point(80, 6);
            textBoxInitialClass.Name = "textBoxInitialClass";
            textBoxInitialClass.Size = new Size(209, 23);
            textBoxInitialClass.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 2;
            label2.Text = "Other Class:";
            // 
            // comboBoxOtherClass
            // 
            comboBoxOtherClass.FormattingEnabled = true;
            comboBoxOtherClass.Location = new Point(80, 59);
            comboBoxOtherClass.Name = "comboBoxOtherClass";
            comboBoxOtherClass.Size = new Size(209, 23);
            comboBoxOtherClass.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 4;
            label3.Text = "Relation Type:";
            // 
            // comboBoxRelationType
            // 
            comboBoxRelationType.FormattingEnabled = true;
            comboBoxRelationType.Location = new Point(98, 112);
            comboBoxRelationType.Name = "comboBoxRelationType";
            comboBoxRelationType.Size = new Size(209, 23);
            comboBoxRelationType.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 166);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 6;
            label4.Text = "Property name:";
            // 
            // textBoxPropertyName
            // 
            textBoxPropertyName.Location = new Point(106, 166);
            textBoxPropertyName.Name = "textBoxPropertyName";
            textBoxPropertyName.Size = new Size(209, 23);
            textBoxPropertyName.TabIndex = 7;
            // 
            // radioButton1InitialClass
            // 
            radioButton1InitialClass.AutoSize = true;
            radioButton1InitialClass.Location = new Point(12, 227);
            radioButton1InitialClass.Name = "radioButton1InitialClass";
            radioButton1InitialClass.Size = new Size(31, 19);
            radioButton1InitialClass.TabIndex = 8;
            radioButton1InitialClass.TabStop = true;
            radioButton1InitialClass.Text = "1";
            radioButton1InitialClass.UseVisualStyleBackColor = true;
            // 
            // radioButtonInitialClass
            // 
            radioButtonInitialClass.AutoSize = true;
            radioButtonInitialClass.Location = new Point(70, 227);
            radioButtonInitialClass.Name = "radioButtonInitialClass";
            radioButtonInitialClass.Size = new Size(30, 19);
            radioButtonInitialClass.TabIndex = 9;
            radioButtonInitialClass.TabStop = true;
            radioButtonInitialClass.Text = "*";
            radioButtonInitialClass.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 209);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 10;
            label5.Text = "Multiplicity:";
            // 
            // button3
            // 
            button3.Location = new Point(124, 415);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 13;
            button3.Text = "Add Relation";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panelForSecondMultiplicity
            // 
            panelForSecondMultiplicity.Controls.Add(radioButtonNOtherClass);
            panelForSecondMultiplicity.Controls.Add(radioButton1OtherClass);
            panelForSecondMultiplicity.Controls.Add(label6);
            panelForSecondMultiplicity.Location = new Point(12, 262);
            panelForSecondMultiplicity.Name = "panelForSecondMultiplicity";
            panelForSecondMultiplicity.Size = new Size(200, 100);
            panelForSecondMultiplicity.TabIndex = 14;
            // 
            // radioButtonNOtherClass
            // 
            radioButtonNOtherClass.AutoSize = true;
            radioButtonNOtherClass.Location = new Point(58, 27);
            radioButtonNOtherClass.Name = "radioButtonNOtherClass";
            radioButtonNOtherClass.Size = new Size(30, 19);
            radioButtonNOtherClass.TabIndex = 16;
            radioButtonNOtherClass.TabStop = true;
            radioButtonNOtherClass.Text = "*";
            radioButtonNOtherClass.UseVisualStyleBackColor = true;
            // 
            // radioButton1OtherClass
            // 
            radioButton1OtherClass.AutoSize = true;
            radioButton1OtherClass.Location = new Point(0, 27);
            radioButton1OtherClass.Name = "radioButton1OtherClass";
            radioButton1OtherClass.Size = new Size(31, 19);
            radioButton1OtherClass.TabIndex = 15;
            radioButton1OtherClass.TabStop = true;
            radioButton1OtherClass.Text = "1";
            radioButton1OtherClass.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 9);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 15;
            label6.Text = "Multiplicity:";
            // 
            // AddRelationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 450);
            Controls.Add(panelForSecondMultiplicity);
            Controls.Add(button3);
            Controls.Add(label5);
            Controls.Add(radioButtonInitialClass);
            Controls.Add(radioButton1InitialClass);
            Controls.Add(textBoxPropertyName);
            Controls.Add(label4);
            Controls.Add(comboBoxRelationType);
            Controls.Add(label3);
            Controls.Add(comboBoxOtherClass);
            Controls.Add(label2);
            Controls.Add(textBoxInitialClass);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddRelationForm";
            Text = "AddRelationForm";
            panelForSecondMultiplicity.ResumeLayout(false);
            panelForSecondMultiplicity.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxInitialClass;
        private Label label2;
        private ComboBox comboBoxOtherClass;
        private Label label3;
        private ComboBox comboBoxRelationType;
        private Label label4;
        private TextBox textBoxPropertyName;
        private RadioButton radioButton1InitialClass;
        private RadioButton radioButtonInitialClass;
        private Label label5;
        private Button button3;
        private Panel panelForSecondMultiplicity;
        private RadioButton radioButtonNOtherClass;
        private RadioButton radioButton1OtherClass;
        private Label label6;
    }
}