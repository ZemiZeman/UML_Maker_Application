﻿using System.Text.Json.Serialization;
using UML_Maker_App;
using UML_Maker_App.Selections;

namespace DragAndDrop
{
    public class Canvas
    {
        [JsonPropertyName("Boxes")]
        public List<Box> _boxes;
        [JsonIgnore]
        private Selection? _selection;
        [JsonPropertyName("Relations")]
        
        public List<Relation> _relations;

        public Canvas()
        {
            _boxes = new List<Box>();
            _selection = null;
            _relations = new List<Relation>();

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
            List<Relation> relationsToDelete = new List<Relation>();
            foreach (Relation relation in _relations)
            {
                if(relation.FirstClass == box)
                    relationsToDelete.Add(relation);

                if(relation.SecondClass == box)
					relationsToDelete.Add(relation);
			}

            foreach (Relation relation in relationsToDelete)
            {
                _relations.Remove(relation);
            }
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

        public void AddRelation(Relation relation)
        {
            _relations.Add(relation);
        }
    }
}
