using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LuongCongTy
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           

            
        }
        public void textfile()
        {
            string[] names = System.IO.File.ReadAllLines(@"C:\Users\Hang\Desktop\nv.txt");
            string[] scores = System.IO.File.ReadAllLines(@"C:\Users\Hang\Desktop\ct.txt");

            IEnumerable<string> scoreQuery1 =
                from name in names
                let ms=name.Substring(0,3)
                let ho=name.Substring(4,15)
                let ten=name.Substring(19,7)
                let phai=name.Substring(26,1)
                let mapb=name.Substring(50,2)
                from id in scores
                let ms1=id.Substring(0,3)
                let cv=id.Substring(4,4)
                let luong=id.Substring(8,1)
                where ms == ms1 
                orderby mapb ascending
                select ms + " " + ho + khoangCach(tinhKhoangCach(20,ms+ " "+ho)) +ten + khoangCach(tinhKhoangCach(27,ms + " " + ho+ khoangCach(tinhKhoangCach(20, ms + " " + ho))+ ten)) +phai+ " " + cv+ khoangCach(tinhKhoangCach(36, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten + khoangCach(tinhKhoangCach(27, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten)) + phai + " " + cv))+ Convert.ToString(Convert.ToInt32(luong) * 250000) + khoangCach(tinhKhoangCach(45, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten + khoangCach(tinhKhoangCach(27, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten)) + phai + " " + cv + khoangCach(tinhKhoangCach(36, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten + khoangCach(tinhKhoangCach(27, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten)) + phai + " " + cv)) + Convert.ToString(Convert.ToInt32(luong) * 250000))) + mapb;
                System.IO.File.WriteAllLines(@"C:\Users\Hang\Desktop\hang.txt", scoreQuery1);

        }
        public void open()
        {
            string file = "C:\\Users\\Hang\\Desktop\\hang.txt";
            FileStream file1 = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader nhanvien = new StreamReader(file1);
            textBox1.Text = nhanvien.ReadToEnd();
        }

        public int tinhKhoangCach(int kcquydinh, string a)
        {
            int h = kcquydinh - a.Length;
            return h;
        }
        public string khoangCach(int kc)
        {

            string a = " ";
            for (int i = 0; i < kc - 2; i++)
            {
                a += " ";
            }
            return a;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textfile();
            open();

        }
    } 
}











