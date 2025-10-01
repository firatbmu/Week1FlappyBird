using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {
        // Variables
        int pipeSpeed = 8; // speed of movement of pipes from right lo left
        int gravity = 15; // the speed at which the bird falls down.
        int score = 0; // Player's score
        public Form1()
        {
            InitializeComponent();           
        }

        private void gamekeyisdown(object sender, KeyEventArgs e) // when pressing the space bar , bird goes up. ( gravity is negative )
        {
            
            if (e.KeyCode == Keys.Space) // It checks whether the pressed key is Space or not.
            {
               gravity = -12; 
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = 12; // When you release the space bar, the bird falls down.( gravity is positive )
            }
        }

        private void endGame()
        { 
            gameTimer.Stop(); 
            scoreText.Text += " Game over!!!"; 

            // when the game is stopped , the timer stops and the screen reads "Game Over!!!" 
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity; // Bird's down/up movement
            pipeBottom.Left -= pipeSpeed; // the left/right movement of bottom pipe
            pipeTop.Left -= pipeSpeed; // the left/right movement of top pipe
            scoreText.Text = "Score: " + score; // score is printed to screen.


            // If the pipes come out from the left of the screen, they come from the right again and the score increases.
            if (pipeBottom.Left < -150) 
            {
                pipeBottom.Left = 800;
                score++;
                
            }
            if (pipeTop.Left < -150)
            {

                pipeTop.Left = 800;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {  
                endGame();
            }
            
            {
                pipeSpeed = 15;
            }

        }  
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
