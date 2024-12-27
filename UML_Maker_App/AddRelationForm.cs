using DragAndDrop;
using System.ComponentModel;

namespace UML_Maker_App
{
    public partial class AddRelationForm : Form
    {
        public event EventHandler SelectPoint;

        private Box _initialBox;
        private List<Box> _allBoxes;
        private Canvas _canvas;
        public AddRelationForm(Box initialBox, List<Box> allBoxes, Canvas canvas)
        {
            _initialBox = initialBox;
            _allBoxes = allBoxes;
            InitializeComponent();

            SetDefaultValues();
            _canvas = canvas;
        }

        private void SetDefaultValues()
        {
            textBoxInitialClass.Text = _initialBox.ClassInBox.Identificator;

            BindingList<string> classList = new BindingList<string>();
            classList.Add("Vyberte třídu...");
            _allBoxes.Remove(_initialBox);
            _allBoxes.ForEach(box => classList.Add(box.ClassInBox.Identificator));
            comboBoxOtherClass.DataSource = classList;

            BindingList<string> relationsList = new BindingList<string>();
            relationsList.Add("Vyberte vztah...");
            Enum.GetNames(typeof(RelationType)).ToList().ForEach(relationsList.Add);
            comboBoxRelationType.DataSource = relationsList;


            radioButton1InitialClass.Checked = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBoxRelationType.SelectedIndex == 0 || comboBoxOtherClass.SelectedIndex == 0)
                return;

            Relation relation = LoadRelation();
            if (!relation.IsValid())
                return;
            _canvas.AddRelation(relation);
            this.Hide();
        }

        private Relation LoadRelation()
        {
            string propertyName = textBoxPropertyName.Text;
            Box firstclass = _initialBox;
            Box secondClass = _allBoxes.SingleOrDefault(b => b.ClassInBox.Identificator == comboBoxOtherClass.Text);

            RelationType relationType = (RelationType)Enum.Parse(typeof(RelationType), comboBoxRelationType.Text);

            MultiplicityType multiplicityInitial = radioButton1InitialClass.Checked ? MultiplicityType.One : MultiplicityType.N;
            MultiplicityType multiplicityOther = radioButton1OtherClass.Checked ? MultiplicityType.One : MultiplicityType.N;

            string propertySecondClass= textBoxPropertyForSecondClass.Text;

            return new Relation(propertyName, firstclass, secondClass, relationType, multiplicityInitial, multiplicityOther,propertySecondClass);
        }

        private void comboBoxRelationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelForInitialMultiplicity.Visible = comboBoxRelationType.SelectedIndex != 5;
            textBoxPropertyName.Visible = comboBoxRelationType.SelectedIndex != 5;
            label4.Visible = comboBoxRelationType.SelectedIndex != 5;

            labelPropertyForSecondClass.Visible = comboBoxRelationType.SelectedIndex == 2;
            textBoxPropertyForSecondClass.Visible = comboBoxRelationType.SelectedIndex == 2;

            panelForSecondMultiplicity.Visible = comboBoxRelationType.SelectedIndex == 2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
