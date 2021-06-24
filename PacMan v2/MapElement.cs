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
            List<int> LockedSides = new List<int>();

            if (LockedRight == false)
            {
                SetSpace(false, 4);
            }
            else 
            {
                LockedSides.Add(2);
            }

            if (LockedDown== false)
            {
                SetSpace(true, 0);
            }
            else
            {
                LockedSides.Add(3);
            }

            if (LockedLeft == false)
            {
                SetSpace(false, 0);
            }
            else
            {
                LockedSides.Add(4);
            }

            if (LockedUp == false)
            {
                SetSpace(true, 4);
            }
            else
            {
                LockedSides.Add(1);
            }



            if (LockedSides.Count != 0)
            {
                int RandomSide = LockedSides[r.Next() % LockedSides.Count];
                int[] technicalLoopArray = { 2, 3, 2, 1, 2 };

                this.element[technicalLoopArray[RandomSide - 1], technicalLoopArray[RandomSide]] = '#';

                this.element[2, 2] = '#';

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
            int a1 = 1, a2 = 2, a3 = 3, b1 = value, b2 = value, b3 = value;
            int RandomSwitch = r.Next() % 3;
            if (!side)
            {
                int temp = a1;
                a1 = b1;
                b1 = temp;
                temp = a2;
                a2 = b2;
                b2 = temp;
                temp = a3;
                a3 = b3;
                b3 = temp;
            }

            this.element[a2, b2] = ' ';
            if (RandomSwitch > 0)
            {
                this.element[a1, b1] = ' ';
            }
            if (RandomSwitch < 2) 
            {
                this.element[a3, b3] = ' ';
            }
        }

    }
}
