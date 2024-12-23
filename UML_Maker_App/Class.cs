
using System.ComponentModel.DataAnnotations;

namespace UML_Maker_App
{
    public class Class : ICodeComponent
    {
        public List<ClassProperty> Properties { get; set; }
        public List<ClassMethod> Methods { get; set; }

        public string Identificator { get; set; }

        public Class(List<ClassProperty> properties, List<ClassMethod> methods, string identificator)
        {
            Properties = properties;
            Methods = methods;
            Identificator = identificator;
        }

        public Class(string identificator)
        {
            Identificator= identificator;
            Properties = new List<ClassProperty>();
            Methods = new List<ClassMethod>();
        }

        public string GetLongestText()
        {
            string longestString = Identificator;

            foreach (ClassProperty classProperty in Properties)
            {
                if (classProperty.ToString().Length > longestString.Length)
                    longestString = classProperty.ToString();
            }

            foreach (ClassMethod classMethod in Methods)
            {
                if(classMethod.ToString().Length > longestString.Length)
                    longestString = classMethod.ToString();
            }

            return longestString;

        }


        public void DrawUML(Graphics g, float posX, float posY)
        {
            
        }

        public float GetMinimalWidth(Graphics g)
        {
            Font fontForProperties = new Font("Arial", 10);

            SizeF size = g.MeasureString(GetLongestText(), fontForProperties);

            return float.Parse(size.Width.ToString()) + 5;
        }

        public float GetMinimalHeight()
        {
            float height = 30;
            height += 30;

            foreach (ClassProperty classProperty in Properties)
                height += 15;

            height += 15;

            foreach (ClassMethod classMethod in Methods)
                height += 15;

            height -= 15;

            return height;

        }

        public void DrawUML(Graphics g,float posX,float posY,float width,float height)
        {
            Font font = new Font("Arial", 14);
            Brush brush = Brushes.Black;
            Pen pen = Pens.CadetBlue;
            Brush brushAlice = Brushes.CadetBlue;

            width = GetMinimalWidth(g);
            height = GetMinimalHeight();


            g.DrawRectangle(pen, posX, posY, width, height);
            g.FillRectangle(brushAlice, posX, posY, width, 29); //výška fontu(teď 14) + 30/2
            g.DrawString($"{Identificator}", font, brush, posX, posY);

            posY += 30;

            for (int i = 0; i < Properties.Count; i++)
            {
                Properties[i].DrawUML(g, posX, posY);
                posY += 15;
            }

            g.DrawLine(pen, posX, posY + 7.5f, posX + width, posY + 7.5f);
            posY += 15;

            for (int i = 0; i < Methods.Count; i++)
            {
                Methods[i].DrawUML(g, posX, posY);
                posY += 15;
            }
        }

        public void WriteCode()
        {
            File.AppendAllText("text.txt", $"public class {Identificator}\n{{\n");
            foreach( var property in Properties )
            {
                property.WriteCode();
            }

            File.AppendAllText("text.txt", "\n");
            foreach (var method in Methods)
            {
                method.WriteCode();
            }
            File.AppendAllText("text.txt", $"}}\n");
        }

        public bool IsValid()
        {
            return Identificator != string.Empty;
        }
    }
}


