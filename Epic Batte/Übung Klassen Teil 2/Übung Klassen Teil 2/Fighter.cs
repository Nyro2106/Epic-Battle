﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EpicBattleSimulator
{
    [Serializable()]
    class Fighter
    {
        private string name;
        private int leben;
        private int maxleben;
        private int attacke;
        private int zaubermacht;
        private int level;
        private bool poisoned = false;
        private bool venomous = false;
        private int roundcount;
        private int experience;
        private int maxexperience;
        Random randy = new Random();

        public Fighter(string nam, int maxl, int life, int attack, int zm, int lvl, int round, int exp, int maxexp, bool ven)
        {
            name = nam;
            maxleben = maxl;
            leben = life;
            attacke = attack;
            zaubermacht = zm;
            level = lvl;
            roundcount = round;
            experience = exp;
            maxexperience = maxexp;
            venomous = ven;
        }

        public Fighter()
        {

        }

        public string Info()
        {
            return $"Leben: {this.leben} / {this.maxleben}\n" +
                    $"Angriff: {this.Attacke}\n" +
                  $"Zaubermacht: {this.Zaubermacht}\n" +
                  $"Erfahrung: {this.experience} / {this.maxexperience}\n" +
                  $"Level: {this.Level}";
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

        public int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
            }
        }

        public int MaxExperience
        {
            get
            {
                return maxexperience;
            }
            set
            {
                maxexperience = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        public int Round
        {
            get
            {
                return roundcount;
            }
            set
            {
                roundcount = value;
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

        public bool isVenomous
        {
            get
            {
                return venomous;
            }
            set
            {
                venomous = value;
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
