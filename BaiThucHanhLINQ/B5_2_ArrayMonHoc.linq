<Query Kind="Program" />

using System;
using System.Collections.Generic;
using System.Linq;

void Main()
{
    B5.ArrayMonHoc_B5_2 app = new B5.ArrayMonHoc_B5_2();
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

    public class ArrayMonHoc_B5_2
    {
        // Khởi tạo Field
        private List<MonHoc> dsMon;
        private int n;

        // Khởi tạo Default Constructor
        public ArrayMonHoc_B5_2()
        {
            dsMon = DuLieu.DS_Mon();
            n = dsMon.Count;
        }

        // Khởi tạo Constructor có tham số
        public ArrayMonHoc_B5_2(List<MonHoc> list)
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
            // a. Cho biết tổng số môn hiện có
            int totalSubjects = dsMon.Count();
            Console.WriteLine($"a. Total subjects: {totalSubjects}\n");

            // b. Đếm số môn có tên bắt đầu bằng "Lập trình"
            int countLapTrinh = dsMon.Count(m => m.TenMon.StartsWith("Lập trình", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"b. Subjects starting with 'Lap trinh': {countLapTrinh}\n");

            // c. Tính tổng số tiết của hệ Kỹ thuật viên (KTV)
            int totalKtvHours = dsMon.Where(m => m.He.Equals("KTV", StringComparison.OrdinalIgnoreCase)).Sum(m => (int)m.SoTiet);
            Console.WriteLine($"c. Total periods of system 'KTV': {totalKtvHours}\n");

            // d. Cho biết tổng số môn của mỗi hệ: Hệ, Tổng số môn
            var queryD = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "(Chua co he)" : m.He)
                              .Select(g => new { He = g.Key, SoLuong = g.Count() });
            Console.WriteLine("d. Subject count by System:");
            foreach (var item in queryD)
            {
                Console.WriteLine($"  - He: {item.He,-12} | Tong so mon: {item.SoLuong}");
            }
            Console.WriteLine();

            // e. Nhóm theo Số tiết; in Số tiết và Tổng số môn, sắp xếp giảm dần theo Số tiết
            var queryE = dsMon.GroupBy(m => m.SoTiet)
                              .OrderByDescending(g => g.Key)
                              .Select(g => new { SoTiet = g.Key, SoLuong = g.Count() });
            Console.WriteLine("e. Group by Periods (descending):");
            foreach (var item in queryE)
            {
                Console.WriteLine($"  - So tiet: {item.SoTiet,-4} | Tong so mon: {item.SoLuong}");
            }
            Console.WriteLine();

            // f. Cho biết thông tin môn học có số tiết cao nhất
            byte maxHours = dsMon.Max(m => m.SoTiet);
            var maxHourSubjects = dsMon.Where(m => m.SoTiet == maxHours);
            Console.WriteLine($"f. Subject(s) with maximum periods ({maxHours}):");
            foreach (var m in maxHourSubjects)
            {
                Console.WriteLine($"  - Ma: {m.MaMon} | Ten: {m.TenMon} | He: {m.He} | So tiet: {m.SoTiet}");
            }
            Console.WriteLine();

            // g. Thống kê theo Hệ: tổng số môn, tổng số tiết, số tiết cao nhất, số tiết thấp nhất
            var queryG = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "(Khac)" : m.He)
                              .Select(g => new
                              {
                                  He = g.Key,
                                  TongMon = g.Count(),
                                  TongTiet = g.Sum(x => (int)x.SoTiet),
                                  MaxTiet = g.Max(x => x.SoTiet),
                                  MinTiet = g.Min(x => x.SoTiet)
                              });
            Console.WriteLine("g. Statistics by System:");
            Console.WriteLine(string.Format("  {0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}", "He", "Tong mon", "Tong tiet", "Max tiet", "Min tiet"));
            Console.WriteLine("  " + new string('-', 56));
            foreach (var item in queryG)
            {
                Console.WriteLine(string.Format("  {0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}",
                    item.He, item.TongMon, item.TongTiet, item.MaxTiet, item.MinTiet));
            }
            Console.WriteLine();

            // h. Liệt kê các môn học được phân nhóm theo Hệ
            var queryH = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "(Khac)" : m.He);
            Console.WriteLine("h. Group subjects by System:");
            foreach (var group in queryH)
            {
                Console.WriteLine($"  * He [{group.Key}]:");
                foreach (var m in group)
                {
                    Console.WriteLine($"     + [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiet)");
                }
            }
            Console.WriteLine();

            // i. Liệt kê các môn học được phân nhóm theo Số tiết và tăng dần theo Số tiết
            var queryI = dsMon.GroupBy(m => m.SoTiet).OrderBy(g => g.Key);
            Console.WriteLine("i. Group subjects by Periods (ascending):");
            foreach (var group in queryI)
            {
                Console.WriteLine($"  * Nhom {group.Key} tiet:");
                foreach (var m in group)
                {
                    Console.WriteLine($"     + [{m.MaMon}] {m.TenMon}");
                }
            }
            Console.WriteLine();

            // j. Với hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5; sắp xếp theo Mã môn
            var queryJ = dsMon.Where(m => m.He.Equals("KTV", StringComparison.OrdinalIgnoreCase))
                              .GroupBy(m => m.MaMon.Contains("_") ? m.MaMon.Split('_')[0] : "Khac")
                              .OrderBy(g => g.Key);
            Console.WriteLine("j. System 'KTV' grouped by HP2, HP3, HP4, HP5:");
            foreach (var group in queryJ)
            {
                Console.WriteLine($"  * Hoc phan {group.Key}:");
                foreach (var m in group.OrderBy(x => x.MaMon))
                {
                    Console.WriteLine($"     + [{m.MaMon}] {m.TenMon}");
                }
            }
            Console.WriteLine();

            // k. Phân nhóm theo Hệ, chỉ lấy các môn có Số tiết > 40; trong mỗi nhóm sắp xếp theo Mã môn
            var queryK = dsMon.Where(m => m.SoTiet > 40)
                              .GroupBy(m => string.IsNullOrEmpty(m.He) ? "(Khac)" : m.He);
            Console.WriteLine("k. Group by System (Periods > 40, sorted by MaMon):");
            foreach (var group in queryK)
            {
                Console.WriteLine($"  * He [{group.Key}]:");
                foreach (var m in group.OrderBy(x => x.MaMon))
                {
                    Console.WriteLine($"     + [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiet)");
                }
            }
            Console.WriteLine();
        }
    }
}