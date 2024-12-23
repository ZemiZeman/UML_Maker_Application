using System.Collections.Immutable;
using System.Diagnostics;
using System.Drawing.Imaging;
using UML_Maker_App;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DragAndDrop
{
    public partial class FormMain : Form
    {
        private Canvas _canvas;
        private bool _isDoubleClicked;
        private Box? _editedBox;

        public FormMain()
        {
            _canvas = new Canvas();
            _isDoubleClicked = false;
            _editedBox = null;

            InitializeComponent();
            panelEditClass.Visible = false;
            LoadComboBoxes();
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _editedBox = _canvas.DoubleSelect(e.X, e.Y, panelEditClass);
            pictureBox.Refresh();

            if (_editedBox == null)
            {
                panelEditClass.Visible = false;
                textBoxClassName.Text = string.Empty;
                return;
            }

            SetValues();

        }

        private void SetValues()
        {

            if (textBoxClassName.Text == _editedBox!.Class!.Identificator)
            {
                panelEditClass.Visible = false;
                textBoxClassName.Text = string.Empty;
                return;
            }

            panelEditClass.Visible = true;
            textBoxClassName.Text = _editedBox!.Class!.Identificator;

            LoadClassInfos();

        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDoubleClicked)
                return;
            _canvas.Unselect();
            pictureBox.Refresh();

        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_isDoubleClicked)
                return;
            _canvas.Select(e.X, e.Y);
            pictureBox.Refresh();
        }



        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _canvas.Move(e.X, e.Y);
            pictureBox.Refresh();
        }



        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            _canvas.Draw(e.Graphics);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClassProperty property1 = new ClassProperty(AccessModifer.Public, "int", "studentNumber");
            ClassProperty property2 = new ClassProperty(AccessModifer.Public, "int", "averageMark");

            ClassMethod method = new ClassMethod(AccessModifer.Public, "bool", "isEligibleToEnroll", new List<string> { "string" });
            ClassMethod method2 = new ClassMethod(AccessModifer.Public, "int", "getSeminarsTaken", new List<string>());

            Class @class = new Class(new List<ClassProperty> { property1, property2 }, new List<ClassMethod> { method, method2 }, "Student");

            @class.WriteCode();
        }

        private void LoadComboBoxes()
        {

            comboBoxAccessModifier.DataSource = Enum.GetValues(typeof(AccessModifer));
        }

        private void LoadClassInfos()
        {
            LoadProperties();
            LoadMethods();
            LoadInfos();
        }

        private void LoadProperties()
        {
            panelProperties.Enabled = true;
            if (_editedBox!.Class!.Properties.Count == 0)
            {
                comboBoxProperties.Enabled = false;
                return;
            }

            comboBoxProperties.Enabled = true;

            List<string> properties = new List<string> { "Vyberte vlastnost:" };
            foreach (var item in _editedBox.Class.Properties)
            {
                properties.Add(item.Identificator);
            }

            comboBoxProperties.DataSource = properties;
        }

        private void LoadMethods()
        {
            panelMethods.Enabled = true;
            if (_editedBox!.Class!.Methods.Count == 0)
            {
                comboBoxMethod.Enabled = false;
                return;
            }

            comboBoxMethod.Enabled = true;

            List<string> methods = new List<string> { "Vyberte metodu:" };
            foreach (var item in _editedBox.Class.Methods)
            {
                methods.Add(item.Identificator);
            }

            comboBoxMethod.DataSource = methods;
        }

        private void LoadInfos()
        {
            panelAccessModifier.Visible = false;
            panelDataType.Visible = false;
            panelIdentificator.Visible = false;
            panelParametrs.Visible = false;
        }

        private void comboBoxProperties_TextChanged(object sender, EventArgs e)
        {
            ClassProperty? property = _editedBox.Class.Properties.SingleOrDefault(p => p.Identificator == comboBoxProperties.Text);
            if (property == null)
            {
                LoadClassInfos();
                return;
            }


            SetPropertiesInfos(property);

        }

        private void SetPropertiesInfos(ClassProperty property)
        {
            panelAccessModifier.Visible = true;
            comboBoxAccessModifier.SelectedItem = property.AccessModifer;
            panelDataType.Visible = true;
            comboBoxDataType.Text = property.DataType;
            panelIdentificator.Visible = true;
            textBoxIdentificator.Text = property.Identificator;

            panelParametrs.Visible = false;
        }

        private void comboBoxMethod_TextChanged(object sender, EventArgs e)
        {
            ClassMethod? method = _editedBox!.Class!.Methods.SingleOrDefault(p => p.Identificator == comboBoxMethod.Text);
            if (method == null)
            {
                LoadClassInfos();
                return;
            }

            SetMethodsInfos(method);
        }

        private void SetMethodsInfos(ClassMethod method)
        {
            panelAccessModifier.Visible = true;
            comboBoxAccessModifier.SelectedItem = method.AccessModifer;
            panelDataType.Visible = true;
            comboBoxDataType.Text = method.DataType;
            panelIdentificator.Visible = true;
            textBoxIdentificator.Text = method.Identificator;
            panelParametrs.Visible = true;
            textBoxParametrs.Text = String.Join(',', method.Parameters);
        }

        private void buttonNewProperty_Click(object sender, EventArgs e)
        {
            SetPropertiesInfos(new ClassProperty());
        }

        private void buttonNewMethod_Click(object sender, EventArgs e)
        {
            SetMethodsInfos(new ClassMethod());
        }

        private void buttonConfirmClass_Click(object sender, EventArgs e)
        {
            if (panelParametrs.Visible)
                ConfirmMethod();
            else if (panelAccessModifier.Visible)
                ConfirmProperty();
            else if (panelProperties.Enabled)
                ConfirmClass();
            else
                ConfirmAddClass();
        }

        public void ConfirmMethod()
        {
            ClassMethod newMethod = new ClassMethod((AccessModifer)comboBoxAccessModifier.SelectedItem!, comboBoxDataType.Text, textBoxIdentificator.Text, textBoxParametrs.Text.Split(',').ToList());
            if (newMethod.IsValid())
            {
                if (comboBoxMethod.SelectedIndex != 0 && comboBoxMethod.Enabled)
                {
                    int index = 0;
                    for (int i = 0; i < comboBoxMethod.Items.Count; i++)
                    {
                        if ((string)comboBoxMethod.Items[i] == newMethod.Identificator)
                        {
                            index = i - 1;
                            break;
                        }
                    }

                    _editedBox.Class.Methods[index] = newMethod;
                    pictureBox.Refresh();
                    LoadClassInfos();
                    return;
                }


                _editedBox!.Class!.Methods.Add(newMethod);
                pictureBox.Refresh();
                LoadClassInfos();
            }

        }

        public void ConfirmProperty()
        {
            ClassProperty newProperty = new ClassProperty((AccessModifer)comboBoxAccessModifier.SelectedItem!, comboBoxDataType.Text, textBoxIdentificator.Text);

            if (newProperty.IsValid())
            {
                if (comboBoxProperties.SelectedIndex != 0 && comboBoxProperties.Enabled)
                {
                    int index = 0;
                    for (int i = 0; i < comboBoxProperties.Items.Count; i++)
                    {
                        if ((string)comboBoxProperties.Items[i] == newProperty.Identificator)
                        {
                            index = i - 1;
                            break;
                        }
                    }

                    _editedBox.Class.Properties[index] = newProperty;
                    pictureBox.Refresh();
                    LoadClassInfos();
                    return;
                }
                _editedBox!.Class!.Properties.Add(newProperty);
                pictureBox.Refresh();
                LoadClassInfos();
            }
        }

        public void ConfirmClass()
        {
            Class newClass = new Class(_editedBox.Class.Properties, _editedBox.Class.Methods, textBoxClassName.Text);

            if (newClass.IsValid())
            {
                _editedBox!.Class = newClass;
                pictureBox.Refresh();
                LoadClassInfos();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteClass_Click(object sender, EventArgs e)
        {
            if (panelParametrs.Visible)
                DeleteMethod();
            else if (panelAccessModifier.Visible)
                DeleteProperty();
            else
                DeleteClass();
        }

        private void DeleteMethod()
        {
            string methodName = textBoxIdentificator.Text;
            DialogResult = MessageBox.Show($"Do you really want to delete METHOD \"{methodName.ToUpper()}\"", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (DialogResult == DialogResult.Cancel || DialogResult == DialogResult.No)
            {
                return;
            }

            _editedBox.Class.Methods.RemoveAll(m => m.Identificator == methodName);
            pictureBox.Refresh();
            LoadClassInfos();
        }

        private void DeleteProperty()
        {
            string propertyName = textBoxIdentificator.Text;
            DialogResult = MessageBox.Show($"Do you really want to delete PROPERTY \"{propertyName.ToUpper()}\"", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (DialogResult == DialogResult.Cancel || DialogResult == DialogResult.No)
            {
                return;
            }

            _editedBox.Class.Properties.RemoveAll(m => m.Identificator == propertyName);
            pictureBox.Refresh();
            LoadClassInfos();
        }

        private void DeleteClass()
        {
            string className = textBoxClassName.Text;
            DialogResult = MessageBox.Show($"Do you really want to delete CLASS \"{className.ToUpper()}\"", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (DialogResult == DialogResult.Cancel || DialogResult == DialogResult.No)
            {
                return;
            }

            _canvas.DeleteBox(_editedBox);
            pictureBox.Refresh();
            panelEditClass.Visible = false;

        }

        private void buttonAddClass_Click(object sender, EventArgs e)
        {
            panelEditClass.Visible = true;

            panelProperties.Enabled = false;
            panelMethods.Enabled = false;
            LoadInfos();
        }

        public void ConfirmAddClass()
        {
            string className = textBoxClassName.Text;
            Class newClass = new Class(className);

            _editedBox = _canvas.AddBox(newClass);

            pictureBox.Refresh();

            if (_editedBox == null)
            {
                panelEditClass.Visible = false;
                textBoxClassName.Text = string.Empty;
                return;
            }

            LoadClassInfos();
        }

        private void buttonSavePNG_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();


            if (result == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics g = Graphics.FromImage(bmp);

                g.Clear(Color.White);
                _canvas.Draw(g);

                bmp.Save(saveFileDialog.FileName, ImageFormat.Png);
            }

        }
    }
}
