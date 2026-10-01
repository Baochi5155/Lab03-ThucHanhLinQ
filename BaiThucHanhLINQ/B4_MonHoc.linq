<Query Kind="Program" />

using System;
using System.Collections.Generic;
using System.Linq;

void Main()
{
    B4.ArrayMonHoc_B4_1 app = new B4.ArrayMonHoc_B4_1();
    app.Input();
    app.Output();
}

namespace B4
{
    // Định nghĩa lớp MonHoc theo đúng đề bài
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        public byte SoTiet { get; set; }
    }

    // Lớp DuLieu cung cấp phương thức tĩnh DS_Mon()
    public class DuLieu
    {
        public static List<MonHoc> DS_Mon()
        {
            return new List<MonHoc>
            {
                new MonHoc { MaMon = "HP2_1", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP2_2", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP3_1", TenMon = "Lập trình Windows Forms", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP3_2", TenMon = "Xây dựng ứng dụng Windows Forms", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP4_1", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP4_2", TenMon = "Xây dựng ứng dụng Web với ASP.NET", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP5_1", TenMon = "Lập trình CSDL SQL Server căn bản", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP5_2", TenMon = "Lập trình CSDL SQL Server nâng cao", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "JLCB", TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
                new MonHoc { MaMon = "LINQ", TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
                new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
                new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
                new MonHoc { MaMon = "CC++", TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
                new MonHoc { MaMon = "JQUE", TenMon = "JQuery", He = "CD", SoTiet = 22 },
                new MonHoc { MaMon = "XML", TenMon = "Công nghệ XML", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "CRYS", TenMon = "Crystal Report trong Visual Studio", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "BWEB", TenMon = "HTML, CSS và JavaScript", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
            };
        }
    }

    public class ArrayMonHoc_B4_1
    {
        // Khởi tạo Field
        private List<MonHoc> dsMon;
        private int n;

        // Khởi tạo Default Constructor
        public ArrayMonHoc_B4_1()
        {
            dsMon = DuLieu.DS_Mon();
            n = dsMon.Count;
        }

        // Khởi tạo Constructor có tham số
        public ArrayMonHoc_B4_1(List<MonHoc> list)
        {
            this.dsMon = list ?? new List<MonHoc>();
            this.n = this.dsMon.Count;
        }

        // Khởi tạo Methods
        public void Input()
        {
            Console.WriteLine($"Total subjects loaded: {n}\n");
        }

        public void Output()
        {
            Console.WriteLine("List of subjects:");
            Console.WriteLine(string.Format("{0,-10} | {1,-42} | {2,-6} | {3,-6}", "Ma mon", "Ten mon", "He", "So tiet"));
            Console.WriteLine(new string('-', 72));

            foreach (var mon in dsMon)
            {
                Console.WriteLine(string.Format("{0,-10} | {1,-42} | {2,-6} | {3,-6}", 
                    mon.MaMon, mon.TenMon, mon.He, mon.SoTiet));
            }
            Console.WriteLine();
        }
    }
}