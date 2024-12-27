
namespace UML_Maker_App
{
    public class ClassMethod : ICodeComponent
    {
        public AccessModifer AccessModifer { get; set; }
        public string DataType { get; set; }
        public string Identificator { get; set; }
        public List<string> Parameters { get; set; }

        public ClassMethod(AccessModifer accessModifer, string dataType, string identificator, List<string> parameters)
        {
            AccessModifer = accessModifer;
            DataType = dataType;
            Identificator = identificator;
            Parameters = parameters;
        }

        public ClassMethod()
        {
            AccessModifer = AccessModifer.Public;
            DataType = string.Empty;
            Identificator = string.Empty;
            Parameters = new List<string>();
        }

        public override string ToString()
        {
            string parameters = string.Empty;
            foreach (string parameter in Parameters)
            {
                parameters += $"{parameter},";
            }

            if (Parameters.Count > 0)
                parameters = parameters.Remove(parameters.Length - 1);

            return $"{AccessModifer.ToSign()}{Identificator}({parameters}): {DataType}";
        }

        public void WriteCode(string path)
        {
            string parameters = string.Empty;
            for (int i = 1; i <= Parameters.Count; i++)
            {
                parameters += $"{Parameters[i-1]} par{i},";
            }

            if(Parameters.Count > 0 )
                parameters = parameters.Remove(parameters.Length - 1);

            File.AppendAllText(path, $"{AccessModifer.InCodeFormat()} {DataType} {Identificator} ({parameters})\n{{\n\n}}\n");
            
        }

        public void DrawUML(Graphics g, float posX, float posY)
        {
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;

            string parameters = string.Empty;
            foreach (string parameter in Parameters)
            {
                parameters += $"{parameter},";
            }

            if (Parameters.Count > 0)
                parameters = parameters.Remove(parameters.Length - 1);

            string str = $"{AccessModifer.ToSign()}{Identificator}({parameters}): {DataType}";

            g.DrawString(str, font, brush, posX + 5, posY);
        }

        public bool IsValid()
        {
            return DataType != string.Empty && Identificator != string.Empty;
        }

    }
}
