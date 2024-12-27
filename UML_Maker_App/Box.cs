using System.Text.Json.Serialization;
using UML_Maker_App;

namespace DragAndDrop
{
    public class Box
    {
        public int PositionX { get; private set; }
		public int PositionY { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }
		public Class? ClassInBox { get; set; }


		[JsonIgnore]
		public int MinWidth => 80;
		[JsonIgnore]
		public int MinHeight => 40;
		[JsonIgnore]
		public int MaxWidth => 320;
		[JsonIgnore]
		public int MaxHeight => 320;

		[JsonIgnore]
		public Brush _color;
		[JsonIgnore]
		private string _text;

        public Box(int x, int y, Class classInBox = null)
        {
            PositionX = x;
            PositionY = y;
            ClassInBox = classInBox;

            Width = 80;
            Height = 80;
            _color = Brushes.Red;
            _text = "Box";
        }

        public Box()
        {
            PositionX = 0;
            PositionY = 0;
            ClassInBox = null;

            Width = 80;
            Height = 80;
            _color = Brushes.Red;
            _text = "";
        }

        public void Select()
        {
            _color = Brushes.Blue;
            _text = "Selected";
        }

        public void Edit(Panel panel)
        {

            panel.Visible = !panel.Visible;
        }

        public void Unselect()
        {
            _color = Brushes.Red;
            _text = "Box";
        }

        public void Move(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public void Resize(int w, int h)
        {
            if (w < MinWidth)
                w = MinWidth;

            if (h < MinHeight)
                h = MinHeight;

            if (w > MaxWidth)
                w = MaxWidth;

            if (h > MaxHeight)
                h = MaxHeight;

            Width = w;
            Height = h;
        }

        public void Draw(Graphics g)
        {
            if (ClassInBox == null)
            {
                g.TranslateTransform(PositionX, PositionY);
                g.FillRectangle(_color, 0, 0, Width, Height);
                g.FillRectangle(Brushes.Black, Width - 10, Height - 10, 10, 10);
                g.DrawString(_text, new Font("Arial", 10), Brushes.Black, 10, 10);
                g.ResetTransform();
            }
            else
            {
                Width = (int)ClassInBox.GetMinimalWidth(g);
                Height = (int)ClassInBox.GetMinimalHeight();
                ClassInBox.DrawUML(g, PositionX, PositionY,Width,Height);
            }
        }

        public bool IsInCollision(int x, int y)
        {
            return x > PositionX && x <= PositionX + Width
                && y > PositionY && y <= PositionY + Height;
        }

        public bool IsInCollisionWithCorner(int x, int y)
        {
            return x > (PositionX + Width - 10) && x <= PositionX + Width
                && y > (PositionY + Height - 10) && y <= PositionY + Height;
        }

        public bool IsInCollisionWithAnotherBox(Box box)
        {
            return this.PositionX + this.Width > box.PositionX && box.PositionX + box.Width > this.PositionX 
                && this.PositionY + this.Height > box.PositionY && box.PositionY + box.Height > this.PositionY;
        }
    }
}
