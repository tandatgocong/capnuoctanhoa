using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAPNUOCTANHOA.Forms.GNKDT
{
    class MyProgressBar
    {
        // Fields of the class
        PictureBox pictureBox;
        int percent;
        string text;
        Color fgColor;
        Color bgColor;
        Color tColor;
        Graphics graphics;
        Font font;
        bool paused = false;

        // Constructor for the class - takes a picture box control, the fore ground color, the back ground color
        // and the text color
        public MyProgressBar(PictureBox picturebox, Color fgColor, Color bgColor, Color tColor)
        {
            pictureBox = picturebox;
            percent = 0;
            this.fgColor = fgColor;
            this.bgColor = bgColor;
            this.tColor = tColor;
            graphics = pictureBox.CreateGraphics();
            font = new Font("Arial", 8);
            Reset();
        }

        // property to get the pause state and set the pause state
        public bool Paused
        {
            get { return paused; }
            set { paused = value; }
        }

        // property to set the string to be displayed in the control
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        // property to get and set the foreground color of the control
        public Color ForeColor
        {
            get { return fgColor; }
            set { fgColor = value; }
        }

        // property to get and set the background color of the control
        public Color BackColor
        {
            get { return bgColor; }
            set { bgColor = value; }
        }

        // property to get and set the text color of the progress bar
        public Color TextColor
        {
            get { return tColor; }
            set { tColor = value; }
        }

        // property used to get if the progress is 100%
        public bool Finished
        {
            get { if (percent == 100) return true; else return false; }
        }

        // property to get what percent the progress is at
        public int Percent
        {
            get { return percent; }
        }

        // Reset the progress bar
        public void Reset()
        {
            paused = false;
            percent = 0;
            text = "";
            Draw();
        }

        // used to update the percentage by 1 percent at a time
        public void Update()
        {
            if (!paused)
            {
                percent++;
                if (percent > 100)
                    percent = 100;
            }
        }

        // used to update the percentage by an amount
        public void Update(int increment)
        {
            if (!paused)
            {
                percent += increment;
                if (percent > 100)
                    percent = 100;
            }
        }

        // is used to draw the progress bar and the text in the progress bar
        public void Draw()
        {
            Rectangle rect = new Rectangle();
            rect = pictureBox.ClientRectangle;
            graphics.FillRectangle(new SolidBrush(bgColor), rect);
            rect.X += 2;
            rect.Y += 2;
            rect.Width -= 4;
            rect.Height -= 4;
            int width = (int)(rect.Width * percent / 100);
            rect.Width = width;
            graphics.FillRectangle(new SolidBrush(fgColor), rect);
            SizeF textSize = graphics.MeasureString(text, font);
            PointF point = new PointF((pictureBox.ClientRectangle.Width / 2) - (textSize.Width / 2),
                (pictureBox.ClientRectangle.Height / 2) - (textSize.Height / 2));
            graphics.DrawString(text, font, new SolidBrush(tColor), point);
        }
    }
}
