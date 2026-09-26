using System.Drawing.Drawing2D;
using System.Timers;

namespace BubbleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int size = 10;
        Color set_color = Color.Red;
        Graphics g;
        int i = 0;
        int level = 100;
        int s = -5;

        void Form_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                size += 5;
            }
            else
            {
                size -= 5;
            }
            label1.Text = "Size= " + size.ToString();
        }
        //app
        //a
        //app
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseWheel += Form_MouseWheel;
            label1.Text = "Size= " + size.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            set_color = colorDialog1.Color;
            pictureBox1.BackColor = set_color;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                set_color = colorRandom();
                pictureBox1.BackColor = set_color;
            }
        }

        Color colorRandom()
        {
            Random r = new Random();
            return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            g = this.CreateGraphics();

            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        g.FillEllipse(new SolidBrush(set_color), e.X, e.Y, size, size);
                        break;
                    }

                case MouseButtons.Right:
                    {
                        Color drawColor = Color.FromArgb(
                                set_color.R * level / 100,
                                set_color.G * level / 100,
                                set_color.B * level / 100
                            );

                        g.FillEllipse(new SolidBrush(drawColor), e.X, e.Y, size, size);

                        pictureBox1.BackColor = drawColor;

                        level += s;

                        if (level <= 0)
                        {
                            level = 0;
                            s = 5;
                        }
                        else if (level >= 100)
                        {
                            level = 100;
                            s = -5;
                        }

                        break;
                    }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            g = this.CreateGraphics();
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        int holdtimeCounter = 0;
                        timer1.Interval = 2000;
                        timer1.Tick -= timer1_Tick;

                        g.FillEllipse(new SolidBrush(set_color), e.X, e.Y, size, size);
                        break;
                    }

                case MouseButtons.Right:
                    {
                        Color drawColor = Color.FromArgb(
                                set_color.R * level / 100,
                                set_color.G * level / 100,
                                set_color.B * level / 100
                            );

                        g.FillEllipse(new SolidBrush(drawColor), e.X, e.Y, size, size);

                        pictureBox1.BackColor = drawColor;

                        level += s;

                        if (level <= 0)
                        {
                            level = 0;
                            s = 5;
                        }
                        else if (level >= 100)
                        {
                            level = 100;
                            s = -5;
                        }

                        break;
                    }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Tick -= timer1_Tick;


        }
    }
}
