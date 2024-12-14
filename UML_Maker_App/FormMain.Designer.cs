namespace DragAndDrop
{
    partial class FormMain
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
            pictureBox = new PictureBox();
            panelEditClass = new Panel();
            tableLayoutPanelClassEdit = new TableLayoutPanel();
            tableLayoutPanelDeleteConfirmButtons = new TableLayoutPanel();
            buttonDeleteClass = new Button();
            buttonConfirmClass = new Button();
            tableLayoutPanelChooseWhatToEdit = new TableLayoutPanel();
            panelParametrs = new Panel();
            textBoxParametrs = new TextBox();
            labelParametrs = new Label();
            panelIdentificator = new Panel();
            textBoxIdentificator = new TextBox();
            labelIdentificator = new Label();
            panelDataType = new Panel();
            comboBoxDataType = new ComboBox();
            label2 = new Label();
            panelMethods = new Panel();
            buttonNewMethod = new Button();
            comboBoxMethod = new ComboBox();
            labelMethod = new Label();
            textBoxClassName = new TextBox();
            panelProperties = new Panel();
            buttonNewProperty = new Button();
            comboBoxProperties = new ComboBox();
            labelProperties = new Label();
            panelAccessModifier = new Panel();
            comboBoxAccessModifier = new ComboBox();
            label1 = new Label();
            tableLayoutPanelCelýForm = new TableLayoutPanel();
            panelPlochaProCanvas = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panelEditClass.SuspendLayout();
            tableLayoutPanelClassEdit.SuspendLayout();
            tableLayoutPanelDeleteConfirmButtons.SuspendLayout();
            tableLayoutPanelChooseWhatToEdit.SuspendLayout();
            panelParametrs.SuspendLayout();
            panelIdentificator.SuspendLayout();
            panelDataType.SuspendLayout();
            panelMethods.SuspendLayout();
            panelProperties.SuspendLayout();
            panelAccessModifier.SuspendLayout();
            tableLayoutPanelCelýForm.SuspendLayout();
            panelPlochaProCanvas.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.White;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1030, 544);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            // 
            // panelEditClass
            // 
            panelEditClass.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelEditClass.BackColor = Color.LightGray;
            panelEditClass.Controls.Add(tableLayoutPanelClassEdit);
            panelEditClass.Location = new Point(787, 0);
            panelEditClass.Margin = new Padding(3, 3, 3, 0);
            panelEditClass.Name = "panelEditClass";
            panelEditClass.Size = new Size(246, 544);
            panelEditClass.TabIndex = 1;
            // 
            // tableLayoutPanelClassEdit
            // 
            tableLayoutPanelClassEdit.ColumnCount = 1;
            tableLayoutPanelClassEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelClassEdit.Controls.Add(tableLayoutPanelDeleteConfirmButtons, 0, 1);
            tableLayoutPanelClassEdit.Controls.Add(tableLayoutPanelChooseWhatToEdit, 0, 0);
            tableLayoutPanelClassEdit.Dock = DockStyle.Fill;
            tableLayoutPanelClassEdit.Location = new Point(0, 0);
            tableLayoutPanelClassEdit.Margin = new Padding(3, 3, 3, 0);
            tableLayoutPanelClassEdit.Name = "tableLayoutPanelClassEdit";
            tableLayoutPanelClassEdit.RowCount = 2;
            tableLayoutPanelClassEdit.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelClassEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelClassEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelClassEdit.Size = new Size(246, 544);
            tableLayoutPanelClassEdit.TabIndex = 0;
            // 
            // tableLayoutPanelDeleteConfirmButtons
            // 
            tableLayoutPanelDeleteConfirmButtons.ColumnCount = 2;
            tableLayoutPanelDeleteConfirmButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDeleteConfirmButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDeleteConfirmButtons.Controls.Add(buttonDeleteClass, 0, 0);
            tableLayoutPanelDeleteConfirmButtons.Controls.Add(buttonConfirmClass, 1, 0);
            tableLayoutPanelDeleteConfirmButtons.Dock = DockStyle.Fill;
            tableLayoutPanelDeleteConfirmButtons.Location = new Point(3, 507);
            tableLayoutPanelDeleteConfirmButtons.Margin = new Padding(3, 3, 3, 0);
            tableLayoutPanelDeleteConfirmButtons.Name = "tableLayoutPanelDeleteConfirmButtons";
            tableLayoutPanelDeleteConfirmButtons.RowCount = 1;
            tableLayoutPanelDeleteConfirmButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelDeleteConfirmButtons.Size = new Size(240, 37);
            tableLayoutPanelDeleteConfirmButtons.TabIndex = 0;
            // 
            // buttonDeleteClass
            // 
            buttonDeleteClass.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonDeleteClass.Location = new Point(0, 14);
            buttonDeleteClass.Margin = new Padding(0);
            buttonDeleteClass.Name = "buttonDeleteClass";
            buttonDeleteClass.Size = new Size(120, 23);
            buttonDeleteClass.TabIndex = 0;
            buttonDeleteClass.Text = "Delete";
            buttonDeleteClass.UseVisualStyleBackColor = true;
            // 
            // buttonConfirmClass
            // 
            buttonConfirmClass.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonConfirmClass.Location = new Point(120, 14);
            buttonConfirmClass.Margin = new Padding(0);
            buttonConfirmClass.Name = "buttonConfirmClass";
            buttonConfirmClass.Size = new Size(120, 23);
            buttonConfirmClass.TabIndex = 1;
            buttonConfirmClass.Text = "Confirm";
            buttonConfirmClass.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelChooseWhatToEdit
            // 
            tableLayoutPanelChooseWhatToEdit.ColumnCount = 1;
            tableLayoutPanelChooseWhatToEdit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelChooseWhatToEdit.Controls.Add(panelParametrs, 0, 6);
            tableLayoutPanelChooseWhatToEdit.Controls.Add(panelIdentificator, 0, 5);
            tableLayoutPanelChooseWhatToEdit.Controls.Add(panelDataType, 0, 4);
            tableLayoutPanelChooseWhatToEdit.Controls.Add(panelMethods, 0, 2);
            tableLayoutPanelChooseWhatToEdit.Controls.Add(textBoxClassName, 0, 0);
            tableLayoutPanelChooseWhatToEdit.Controls.Add(panelProperties, 0, 1);
            tableLayoutPanelChooseWhatToEdit.Controls.Add(panelAccessModifier, 0, 3);
            tableLayoutPanelChooseWhatToEdit.Location = new Point(3, 3);
            tableLayoutPanelChooseWhatToEdit.Name = "tableLayoutPanelChooseWhatToEdit";
            tableLayoutPanelChooseWhatToEdit.RowCount = 7;
            tableLayoutPanelChooseWhatToEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanelChooseWhatToEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelChooseWhatToEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelChooseWhatToEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelChooseWhatToEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelChooseWhatToEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelChooseWhatToEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelChooseWhatToEdit.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelChooseWhatToEdit.Size = new Size(240, 301);
            tableLayoutPanelChooseWhatToEdit.TabIndex = 1;
            // 
            // panelParametrs
            // 
            panelParametrs.Controls.Add(textBoxParametrs);
            panelParametrs.Controls.Add(labelParametrs);
            panelParametrs.Dock = DockStyle.Fill;
            panelParametrs.Location = new Point(3, 263);
            panelParametrs.Name = "panelParametrs";
            panelParametrs.Size = new Size(234, 35);
            panelParametrs.TabIndex = 6;
            // 
            // textBoxParametrs
            // 
            textBoxParametrs.BorderStyle = BorderStyle.FixedSingle;
            textBoxParametrs.Location = new Point(85, 6);
            textBoxParametrs.Name = "textBoxParametrs";
            textBoxParametrs.Size = new Size(149, 23);
            textBoxParametrs.TabIndex = 1;
            // 
            // labelParametrs
            // 
            labelParametrs.AutoSize = true;
            labelParametrs.Location = new Point(3, 9);
            labelParametrs.Name = "labelParametrs";
            labelParametrs.Size = new Size(63, 15);
            labelParametrs.TabIndex = 0;
            labelParametrs.Text = "Parametrs:";
            // 
            // panelIdentificator
            // 
            panelIdentificator.Controls.Add(textBoxIdentificator);
            panelIdentificator.Controls.Add(labelIdentificator);
            panelIdentificator.Dock = DockStyle.Fill;
            panelIdentificator.Location = new Point(3, 223);
            panelIdentificator.Name = "panelIdentificator";
            panelIdentificator.Size = new Size(234, 34);
            panelIdentificator.TabIndex = 5;
            // 
            // textBoxIdentificator
            // 
            textBoxIdentificator.BorderStyle = BorderStyle.FixedSingle;
            textBoxIdentificator.Location = new Point(85, 6);
            textBoxIdentificator.Name = "textBoxIdentificator";
            textBoxIdentificator.Size = new Size(149, 23);
            textBoxIdentificator.TabIndex = 1;
            // 
            // labelIdentificator
            // 
            labelIdentificator.AutoSize = true;
            labelIdentificator.Location = new Point(3, 9);
            labelIdentificator.Name = "labelIdentificator";
            labelIdentificator.Size = new Size(77, 15);
            labelIdentificator.TabIndex = 0;
            labelIdentificator.Text = "Identificator: ";
            // 
            // panelDataType
            // 
            panelDataType.Controls.Add(comboBoxDataType);
            panelDataType.Controls.Add(label2);
            panelDataType.Dock = DockStyle.Fill;
            panelDataType.Location = new Point(3, 183);
            panelDataType.Name = "panelDataType";
            panelDataType.Size = new Size(234, 34);
            panelDataType.TabIndex = 4;
            // 
            // comboBoxDataType
            // 
            comboBoxDataType.Anchor = AnchorStyles.Right;
            comboBoxDataType.FormattingEnabled = true;
            comboBoxDataType.Location = new Point(62, 6);
            comboBoxDataType.Name = "comboBoxDataType";
            comboBoxDataType.Size = new Size(172, 23);
            comboBoxDataType.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 0;
            label2.Text = "Data type:";
            // 
            // panelMethods
            // 
            panelMethods.Controls.Add(buttonNewMethod);
            panelMethods.Controls.Add(comboBoxMethod);
            panelMethods.Controls.Add(labelMethod);
            panelMethods.Dock = DockStyle.Fill;
            panelMethods.Location = new Point(3, 103);
            panelMethods.Name = "panelMethods";
            panelMethods.Size = new Size(234, 34);
            panelMethods.TabIndex = 2;
            // 
            // buttonNewMethod
            // 
            buttonNewMethod.Location = new Point(191, 6);
            buttonNewMethod.Name = "buttonNewMethod";
            buttonNewMethod.Size = new Size(40, 23);
            buttonNewMethod.TabIndex = 2;
            buttonNewMethod.Text = "New";
            buttonNewMethod.TextAlign = ContentAlignment.MiddleLeft;
            buttonNewMethod.UseVisualStyleBackColor = true;
            // 
            // comboBoxMethod
            // 
            comboBoxMethod.FormattingEnabled = true;
            comboBoxMethod.Location = new Point(72, 6);
            comboBoxMethod.Name = "comboBoxMethod";
            comboBoxMethod.Size = new Size(113, 23);
            comboBoxMethod.TabIndex = 1;
            // 
            // labelMethod
            // 
            labelMethod.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelMethod.AutoSize = true;
            labelMethod.Location = new Point(3, 10);
            labelMethod.Name = "labelMethod";
            labelMethod.Size = new Size(57, 15);
            labelMethod.TabIndex = 0;
            labelMethod.Text = "Methods:";
            // 
            // textBoxClassName
            // 
            textBoxClassName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxClassName.BorderStyle = BorderStyle.FixedSingle;
            textBoxClassName.Location = new Point(3, 18);
            textBoxClassName.Name = "textBoxClassName";
            textBoxClassName.Size = new Size(234, 23);
            textBoxClassName.TabIndex = 0;
            textBoxClassName.TextAlign = HorizontalAlignment.Center;
            // 
            // panelProperties
            // 
            panelProperties.Controls.Add(buttonNewProperty);
            panelProperties.Controls.Add(comboBoxProperties);
            panelProperties.Controls.Add(labelProperties);
            panelProperties.Dock = DockStyle.Fill;
            panelProperties.Location = new Point(3, 63);
            panelProperties.Name = "panelProperties";
            panelProperties.Size = new Size(234, 34);
            panelProperties.TabIndex = 1;
            // 
            // buttonNewProperty
            // 
            buttonNewProperty.Location = new Point(191, 6);
            buttonNewProperty.Name = "buttonNewProperty";
            buttonNewProperty.Size = new Size(40, 23);
            buttonNewProperty.TabIndex = 2;
            buttonNewProperty.Text = "New";
            buttonNewProperty.TextAlign = ContentAlignment.MiddleLeft;
            buttonNewProperty.UseVisualStyleBackColor = true;
            // 
            // comboBoxProperties
            // 
            comboBoxProperties.FormattingEnabled = true;
            comboBoxProperties.Location = new Point(72, 6);
            comboBoxProperties.Name = "comboBoxProperties";
            comboBoxProperties.Size = new Size(113, 23);
            comboBoxProperties.TabIndex = 1;
            // 
            // labelProperties
            // 
            labelProperties.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelProperties.AutoSize = true;
            labelProperties.Location = new Point(3, 9);
            labelProperties.Name = "labelProperties";
            labelProperties.Size = new Size(63, 15);
            labelProperties.TabIndex = 0;
            labelProperties.Text = "Properties:";
            // 
            // panelAccessModifier
            // 
            panelAccessModifier.Controls.Add(comboBoxAccessModifier);
            panelAccessModifier.Controls.Add(label1);
            panelAccessModifier.Dock = DockStyle.Fill;
            panelAccessModifier.Location = new Point(3, 143);
            panelAccessModifier.Name = "panelAccessModifier";
            panelAccessModifier.Size = new Size(234, 34);
            panelAccessModifier.TabIndex = 3;
            // 
            // comboBoxAccessModifier
            // 
            comboBoxAccessModifier.Anchor = AnchorStyles.Right;
            comboBoxAccessModifier.FormattingEnabled = true;
            comboBoxAccessModifier.Location = new Point(103, 6);
            comboBoxAccessModifier.Name = "comboBoxAccessModifier";
            comboBoxAccessModifier.Size = new Size(131, 23);
            comboBoxAccessModifier.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 0;
            label1.Text = "Access Modifier:";
            // 
            // tableLayoutPanelCelýForm
            // 
            tableLayoutPanelCelýForm.ColumnCount = 1;
            tableLayoutPanelCelýForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelCelýForm.Controls.Add(panelPlochaProCanvas, 0, 1);
            tableLayoutPanelCelýForm.Controls.Add(button1, 0, 0);
            tableLayoutPanelCelýForm.Dock = DockStyle.Fill;
            tableLayoutPanelCelýForm.Location = new Point(0, 10);
            tableLayoutPanelCelýForm.Name = "tableLayoutPanelCelýForm";
            tableLayoutPanelCelýForm.RowCount = 3;
            tableLayoutPanelCelýForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelCelýForm.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelCelýForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelCelýForm.Size = new Size(1036, 630);
            tableLayoutPanelCelýForm.TabIndex = 2;
            // 
            // panelPlochaProCanvas
            // 
            panelPlochaProCanvas.BackColor = Color.Red;
            panelPlochaProCanvas.Controls.Add(panelEditClass);
            panelPlochaProCanvas.Controls.Add(pictureBox);
            panelPlochaProCanvas.Dock = DockStyle.Fill;
            panelPlochaProCanvas.Location = new Point(3, 43);
            panelPlochaProCanvas.Name = "panelPlochaProCanvas";
            panelPlochaProCanvas.Size = new Size(1030, 544);
            panelPlochaProCanvas.TabIndex = 2;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(480, 8);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 650);
            Controls.Add(tableLayoutPanelCelýForm);
            Name = "FormMain";
            Padding = new Padding(0, 10, 0, 10);
            Text = "UML MAKER";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panelEditClass.ResumeLayout(false);
            tableLayoutPanelClassEdit.ResumeLayout(false);
            tableLayoutPanelDeleteConfirmButtons.ResumeLayout(false);
            tableLayoutPanelChooseWhatToEdit.ResumeLayout(false);
            tableLayoutPanelChooseWhatToEdit.PerformLayout();
            panelParametrs.ResumeLayout(false);
            panelParametrs.PerformLayout();
            panelIdentificator.ResumeLayout(false);
            panelIdentificator.PerformLayout();
            panelDataType.ResumeLayout(false);
            panelDataType.PerformLayout();
            panelMethods.ResumeLayout(false);
            panelMethods.PerformLayout();
            panelProperties.ResumeLayout(false);
            panelProperties.PerformLayout();
            panelAccessModifier.ResumeLayout(false);
            panelAccessModifier.PerformLayout();
            tableLayoutPanelCelýForm.ResumeLayout(false);
            panelPlochaProCanvas.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private Panel panelEditClass;
        private TableLayoutPanel tableLayoutPanelCelýForm;
        private TableLayoutPanel tableLayoutPanelClassEdit;
        private TableLayoutPanel tableLayoutPanelDeleteConfirmButtons;
        private Button buttonDeleteClass;
        private Button buttonConfirmClass;
        private Panel panelPlochaProCanvas;
        private TableLayoutPanel tableLayoutPanelChooseWhatToEdit;
        private TextBox textBoxClassName;
        private Panel panelProperties;
        private Label labelProperties;
        private Button buttonNewProperty;
        private ComboBox comboBoxProperties;
        private Panel panelMethods;
        private Button buttonNewMethod;
        private ComboBox comboBoxMethod;
        private Label labelMethod;
        private Panel panelDataType;
        private ComboBox comboBoxDataType;
        private Label label2;
        private Panel panelAccessModifier;
        private ComboBox comboBoxAccessModifier;
        private Label label1;
        private Panel panelIdentificator;
        private TextBox textBoxIdentificator;
        private Label labelIdentificator;
        private Panel panelParametrs;
        private TextBox textBoxParametrs;
        private Label labelParametrs;
        private Button button1;
    }
}
