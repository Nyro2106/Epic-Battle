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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace EpicBattleSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisableButtons();
        }

        int roundcount = 1;
        int poisoncount = 3;


        Fighter player = new Fighter("", 100, 100, 10, 10, 1);
        Fighter enemy = new Fighter("Tork der Ork", 100, 100, 10, 10, 1);


        private void UpdateInfo()
        {
            lblPlayerInfo.Text = $"{player.Info()}";
            lblEnemyInfo.Text = $"{enemy.Info()}";
        }

        private void StartProperties()
        {
            if (player.Name == "")
            {
                string name = Interaction.InputBox("Gib hier den Namen deines Helden ein!", "Name", "Heldenname");
                player.Name = name;
            }
            EnableButtons();
            lblPlayerInfo.Text = $"{player.Info()}";
            lblEnemyInfo.Text = $"{enemy.Info()}";
            lblInfo.Text = $"Du kämpfst gegen {enemy.Name}";
            progBarHealth.Maximum = player.MaxLeben;
            progBarEnemy.Maximum = enemy.MaxLeben;
            progBarHealth.Value = progBarHealth.Maximum;
            progBarEnemy.Value = progBarEnemy.Maximum;
            player.Leben = player.MaxLeben;
            enemy.Leben = enemy.MaxLeben;
            lblPlayer.Text = $"{player.Name}";
            lblEnemy.Text = $"{enemy.Name}";
            poisoncount = 3;
        }

        private void EnemyAttacke()
        {
            int currentdmg = EnemyGesamtschaden();

            try
            {
                lblInfo.Text = $"{enemy.Name} ist dran!\n";
                lblInfo.Text += $"Er verursacht {currentdmg} Schaden\n";
                progBarHealth.Value -= currentdmg;
                player.Leben -= currentdmg;
                if (player.Leben > 50 && player.Vergiftet == false)
                {
                    player.Vergiftet = true;
                    lblInfo.Text += $"Du wurdest vergiftet";
                }
                if (progBarHealth.Value == 0)
                {
                    progBarHealth.Value = -1;
                }
                UpdateInfo();
                timRound2.Enabled = true;
            }
            catch 
            {
                playerDefeated();
            }
        }

        private void checkVergiftung()
        {
            int currentpoison = enemy.Giftschaden;

            try
            {
                if (player.Vergiftet)
                {
                    lblInfo.Text += $"Du erleidest {currentpoison} Giftschaden!\n";
                    player.Leben -= currentpoison;
                    progBarHealth.Value -= currentpoison;
                    UpdateInfo();
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
            return enemy.Attacke + enemy.Bonusschaden;
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
            Deserialize();
            StartProperties();
        }

        private void spielSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Serialize();
        }

        private void neuesSpielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Name = "";
            EnableButtons();
            StartProperties();
        }
     

        private void heilungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentheal = PlayerGesamtheilung();

            lblInfo.Text = $"Du heilst dich um {currentheal} Leben!";
            try
            {
                progBarHealth.Value += currentheal;
                player.Leben += currentheal;
            }
            catch
            {
                progBarHealth.Value = progBarHealth.Maximum;
                player.Leben = player.MaxLeben;
            }
            DisableButtons();
            UpdateInfo();
            timRound.Enabled = true;
        }

        private void picSwordAttack_Click(object sender, EventArgs e)
        {
            int currentdmg = PlayerGesamtschaden();

            lblInfo.Text = $"Du verusachst {currentdmg} Schaden!";
            enemy.Leben -= currentdmg;
            DisableButtons();
            try
            {
                progBarEnemy.Value -= currentdmg;
                if (progBarEnemy.Value == 0)
                {
                    progBarEnemy.Value -= 1;
                }
                UpdateInfo();
                timRound.Enabled = true;
            }
            catch
            {
                disableTimers();
                progBarEnemy.Value = progBarEnemy.Minimum;
                DisableButtons();
                lblInfo.Text = $"{enemy.Name} wurde besiegt!";
            }
        }


        public void Serialize()
        {
            Fighter saveplayer = new Fighter();
            saveplayer = player;
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, saveplayer);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                MessageBox.Show($"Spielstand {player.Name} erfolgreich gespeichert!");
                fs.Close();
            }
        }

        public void Deserialize()
        {
            

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // assign the reference to the local variable.
                player = (Fighter)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                MessageBox.Show($"Spielstand {player.Name} erfolgreich geladen");
                fs.Close();
            }
        }




    }
}
