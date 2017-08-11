using System;
using System.Drawing;
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
            button.BackColor = System.Drawing.Color.SaddleBrown;
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
                if (x is Button && (string)x.Tag == "play")
                {
                    ((Button)x).Enabled = true;
                    ((Button)x).Text = "?";
                    ((Button)x).BackColor = default(Color);
                }
            }
        }
        // More elegant check func, we can also delete all "Check()" and replace with "Mark"
        private void Mark(string mark)
        {
            if (
             button1.Text == mark && button2.Text == mark && button3.Text == mark ||
             button4.Text == mark && button5.Text == mark && button6.Text == mark ||
             button7.Text == mark && button8.Text == mark && button9.Text == mark ||
             button1.Text == mark && button4.Text == mark && button7.Text == mark ||
             button2.Text == mark && button5.Text == mark && button8.Text == mark ||
             button3.Text == mark && button6.Text == mark && button9.Text == mark ||
             button1.Text == mark && button5.Text == mark && button9.Text == mark ||
             button3.Text == mark && button5.Text == mark && button7.Text == mark
             )
            {
                WON();
                label1.Text = (mark == "x") ? "You won!" : "You lose!";
            }
        }

        //This is where we check to see if there is 3 in a row on either side. If there is, that players victory message is populated.
        private void Check()
        {
            Mark("x");
            Mark("O");

        }

        //Logic for winning the game. 
        private void WON()
        {
            foreach (Control x in this.Controls)
            {
                if (x is Button && (string)x.Tag == "play")
                {
                    ((Button)x).Enabled = false;
                    ((Button)x).BackColor = default(Color);
                }
            }
        }
    }
}
