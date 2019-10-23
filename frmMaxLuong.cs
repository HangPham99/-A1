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
    public partial class frmMaxLuong : Form
    {
        public frmMaxLuong()
        {
            InitializeComponent();
        }

         public void SingleColumn()
            {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Hang\Desktop\hang.txt");

            var columnQuery =
                    from line in lines
                    let ms = line.Substring(0, 3)
                    let ho = line.Substring(4, 15)
                    let ten = line.Substring(19, 7)
                    let phai = line.Substring(28, 1)
                    let cv = line.Substring(30, 4)
                    let mapb = line.Substring(44, 2)
                    let luong = line.Substring(35, 9)
                    select Convert.ToInt32(luong);
                var results = columnQuery.ToList();
                double average = results.Average();
                int max = results.Max();
                int min = results.Min();
               
            var columnQuery1 =
                  from line1 in lines
                  let ms = line1.Substring(0, 3)
                  let ho = line1.Substring(4, 15)
                  let ten = line1.Substring(19, 7)
                  let phai = line1.Substring(28, 1)
                  let cv = line1.Substring(30, 4)
                  let mapb = line1.Substring(44, 2)
                  let luong = line1.Substring(35, 9)
                  where Convert.ToInt32(luong) == max
                  select ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten + khoangCach(tinhKhoangCach(27, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten)) + phai + " " + cv + khoangCach(tinhKhoangCach(36, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten + khoangCach(tinhKhoangCach(27, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten)) + phai + " " + cv)) + max + khoangCach(tinhKhoangCach(45, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten + khoangCach(tinhKhoangCach(27, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten)) + phai + " " + cv + khoangCach(tinhKhoangCach(36, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten + khoangCach(tinhKhoangCach(27, ms + " " + ho + khoangCach(tinhKhoangCach(20, ms + " " + ho)) + ten)) + phai + " " + cv)) +max)) + mapb;
                System.IO.File.WriteAllLines(@"C:\Users\Hang\Desktop\mimi.txt", columnQuery1);


            }
            public void open()
        {
            string file = "C:\\Users\\Hang\\Desktop\\mimi.txt";
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

        private void frmMaxLuong_Load(object sender, EventArgs e)
        {
            SingleColumn();
            open();
        }
    }
}
