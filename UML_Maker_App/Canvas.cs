using UML_Maker_App;
using UML_Maker_App.Selections;

namespace DragAndDrop
{
    public class Canvas
    {
        private List<Box> _boxes;
        private Selection? _selection;
        private List<Relation> _relations;

        public Canvas()
        {
            _boxes = new List<Box>();
            _selection = null;
            _relations = new List<Relation>();

            //for(int i = 0; i < 5; i++)
            //{
            //    Box box = new Box(10, (i * 100) + 10,(i+1).ToString());
            //    _boxes.Add(box);
            //}

            ClassProperty property1 = new ClassProperty(AccessModifer.Public, "int", "studentNumber");
            ClassProperty property2 = new ClassProperty(AccessModifer.Public, "int", "averageMark");

            ClassMethod method = new ClassMethod(AccessModifer.Public, "bool", "isEligibleToEnroll", new List<string> { "string" });
            ClassMethod method2 = new ClassMethod(AccessModifer.Public, "int", "getSeminarsTaken", new List<string> ());

            Class @class = new Class(new List<ClassProperty> { property1, property2 }, new List<ClassMethod> { method, method2 }, "Student");

            _boxes.Add(new Box(10, 10, @class));

            ClassProperty property3 = new ClassProperty(AccessModifer.Public, "int", "countOfTeacher");
            ClassProperty property4 = new ClassProperty(AccessModifer.Private, "int", "budget");

            ClassMethod method3 = new ClassMethod(AccessModifer.Public, "bool", "isOpen", new List<string> { "" });
            ClassMethod method4 = new ClassMethod(AccessModifer.Public, "void", "FireTeacher", new List<string>());

            Class @class2 = new Class(new List<ClassProperty> { property3, property4 }, new List<ClassMethod>{ method3, method4}, "School");

            _boxes.Add(new Box(250, 10,@class2));

            ClassProperty propert5 = new ClassProperty(AccessModifer.Private, "bool", "IsAvaiable");

            ClassMethod method5 = new ClassMethod(AccessModifer.Internal,"","teach",new List<string> {"str","int"});

            Class @class3 = new Class(new List<ClassProperty> { propert5 }, new List<ClassMethod> { method5 }, "Teacher");

            _boxes.Add(new Box(150, 250,@class3));

            _relations.Add(new Relation("students", _boxes.SingleOrDefault(b => b.Class.Identificator == "School")!, _boxes.SingleOrDefault(b => b.Class.Identificator == "Student")!, MultiplicityType.One));
            _relations.Add(new Relation("teachers", _boxes.SingleOrDefault(b => b.Class.Identificator == "School")!, _boxes.SingleOrDefault(b => b.Class.Identificator == "Teacher")!, MultiplicityType.N));
        }

        public void Draw(Graphics g)
        {
            foreach (Box box in _boxes)
                box.Draw(g);

            foreach(Relation relation in _relations)
                relation.DrawUML(g);
        }

        public void Select(int x, int y)
        {
            Unselect();
            for (int i = 0; i < _boxes.Count; i++)
            {
                Box box = _boxes[i];
                if (box.IsInCollisionWithCorner(x, y))
                {
                    //MessageBox.Show("Corner selected!");

                    _selection = new ResizeSelection(box, x, y);
                    _selection.Select();
                    return;
                }
                else if (box.IsInCollision(x, y))
                {
                    _selection = new MoveSelection(box, x, y);
                    _selection.Select();
                    return;
                }
            }
        }

        
        public void Unselect()
        {
            if (_selection == null)
                return;

            _selection.Unselect();
            _selection = null;
        }

        public void Move(int x, int y)
        {
            if (_selection == null)
                return;

            _selection.Move(x, y);
        }

        public Box DoubleSelect(int x, int y, Panel panel)
        {
            Unselect();
            for (int i = 0; i < _boxes.Count; i++)
            {
                Box box = _boxes[i];
                if (box.IsInCollision(x, y))
                {
                    return box;
                }
            }
            return null;
        }

        public void DeleteBox(Box box)
        {
            _boxes.Remove(box);
        }

        public Box AddBox(Class @class)
        {
            int row = _boxes.Count / 4;
            int help = 0;
            if (row == 0)
                help++;
            int x = _boxes.Count % 4;

            Box box = new Box(x * 250 + 10, row*150+10,@class);
            _boxes.Add(box);
            return box;
        }
    }
}
