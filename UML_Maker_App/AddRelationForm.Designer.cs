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
            button3 = new Button();
            panelForSecondMultiplicity = new Panel();
            radioButtonNOtherClass = new RadioButton();
            radioButton1OtherClass = new RadioButton();
            label6 = new Label();
            panelForInitialMultiplicity = new Panel();
            label5 = new Label();
            radioButtonInitialClass = new RadioButton();
            radioButton1InitialClass = new RadioButton();
            textBoxPropertyForSecondClass = new TextBox();
            labelPropertyForSecondClass = new Label();
            panelForSecondMultiplicity.SuspendLayout();
            panelForInitialMultiplicity.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "First ClassInBox:";
            // 
            // textBoxInitialClass
            // 
            textBoxInitialClass.Location = new Point(80, 6);
            textBoxInitialClass.Name = "textBoxInitialClass";
            textBoxInitialClass.ReadOnly = true;
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
            label2.Text = "Other ClassInBox:";
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
            comboBoxRelationType.SelectedIndexChanged += comboBoxRelationType_SelectedIndexChanged;
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
            textBoxPropertyName.Location = new Point(106, 163);
            textBoxPropertyName.Name = "textBoxPropertyName";
            textBoxPropertyName.Size = new Size(209, 23);
            textBoxPropertyName.TabIndex = 7;
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
            panelForSecondMultiplicity.Location = new Point(12, 302);
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
            // panelForInitialMultiplicity
            // 
            panelForInitialMultiplicity.Controls.Add(label5);
            panelForInitialMultiplicity.Controls.Add(radioButtonInitialClass);
            panelForInitialMultiplicity.Controls.Add(radioButton1InitialClass);
            panelForInitialMultiplicity.Location = new Point(12, 251);
            panelForInitialMultiplicity.Name = "panelForInitialMultiplicity";
            panelForInitialMultiplicity.Size = new Size(195, 45);
            panelForInitialMultiplicity.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 13;
            label5.Text = "Multiplicity:";
            // 
            // radioButtonInitialClass
            // 
            radioButtonInitialClass.AutoSize = true;
            radioButtonInitialClass.Location = new Point(63, 18);
            radioButtonInitialClass.Name = "radioButtonInitialClass";
            radioButtonInitialClass.Size = new Size(30, 19);
            radioButtonInitialClass.TabIndex = 12;
            radioButtonInitialClass.TabStop = true;
            radioButtonInitialClass.Text = "*";
            radioButtonInitialClass.UseVisualStyleBackColor = true;
            // 
            // radioButton1InitialClass
            // 
            radioButton1InitialClass.AutoSize = true;
            radioButton1InitialClass.Location = new Point(5, 18);
            radioButton1InitialClass.Name = "radioButton1InitialClass";
            radioButton1InitialClass.Size = new Size(31, 19);
            radioButton1InitialClass.TabIndex = 11;
            radioButton1InitialClass.TabStop = true;
            radioButton1InitialClass.Text = "1";
            radioButton1InitialClass.UseVisualStyleBackColor = true;
            // 
            // textBoxPropertyForSecondClass
            // 
            textBoxPropertyForSecondClass.Location = new Point(188, 204);
            textBoxPropertyForSecondClass.Name = "textBoxPropertyForSecondClass";
            textBoxPropertyForSecondClass.Size = new Size(127, 23);
            textBoxPropertyForSecondClass.TabIndex = 17;
            textBoxPropertyForSecondClass.TextChanged += textBox1_TextChanged;
            // 
            // labelPropertyForSecondClass
            // 
            labelPropertyForSecondClass.AutoSize = true;
            labelPropertyForSecondClass.Location = new Point(12, 207);
            labelPropertyForSecondClass.Name = "labelPropertyForSecondClass";
            labelPropertyForSecondClass.Size = new Size(177, 15);
            labelPropertyForSecondClass.TabIndex = 16;
            labelPropertyForSecondClass.Text = "Property name for second ClassInBox:";
            // 
            // AddRelationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 450);
            Controls.Add(textBoxPropertyForSecondClass);
            Controls.Add(labelPropertyForSecondClass);
            Controls.Add(panelForInitialMultiplicity);
            Controls.Add(panelForSecondMultiplicity);
            Controls.Add(button3);
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
            panelForInitialMultiplicity.ResumeLayout(false);
            panelForInitialMultiplicity.PerformLayout();
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
        private Button button3;
        private Panel panelForSecondMultiplicity;
        private RadioButton radioButtonNOtherClass;
        private RadioButton radioButton1OtherClass;
        private Label label6;
        private Panel panelForInitialMultiplicity;
        private Label label5;
        private RadioButton radioButtonInitialClass;
        private RadioButton radioButton1InitialClass;
        private TextBox textBoxPropertyForSecondClass;
        private Label labelPropertyForSecondClass;
    }
}