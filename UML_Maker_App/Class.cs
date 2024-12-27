
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms.VisualStyles;

namespace UML_Maker_App
{
    public class Class
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

        public Class()
        {
            Identificator = string.Empty;
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
            

            string longestText = GetLongestText();
            int fontSize = longestText == this.Identificator ? 16 : 10;

			Font fontForProperties = new Font("Arial", fontSize);

			SizeF size = g.MeasureString(longestText, fontForProperties);

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
            StringFormat format = new StringFormat()
            {
                Alignment = StringAlignment.Center,
            };
            Brush brush = Brushes.Black;
            Pen pen = Pens.CadetBlue;
            Brush brushAlice = Brushes.CadetBlue;

            width = GetMinimalWidth(g);
            height = GetMinimalHeight();


            g.DrawRectangle(pen, posX, posY, width, height);
            g.FillRectangle(brushAlice, posX, posY, width, 29); //výška fontu(teď 14) + 30/2
            g.DrawString($"{Identificator}", font, brush, posX + width/2, posY,format);

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

        public void WriteCode(string path, List<Relation> relations)
        {
            string inherianceClass = "";

            Relation? inheritanceRelation = relations.Where(r => r?.RelationType == RelationType.Inheritance).FirstOrDefault(r => r?.FirstClass?.ClassInBox?.Identificator == this.Identificator);
           
            if(inheritanceRelation != null)
            {
                inherianceClass = $" : {inheritanceRelation.SecondClass.ClassInBox.Identificator}";
            }


			List<ClassProperty> externalProperties = new List<ClassProperty>();

            LoadExternalProperties(relations, externalProperties);
            LoadExternalPropertiesFromBiAssociation(relations, externalProperties);


			File.AppendAllText(path, $"public class {Identificator}{inherianceClass}\n{{\n");
            foreach( var property in Properties )
            {
                property.WriteCode(path);
            }
            foreach( var property in externalProperties )
            {
                property.WriteCode(path);
            }

            File.AppendAllText(path, "\n");
            foreach (var method in Methods)
            {
                method.WriteCode(path);
            }
            File.AppendAllText(path, $"}}\n\n");
        }

        public bool IsValid()
        {
            return Identificator != string.Empty;
        }

        private void LoadExternalProperties(List<Relation> relations, List<ClassProperty> externalProperties)
        {
			List<Relation> relationList = relations.Where(r => r?.RelationType != RelationType.Inheritance).Where(r => r?.FirstClass?.ClassInBox?.Identificator == this.Identificator).ToList();


			foreach (var item in relationList)
			{
				string dataType = "";
				if (item.MultiplicityForInitialClass == MultiplicityType.One)
				{
					dataType = item.SecondClass.ClassInBox.Identificator;
				}
				else
				{
					dataType = $"List<{item.SecondClass.ClassInBox.Identificator}>";
				}
				string propertyName = item.PropertyName;

				ClassProperty classProperty = new ClassProperty(AccessModifer.Public, dataType, propertyName);
				externalProperties.Add(classProperty);
			}
		}

        private void LoadExternalPropertiesFromBiAssociation(List<Relation> relations, List<ClassProperty> externalProperties)
        {
			List<Relation> relationList = relations.Where(r => r?.RelationType == RelationType.BiDirectional_Association).Where(r => r?.SecondClass?.ClassInBox?.Identificator == this.Identificator).ToList();
			foreach (var item in relationList)
			{
				string dataType = "";
				if (item.MultiplicityForSecondClass == MultiplicityType.One)
				{
					dataType = item.FirstClass.ClassInBox.Identificator;
				}
				else
				{
					dataType = $"List<{item.FirstClass.ClassInBox.Identificator}>";
				}
				string propertyName = item.PropertyNameInSecondClass;

				ClassProperty classProperty = new ClassProperty(AccessModifer.Public, dataType, propertyName);
				externalProperties.Add(classProperty);
			}
		}
    }
}


