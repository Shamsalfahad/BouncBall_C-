using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBall
{
    public partial class Form1 : Form
    {
        private int ballWidth = 70;
        private int ballHeight = 70;
        private int ballPosX = 1;
        private int ballPosY = 5;
        private int moveStepX = 2;
        private int moveStepY = 6;

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true
                );

            this.UpdateStyles();
        }

        private void PaintCircle(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = 
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.Clear(this.BackColor);

            e.Graphics.FillEllipse(Brushes.Gray,
                ballPosX, ballPosY,
                ballWidth, ballHeight);

            e.Graphics.DrawEllipse(Pens.AliceBlue,
                ballPosX, ballPosY,
                ballWidth, ballHeight);
        }

        private void MoveBall(object sender, EventArgs e)
        {
            
            ballPosX += moveStepX;
            if (
                ballPosX < 0 ||
                ballPosX + ballWidth > this.ClientSize.Width
                )
            {
                moveStepX = -moveStepX;
            }

            ballPosY += moveStepY;
            if (
                ballPosY < 0 ||
                ballPosY + ballHeight > this.ClientSize.Height
                )
            {
                moveStepY = -moveStepY;
            }

            
            this.Refresh();
        }
    }
}
