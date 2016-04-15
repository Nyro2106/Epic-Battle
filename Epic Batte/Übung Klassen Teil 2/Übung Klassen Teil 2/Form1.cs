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

        int roundcount = 1;
        int poisoncount = 3;


        Fighter player = new Fighter("Tim", 120, 100, 10, 10);
        Fighter enemy = new Fighter("Tork der Ork",150, 150, 10, 8);

        private void cmdSerialize_Click(object sender, EventArgs e)
        {
            Serialize();
            lblAusgabe.Text = $"Gespeichert!";
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deserialize();
            lblAusgabe.Text = $"Geladen!";
        }


        private void StartProperties()
        {
            Deserialize();
            if (player.Name == null)
            {
                string name = Interaction.InputBox("Gib hier den Namen deines Helden ein!", "Name", "Heldenname");
                
                player.Name = name;
            }
            
            lblInfo.Text = $"Du kämpfst gegen {enemy.Name}";
            progBarHealth.Maximum = player.MaxLeben;
            progBarEnemy.Maximum = enemy.MaxLeben;
            progBarHealth.Value = progBarHealth.Maximum;
            progBarEnemy.Value = progBarEnemy.Maximum;
            player.Leben = player.MaxLeben;
            enemy.Leben = enemy.MaxLeben;
            lblPlayer.Text = $"{player.Name}";
            lblEnemy.Text = $"{enemy.Name}";
            lblStatus.Text = "";
            poisoncount = 3;
        }

        private void EnemyAttacke()
        {
            try
            {
                lblInfo.Text = $"{enemy.Name} ist dran!\n";
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
                    lblInfo.Text += $"Du erleidest {enemy.Giftschaden} Giftschaden!\n";
                    player.Leben -= enemy.Giftschaden;
                    progBarHealth.Value -= enemy.Giftschaden;
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
            //player.Name = "";
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
                lblInfo.Text = $"{enemy.Name} wurde besiegt!";
            }
        }


        public void Serialize()
        {
            // Create a hashtable of values that will eventually be serialized.
            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, player);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public void Deserialize()
        {
            // Declare the hashtable reference.
            Fighter player = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
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
                fs.Close();
            }

            // To prove that the table deserialized correctly, 
            // display the key/value pairs.

        }

    }
}
