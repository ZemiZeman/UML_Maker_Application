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
            textBoxInitialClass.Text = _initialBox.Class.Identificator;
            BindingList<string> classList = new BindingList<string>();
            classList.Add("Vyberte třídu");
            _allBoxes.Remove(_initialBox);
            _allBoxes.ForEach(box => classList.Add(box.Class.Identificator));
            comboBoxOtherClass.DataSource = classList;

            radioButton1InitialClass.Checked = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Relation relation = LoadRelation();
            _canvas.AddRelation(relation);
            this.Hide();    
        }

        private Relation LoadRelation()
        {
            string propertyName = textBoxPropertyName.Text;
            Box firstclass = _initialBox;
            Box secondClass = _allBoxes.SingleOrDefault(b => b.Class.Identificator == comboBoxOtherClass.Text);

            MultiplicityType multiplicityInitial = radioButton1InitialClass.Checked ? MultiplicityType.One : MultiplicityType.N;
            MultiplicityType multiplicityOther = radioButton1OtherClass.Checked ? MultiplicityType.One : MultiplicityType.N;

            return new Relation(propertyName,firstclass,secondClass,multiplicityInitial,multiplicityOther);
        }
    }
}
