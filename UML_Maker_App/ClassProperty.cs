namespace UML_Maker_App
{
    public class ClassProperty : ICodeComponent
    {
        public AccessModifer AccessModifer { get; set; }
        public string DataType { get; set; }
        public string Identificator { get; set; }

        public ClassProperty(AccessModifer accessModifer, string dataType, string identificator)
        {
            AccessModifer = accessModifer;
            DataType = dataType;
            Identificator = identificator;
        }

        public ClassProperty()
        {
            AccessModifer = AccessModifer.Public;
            DataType = string.Empty;
            Identificator = string.Empty;
        }

        public void WriteCode()
        {
            File.AppendAllText("text.txt", $"{AccessModifer.InCodeFormat()} {DataType} {Identificator}  {{get; set;}} \n");
        }

        public void DrawUML(Graphics g, float posX, float posY)
        {
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;

            string str = $"{AccessModifer.ToSign()}{Identificator}: {DataType}";

            g.DrawString(str, font, brush, posX, posY);
        }

        public bool IsValid()
        {
            return DataType != string.Empty && Identificator != string.Empty;
        }
    }
}
