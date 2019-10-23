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
    public partial class frmMaxLuongMoiPhongBan : Form
    {
        public frmMaxLuongMoiPhongBan()
        {
            InitializeComponent();
        }
        public void MaxEachRoom()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Hang\Pictures\hang.txt");
            var columnQuery =
                 from line in lines
                 let ms = line.Substring(0, 3)
                 let ho = line.Substring(4, 15)
                 let ten = line.Substring(19, 7)
                 let phai = line.Substring(28, 1)
                 let cv = line.Substring(30, 4)
                 let mapb = line.Substring(44, 2)
                 let luong = line.Substring(35, 9)
                 group line by mapb into g
                 orderby g.Key
                 select g;
            List<string> ts = new List<string>();

            foreach (var g in columnQuery)
            {
                string file = @"C:\Users\Hang\Pictures\testFile0001_" + g.Key + ".txt";
                int max = 0;
                //ghi lên file
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file))
                {
                    foreach (var item in g)
                    {
                        sw.WriteLine(item);
                    }
                }
                string[] lines1 = File.ReadAllLines(@"C:\Users\Hang\Pictures\testFile0001_" + g.Key + ".txt");

                foreach (var item in g)
                {
                    string mmm = item.Substring(35, 9);
                    var columnQuery1 =
                    from line in lines1
                    let luong = line.Substring(35, 9)
                    select Convert.ToInt32(luong);
                    var results1 = columnQuery1.ToList();
                    max = results1.Max();
                }



                foreach (var item in g)
                {

                    string mmm = item.Substring(35, 9);
                    int mx = max;

                    if (Convert.ToInt32(mmm) == mx)
                    {
                        ts.Add(item.ToString());
                    }


                }
                File.Delete(file);

            }
            using (System.IO.StreamWriter sw1 = new System.IO.StreamWriter("textfile.txt"))
            {
                for (int i = 0; i < ts.Count; i++)
                {
                    sw1.WriteLine(ts[i]);

                }
            }

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

        public void open()
        {
            string file = "textfile.txt";
            FileStream file1 = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader nhanvien = new StreamReader(file1);
            textBox1.Text = nhanvien.ReadToEnd();
        }

        private void frmMaxLuongMoiPhongBan_Load(object sender, EventArgs e)
        {
            MaxEachRoom();
            open();
        }
    }
}
    
    

