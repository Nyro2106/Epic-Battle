﻿using System;
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
using System.Data.OleDb;

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
        bool defeated = false;
        Random rand = new Random();


        Fighter player = new Fighter("", 180, 180, 20, 10, 1, 1, 0, 80, false);
        Fighter enemy = new Fighter();


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
            GenerateEnemy();
            EnableButtons();
            player.Vergiftet = false;
            checkVergiftung();
            lblPlayerInfo.Text = $"{player.Info()}";
            lblEnemyInfo.Text = $"{enemy.Info()}";
            lblInfo.Text = $"Du kämpfst gegen {enemy.Name}";
            progBarHealth.Maximum = player.MaxLeben;
            progBarEnemy.Maximum = enemy.MaxLeben;
            progBarHealth.Value = player.MaxLeben;
            progBarEnemy.Value = enemy.MaxLeben;
            player.Leben = player.MaxLeben;
            enemy.Leben = enemy.MaxLeben;
            lblPlayer.Text = $"{player.Name}";
            lblEnemy.Text = $"{enemy.Name}";
            poisoncount = 3;
        }

        private void LoadProperties()
        {
            EnableButtons();
            player.Vergiftet = player.Vergiftet;
            lblPlayerInfo.Text = $"{player.Info()}";
            lblEnemyInfo.Text = $"{enemy.Info()}";
            progBarHealth.Maximum = player.MaxLeben;
            progBarEnemy.Maximum = enemy.MaxLeben;
            progBarHealth.Value = player.Leben;
            progBarEnemy.Value = enemy.Leben;
            player.Leben = player.Leben;
            enemy.Leben = enemy.Leben;
            lblPlayer.Text = $"{player.Name}";
            lblEnemy.Text = $"{enemy.Name}";
            poisoncount = 3;
        }

        private void EnemyAttacke()
        {
            int currentdmg = enemy.Gesamtschaden();

            try
            {
                lblInfo.Text = $"{enemy.Name} ist dran!\n";
                lblInfo.Text += $"und verursacht {currentdmg} Schaden\n";
                progBarHealth.Value -= currentdmg;
                player.Leben -= currentdmg;
                if (player.Leben > 50 && player.Vergiftet == false && enemy.isVenomous)
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
                playAgain();
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
                    if (progBarHealth.Value == 0)
                    {
                        progBarHealth.Value -= 1;
                    }
                    poisoncount -= 1;
                    toolStripStatusLbLBottom.Text = $"Status: Vergiftet!";
                    toolStripStatusLeisteBottom.Value = poisoncount;

                }
                if (poisoncount == 0 || player.Vergiftet == false)
                {
                    player.Vergiftet = false;
                    poisoncount = 3;
                    toolStripStatusLbLBottom.Text = $"Status: Normal";
                    toolStripStatusLeisteBottom.Value = 0;
                }
            }
            catch
            {
                disableTimers();
                playerDefeated();
                playAgain();
            }

        }

        private void playerDefeated()
        {
            progBarHealth.Value = progBarHealth.Minimum;
            DisableButtons();
            lblInfo.Text += "Du wurdest besiegt!";
            timRound.Enabled = false;
            timRound2.Enabled = false;
            defeated = true;
            getEXP();
            return;
        }

        private void playAgain()
        {
            DialogResult dr = MessageBox.Show("Weiterkämpfen?", "Determination", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                StartProperties();
            }
            else
            {
                return;
            }
        }

        private void disableTimers()
        {
            timRound.Enabled = false;
            timRound2.Enabled = false;
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

        private void timUpdateStats_Tick(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void spielLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Soll das Spiel geladen werden?", "Spiel laden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Deserialize();
                DeserializeEnemy();
                LoadProperties();
            }
            else
            {
                return;
            }
        }

        private void spielSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Soll der Spielstand gespeichert werden?", "Spiel Speichern?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Serialize();
                SerializeEnemy();
            }
            else
            {
                return;
            }
        }

        private void neuesSpielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Name = "";
            EnableButtons();
            StartProperties();
        }


        private void heilungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentheal = player.Gesamtheilung();

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
            timRound.Enabled = true;
        }

        private void picSwordAttack_Click(object sender, EventArgs e)
        {
            int currentdmg = player.Gesamtschaden();

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
                timRound.Enabled = true;
            }
            catch
            {
                disableTimers();
                progBarEnemy.Value = progBarEnemy.Minimum;
                DisableButtons();
                lblInfo.Text = $"{enemy.Name} wurde besiegt!";
                playAgain();
                getEXP();
            }
        }

        private void getEXP()
        {
            int good_exp = enemy.MaxLeben / 100 * 120;
            int bad_exp = enemy.MaxLeben / 100 * 20;
            
            if (defeated)
            {
                player.Experience += bad_exp;
                defeated = false;
            }
            else
            {
                player.Experience += good_exp;
            }
            
            if (player.Experience >= player.MaxExperience)
            {
                player.Experience = player.Experience - player.MaxExperience;
                player.LevelUp();
            }
        }

        public void Serialize()
        {
            Fighter saveplayer = new Fighter();
            saveplayer = player;
            FileStream fs = new FileStream("PlayerFile.dat", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, saveplayer);
                MessageBox.Show($"Spielstand '{player.Name}' erfolgreich gespeichert!");
            }
            catch (SerializationException e)
            {
                MessageBox.Show($"Spielstand konnte nicht gespeichert werden!");
                return;
            }
            finally
            {
                fs.Close();
            }
        }

        public void SerializeEnemy()
        {
            Fighter saveenemy = new Fighter();
            saveenemy = enemy;
            FileStream fs = new FileStream("EnemyFile.dat", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, saveenemy);
            }
            catch (SerializationException e)
            {
                return;
            }
            finally
            {
                fs.Close();
            }
        }

        public void Deserialize()
        {

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = new FileStream("PlayerFile.dat", FileMode.Open);
                player = (Fighter)formatter.Deserialize(fs);
                MessageBox.Show($"Spielstand '{player.Name}' erfolgreich geladen");
                fs.Close();
            }
            catch
            {
                MessageBox.Show($"Spielstand konnte nicht geladen werden!");
                return;
            }
        }

        public void DeserializeEnemy()
        {

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = new FileStream("EnemyFile.dat", FileMode.Open);
                enemy = (Fighter)formatter.Deserialize(fs);
                fs.Close();
            }
            catch
            {
                return;
            }
        }

        private void GenerateEnemy()
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader reader;

            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=D:/Databases/Enemies.accdb";

            cmd.Connection = con;
            cmd.CommandText = $"SELECT * FROM enemies WHERE id = {rand.Next(1,6)}";
            //cmd.CommandText = $"SELECT * FROM enemies WHERE level = {player.Level}";

            try
            {
                con.Open();

                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    
                    enemy.Name = $"{reader["fullname"]}";
                    enemy.Leben = (int)reader["leben"];
                    enemy.MaxLeben = (int)reader["maxleben"];
                    enemy.Attacke = (int)reader["attacke"];
                    enemy.Zaubermacht = (int)reader["zaubermacht"];
                    enemy.Level = (int)reader["level"];
                    enemy.isVenomous = Convert.ToBoolean(reader["venomous"]);

                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }


    }
}
