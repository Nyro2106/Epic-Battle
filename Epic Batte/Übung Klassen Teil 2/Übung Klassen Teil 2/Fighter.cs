using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicBattleSimulator
{
    class Fighter
    {
        private string name;
        private int leben;
        private int maxleben;
        private int attacke;
        private int zaubermacht;
        private bool poisoned = false;
        Random randy = new Random();

        public Fighter(string nam, int maxl, int life, int attack, int zm)
        {
            name = nam;
            maxleben = maxl;
            leben = life;
            attacke = attack;
            zaubermacht = zm;
        }

        public int Bonusschaden
        {
            get
            {
                return randy.Next(1, 10);
            }
            set
            {
                randy.Next(value, value);
            }
        }

        public int MaxLeben
        {
            get
            {
                return maxleben;
            }
            set
            {
                maxleben = value;
            }
        }

        public int Giftschaden
        {
            get
            {
                return randy.Next(5, 8);
            }
            set
            {
                randy.Next(value, value);
            }
        }

        public bool Vergiftet
        {
            get
            {
                return poisoned;
            }
            set
            {
                poisoned = value;
            }
        }

        public int Bonusheilung
        {
            get
            {
                return randy.Next(1, 10);
            }
            set
            {
                randy.Next(value, value);
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Leben
        {
            get
            {
                return leben;
            }
            
            set
            {
                leben = value;
            }
        }

        public int Attacke
        {
            get
            {
                return attacke;
            }

            set
            {
                attacke = value;
            }
        }

        public int Zaubermacht
        {
            get
            {
                return zaubermacht;
            }

            set
            {
                zaubermacht = value;
            }
        }

    }
}
