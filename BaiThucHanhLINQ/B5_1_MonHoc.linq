<Query Kind="Program" />

using System;
using System.Collections.Generic;
using System.Linq;

void Main()
{
    B5.ArrayMonHoc_B5_1 app = new B5.ArrayMonHoc_B5_1();
    app.Input();
    app.Output();
}

namespace B5
{
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        public byte SoTiet { get; set; }
    }

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

    public class ArrayMonHoc_B5_1
    {
        // Khởi tạo Field
        private List<MonHoc> dsMon;
        private int n;

        // Khởi tạo Default Constructor
        public ArrayMonHoc_B5_1()
        {
            dsMon = DuLieu.DS_Mon();
            n = dsMon.Count;
        }

        // Khởi tạo Constructor có tham số
        public ArrayMonHoc_B5_1(List<MonHoc> list)
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
            // a. Liệt kê tên các môn học bắt đầu bằng "Lập trình"
            var queryA = dsMon
                .Where(m => m.TenMon.StartsWith("Lập trình", StringComparison.OrdinalIgnoreCase))
                .Select(m => m.TenMon);

            Console.WriteLine("a. Subjects starting with 'Lap trinh':");
            foreach (var ten in queryA)
            {
                Console.WriteLine($"  - {ten}");
            }
            Console.WriteLine();

            // b. Liệt kê các môn thuộc hệ "CD", sắp xếp số tiết giảm dần rồi mã môn tăng dần
            var queryB = dsMon
                .Where(m => m.He.Equals("CD", StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(m => m.SoTiet)
                .ThenBy(m => m.MaMon);

            Console.WriteLine("b. System 'CD' (SoTiet desc, MaMon asc):");
            Console.WriteLine(string.Format("  {0,-10} | {1,-42} | {2,-6} | {3,-6}", "Ma mon", "Ten mon", "He", "So tiet"));
            Console.WriteLine("  " + new string('-', 70));
            foreach (var m in queryB)
            {
                Console.WriteLine(string.Format("  {0,-10} | {1,-42} | {2,-6} | {3,-6}", m.MaMon, m.TenMon, m.He, m.SoTiet));
            }
            Console.WriteLine();

            // c. Liệt kê các môn có tên chứa từ “web”, chỉ lấy Tên môn và Hệ
            var queryC = dsMon
                .Where(m => m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase))
                .Select(m => new { m.TenMon, m.He });

            Console.WriteLine("c. Subjects containing 'web' (TenMon, He):");
            Console.WriteLine(string.Format("  {0,-45} | {1,-6}", "Ten mon", "He"));
            Console.WriteLine("  " + new string('-', 55));
            foreach (var item in queryC)
            {
                Console.WriteLine(string.Format("  {0,-45} | {1,-6}", item.TenMon, item.He));
            }
            Console.WriteLine();

            // d. Liệt kê các môn thuộc hệ "KTV", sắp xếp tăng dần theo Mã môn
            var queryD = dsMon
                .Where(m => m.He.Equals("KTV", StringComparison.OrdinalIgnoreCase))
                .OrderBy(m => m.MaMon);

            Console.WriteLine("d. System 'KTV' (MaMon asc):");
            Console.WriteLine(string.Format("  {0,-10} | {1,-42} | {2,-6} | {3,-6}", "Ma mon", "Ten mon", "He", "So tiet"));
            Console.WriteLine("  " + new string('-', 70));
            foreach (var m in queryD)
            {
                Console.WriteLine(string.Format("  {0,-10} | {1,-42} | {2,-6} | {3,-6}", m.MaMon, m.TenMon, m.He, m.SoTiet));
            }
            Console.WriteLine();
        }
    }
}