using DragAndDrop;
using System.Security.Authentication.ExtendedProtection;
using System.Windows.Forms.VisualStyles;

namespace UML_Maker_App
{
    public class Relation
    {
        public string PropertyName { get; set; }
        public string? PropertyNameInSecondClass { get; set; }

        public Box FirstClass { get; set; } //Classa ve které je odkaz na 2. classu
        public Box SecondClass { get; set; } //Classa na kterou je odkaz
        public RelationType RelationType { get; set; }
        public MultiplicityType? MultiplicityForInitialClass { get; set; }
        public MultiplicityType? MultiplicityForSecondClass { get; set; } //Pro případ obousměrné asociace

        public PointF StartPoint { get; set; } //Bod, kde čára ze středu boxu1, protne hranu boxu
        public PointF EndPoint { get; set; } //Bod, kde čára ze středu boxu2, protne hranu boxu

        public Relation(string propertyName, Box firstClass, Box secondClass,RelationType relationType, MultiplicityType multiplicityForInitialClass, MultiplicityType? multiplicityForSecondClass = null, string? propertyNameInSecondClass = null)
        {
            PropertyName = propertyName;
            FirstClass = firstClass;
            SecondClass = secondClass;
            RelationType = relationType;
            MultiplicityForInitialClass = multiplicityForInitialClass;
            MultiplicityForSecondClass = multiplicityForSecondClass;
            PropertyNameInSecondClass = propertyNameInSecondClass;

            StartPoint = new Point(0, 0);
            EndPoint = new Point(0, 0);
        }

        public Relation()
        {
            PropertyName = string.Empty;
            FirstClass = new Box();
            SecondClass = new Box();
            RelationType = RelationType.Aggregation;
            MultiplicityForInitialClass = MultiplicityType.One;
            MultiplicityForSecondClass = MultiplicityType.One;
            PropertyNameInSecondClass = string.Empty;

            StartPoint = new Point(0, 0);
            EndPoint = new Point(0, 0);



        }
        public bool IsValid()
        {
            if (PropertyName == string.Empty)
                return true;
            return char.IsLetter(PropertyName[0]);
        }
        public void DrawUML(Graphics g)
        {
            

            int x1 = FirstClass.PositionX + FirstClass.Width / 2;
            int y1 = FirstClass.PositionY + FirstClass.Height / 2;
            PointF lineStart = new PointF(x1, y1); //Střed 1. boxu

            int x2 = SecondClass.PositionX + SecondClass.Width / 2;
            int y2 = SecondClass.PositionY + SecondClass.Height / 2;
            Point lineEnd = new Point(x2, y2); //Střed 2. boxu

            Rectangle firstBox = new Rectangle(FirstClass.PositionX, FirstClass.PositionY, FirstClass.Width, FirstClass.Height);
            Rectangle secondBox = new Rectangle(SecondClass.PositionX, SecondClass.PositionY, SecondClass.Width, SecondClass.Height);

            StartPoint = GetIntersectionPoint(firstBox,lineStart,lineEnd);
            EndPoint = GetIntersectionPoint(secondBox,lineStart,lineEnd);



            Pen pen = new Pen(Color.Red, 2);

            if (RelationType == RelationType.UniDirectional_Association)
            {
                DrawUniAssociation(g,pen);
            }
            else if (RelationType == RelationType.BiDirectional_Association)
            {
                DrawBiAssociation(g,pen);
            }
            else if (RelationType == RelationType.Aggregation)
            {
                DrawAggregation(g,pen);
            }
            else if (RelationType == RelationType.Composition)
            {
                DrawComposition(g,pen);
            }
            else if (RelationType == RelationType.Inheritance)
            {
                DrawInheritance(g,pen);
            }
        }

        private void DrawUniAssociation(Graphics g,Pen pen)
        {
            g.DrawLine(pen, StartPoint, EndPoint);
            DrawArrow(g, pen);
            DrawInformations(g);
        }

        private void DrawBiAssociation(Graphics g,Pen pen)
        {
            g.DrawLine(pen, StartPoint, EndPoint);
            DrawInformations(g);
            DrawInformationsForBiAssociation(g);

        }

        private void DrawAggregation(Graphics g, Pen pen)
        {
            PointF[] points = DrawRhombus(g, pen);

            int option = GetEndPointOfRhumbus(g);
            if (option == 4)
                option = 0;

            g.DrawLine(pen, points[option], EndPoint);
            DrawInformations(g);

        }

        private void DrawComposition(Graphics g, Pen pen)
        {
            PointF[] points = FillRhombus(g, pen);

            int option = GetEndPointOfRhumbus(g);
            if (option == 4)
                option = 0;

            g.DrawLine(pen, points[option], EndPoint);
            DrawInformations(g);
        }

        private void DrawInheritance(Graphics g, Pen pen)
        {
            g.DrawLine(pen, StartPoint, EndPoint);
            DrawTriangle(g, pen);
            DrawInformations(g);
        }

        //Pro asociaci
        private void DrawArrow(Graphics g,Pen pen)
        {
                       
            g.TranslateTransform(EndPoint.X, EndPoint.Y);
            g.RotateTransform(GetLineAngle());

            
            g.DrawLine(pen, 0, 0, -20, -10);
            g.DrawLine(pen, 0, 0, -20, 10);
            g.ResetTransform();
            
        }

        //Pro agregaci
        private PointF[] DrawRhombus(Graphics g,Pen pen)
        {

            int options = GetEndPointOfRhumbus(g);
            PointF[] points = GetArrayOfRhombusPoints(options);

            g.DrawPolygon(pen, points);

            return points;
        }


        
        public PointF[] GetArrayOfRhombusPoints(int option)
        {
            float diagonalHorizontal = 0;
            float diagonalVertical = 0;

            if (option % 2 == 1)
            {
                diagonalHorizontal = (float)Math.Sqrt(1200);
                diagonalVertical = 20;
            }
            else
            {
                diagonalVertical = (float)Math.Sqrt(1200);
                diagonalHorizontal = 20;
            }

            PointF[] points = new PointF[4];
            PointF centerPoint = new PointF(0,0);

            if (option == 1)
            {
                centerPoint = new PointF(StartPoint.X + 20, StartPoint.Y);
            }
            if (option == 2)
            {
                centerPoint = new PointF(StartPoint.X, StartPoint.Y + 20);
            }
            if(option == 3)
            {
                centerPoint = new PointF(StartPoint.X - 20, StartPoint.Y);
            }
            if (option ==4)
            {
                centerPoint = new PointF(StartPoint.X, StartPoint.Y - 20);
            }

            points[0] = new PointF(centerPoint.X, centerPoint.Y - diagonalVertical / 2); //Horní vrchol
            points[1] = new PointF(centerPoint.X + diagonalHorizontal / 2, centerPoint.Y); // Pravý vrchol
            points[2] = new PointF(centerPoint.X, centerPoint.Y + diagonalVertical / 2); // Dolní vrchol
            points[3] = new PointF(centerPoint.X - diagonalHorizontal / 2, centerPoint.Y);  // Levý vrchol

            return points;

        }

        //Zjistí na jakou stranu směřuje pojící čára,aby se podle toho mohl postavit/položit kosočtverec
        private int GetEndPointOfRhumbus(Graphics g)
        {
            float angle = GetLineAngle();
            int option = 0;

            //float leftUpperCornerAngle = GetCornerAngle(new PointF(FirstClass.PositionX,FirstClass.PositionY), angle);
            //float rightUpperCornerAngle = GetCornerAngle(new PointF(FirstClass.PositionX+FirstClass.Width,FirstClass.PositionY), angle);
            //float leftLowerCornerAngle = GetCornerAngle(new PointF(FirstClass.PositionX,FirstClass.PositionY+FirstClass.Height), angle);
            //float rightLowerCornerAngle = GetCornerAngle(new PointF(FirstClass.PositionX + FirstClass.Width,FirstClass.PositionY + FirstClass.Height),angle);
            float rightLowerCornerAngle = GetCornerAngle(new PointF(FirstClass.PositionX + FirstClass.Width, FirstClass.PositionY + FirstClass.Height), angle);
            float leftUpperCornerAngle = (180 - rightLowerCornerAngle) * -1;
            float rightUpperCornerAngle = rightLowerCornerAngle * -1;
            float leftLowerCornerAngle = leftUpperCornerAngle * -1;

            //if ((angle > -40 && angle <= 0) || (angle >= 0 && angle < 40))
            //    option = 1;
            //else if (angle >=40 && angle <= 139)
            //    option = 2;
            //else if ((angle > 139 && angle <=180)|| (angle >= -180 && angle < -139))
            //    option = 3;
            //else if (angle >= -139 && angle <= -40)
            //    option = 4;

            if ((angle > rightUpperCornerAngle && angle <= 0) || (angle >= 0 && angle < rightLowerCornerAngle))
                option = 1;
            else if (angle >= rightLowerCornerAngle && angle <= leftLowerCornerAngle)
                option = 2;
            else if ((angle > leftLowerCornerAngle && angle <= 180) || (angle >= -180 && angle < leftUpperCornerAngle))
                option = 3;
            else if (angle >= leftUpperCornerAngle && angle <= rightUpperCornerAngle)
                option = 4;

            g.DrawString(angle.ToString(), new Font("Arial", 16), Brushes.Black, 50, 50);

            return option;
        }

        public float GetCornerAngle(PointF corner, float lineAngle)
        {
            double angelCorner = Math.Atan2(StartPoint.Y - corner.Y,StartPoint.X - corner.X);
            double angelCornerDegrees = angelCorner * (180 / Math.PI);

            float finalAngel = lineAngle - (float)angelCornerDegrees;
            return finalAngel;
        }

        //Pro kompozici
        private PointF[] FillRhombus( Graphics g,Pen pen)
        {
            int options = GetEndPointOfRhumbus(g);
            PointF[] points = GetArrayOfRhombusPoints(options);

            g.FillPolygon(Brushes.Red, points);
            return points;
        }

        private void DrawTriangle(Graphics g,Pen pen)
        {
            g.TranslateTransform(EndPoint.X, EndPoint.Y);
            //g.RotateTransform(GetLineAngle());

            
            PointF[] points = new PointF[]
            {
                new PointF(0, 0),
                new PointF(-20,-10),
                new PointF(-20,10)
            };

            g.RotateTransform(GetLineAngle());
            g.FillPolygon(Brushes.White, points);
            g.DrawPolygon(pen, points);
            g.ResetTransform();


        }

        //Zjistí, pod jakým úhlem se nachází spojovací čára
        private float GetLineAngle()
        {
            float angle = (float)Math.Atan2(EndPoint.Y - StartPoint.Y, EndPoint.X - StartPoint.X);
            float degreeAngle = angle * (float)(180 / Math.PI);

            return degreeAngle;
        }



        //Vypíše multiplicitu a název metody, pod kterou je nastavený odkaz na jinou Classu
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
        }

        private void DrawInformationsForBiAssociation(Graphics g)
        {
            float angle = GetLineAngle();
            byte stringOption = 1;


            if ((angle > -40 && angle <= 0) || (angle >= 0 && angle < 40))
                stringOption = 1;
            else if (angle >= 40 && angle <= 139)
                stringOption = 2;
            else if ((angle > 139 && angle <= 180) || (angle >= -180 && angle < -139))
                stringOption = 3;
            else if (angle >= -139 && angle < -30)
                stringOption = 4;



            string multiplicityInfo = MultiplicityForSecondClass == null ? "" : MultiplicityForSecondClass == MultiplicityType.One ? "1" : "*";
            string propertyInfo = PropertyNameInSecondClass;
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
                    g.DrawString(multiplicityInfo, font, Brushes.Red, StartPoint.X + 10, StartPoint.Y + 20, style1);
                    g.DrawString(propertyInfo, font, Brushes.Red, StartPoint.X + 10, StartPoint.Y - 20 - g.MeasureString(propertyInfo, font).Height, style1);
                    break;
                case 2:
                    g.DrawString(multiplicityInfo, font, Brushes.Red, StartPoint.X + 20, StartPoint.Y + 10, style2);
                    g.DrawString(propertyInfo, font, Brushes.Red, StartPoint.X - 20 - g.MeasureString(propertyInfo, font).Width, StartPoint.Y + 10, style2);
                    break;
                case 3:
                    g.DrawString(multiplicityInfo, font, Brushes.Red, StartPoint.X - 10, StartPoint.Y + 20, style3);
                    g.DrawString(propertyInfo, font, Brushes.Red, StartPoint.X - 10, StartPoint.Y - 20 - g.MeasureString(propertyInfo, font).Height, style3);
                    break;
                case 4:
                    g.DrawString(multiplicityInfo, font, Brushes.Red, StartPoint.X + 20, StartPoint.Y - 10, style4);
                    g.DrawString(propertyInfo, font, Brushes.Red, StartPoint.X - 20 - g.MeasureString(propertyInfo, font).Width, StartPoint.Y - 10, style4);
                    break;
            }
        }

        //metoda pro zjištení, kde se čára ze středu boxu, střetne s hranou boxu
        //takže pak pro vykreslování může jít čára právě z toho místa a ne ze středu
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

        //metoda pro zjištení, kde se čára ze středu boxu, střetne s hranou boxu
        //takže pak pro vykreslování může jít čára právě z toho místa a ne ze středu
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
