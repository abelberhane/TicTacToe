using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //Creating a new instance of player
        Player currentPlayer;

        public Form1()
        {
            InitializeComponent();
        }

        //Player holds the x or o values
        public enum Player
        {
            x,
            O
        }

        //Logic for the button. 
        //Set the player to X. 
        //Parse the X text. 
        //Disable the button and make the background green. 
        //Check for win. 
        //Start the AI Timers turn. 
        private void buttonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.x;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.LightGreen;
            Check();
            AITimer.Start();
        }

        //Disable the X button
        //Change the player to Robot Mode, O
        //Parse the O
        //Change the color of the background and stop the AI Timer
        //Check to see if theres a winner
        //Break the loop
        //Else stop the timer
        private void playAI(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is Button && x.Text == "?" && x.Enabled)
                {
                    x.Enabled = false;
                    currentPlayer = Player.O;
                    x.Text = currentPlayer.ToString();
                    x.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    AITimer.Stop();
                    Check();
                    break;
                }
                else
                {
                    AITimer.Stop();
                }
            }
        }

        //Reset the game to how it was in the beginning.
        private void resetGame(object sender, EventArgs e)
        {
            label1.Text = "Who Will Win?";

            foreach (Control x in this.Controls)
            {
                if (x is Button && x.Tag == "play")
                {
                    ((Button)x).Enabled = true;
                    ((Button)x).Text = "?";
                    ((Button)x).BackColor = default(Color);
                }
            }
        }

        //This is where we check to see if there is 3 in a row on either side. If there is, that players victory message is populated.
        private void Check()
        {
           if (
           button1.Text == "X" && button2.Text == "X" && button3.Text == "X" ||
           button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
           button7.Text == "X" && button8.Text == "X" && button9.Text == "X" ||
           button1.Text == "X" && button4.Text == "X" && button7.Text == "X" ||
           button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
           button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
           button1.Text == "X" && button5.Text == "X" && button9.Text == "X" ||
           button3.Text == "X" && button5.Text == "X" && button7.Text == "X" 
           )
            {
                WON();
                label1.Text = "You Win X!";
            }
           else if (
           button1.Text == "O" && button2.Text == "O" && button3.Text == "O" ||
           button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
           button7.Text == "O" && button8.Text == "O" && button9.Text == "O" ||
           button1.Text == "O" && button4.Text == "O" && button7.Text == "O" ||
           button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
           button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
           button1.Text == "O" && button5.Text == "O" && button9.Text == "O" ||
           button3.Text == "O" && button5.Text == "O" && button7.Text == "X"
            )
            {
                WON();
                label1.Text = "You Win O!";
            }
        }

        //Logic for winning the game. 
        private void WON()
        {
            foreach (Control x in this.Controls)
            {
                if (x is Button && x.Tag == "play")
                {
                    ((Button)x).Enabled = false;
                    ((Button)x).BackColor = default(Color);
                }
            }
        }
    }
}
