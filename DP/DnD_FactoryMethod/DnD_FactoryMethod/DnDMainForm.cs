using DnD_FactoryMethod.Characters;
using DnD_FactoryMethod.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_FactoryMethod {
    public partial class DnDMainForm : Form {
        Character currentCharacter;
        EntityFactory characterFactory;

        public DnDMainForm() {
            InitializeComponent();

            setComboBoxes();

            characterFactory = new CharacterFactory();
        }

        public void setComboBoxes() {
            raceComboBox.Items.Add("Human");
            raceComboBox.Items.Add("Elf");
            raceComboBox.Items.Add("Orc");
            raceComboBox.Items.Add("Dwarf");

            classComboBox.Items.Add("Fighter");
            classComboBox.Items.Add("Rogue");
            classComboBox.Items.Add("Warlock");
            classComboBox.Items.Add("Wizard");
        }

        private void button1_Click(object sender, EventArgs e) {
            if (raceComboBox.SelectedItem == null || classComboBox.SelectedItem == null || CharacterNameTextBox.Text == "")
                return;

            currentCharacter = characterFactory.createCharacter(CharacterNameTextBox.Text, raceComboBox.SelectedItem.ToString(), classComboBox.SelectedItem.ToString());

            characterStatsPictureBox.Invalidate();
            characterPictureBox.Invalidate();
        }

        private void characterPictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                if (currentCharacter == null)
                    return;

                e.Graphics.DrawImage(currentCharacter.charRace.image, 0, 0, 200, 400);
                e.Graphics.DrawImage(currentCharacter.charClass.image, 0, 0, 60, 400);
            }
        }

        private void CharacterLevelNumeric_ValueChanged(object sender, EventArgs e) {
            characterStatsPictureBox.Invalidate();
        }

        private void characterStatsPictureBox_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            {
                if (currentCharacter == null)
                    return;

                string text = "";
                text += "Name: " + currentCharacter.charName + "\n";
                text += "Race: " + currentCharacter.charRace + "\n";
                text += "Class: " + currentCharacter.charClass + "\n";
                text += "Hit Points: " + Stats.getHitPoints(currentCharacter.charClass.hitdie, (int)CharacterLevelNumeric.Value, Stats.getMod(currentCharacter.charStats.constitution)) + "\n";
                text += "Stats:\n" + currentCharacter.charStats;

                e.Graphics.DrawString(text, new Font("Bookman Old Style", 8), new SolidBrush(Color.Black), new PointF(0, 0));
            }
        }
    }
}
