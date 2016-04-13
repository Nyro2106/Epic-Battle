using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Microsoft.VisualBasic;

namespace EpicBattleSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int roundcount = 1;
        int poisoncount = 3;
        

        Fighter player = new Fighter("",120, 120, 15, 12);
        Fighter ork = new Fighter("Tork der Ork",150, 150, 10, 8);

        private void StartProperties()
        {
            
            if (player.Name == "")
            {
                string name = Interaction.InputBox("Gib hier den Namen deines Helden ein!", "Name", "Heldenname");
                player.Name = name;
            }
            
            lblInfo.Text = $"Du kämpfst gegen {ork.Name}";
            progBarHealth.Maximum = player.MaxLeben;
            progBarEnemy.Maximum = ork.MaxLeben;
            progBarHealth.Value = progBarHealth.Maximum;
            progBarEnemy.Value = progBarEnemy.Maximum;
            player.Leben = player.MaxLeben;
            ork.Leben = ork.MaxLeben;
            lblPlayer.Text = $"{player.Name}";
            lblEnemy.Text = $"{ork.Name}";
            lblStatus.Text = "";
            poisoncount = 3;
        }

        private void EnemyAttacke()
        {
            try
            {
                lblInfo.Text = $"{ork.Name} ist dran!\n";
                lblInfo.Text += $"Er verursacht {EnemyGesamtschaden()} Schaden\n";
                progBarHealth.Value -= EnemyGesamtschaden();
                if (player.Leben > 50 && player.Vergiftet == false)
                {
                    player.Vergiftet = true;
                    lblInfo.Text += $"Du wurdest vergiftet";
                }
                if (progBarHealth.Value == 0)
                {
                    progBarHealth.Value = -1;
                }
                timRound2.Enabled = true;
            }
            catch 
            {
                playerDefeated();
            }
        }

        private void checkVergiftung()
        {
            try
            {
                if (player.Vergiftet)
                {
                    lblInfo.Text += $"Du erleidest {ork.Giftschaden} Giftschaden!\n";
                    player.Leben -= ork.Giftschaden;
                    progBarHealth.Value -= ork.Giftschaden;
                    if (progBarHealth.Value == 0)
                    {
                        progBarHealth.Value -= 1;
                    }
                    poisoncount -= 1;
                    toolStripStatusLbLBottom.Text = $"Status: Vergiftet!";
                    toolStripStatusLeisteBottom.Value = poisoncount;
                    
                }
                if (poisoncount == 0)
                {
                    player.Vergiftet = false;
                    poisoncount = 3;
                    toolStripStatusLbLBottom.Text = $"Status: Normal";
                    lblInfo.Text += "Du bist nichtmehr vergiftet!\n";
                }
            }
            catch
            {
                disableTimers();
                playerDefeated();
            }

        }

        private void playerDefeated()
        {
            progBarHealth.Value = progBarHealth.Minimum;
            DisableButtons();
            lblInfo.Text += "Du wurdest besiegt!";
            return;
        }

        private void disableTimers()
        {
            timRound.Enabled = false;
            timRound2.Enabled = false;
        }

        private int EnemyGesamtschaden()
        {
            return ork.Attacke + ork.Bonusschaden;
        }

        private int PlayerGesamtschaden()
        {
            return player.Attacke + player.Bonusschaden;
        }

        private int PlayerGesamtheilung()
        {
            return player.Zaubermacht + player.Bonusheilung;
        }

        private void DisableButtons()
        {
            contextMenuStripZauberbuch.Enabled = false;
            picSpellbook.Enabled = false;
            picSwordAttack.Enabled = false;
        }

        private void EnableButtons()
        {
            contextMenuStripZauberbuch.Enabled = true;
            picSpellbook.Enabled = true;
            picSwordAttack.Enabled = true;
        }

        private void timRound_Tick(object sender, EventArgs e)
        {
            EnemyAttacke();
            timRound.Enabled = false;
        }

        private void timRound2_Tick(object sender, EventArgs e)
        {
            lblInfo.Text = ""; 
            roundcount += 1;
            lblInfo.Text += $"Du bist dran! \nEs ist Runde: {roundcount}\n";
            timRound2.Enabled = false;
            EnableButtons();
            checkVergiftung();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void spielLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("savegame.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string zeile;


            while (sr.Peek() != -1)
            {
                zeile = sr.ReadLine();
                player.Name = $"{zeile}";
            }
            sr.Close();
            StartProperties();

            MessageBox.Show($"Spielstand {player.Name} erfolgreich geladen!");
        }

        private void neuesSpielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Name = "";
            EnableButtons();
            StartProperties();
        }

        private void heilungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblInfo.Text = $"Du heilst dich um {PlayerGesamtheilung()} Leben!";
            try
            {
                progBarHealth.Value += PlayerGesamtheilung();
            }
            catch
            {
                progBarHealth.Value = progBarHealth.Maximum;
            }
            DisableButtons();
            timRound.Enabled = true;
        }

        private void picSwordAttack_Click(object sender, EventArgs e)
        {
            lblInfo.Text = $"Du verusachst {PlayerGesamtschaden()} Schaden!";
            DisableButtons();
            try
            {
                progBarEnemy.Value -= PlayerGesamtschaden();
                if (progBarEnemy.Value == 0)
                {
                    progBarEnemy.Value -= 1;
                }
                timRound.Enabled = true;
            }
            catch
            {
                disableTimers();
                progBarEnemy.Value = progBarEnemy.Minimum;
                DisableButtons();
                lblStatus.Text = "Du hast gewonnen!";
                lblInfo.Text = $"{ork.Name} wurde besiegt!";
            }
        }
    }
}
