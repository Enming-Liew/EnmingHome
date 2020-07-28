using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 闭包理解
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usersLoad();
            string tipWords = "您将关闭当前对话框";
            this.FormClosing += delegate
            {
                MessageBox.Show(tipWords);
            };
        }

        private void usersLoad()
        {
            List<UserModel> userList = new List<UserModel> {
                new UserModel { UserName = "liutian", UserAge = 26 },
                new UserModel { UserName = "Enming", UserAge = 26 },
                new UserModel { UserName = "Tina", UserAge = 26 }
            };

            for (int i = 0; i < userList.Count; i++)
            {
                UserModel u = userList[i];
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    Thread.Sleep(1000);
                    //UserModel u = userList[i];                   
                    MessageBox.Show(u.UserName);
                });
            }

        }
     


    }
}
