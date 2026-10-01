<Query Kind="Program" />

using System;
using System.Collections.Generic;
using System.Linq;

void Main()
{
    B6.Join app = new B6.Join();
    app.Input();
    app.Output();
}

namespace B6
{
    // Định nghĩa lớp He theo đề bài
    public class He
    {
        public string MaHe { get; set; } = "";
        public string TenHe { get; set; } = "";
    }

    // Lớp DuLieu chứa phương thức tĩnh DS_He()
    public class DuLieu
    {
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

    public class Join
    {
        // Khởi tạo Field
        private List<He> dsHe;
        private int n;

        // Khởi tạo Default Constructor
        public Join()
        {
            dsHe = DuLieu.DS_He();
            n = dsHe.Count;
        }

        // Khởi tạo Constructor có tham số
        public Join(List<He> list)
        {
            this.dsHe = list ?? new List<He>();
            this.n = this.dsHe.Count;
        }

        // Khởi tạo Methods
        public void Input()
        {
            Console.WriteLine($"Total systems loaded: {n}\n");
        }

        public void Output()
        {
            Console.WriteLine("List of systems (He):");
            Console.WriteLine(string.Format("{0,-10} | {1,-25}", "Ma he", "Ten he"));
            Console.WriteLine(new string('-', 38));

            foreach (var item in dsHe)
            {
                Console.WriteLine(string.Format("{0,-10} | {1,-25}", item.MaHe, item.TenHe));
            }
            Console.WriteLine();
        }
    }
}