using DragAndDrop;
using System.Drawing.Printing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UML_Maker_App
{
    public class JSONParser
    {
        public string Path { get; set; }
        private JsonSerializerOptions _options;

        public JSONParser(string path)
        {
            Path = path;
            _options = new JsonSerializerOptions //nastavení možností deserializace JSON
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, //vlastnosti jsou zapsány camelCase s malým počátečním písmenem
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }, //případné enums jsou převáděny z int na string
                IncludeFields = true,
                PropertyNameCaseInsensitive = true

            };
        }

        public void SaveJson(Canvas canvas)
        {

            string json = "";
            json += JsonSerializer.Serialize(canvas, _options);

            File.WriteAllText(Path, json);
        }

        public Canvas ReadJsonFile()
        {
            string json = File.ReadAllText(Path);

            Canvas canvas = JsonSerializer.Deserialize<Canvas>(json,_options)!;

            return canvas;
        }




	}
}
