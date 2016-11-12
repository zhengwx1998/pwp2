using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 个人平台专用版
{
    class Schedule
    {
        public string title, content;
        public DateTime timeStart, timeEnd;
        public int id=-1;
        public int status;
        public string GetStatus()
        {
            switch(status)
            {
            case 0:
                return "进行中";
            case 1:
                return "未开始";
            case 2:
                return "已完成";
            }
            return "A Bug Has Occurred";
        }
        public string ToString(int type)
        {
            if (id == -1)
                return "暂无";
            if (type == 0)
                return "ID: " + id + " 状态: " + GetStatus()
                    +" 标题: "+title+" 内容: "+content
                    +" 结束时间: "+timeEnd.ToString("yyyy-MM-dd HH:mm:ss");
            else
                return "ID: " + id + " 状态: " + GetStatus()
                    + " 标题: " + title + " 内容: " + content
                    + " 开始时间: " + timeStart.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
