using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 个人平台专用版
{
    public partial class ControlCenter : Form
    {
        public class score
        {
            public int data, avg, minus;
        }
        public score chinese, math, english, physics, chemistry;
        public Output output;
        //private Schedule.time realtime = new Schedule.time();
        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = "主控时钟：" + output.OutputLabel.Text;
            /*realtime.day = output.day;
            realtime.month = output.month;
            realtime.year = output.year;
            realtime.hour = output.hour;
            realtime.minute = output.minute;
            realtime.second = output.second;*/
        }

        public ControlCenter()
        {
            InitializeComponent();
        }

        private void ControlCenter_Load(object sender, EventArgs e)
        {
            output = new Output();
            output.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chinese = new score();
            math = new score();
            english = new score();
            physics = new score();
            chemistry = new score();
            chinese.data = Convert.ToInt32(textBox1.Text);
            chinese.avg = Convert.ToInt32(textBox2.Text);
            chinese.minus = chinese.data - chinese.avg;
            math.data = Convert.ToInt32(textBox3.Text);
            math.avg = Convert.ToInt32(textBox4.Text);
            math.minus = math.data - math.avg;
            english.data = Convert.ToInt32(textBox5.Text);
            english.avg = Convert.ToInt32(textBox6.Text);
            english.minus = english.data - english.avg;
            physics.data = Convert.ToInt32(textBox7.Text);
            physics.avg = Convert.ToInt32(textBox8.Text);
            physics.minus = physics.data - physics.avg;
            chemistry.data = Convert.ToInt32(textBox9.Text);
            chemistry.avg = Convert.ToInt32(textBox10.Text);
            chemistry.minus = chemistry.data - chemistry.avg;
            output.label11.Text = chinese.data.ToString();
            output.label12.Text = math.data.ToString();
            output.label13.Text = english.data.ToString();
            output.label14.Text = physics.data.ToString();
            output.label15.Text = chemistry.data.ToString();
            output.label16.Text = chinese.avg.ToString();
            output.label17.Text = math.avg.ToString();
            output.label18.Text = english.avg.ToString();
            output.label19.Text = physics.avg.ToString();
            output.label20.Text = chemistry.avg.ToString();
            if(chinese.minus == 0)
            {
                output.label21.Text = 0.ToString();
                output.label21.ForeColor = Color.Black;
            }
            if (chinese.minus < 0)
            {
                output.label21.Text = Const.UpAndDownTriangle[2] + (-chinese.minus).ToString();
                output.label21.ForeColor = Const.green;
            }
            if (chinese.minus > 0)
            {
                output.label21.Text = Const.UpAndDownTriangle[1] + chinese.minus.ToString();
                output.label21.ForeColor = Const.red;
            }
            //
            if (math.minus == 0)
            {
                output.label22.Text = 0.ToString();
                output.label22.ForeColor = Color.Black;
            }
            if (math.minus < 0)
            {
                output.label22.Text = Const.UpAndDownTriangle[2] + (-math.minus).ToString();
                output.label22.ForeColor = Const.green;
            }
            if (math.minus > 0)
            {
                output.label22.Text = Const.UpAndDownTriangle[1] + math.minus.ToString();
                output.label22.ForeColor = Const.red;
            }
            //
            if (english.minus == 0)
            {
                output.label23.Text = 0.ToString();
                output.label23.ForeColor = Color.Black;
            }
            if (english.minus < 0)
            {
                output.label23.Text = Const.UpAndDownTriangle[2] + (-english.minus).ToString();
                output.label23.ForeColor = Const.green;
            }
            if (english.minus > 0)
            {
                output.label23.Text = Const.UpAndDownTriangle[1] + english.minus.ToString();
                output.label23.ForeColor = Const.red;
            }
            //
            if (physics.minus == 0)
            {
                output.label24.Text = 0.ToString();
                output.label24.ForeColor = Color.Black;
            }
            if (physics.minus < 0)
            {
                output.label24.Text = Const.UpAndDownTriangle[2] + (-physics.minus).ToString();
                output.label24.ForeColor = Const.green;
            }
            if (physics.minus > 0)
            {
                output.label24.Text = Const.UpAndDownTriangle[1] + physics.minus.ToString();
                output.label24.ForeColor = Const.red;
            }
            //
            if (chemistry.minus == 0)
            {
                output.label25.Text = 0.ToString();
                output.label25.ForeColor = Color.Black;
            }
            if (chemistry.minus < 0)
            {
                output.label25.Text = Const.UpAndDownTriangle[2] + (-chemistry.minus).ToString();
                output.label25.ForeColor = Const.green;
            }
            if (chemistry.minus > 0)
            {
                output.label25.Text = Const.UpAndDownTriangle[1] + chemistry.minus.ToString();
                output.label25.ForeColor = Const.red;
            }
        }
    }
}
