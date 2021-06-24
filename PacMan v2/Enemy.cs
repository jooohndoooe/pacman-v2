using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public abstract class Enemy:Entity
    {
        public char role { get; set; }
        public int slowness { get; set; }
        public int slownessCounter { get; set; }
        public Enemy(int x, int y, char ch, char direction, int level, char role) : base(x, y, ch, direction, level) {
            SetBase(role);
        }
        public Enemy(int x, int y, char ch, char direction, char role) : base(x, y, ch, direction) {
            SetBase(role);
        }
        public Enemy(int x, int y, char ch, int lvl, char role) : base(x, y, ch, lvl) {
            SetBase(role);
        }
        public Enemy(int x, int y, char ch, char role) : base(x, y, ch) {
            SetBase(role);
        }

        public void SetBase(char role) 
        {
            this.role = role;
            this.slowness = 1;
            this.slownessCounter = 0;
            if (role == 'p') { this.slowness = 2; }
            if (role == 'i') { this.slowness = 3; }
            if (role == 'f') { this.slowness = 2; }
        }

        public void AssignRole(char _ch) 
        {
            this.role = _ch;
        }

        public abstract void Go(Level L, DotField D, UpgradeField U, Player P1, Player P2);

        public void GravityGo(Level L, DotField D, UpgradeField U, Player P1, Player P2, GravityField G)
        {
            GravityMove(L, D, U, G);
            Go(L, D, U, P1, P2);
        }

        

        public int PredictedX(Level L, Player P) 
        {
            if (P.direction == 'd' || P.direction == 'u') { 
                return P.x; }
            int PredictedXCounter = P.x;
            while (PredictedXCounter < L.sizeX && PredictedXCounter >= 0 && L.field[PredictedXCounter, P.y].lvl == 0) { if (P.direction == 'l') { PredictedXCounter--; } if (P.direction == 'r') { PredictedXCounter++; } }
            if (P.direction == 'l') { PredictedXCounter++; }
            if (P.direction == 'r') { PredictedXCounter--; }
            return PredictedXCounter;
        }

        public int PredictedY(Level L, Player P)
        {
            if (P.direction == 'r' || P.direction == 'l') { return P.y; }
            int PredictedYCounter = P.y;
            while (PredictedYCounter < L.sizeY && PredictedYCounter >= 0 && L.field[P.x, PredictedYCounter].lvl == 0) { if (P.direction == 'u') { PredictedYCounter--; } if (P.direction == 'd') { PredictedYCounter++; } }
            if (P.direction == 'u') { PredictedYCounter++; }
            if (P.direction == 'd') { PredictedYCounter--; }
            return PredictedYCounter;
           
        }

        public bool IsInSight(Level L, Player P) {
            if (this.x != P.x && this.y != P.y) { return false; }

            if (this.x == P.x) {
                int min = P.y;
                int max = this.y;
                if (max < min) { int temp = min; min = max; max = temp; }
                for (int i = min; i < max; i++) { if (L.field[P.x, i].lvl > this.lvl) { return false; } }
            }

            if (this.y == P.y)
            {
                int min = P.x;
                int max = this.x;
                if (max < min) { int temp = min; min = max; max = temp; }
                for (int i = min; i < max; i++) { if (L.field[i, P.y].lvl > this.lvl) { return false; } }
            }

            return true;
        }
    }
}
