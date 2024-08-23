using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO_game_with_AI
{
    public partial class Form1 : Form
    {
        public enum Player 
        {
            X,O
        }

        Player currentPlayer;
        Random random = new Random();
        int PlayerWinCount = 0;
        int AIWinCount = 0;
        List<Button> buttons;



        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer=Player.X;
            button.Text=currentPlayer.ToString();   
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            buttons.Remove(button);
            CheckGame();
            AITimer.Start();



        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
        {

            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                AITimer.Stop();
                MessageBox.Show("player is win", "XO Game");
                PlayerWinCount++;
                label1.Text = "Player is win :" + PlayerWinCount;
                RestartGame();
            }



            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O") 
            
            {
                AITimer.Stop();
                MessageBox.Show("AI is win", "XO Game");
                AIWinCount++;
                label2.Text = "AI is win :" +AIWinCount;
                RestartGame();

            }

        }


        private void RestartGame() 
        { 
            buttons = new List<Button> {button1,button2,button3,button4,button5
            ,button6,button7,button8,button8,button9};

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }

        }
        
        

        private void AImove(object sender, EventArgs e)
        {
            if (buttons.Count > 0) 
            {
                int index=random.Next(buttons.Count);
                buttons[index].Enabled = false;  
                currentPlayer = Player.O;
                buttons[index].Text =currentPlayer.ToString();
                buttons[index].BackColor = Color.DarkSalmon;
                buttons.RemoveAt(index);
                CheckGame();
                AITimer.Stop();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
