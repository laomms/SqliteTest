using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqliteTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\sqlite3.dll") == false)
            {
                System.IO.File.WriteAllBytes(Application.StartupPath + "\\sqlite3.dll", Properties.Resources.sqlite3);
            }

            this.listView1.Items.Clear();
            this.listView1.GridLines = true;
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;
            this.listView1.Columns.Add("ID", 30, HorizontalAlignment.Center);
            this.listView1.Columns.Add("用户ID", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("用户名", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("密码", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("时间", listView1.Width-30-300, HorizontalAlignment.Center);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tablevalue = new List<string[]>() {
                new string[]{ "`Name` TEXT", "`EMAIL` TEXT", "`CODE` TEXT"},
                new string[]{ "`用户ID` TEXT", "`用户名` TEXT", "`密码` TEXT", "`时间` TEXT" }
            };

            SqliHelper.CreateTable(new string[] { "table1", "表2" }, tablevalue);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (SqliHelper.CheckDataExsit("table1", "Name","aaa")==false)
            {
                SqliHelper.InsertData("table1", new string[] { "Name", "EMAIL", "CODE" }, new string[] { "aaa", "aaa@.com", "1234" });
                SqliHelper.InsertData("table1", new string[] { "Name", "EMAIL", "CODE" }, new string[] { "bbb", "aaa@.com", "5678" });
                SqliHelper.InsertData("table1", new string[] { "Name", "EMAIL", "CODE" }, new string[] { "ccc", "aaa@.com", "6666" });
            }
            if (SqliHelper.CheckDataExsit("table1", "用户ID", "用户1") == false)
            {
                SqliHelper.InsertData("表2", new string[] { "用户ID", "用户名", "密码" , "时间" }, new string[] { "用户1", "网中行", "1234", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture) });
            }
            if (SqliHelper.CheckDataExsit("table1", "用户ID", "用户2") == false)
            {
                SqliHelper.InsertData("表2", new string[] { "用户ID", "用户名", "密码", "时间" }, new string[] { "用户2", "小水", "8888", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture) });
                SqliHelper.InsertData("表2", new string[] { "用户ID", "用户名", "密码", "时间" }, new string[] { "用户3", "阿男达", "8888", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture) });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> List = SqliHelper.ReadData("table1", new string[] { "Name", "CODE" }, "Name like 'aaa'", "CODE like '1234'");
                if (List.Count>0)
                {
                    textBox1.Text = List[0];textBox2.Text = List[1];textBox3.Text = List[2];
                }
                SqliHelper.CheckImporlistview(this.listView1, "表2","");
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqliHelper.UpdateData("table1", new string[] { "Name = 'aaa'" }, "EMAIL='修改@.com'", "CODE='修改'");
            List<string> List = SqliHelper.ReadData("table1", new string[] { "Name", "CODE" }, "Name like 'aaa'");
            if (List.Count > 0)
            {
                textBox1.Text = List[0]; textBox2.Text = List[1];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SqliHelper.DeleteData("表2", "用户名 Like '阿男达'", "密码 like '8888'")==true)
                SqliHelper.CheckImporlistview(this.listView1, "表2", "");
        }
    }
}
