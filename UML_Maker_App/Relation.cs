using DragAndDrop;
using System.Security.Authentication.ExtendedProtection;

namespace UML_Maker_App
{
    public class Relation
    {
        public string PropertyName { get; set; }

        public Box FirstClass { get; set; }
        public Box SecondClass { get; set; }
        public MultiplicityType? MultiplicityForInitialClass { get; set; }
        public MultiplicityType? MultiplicityForSecondClass { get; set; }

        public PointF StartPoint { get; set; }
        public PointF EndPoint { get; set; }

        public Relation(string propertyName, Box firstClass, Box secondClass, MultiplicityType multiplicityForInitialClass, MultiplicityType? multiplicityForSecondClass)
        {
            PropertyName = propertyName;
            FirstClass = firstClass;
            SecondClass = secondClass;
            MultiplicityForInitialClass = multiplicityForInitialClass;
            MultiplicityForSecondClass = multiplicityForSecondClass;


            StartPoint = new Point(0, 0);
            EndPoint = new Point(0, 0);
        }

        public void DrawUML(Graphics g)
        {
            

            int x1 = FirstClass.PositionX + FirstClass.Width / 2;
            int y1 = FirstClass.PositionY + FirstClass.Height / 2;
            PointF lineStart = new PointF(x1, y1);

            int x2 = SecondClass.PositionX + SecondClass.Width / 2;
            int y2 = SecondClass.PositionY + SecondClass.Height / 2;
            Point lineEnd = new Point(x2, y2);

            Rectangle firstBox = new Rectangle(FirstClass.PositionX, FirstClass.PositionY, FirstClass.Width, FirstClass.Height);
            Rectangle secondBox = new Rectangle(SecondClass.PositionX, SecondClass.PositionY, SecondClass.Width, SecondClass.Height);

            StartPoint = GetIntersectionPoint(firstBox,lineStart,lineEnd);
            EndPoint = GetIntersectionPoint(secondBox,lineStart,lineEnd);



            Pen pen = new Pen(Color.Red, 2);
            g.DrawLine(pen, StartPoint,EndPoint);
            DrawArrow(g, pen);
            DrawInformations(g);

            
        }

        private void DrawArrow(Graphics g,Pen pen)
        {
                       
            g.TranslateTransform(EndPoint.X, EndPoint.Y);
            g.RotateTransform(GetLineAngle());

            
            g.DrawLine(pen, 0, 0, -20, -10);
            g.DrawLine(pen, 0, 0, -20, 10);

            g.ResetTransform();
            
        }

        private float GetLineAngle()
        {
            float angle = (float)Math.Atan2(EndPoint.Y - StartPoint.Y, EndPoint.X - StartPoint.X);
            float degreeAngle = angle * (float)(180 / Math.PI);

            return degreeAngle;
        }

        private void DrawInformations(Graphics g)
        {
            float angle = GetLineAngle();
            byte stringOption = 1;


            if ((angle >= 149 && angle <= 180) || (angle >= -180 && angle <= -149))
                stringOption = 1;
            else if (angle < -30 && angle > -149)
                stringOption = 2;
            else if (angle >= -30 && angle <= 30)
                stringOption = 3;
            else if(angle > 30 && angle < 149)
                stringOption = 4;
                


            string multiplicityInfo = MultiplicityForInitialClass == null ? "" : MultiplicityForInitialClass == MultiplicityType.One ? "1" : "*";
            string propertyInfo = PropertyName;
            StringFormat style1 = new StringFormat()
            {
                Alignment = StringAlignment.Near,

            };
            StringFormat style2 = new StringFormat()
            {
                LineAlignment = StringAlignment.Near,

            };
            StringFormat style3 = new StringFormat()
            {
                Alignment = StringAlignment.Far,

            };
            StringFormat style4 = new StringFormat()
            {
                LineAlignment = StringAlignment.Far,

            };

            Font font = new Font("Arial", 10);

            switch (stringOption)
            {
                case 1:
                    g.DrawString(multiplicityInfo, font, Brushes.Red, EndPoint.X + 10, EndPoint.Y + 20,style1);
                    g.DrawString(propertyInfo, font, Brushes.Red, EndPoint.X + 10, EndPoint.Y - 20 - g.MeasureString(propertyInfo,font).Height,style1);
                    break;
                case 2:
                    g.DrawString(multiplicityInfo, font, Brushes.Red, EndPoint.X + 20, EndPoint.Y + 10,style2);
                    g.DrawString(propertyInfo, font, Brushes.Red, EndPoint.X - 20 - g.MeasureString(propertyInfo,font).Width, EndPoint.Y + 10,style2);
                    break;
                case 3:
                    g.DrawString(multiplicityInfo, font, Brushes.Red, EndPoint.X - 10, EndPoint.Y + 20,style3);
                    g.DrawString(propertyInfo, font, Brushes.Red, EndPoint.X - 10 , EndPoint.Y - 20 - g.MeasureString(propertyInfo, font).Height, style3);
                    break;
                case 4:
                    g.DrawString(multiplicityInfo, font, Brushes.Red, EndPoint.X + 20, EndPoint.Y - 10, style4);
                    g.DrawString(propertyInfo, font, Brushes.Red, EndPoint.X - 20 - g.MeasureString(propertyInfo, font).Width, EndPoint.Y - 10, style4);
                    break;
            }

            g.DrawString(angle.ToString(), new Font("Arial", 16), Brushes.Black, 50, 50);
            g.DrawString(stringOption.ToString(), new Font("Arial", 16), Brushes.Black, 50, 75);

            
        }


        public static PointF GetIntersectionPoint(Rectangle box, PointF lineStart, PointF lineEnd)
        {
            PointF[] boxEdges = new PointF[]
            {
            new PointF(box.Left, box.Top),     // Levý horní roh
            new PointF(box.Right, box.Top),   // Pravý horní roh
            new PointF(box.Right, box.Bottom),// Pravý dolní roh
            new PointF(box.Left, box.Bottom)  // Levý dolní roh
            };

            PointF closestIntersection = new PointF(0,0);
            float closestT = float.MaxValue;

            // Projdeme všechny 4 hrany boxu
            for (int i = 0; i < 4; i++)
            {
                PointF edgeStart = boxEdges[i];
                PointF edgeEnd = boxEdges[(i + 1) % 4];

                if (LineSegmentIntersection(lineStart, lineEnd, edgeStart, edgeEnd, out PointF intersection, out float t))
                {
                    if (t < closestT)
                    {
                        closestT = t;
                        closestIntersection = intersection;
                    }
                }
            }

            return closestIntersection;
        }

        private static bool LineSegmentIntersection(
            PointF p1, PointF p2, PointF q1, PointF q2,
            out PointF intersection, out float t)
        {
            intersection = default;
            t = 0;

            float dx1 = p2.X - p1.X;
            float dy1 = p2.Y - p1.Y;
            float dx2 = q2.X - q1.X;
            float dy2 = q2.Y - q1.Y;

            float denominator = dx1 * dy2 - dy1 * dx2;

            if (Math.Abs(denominator) < 1e-6)
            {
                // Čáry jsou rovnoběžné nebo totožné
                return false;
            }

            float dx = q1.X - p1.X;
            float dy = q1.Y - p1.Y;

            float t1 = (dx * dy2 - dy * dx2) / denominator;
            float t2 = (dx * dy1 - dy * dx1) / denominator;

            if (t1 >= 0 && t1 <= 1 && t2 >= 0 && t2 <= 1)
            {
                intersection = new PointF(p1.X + t1 * dx1, p1.Y + t1 * dy1);
                t = t1;
                return true;
            }

            return false;
        }
    }
}
