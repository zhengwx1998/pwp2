using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Runtime.InteropServices; 

namespace 个人平台专用版
{
    public partial class Output : Form
    {
        public int year, month, day, hour, minute, second;
        private IList<Schedule> schedules = new List<Schedule>();
        private byte BlinkTimer;
        public Output()
        {
            InitializeComponent();
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create("test.xml", settings);
            xmlDoc.Load(reader);
            XmlNode xn = xmlDoc.SelectSingleNode("root");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode xnode in xnl)
            {
                XmlElement xe = (XmlElement)xnode;
                Schedule newSch = new Schedule();
                newSch.id = Convert.ToInt32(xe.GetAttribute("id"));
                newSch.status = Convert.ToInt32(xe.GetAttribute("status"));

                XmlNodeList xnl0 = xe.ChildNodes;
                newSch.title = xnl0.Item(0).InnerText;
                newSch.content = xnl0.Item(1).InnerText;

                XmlNodeList xnl1 = xnl0.Item(2).ChildNodes;
                newSch.timeStart = new DateTime(
                    Convert.ToInt32(xnl1.Item(0).InnerText),
                    Convert.ToInt32(xnl1.Item(1).InnerText),
                    Convert.ToInt32(xnl1.Item(2).InnerText),
                    Convert.ToInt32(xnl1.Item(3).InnerText),
                    Convert.ToInt32(xnl1.Item(4).InnerText),
                    Convert.ToInt32(xnl1.Item(5).InnerText));
                xnl1 = xnl0.Item(3).ChildNodes;
                newSch.timeEnd = new DateTime(
                    Convert.ToInt32(xnl1.Item(0).InnerText),
                    Convert.ToInt32(xnl1.Item(1).InnerText),
                    Convert.ToInt32(xnl1.Item(2).InnerText),
                    Convert.ToInt32(xnl1.Item(3).InnerText),
                    Convert.ToInt32(xnl1.Item(4).InnerText),
                    Convert.ToInt32(xnl1.Item(5).InnerText));
                schedules.Add(newSch);
            }
            reader.Close();

            foreach (Schedule sch in schedules)
            {
                int rSch = TaskGrid.Rows.Add();
                TaskGrid.Rows[rSch].Cells[0].Value = sch.id;
                TaskGrid.Rows[rSch].Cells[1].Value = sch.GetStatus();
                TaskGrid.Rows[rSch].Cells[2].Value = sch.title;
                TaskGrid.Rows[rSch].Cells[3].Value = sch.content;
                TaskGrid.Rows[rSch].Cells[4].Value = sch.timeStart.ToString("yyyy-MM-dd HH:mm:ss");
                if (sch.timeStart.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    int r = todayGrid.Rows.Add();
                    todayGrid.Rows[r].Cells[0].Value = sch.id;
                    todayGrid.Rows[r].Cells[1].Value = sch.GetStatus();
                    todayGrid.Rows[r].Cells[2].Value = sch.title;
                    todayGrid.Rows[r].Cells[3].Value = sch.content;
                    todayGrid.Rows[r].Cells[4].Value = sch.timeStart.ToString("yyyy-MM-dd HH:mm:ss");
                    todayGrid.Rows[r].Cells[5].Value = sch.timeEnd.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else if (sch.timeStart.ToString("yyyy-MM-dd") == DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"))
                {
                    int r = nextGrid.Rows.Add();
                    nextGrid.Rows[r].Cells[0].Value = sch.id;
                    nextGrid.Rows[r].Cells[1].Value = sch.GetStatus();
                    nextGrid.Rows[r].Cells[2].Value = sch.title;
                    nextGrid.Rows[r].Cells[3].Value = sch.content;
                    nextGrid.Rows[r].Cells[4].Value = sch.timeStart.ToString("yyyy-MM-dd HH:mm:ss");
                    nextGrid.Rows[r].Cells[5].Value = sch.timeEnd.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OutputLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            DateTime now = DateTime.Now;
            year = (int)now.Year;
            month = (int)now.Month;
            day = (int)now.Day;
            hour = (int)now.Hour;
            minute = (int)now.Minute;
            second = (int)now.Second;
            int n = (int)now.DayOfWeek;
            string[] weekDays = { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
            label5.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label6.Text = weekDays[n];

            //Get Next Task
            int minDeltaT=1073741824;
            Schedule minDeltaSch = new Schedule(), nowSch = new Schedule();
            foreach (Schedule sch in schedules)
            {
                TimeSpan deltaSpan = sch.timeStart - DateTime.Now;
                int deltaT = Convert.ToInt32(deltaSpan.TotalSeconds);
                if (deltaT <= 0)
                {
                    nowSch = sch;
                    sch.status = 0; 
                    if ((sch.timeEnd - DateTime.Now).TotalSeconds < 0)
                        sch.status = 2;
                }
                else if (deltaT < minDeltaT)
                {
                    minDeltaSch = sch;
                    minDeltaT = deltaT;
                }
            }
            labelThisSchedule.Text = nowSch.ToString(0);
            labelNextSchedule.Text = minDeltaSch.ToString(1);
            if (minDeltaT < 1200)
            {
                BlinkTimer++;
                if (BlinkTimer % 6 < 3)
                    labelNextSchedule.Text = "";
                if (BlinkTimer == 6)
                    BlinkTimer = 0;
                //seems that it can only play a few kind of Wav Files
                /*if (BlinkTimer == 1)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Const.NotificationFile);
                    player.Play();
                }*/
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
