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
using System.Media;

namespace square_game
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(70, 300, 30, 30);
        Rectangle player2 = new Rectangle(700, 300, 30, 30);       
        Rectangle food = new Rectangle(-10, 195, 10, 10);
        Rectangle speed = new Rectangle(-10, 185, 10, 10);
        Rectangle power = new Rectangle(-10, 175, 10, 10);
        Rectangle death = new Rectangle(-25, 165, 25, 25);
        
        int player1speed = 5;
        int player2speed = 5;
        int deathXspeed = 0;
        int deathYspeed = 0;
        int player1score = 0;
        int player2score = 0;
        int doubler = 1; 
        int currenttickspeed1 = 0;
        int currenttickspeed2 = 0;
        int currenttickpower1 = 0;
        int currenttickpower2 = 0;
        int currenttickmusic = 0;
        int currentticklabel = 0;
        int currenttickdamage = 0;
        int tick = 0;

        bool wPressed = false;
        bool sPressed = false;
        bool aPressed = false;
        bool dPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool leftPressed = false;
        bool rightPressed = false;
        bool backPressed = false;
        bool enterPressed = false;

        bool power1 = false;
        bool power2 = false;
        bool speed1 = false;
        bool speed2 = false;
        bool click = false;
        bool invis = false;

        SoundPlayer pointSound = new SoundPlayer(Properties.Resources.point);
        SoundPlayer deathSound = new SoundPlayer(Properties.Resources.death);
        SoundPlayer victorySound = new SoundPlayer(Properties.Resources.victory);

        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();         
            victoryLabel.Text = "Click to start";
            titleLabel.Text = "CubeRunner";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    enterPressed = true;
                    break;
                case Keys.Back:
                    backPressed = true;
                    break;
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    enterPressed = false;
                    break;
                case Keys.Back:
                    backPressed = false;
                    break;
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (click == true)
            {
                if (power1 == true && tick / 25 % 2 == 0)
                {
                    e.Graphics.FillRectangle(purpleBrush, player1);
                }
                else
                {
                    e.Graphics.FillRectangle(orangeBrush, player1);
                }
                if (power2 == true && tick / 25 % 2 == 0)
                {
                    e.Graphics.FillRectangle(purpleBrush, player2);
                }
                else {
                    e.Graphics.FillRectangle(blueBrush, player2);
                }
                e.Graphics.FillRectangle(whiteBrush, food);
                e.Graphics.FillRectangle(yellowBrush, speed);
                e.Graphics.FillRectangle(purpleBrush, power);
                e.Graphics.FillRectangle(redBrush, death);
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (click == true)
            {
                // player 1 movement
                if (wPressed == true && player1.Y > 0)
                {
                    player1.Y = player1.Y - player1speed;
                }
                if (sPressed == true && player1.Y < this.Height - player1.Height)
                {
                    player1.Y = player1.Y + player1speed;
                }
                if (aPressed == true && player1.X > 0)
                {
                    player1.X = player1.X - player1speed;
                }
                if (dPressed == true && player1.X < this.Width - player1.Width)
                {
                    player1.X = player1.X + player1speed;
                }

                // player 2 movement
                if (upPressed == true && player2.Y > 0)
                {
                    player2.Y = player2.Y - player2speed;
                }
                if (downPressed == true && player2.Y < this.Height - player1.Height)
                {
                    player2.Y = player2.Y + player2speed;
                }
                if (leftPressed == true && player2.X > 0)
                {
                    player2.X = player2.X - player2speed;
                }
                if (rightPressed == true && player2.X < this.Width - player1.Width)
                {
                    player2.X = player2.X + player2speed;
                }

                // food spawn
                if (food.X < 0)
                {
                    int foodY = rand.Next(0, this.Height - food.Height);
                    int foodX = rand.Next(0, this.Width - food.Width);
                    food.X = foodX;
                    food.Y = foodY;
                }

                // food eating
                if (player1.IntersectsWith(food))
                {
                    pointSound.Play();
                    food.X = -10;
                    player1score = player1score + doubler;
                    currenttickmusic = tick;
                }
                if (player2.IntersectsWith(food))
                {
                    pointSound.Play();
                    food.X = -10;
                    player2score = player2score + doubler;
                    currenttickmusic = tick;
                }
                if (tick == currenttickmusic + 20)
                {
                    pointSound.Stop();
                }

                // speed/ power spawn
                if (speed.X < 0 && power.X < 0)
                {
                    int powerup = rand.Next(1, 9);
                    if (powerup == 1)
                    {
                        int powerY = rand.Next(0, this.Height - power.Height);
                        int powerX = rand.Next(0, this.Width - power.Width);
                        power.X = powerX;
                        power.Y = powerY;
                    }
                    else
                    {
                        int speedY = rand.Next(0, this.Height - speed.Height);
                        int speedX = rand.Next(0, this.Width - speed.Width);
                        speed.X = speedX;
                        speed.Y = speedY;
                    }
                }

                // speed eating
                if (player2.IntersectsWith(speed))
                {
                    pointSound.Play();
                    currenttickmusic = tick;
                    speed.X = -10;
                    player2speed = 8;
                    speed2 = true;
                    currenttickspeed2 = tick;
                }
                if (player2speed != 5 && currenttickspeed2 + 100 == tick)
                { 
                    if (power2 == false)
                    {
                        player2speed = 5;
                    }
                }
                if (player1.IntersectsWith(speed))
                {
                    pointSound.Play();
                    currenttickmusic = tick;
                    speed.X = -10;
                    player1speed = 8;
                    speed1 = true; 
                    currenttickspeed1 = tick;
                }
                if (player1speed != 5 && currenttickspeed1 + 100 == tick)
                {
                    if (power1 == false)
                    {
                        player1speed = 5;
                    }    
                }

                // power eating
                if (player2.IntersectsWith(power))
                {
                    pointSound.Play();
                    currenttickmusic = tick;
                    power.X = -10;
                    player2speed = 8;
                    power2 = true;
                    currenttickpower2 = tick;
                }
                if (player1.IntersectsWith(power))
                {
                    pointSound.Play();
                    currenttickmusic = tick;
                    power.X = -10;
                    player1speed = 8;
                    power1 = true;
                    currenttickpower1 = tick;
                }
                if (power1 != power2)
                {
                    if (player1.IntersectsWith(player2) && power1 == true)
                    {
                        if (invis == false)
                        {
                            if (player2score > 0)
                            {
                                deathSound.Play();
                                player2score = player2score - doubler;
                            }
                            else
                            {
                                player2score = 0;
                            }
                            currenttickdamage = tick;
                            invis = true;
                        }
                    }
                    if (player2.IntersectsWith(player1) && power2 == true)
                    {
                        if (invis == false)
                        {
                            if (player1score > 0)
                            {
                                deathSound.Play();
                                player1score = player1score - doubler;
                            }
                            else
                            {
                                player1score = 0;
                            }
                            currenttickdamage = tick;
                            invis = true;
                        }
                    }
                }
                if (power1 == true && currenttickpower1 + 150 == tick)
                {
                    if (speed1 == false)
                    {
                        player1speed = 5;
                    }
                    power1 = false;
                }
                if (power2 == true && currenttickpower2 + 150 == tick)
                {
                    if (speed2 == false)
                    {
                        player2speed = 5;
                    }
                    power2 = false;
                }

                // death spawn
                if (tick / 50 == 5)
                {
                    deathXspeed = 5;
                    deathYspeed = 5;
                    death.X = 0;
                    death.Y = 0;
                }

                // death movement
                death.X = death.X + deathXspeed;
                death.Y = death.Y + deathYspeed;
                if (death.Y < 0)
                {
                    deathYspeed = -deathYspeed;
                }
                if (death.Y > this.Height - death.Height)
                {
                    deathYspeed = -deathYspeed;
                }
                if (death.X < 0)
                {
                    deathXspeed = -deathXspeed;
                }
                if (death.X > this.Width - death.Width)
                {
                    deathXspeed = -deathXspeed;
                }
                if (tick == 500 || tick == 750)
                 {
                     if (deathXspeed > 0)
                     {
                         deathXspeed = deathXspeed + 3;                   
                     }
                     else
                     {
                         deathXspeed = deathXspeed - 3;

                     }
                     if (deathYspeed > 0)
                     {
                         deathYspeed = deathYspeed + 3;
                     }
                     else
                     {
                         deathYspeed = deathYspeed - 3;
                     }
                 }

                //death attack 
                if (death.IntersectsWith(player1))               
                {
                    if (invis == false)
                    {
                        if (player1score > 0)
                        {
                            deathSound.Play();
                            player1score = player1score - doubler;
                        }
                        else
                        {
                            player1score = 0;
                        }
                        currenttickdamage = tick;
                        invis = true;
                    }
                }
                if (death.IntersectsWith(player2))
                {
                    if (invis == false)
                    {
                        if (player2score > 0)
                        {
                            deathSound.Play();
                            player2score = player2score - doubler;
                        }
                        else
                        {
                            player1score = 0;
                        }
                        currenttickdamage = tick;
                        invis = true;
                    }
                }

                //bonus time
                if (tick == 1000)
                {
                   currentticklabel = doubletime(tick);
                }
                if (enterPressed == true)
                {
                   currentticklabel = doubletime(tick);
                }
                if (currentticklabel + 100 <= tick)
                {
                    victoryLabel.Text = "";
                }

                // victory
                if (backPressed == true)
                {
                    victor(player1score, player2score);
                }
                if (tick % 50 == 0)
                {
                    timerLabel.Text = $"{tick / 50}";
                    if (tick / 50 == 30)
                    {
                        victor(player1score, player2score);
                    }
                }
                // invis frames
                if (currenttickdamage + 50 == tick)
                {
                    invis = false;
                }
                
                // fixing weirdness
                if (player1.X < 0)
                {
                    player1.X = 0;
                }
                if (player1.Y < 0)
                {
                    player1.Y = 0;
                }
                if (player1.Y > this.Height - player1.Height)
                {
                    player1.Y = this.Height - player1.Height;
                }
                if (player1.X > this.Width - player1.Width)
                {
                    player1.X = this.Width - player1.Width;
                }
                if (player2.X < 0)
                {
                    player2.X = 0;
                }
                if (player2.Y < 0)
                {
                    player2.Y = 0;
                }
                if (player2.Y > this.Height - player2.Height)
                {
                    player2.Y = this.Height - player2.Height;
                }
                if (player2.X > this.Width - player2.Width)
                {
                    player2.X = this.Width - player2.Width;
                }
                player1scoreLabel.Text = $"{player1score}";
                player2scoreLabel.Text = $"{player2score}";
                tick++;
                Refresh();
            }
        }
        public void victor(int player1score, int player2score)
        {
            if (player1score > player2score)
            {
                victoryLabel.Text = "The Victor is Player1";
            }
            else if (player1score < player2score)
            {
                victoryLabel.Text = "The Victor is Player2";
            }
            else
            {
                victoryLabel.Text = "No Winner";
            }
            victorySound.Play();
            Refresh();
            Thread.Sleep(5000);
            Application.Exit();
        }

        public int doubletime(int tick)
        {
            int currentticklabel;
            victoryLabel.Text = "Double points";
            doubler = 2;
            currentticklabel = tick;
            return currentticklabel;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            click = true;
            victoryLabel.Text = "";
            titleLabel.Text = "";
        }
    }
}