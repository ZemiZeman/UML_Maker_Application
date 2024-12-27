namespace UML_Maker_App
{
    public interface ICodeComponent
    {
        void WriteCode(string path);

        void DrawUML(Graphics g, float posX, float posY);

    }
}
