using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace EpicBattleSimulator
{
    [Serializable()]
    class Fighter
    {
        Random randy = new Random();

        public Fighter(string name, int maxl, int life, int attack, int zm, int lvl, int round, int exp, int maxexp, bool ven)
        {
            Name = name;
            MaxLeben = maxl;
            Leben = life;
            Attacke = attack;
            Zaubermacht = zm;
            Level = lvl;
            Roundcount = round;
            Experience = exp;
            MaxExperience = maxexp;
            isVenomous = ven;
        }

        public Fighter() { }

        public string Info()
        {
            return $"Leben: {Leben} / {MaxLeben}\n" +
                    $"Angriff: {Attacke}\n" +
                  $"Zaubermacht: {Zaubermacht}\n" +
                  $"Erfahrung: {Experience} / {MaxExperience}\n" +
                  $"Level: {Level}";
        }

        public string EmptyInfo()
        {
            return "";
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

        public void LevelUp()
        {
            int bonusstat = randy.Next(2, 7);
            int bonushp = randy.Next(5, 20);

            MessageBox.Show($"Du bist eine Stufe aufgestiegen:\nNeues Level: {Level + 1}\n" +
                $"Leben + {30 + bonushp}\n" +
                $"Attacke + {6 + bonusstat}\n" +
                $"Zaubermacht + {3 + bonusstat}\n");

            Level += 1;
            MaxExperience += 50;
            Leben += 30 + bonushp;
            MaxLeben += 30 + bonushp;
            Attacke += 6 + bonusstat;
            Zaubermacht += 3 + bonusstat;

            
        }

        public int Gesamtschaden() => Attacke + Bonusschaden;

        public int Gesamtheilung() => Zaubermacht + Bonusheilung;

        public int Experience { get; set; }

        public int MaxExperience { get; set; }

        public int Level { get; set; }

        public int Round { get; set; }

        public int MaxLeben { get; set; }

        public bool Vergiftet { get; set; }

        public bool isVenomous { get; set; }

        public string Name { get; set; }

        public int Leben { get; set; }

        public int Attacke { get; set; }

        public int Zaubermacht { get; set; }

        public int Roundcount { get; set; }

    }
}
