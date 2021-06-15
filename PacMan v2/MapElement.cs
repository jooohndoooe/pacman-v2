using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class MapElement
    {
        public bool LockedUp { get; set; }
        public bool LockedDown { get; set; }
        public bool LockedLeft { get; set; }
        public bool LockedRight { get; set; }
        public char[,] element { get; set; }

        public MapElement(bool LockedUp, bool LockedRight, bool LockedDown, bool LockedLeft)
        {
            this.LockedUp = LockedUp;
            this.LockedRight = LockedRight;
            this.LockedDown = LockedDown;
            this.LockedLeft = LockedLeft;

            this.element = new char[5, 5];
            this.element[0, 0] = '#'; this.element[0, 1] = '#'; this.element[0, 2] = '#'; this.element[0, 3] = '#'; this.element[0, 4] = '#';
            this.element[1, 0] = '#'; this.element[1, 1] = ' '; this.element[1, 2] = ' '; this.element[1, 3] = ' '; this.element[1, 4] = '#';
            this.element[2, 0] = '#'; this.element[2, 1] = ' '; this.element[2, 2] = ' '; this.element[2, 3] = ' '; this.element[2, 4] = '#';
            this.element[3, 0] = '#'; this.element[3, 1] = ' '; this.element[3, 2] = ' '; this.element[3, 3] = ' '; this.element[3, 4] = '#';
            this.element[4, 0] = '#'; this.element[4, 1] = '#'; this.element[4, 2] = '#'; this.element[4, 3] = '#'; this.element[4, 4] = '#';
            Random r = new Random();


            int RandomSwitch = 0;
            List<string> LockedSides = new List<string>();

            if (LockedRight == false)
            {
                SetSpace(false, 4);
            }
            else 
            {
                LockedSides.Add("Right");
            }

            if (LockedDown== false)
            {
                SetSpace(true, 0);
            }
            else
            {
                LockedSides.Add("Down");
            }

            if (LockedLeft == false)
            {
                SetSpace(false, 0);
            }
            else
            {
                LockedSides.Add("Left");
            }

            if (LockedUp == false)
            {
                SetSpace(true, 4);
            }
            else
            {
                LockedSides.Add("Up");
            }



            if (LockedSides.Count != 0)
            {
                string RandomSide = LockedSides[r.Next() % LockedSides.Count];

                if (RandomSide == "Right")
                {
                    this.element[3, 2] = '#';
                    this.element[2, 2] = '#';
                }
                if (RandomSide == "Down")
                {
                    this.element[2, 1] = '#';
                    this.element[2, 2] = '#';
                }
                if (RandomSide == "Left")
                {
                    this.element[1, 2] = '#';
                    this.element[2, 2] = '#';
                }
                if (RandomSide == "Up")
                {
                    this.element[2, 3] = '#';
                    this.element[2, 2] = '#';
                }
            }

            RandomSwitch = r.Next() % 2;
            if (RandomSwitch == 0)
            {
                this.element[2, 2] = '#';
            }
        }

        public void SetSpace(bool side, int value)  
        {
            Random r = new Random();
            int RandomSwitch = r.Next() % 2;
            if (side)
            {
                this.element[2, value] = ' ';
                if (RandomSwitch == 0)
                {
                    this.element[1, value] = ' ';
                    this.element[3, value] = ' ';
                }
            }
            else
            {
                this.element[value, 2] = ' ';
                if (RandomSwitch == 0)
                {
                    this.element[value, 1] = ' ';
                    this.element[value, 3] = ' ';
                }
            }
        }

    }
}
