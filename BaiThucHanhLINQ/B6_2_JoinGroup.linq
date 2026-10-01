<Query Kind="Program" />

using System;
using System.Collections.Generic;
using System.Linq;

void Main()
{
    B6.JoinGroup app = new B6.JoinGroup();
    app.Input();
    app.Output();
}

namespace B6
{
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        public byte SoTiet { get; set; }
    }

    public class He
    {
        public string MaHe { get; set; } = "";
        public string TenHe { get; set; } = "";
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

        public static List<He> DS_He()
        {
            return new List<He>
            {
                new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
                new He { MaHe = "CD", TenHe = "Chuyên đề" },
                new He { MaHe = "QT", TenHe = "Chứng chỉ quốc tế" }
            };
        }
    }

    public class JoinGroup
    {
        // Khởi tạo Field
        private List<MonHoc> dsMon;
        private List<He> dsHe;

        // Khởi tạo Default Constructor
        public JoinGroup()
        {
            dsMon = DuLieu.DS_Mon();
            dsHe = DuLieu.DS_He();
        }

        // Khởi tạo Constructor có tham số
        public JoinGroup(List<MonHoc> dsMon, List<He> dsHe)
        {
            this.dsMon = dsMon ?? new List<MonHoc>();
            this.dsHe = dsHe ?? new List<He>();
        }

        // Khởi tạo Methods
        public void Input()
        {
            Console.WriteLine($"Loaded: {dsMon.Count} subjects, {dsHe.Count} systems.\n");
        }

        public void Output()
        {
            // a. Dùng join để liệt kê: Tên hệ, Mã môn, Tên môn[cite: 8]
            var queryA = from m in dsMon
                         join h in dsHe on m.He equals h.MaHe
                         select new { h.TenHe, m.MaMon, m.TenMon };

            Console.WriteLine("a. Inner Join (Ten he, Ma mon, Ten mon):");
            Console.WriteLine(string.Format("  {0,-20} | {1,-10} | {2,-40}", "Ten he", "Ma mon", "Ten mon"));
            Console.WriteLine("  " + new string('-', 75));
            foreach (var item in queryA)
            {
                Console.WriteLine(string.Format("  {0,-20} | {1,-10} | {2,-40}", item.TenHe, item.MaMon, item.TenMon));
            }
            Console.WriteLine();

            // b. Liệt kê cả những hệ chưa có môn học (left outer join với GroupJoin + DefaultIfEmpty)[cite: 8]
            var queryB = dsHe.GroupJoin(
                            dsMon,
                            h => h.MaHe,
                            m => m.He,
                            (h, monGroup) => new { He = h, MonList = monGroup.DefaultIfEmpty() }
                         )
                         .SelectMany(
                            x => x.MonList,
                            (x, m) => new
                            {
                                TenHe = x.He.TenHe,
                                MaMon = m != null ? m.MaMon : "(Chua co mon)",
                                TenMon = m != null ? m.TenMon : "(Chua co mon)"
                            }
                         );

            Console.WriteLine("b. Left Outer Join (Lay ca he chua co mon):");
            Console.WriteLine(string.Format("  {0,-20} | {1,-12} | {2,-40}", "Ten he", "Ma mon", "Ten mon"));
            Console.WriteLine("  " + new string('-', 77));
            foreach (var item in queryB)
            {
                Console.WriteLine(string.Format("  {0,-20} | {1,-12} | {2,-40}", item.TenHe, item.MaMon, item.TenMon));
            }
            Console.WriteLine();

            // c. Liệt kê cả hệ chưa có môn học và môn học chưa khai báo hệ (Full Outer Join)[cite: 8]
            var leftJoin = from h in dsHe
                           join m in dsMon on h.MaHe equals m.He into gm
                           from m in gm.DefaultIfEmpty()
                           select new
                           {
                               TenHe = h.TenHe,
                               MaMon = m != null ? m.MaMon : "(Khong co)",
                               TenMon = m != null ? m.TenMon : "(Khong co)"
                           };

            var rightJoin = from m in dsMon
                            where !dsHe.Any(h => h.MaHe == m.He)
                            select new
                            {
                                TenHe = "(Chua khai bao he)",
                                MaMon = m.MaMon,
                                TenMon = m.TenMon
                            };

            var queryC = leftJoin.Union(rightJoin);

            Console.WriteLine("c. Full Outer Join (Ca he chua co mon va mon chua co he):");
            Console.WriteLine(string.Format("  {0,-22} | {1,-10} | {2,-40}", "Ten he", "Ma mon", "Ten mon"));
            Console.WriteLine("  " + new string('-', 77));
            foreach (var item in queryC)
            {
                Console.WriteLine(string.Format("  {0,-22} | {1,-10} | {2,-40}", item.TenHe, item.MaMon, item.TenMon));
            }
            Console.WriteLine();

            // d. Chỉ liệt kê những hệ chưa có môn học và những môn học chưa khai báo hệ[cite: 8]
            var heChuaCoMon = dsHe.Where(h => !dsMon.Any(m => m.He == h.MaHe))
                                  .Select(h => new { Loai = "He chua co mon", Ma = h.MaHe, Ten = h.TenHe });

            var monChuaCoHe = dsMon.Where(m => !dsHe.Any(h => h.MaHe == m.He))
                                  .Select(m => new { Loai = "Mon chua co he", Ma = m.MaMon, Ten = m.TenMon });

            var queryD = heChuaCoMon.Concat(monChuaCoHe);

            Console.WriteLine("d. Chi he chua co mon va mon chua khai bao he:");
            Console.WriteLine(string.Format("  {0,-18} | {1,-10} | {2,-30}", "Loai", "Ma", "Ten"));
            Console.WriteLine("  " + new string('-', 63));
            foreach (var item in queryD)
            {
                Console.WriteLine(string.Format("  {0,-18} | {1,-10} | {2,-30}", item.Loai, item.Ma, item.Ten));
            }
            Console.WriteLine();

            // e. Lấy 5 môn học đầu tiên có số tiết giảm dần; hiển thị Tên hệ, Mã môn, Tên môn, Số tiết[cite: 8]
            var queryE = (from m in dsMon
                          join h in dsHe on m.He equals h.MaHe into gh
                          from h in gh.DefaultIfEmpty()
                          orderby m.SoTiet descending
                          select new
                          {
                              TenHe = h != null ? h.TenHe : "(Chua ro)",
                              m.MaMon,
                              m.TenMon,
                              m.SoTiet
                          }).Take(5);

            Console.WriteLine("e. Top 5 mon co so tiet giam dan:");
            Console.WriteLine(string.Format("  {0,-20} | {1,-10} | {2,-40} | {3,-7}", "Ten he", "Ma mon", "Ten mon", "So tiet"));
            Console.WriteLine("  " + new string('-', 83));
            foreach (var item in queryE)
            {
                Console.WriteLine(string.Format("  {0,-20} | {1,-10} | {2,-40} | {3,-7}", item.TenHe, item.MaMon, item.TenMon, item.SoTiet));
            }
            Console.WriteLine();

            // f. Cho biết tổng số môn học của mỗi hệ: Mã hệ, Tên hệ, Tổng số môn[cite: 8]
            var queryF = dsHe.GroupJoin(
                            dsMon,
                            h => h.MaHe,
                            m => m.He,
                            (h, monGroup) => new
                            {
                                h.MaHe,
                                h.TenHe,
                                TongSoMon = monGroup.Count()
                            });

            Console.WriteLine("f. Tong so mon theo tung he:");
            Console.WriteLine(string.Format("  {0,-8} | {1,-20} | {2,-12}", "Ma he", "Ten he", "Tong so mon"));
            Console.WriteLine("  " + new string('-', 46));
            foreach (var item in queryF)
            {
                Console.WriteLine(string.Format("  {0,-8} | {1,-20} | {2,-12}", item.MaHe, item.TenHe, item.TongSoMon));
            }
            Console.WriteLine();

            // g. Cho biết có bao nhiêu loại Số tiết khác nhau trong danh sách môn học[cite: 8]
            int distinctSoTiet = dsMon.Select(m => m.SoTiet).Distinct().Count();
            Console.WriteLine($"g. Co {distinctSoTiet} loai so tiet khac nhau.\n");

            // h. Tìm môn học đầu tiên có tên bắt đầu bằng “Lập trình”[cite: 8]
            var firstLapTrinh = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("h. Mon hoc dau tien bat dau bang 'Lap trinh':");
            if (firstLapTrinh != null)
            {
                Console.WriteLine($"  [{firstLapTrinh.MaMon}] {firstLapTrinh.TenMon} - He: {firstLapTrinh.He} - So tiet: {firstLapTrinh.SoTiet}\n");
            }
            else
            {
                Console.WriteLine("  Khong tim thay!\n");
            }

            // i. Liệt kê các môn theo từng hệ, đánh số thứ tự trong mỗi nhóm[cite: 8]
            var queryI = dsHe.GroupJoin(
                            dsMon,
                            h => h.MaHe,
                            m => m.He,
                            (h, monGroup) => new
                            {
                                He = h,
                                MonList = monGroup.ToList()
                            });

            Console.WriteLine("i. Liet ke cac mon theo tung he (kem STT trong nhom):");
            foreach (var nhom in queryI)
            {
                Console.WriteLine($"  * He: {nhom.He.TenHe} ({nhom.He.MaHe})");
                if (nhom.MonList.Count == 0)
                {
                    Console.WriteLine("     (Chua co mon hoc nao)");
                }
                else
                {
                    int stt = 1;
                    foreach (var m in nhom.MonList)
                    {
                        Console.WriteLine($"     {stt++}. [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiet)");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}