using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;
//Addies final project

namespace keyPressAnimations
{
    public partial class Form1 : Form
    {

        int scene = 1;  // tracks what part of the game the user is at
       
        //initial starting values for Hero character
        int xHero = 100;
        int yHero =  100;
        int speedHero = 4;
        int widthHero = 147;
        int heightHero = 150;

        //values for door
        int xDoor1;
        int yDoor1;
        int xDoor2;
        int yDoor2;
        int xDoor3;
        int yDoor3;
        int xDoor4;
        int yDoor4;
        int door1Width = 110;
        int door1Height = 100;
        int door2Width = 100;
        int door2Height = 110;
        int door3Width = 110;
        int door3Height = 100;
        int door4Width = 110;
        int door4Height = 100;

        //values for products
        int p1x = 3;
        int p1y = 3;
        int p2x = 3;
        int p2y = 3;
        int p3x = 5;
        int p3y = 0;
        int p4x = 0;
        int p4y = 0;

        //set up sound
        SoundPlayer player = new SoundPlayer(Properties.Resources.tada);
        SoundPlayer audio = new SoundPlayer(Properties.Resources.buzzer);

        //determines whether a key is being pressed or not
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.LightCoral);
        Image backImage;
        Graphics g ;
        Font drawFont = new Font("Arial", 16, FontStyle.Bold);
        SolidBrush fontBrush = new SolidBrush(Color.AntiqueWhite);
        public Form1()
        {
            InitializeComponent();

            backImage = Properties.Resources.tiles;

            Graphics g = this.CreateGraphics();

            xHero = this.Width /2 - 30;
            yHero = this.Height /2 - 28;


            p2x = this.Width - 110;
            p3y = this.Height - 110;
            p4x = this.Width - 110;
            p4y = this.Height - 110;

            xDoor1 = this.Width - 100;
            yDoor1 = this.Height / 2;
            xDoor2 = 0;
            yDoor2 = this.Height / 2 - 10;
            xDoor3 = this.Width / 2 - 20;
            yDoor3 = 0;
            xDoor4 = this.Width / 2 - 20;
            yDoor4 = this.Height - 100;

            //start the timer when the program starts
            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        //check keys
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                default:
                    break;
            }

        }

        //check key release
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        //move character
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region move character based on key presses

            if (leftArrowDown == true)
            {
                xHero = xHero - speedHero;
            }

            if (downArrowDown == true)
            {
                yHero = yHero + speedHero;
            }

            if (rightArrowDown == true)
            {
                xHero = xHero + speedHero;
            }

            if (upArrowDown == true)
            {
                yHero = yHero - speedHero;
            }

            #endregion

            if (leftArrowDown == true)
            {
                if (xHero > 0)
                {
                    xHero = xHero - speedHero;
                }
                else
                {
                    xHero = this.Width;
                }
            }

            if (downArrowDown == true)
            {
                yHero = yHero + speedHero;
            }

            if (rightArrowDown == true)
            {
                if (xHero < this.Width - widthHero)
                {
                    xHero = xHero + speedHero;
                }
            }
            if (upArrowDown == true)
            {
                yHero = yHero - speedHero;
            }
            
            //refresh the screen, which causes the Form1_Paint method to run
            #region set rectangles 
            Rectangle beyonceRec = new Rectangle(xHero, yHero, widthHero, heightHero);
            Rectangle doorRec1 = new Rectangle(xDoor1, yDoor1, door1Width, door1Height);
            Rectangle doorRec2 = new Rectangle(xDoor2, yDoor2, door2Width, door2Height);
            Rectangle doorRec3 = new Rectangle(xDoor3, yDoor3, door3Width, door3Height);
            Rectangle doorRec4 = new Rectangle(xDoor4, yDoor4, door4Width, door4Height);
            Rectangle pRec1 = new Rectangle(p1x, p1y, door1Width, door1Height);
            Rectangle pRec2 = new Rectangle(p2x, p2y, door1Width, door1Height);
            Rectangle pRec3 = new Rectangle(p3x, p3y, door1Width, door1Height);
            Rectangle pRec4 = new Rectangle(p4x, p4y, door1Width, door1Height);
            #endregion
             
            #region What will happen if beyonce intersects with an object
            if (scene == 1)
            {
                if (beyonceRec.IntersectsWith(doorRec1))
                {
                    scene = 2;
                    drawBrush = new SolidBrush(Color.Red);
                    this.BackgroundImage = (Properties.Resources.TOO_FACED);

                    //set variable, add, case 
                }

                if (beyonceRec.IntersectsWith(doorRec2))
                {
                    scene = 3;
                    drawBrush = new SolidBrush(Color.Yellow);
                    this.BackgroundImage = (Properties.Resources.BENEFIT2);
                    //set variable, add, case 
                }

                if (beyonceRec.IntersectsWith(doorRec3))
                {
                    scene = 4;
                    drawBrush = new SolidBrush(Color.Green);
                    this.BackgroundImage = (Properties.Resources.ANASTASIA__);
                    //set variable, add, case 
                }

                if (beyonceRec.IntersectsWith(doorRec4))
                {
                    scene = 5;
                    drawBrush = new SolidBrush(Color.CornflowerBlue);
                    this.BackgroundImage = (Properties.Resources.TARTE__);
                    //set variable, add, case 
                }
            }

            if (scene == 2)

            {
                if (beyonceRec.IntersectsWith(pRec1))
                {
                    player.Play();
                    this.BackgroundImage = (Properties.Resources.winner);
                }

                if (beyonceRec.IntersectsWith(pRec2))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }

                if (beyonceRec.IntersectsWith(pRec3))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }

                if (beyonceRec.IntersectsWith(pRec4))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }
            }


            if (scene == 3)
            {
                if (beyonceRec.IntersectsWith(pRec1))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }

                if (beyonceRec.IntersectsWith(pRec2))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }

                if (beyonceRec.IntersectsWith(pRec3))
                {
                    player.Play();
                    this.BackgroundImage = (Properties.Resources.winner);
                }

                if (beyonceRec.IntersectsWith(pRec4))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }
            }

            if (scene == 4)
            {
                if (beyonceRec.IntersectsWith(pRec1))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }

                if (beyonceRec.IntersectsWith(pRec2))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }

                if (beyonceRec.IntersectsWith(pRec3))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }

                if (beyonceRec.IntersectsWith(pRec4))
                {
                    player.Play();
                    this.BackgroundImage = (Properties.Resources.winner);
                }
            }

            if (scene == 5)
            {
                if (beyonceRec.IntersectsWith(pRec1))
                {
                    player.Play();
                    this.BackgroundImage = (Properties.Resources.winner);
                }

                if (beyonceRec.IntersectsWith(pRec2))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }

                if (beyonceRec.IntersectsWith(pRec3))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }

                if (beyonceRec.IntersectsWith(pRec4))
                {
                    audio.Play();
                    this.BackgroundImage = (Properties.Resources.losr);
                }
            }

            Refresh();
        }
        #endregion

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw rectangle to screen
            if (scene == 1)
            {
                e.Graphics.FillRectangle(drawBrush, xDoor1, yDoor1, door1Width, door1Height);
                e.Graphics.FillRectangle(drawBrush, xDoor2, yDoor2, door2Width, door2Height);
                e.Graphics.FillRectangle(drawBrush, xDoor3, yDoor3, door3Width, door3Height);
                e.Graphics.FillRectangle(drawBrush, xDoor4, yDoor4, door4Width, door4Height);
            }
            //draw products to screen if scene = 2,3,4,5
            if (scene == 2)
            {
                e.Graphics.DrawImage(Properties.Resources.TF1, p1x, p1y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.TF2, p2x, p2y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.TF3, p3x, p3y , door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.TF4, p4x, p4y, door1Width, door1Height);
            }
            if (scene == 3)
            {
                e.Graphics.DrawImage(Properties.Resources.anastasia_brow, p1x, p1y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.A2, p2x, p2y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.A3, p3x, p3y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.A4, p4x, p4y, door1Width, door1Height);
            }

            if (scene == 4)
            {
                e.Graphics.DrawImage(Properties.Resources.anastasia_brow, p1x, p1y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.A2, p2x, p2y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.A3, p3x, p3y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.A4, p4x, p4y, door1Width, door1Height);
            }

            if (scene == 5)
            {
                e.Graphics.DrawImage(Properties.Resources.T1, p1x, p1y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.T2, p2x, p2y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.T3, p3x , p3y, door1Width, door1Height);
                e.Graphics.DrawImage(Properties.Resources.T4, p4x, p4y, door1Width, door1Height);
            }
            
            //draw beyonce
            e.Graphics.DrawImage(Properties.Resources.Beyonce, xHero, yHero, widthHero, heightHero);
        }
    }       
}   