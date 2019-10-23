using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace LuongCongTy
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            string file = "C:\\Users\\Hang\\Downloads\\ĐA1\\LuongCongTy\\NhanVien.txt";
            FileStream file1 = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader nhanvien = new StreamReader(file1);
            textBox1.Text = nhanvien.ReadToEnd().Remove(0, 403);

        }
        private void openfile_Click(object sender, EventArgs e)
        {
            //Stream myStream;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    if ((myStream = openFileDialog1.OpenFile()) != null)
            //    {
            //        string strfilename = openFileDialog1.FileName;
            //        string filetext = File.ReadAllText(strfilename, Encoding.Unicode);
            //        textBox1.Text = filetext.Remove(0, 402);
            //    }
            //}
        }
        LinkedList<string> sentence = new LinkedList<string>();
        public void delete_Click(object sender, EventArgs e)
        {
            TextReader read = new System.IO.StringReader(textBox1.Text);
            string m;
            //LinkedList<string> sentence = new LinkedList<string>();
            while ((m = read.ReadLine()) != null)
            {
                if (m.Contains(textBox3.Text))
                {
                    //remove nguyên cái hàng có chứa tập con đó
                    m.Remove(0);
                }
                else
                {
                    sentence.AddLast(m);
                }
            }
            //// xóa khoảng dòng trống đầu tiên trên textbox2
            //sentence.RemoveFirst();
            textBox2.Text = string.Join(Environment.NewLine, sentence);
        }

        public void insertAfter(object sender, EventArgs e)
        {

            TextReader read = new System.IO.StringReader(textBox2.Text);
            string m;
            string t3 = textBox3.Text;
            string t4 = textBox11.Text;
            LinkedList<string> sentence = new LinkedList<string>();
            while ((m = read.ReadLine()) != null)
            {
                if (m.Contains(t3))
                {
                    //lấy địa chỉ của node tại node m để thực hiện thêm trước
                    var newNode = sentence.AddLast(m);
                    sentence.AddAfter(newNode, t4);
                }
                else
                {
                    sentence.AddLast(m);
                }
            }

            textBox2.Text = string.Join(Environment.NewLine, sentence);

        }

        private void insertFirst(object sender, EventArgs e)
        {
            TextReader read = new System.IO.StringReader(textBox2.Text);
            string m;
            string t3 = textBox3.Text;
            string t4 = textBox11.Text;
            LinkedList<string> sentence = new LinkedList<string>();
            while ((m = read.ReadLine()) != null)
            {
                if (m.Contains(t3))
                {
                    //lấy địa chỉ của node tại node m để thực hiện thêm trước
                    var newNode = sentence.AddLast(m);
                    sentence.AddBefore(newNode, t4);
                }
                else
                {
                    sentence.AddLast(m);
                }
            }
            textBox2.Text = string.Join(Environment.NewLine, sentence);
        }

        private void noiChuoi()
        {
            string t4 = textBox4.Text;
            string t5 = textBox5.Text;
            string t6 = textBox6.Text;
            string t7 = textBox7.Text;
            string t8 = textBox8.Text;
            string t9 = textBox9.Text;
            string t10 = textBox10.Text;
            int kc = tinhKhoangCach(20, t4 + " " + t5);
            string t11 = khoangCach(kc);
            int kc1 = tinhKhoangCach(27, t4 + " " + t5+t11+ t6);

          
            string t12 = khoangCach(kc1);
            string t = t4 + " " + t5 +t11+ t6 +t12+ t7 + " "+t8 +" "+ t9 +" "+ t10;
            textBox11.Text = t;
        }

        private int tinhKhoangCach(int kcquydinh,string a)
        {
            int h = kcquydinh - a.Length;
            return h;
        }
        private string khoangCach(int kc)
        {

            string a = " ";
            for(int i=0;i<kc-2;i++)
            {
                a += " ";
            }
            return a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            noiChuoi();
            
        }



    }
}



