using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Table
    {
        public int height { get; set; }
        public int width { get; set; }
        public bool[,] LockedUp { get; set; }
        public bool[,] LockedRight { get; set; }
        public bool[,] LockedLeft { get; set; }
        public bool[,] LockedDown { get; set; }

        public Table(int height, int width)
        {
            height = 3;
            width = 5;
            this.height = height;
            this.width = width;
            
            LockedUp = new bool[height, width];
            LockedRight = new bool[height, width];
            LockedDown = new bool[height, width];
            LockedLeft = new bool[height, width];
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    LockedUp[i, j] = true;
                    LockedRight[i, j] = true;
                    LockedDown[i, j] = true;
                    LockedLeft[i, j] = true;
                }
            }

            Random r = new Random();

            while (!isValid())
            {
                int y = r.Next() % height;
                int x = r.Next() % width;
                
                List<string> LockedSides = new List<string>();

                if (LockedUp[y, x] && y > 0)
                {
                    LockedSides.Add("Up");
                }

                if (LockedRight[y, x] && x < width - 1)
                {
                    LockedSides.Add("Right");
                }

                if (LockedDown[y, x] && y < height - 1)
                {
                    LockedSides.Add("Down");
                }

                if (LockedLeft[y, x] && x > 0)
                {
                    LockedSides.Add("Left");
                }
                if (LockedSides.Count() == 0) { continue; }

                string RandomDirection = LockedSides[r.Next(LockedSides.Count())];

                if (RandomDirection == "Up") { LockedUp[y, x] = false; LockedDown[y - 1, x] = false; }
                if (RandomDirection == "Right") { LockedRight[y, x] = false; LockedLeft[y, x + 1] = false; }
                if (RandomDirection == "Down") { LockedDown[y, x] = false; LockedUp[y + 1, x] = false; }
                if (RandomDirection == "Left") { LockedLeft[y, x] = false; LockedRight[y, x - 1] = false; }
            }

            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (LockedRight[i, j] == false && LockedDown[i, j] == false && LockedUp[i + 1, j + 1] == false && LockedLeft[i + 1, j + 1] == false)
                    {
                        int t = r.Next() % 4;
                        if (t == 0) { LockedLeft[i, j + 1] = true; LockedRight[i, j]=true; }
                        if (t == 1) { LockedDown[i, j] = true; LockedUp[i + 1, j] = true; }
                        if (t == 2) { LockedLeft[i + 1, j + 1] = true; LockedRight[i + 1, j] = true; }
                        if (t == 3) { LockedDown[i, j + 1] = true; LockedUp[i + 1, j + 1] = true; }
                    }
                }
            }

        }

        public bool isValid()
        {
            bool[,] AbleToPass = new bool[height, width];
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    AbleToPass[i, j] = false;
                }
            }
            AbleToPass[0, 0] = true;
            AbleToPass=isValidRec(AbleToPass, 0, 0);
            
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (AbleToPass[i, j] == false) { return false; }
                }
            }

            return true;
        }

        public bool[,] isValidRec(bool[,] AbleToPass, int x, int y) 
        {
            
            if (!LockedLeft[x, y] && y > 0) { 
                if (!AbleToPass[x, y - 1]) { 
                    AbleToPass[x, y - 1] = true; 
                    AbleToPass = isValidRec(AbleToPass, x, y - 1); 
                } 
            }
            if (!LockedRight[x, y] && y < width - 1) { 
                if (!AbleToPass[x, y + 1]) { 
                    AbleToPass[x, y + 1] = true; 
                    AbleToPass = isValidRec(AbleToPass, x, y + 1); 
                } 
            }
            if (!LockedUp[x, y] && x > 0) { 
                if (!AbleToPass[x - 1, y]) { 
                    AbleToPass[x - 1, y] = true; 
                    AbleToPass = isValidRec(AbleToPass, x - 1, y); 
                }
            }
            if (!LockedDown[x, y] && x < height - 1) { 
                if (!AbleToPass[x + 1, y]) { 
                    AbleToPass[x + 1, y] = true; 
                    AbleToPass = isValidRec(AbleToPass, x + 1, y); 
                } 
            }
            
            return AbleToPass;
        }
    }
}
