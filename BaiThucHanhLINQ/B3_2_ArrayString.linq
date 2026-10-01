<Query Kind="Program" />

using System;
using System.Collections;
using System.Linq;

void Main()
{
    B3.ArrayString_B3_2 app = new B3.ArrayString_B3_2();
    app.Input();
    app.Output();
}

namespace B3
{
    public class ArrayString_B3_2
    {
        // Khởi tạo Field
        private string[] monAn;
        private int n;

        // Khởi tạo Default Constructor
        public ArrayString_B3_2()
        {
            monAn = new string[] 
            { 
                "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì", 
                "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào", 
                "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" 
            };
            n = monAn.Length;
        }

        // Khởi tạo Constructor có tham số
        public ArrayString_B3_2(string[] arr)
        {
            this.monAn = arr;
            this.n = arr != null ? arr.Length : 0;
        }

        // Khởi tạo Methods
        public void Input()
        {
            Console.Write("Original array = ");
            for (int i = 0; i < n; i++)
            {
                Console.Write("[{0}] ", monAn[i]);
            }
            Console.WriteLine("\n");
        }

        public void Output()
        {
            // a. Tìm các phần tử có chiều dài ngắn nhất và dài nhất
            int minLen = monAn.Min(s => s.Length);
            int maxLen = monAn.Max(s => s.Length);

            var shortest = monAn.Where(s => s.Length == minLen);
            var longest = monAn.Where(s => s.Length == maxLen);

            Console.Write($"a. Shortest ({minLen} chars): ");
            foreach (var item in shortest) Console.Write("[{0}] ", item);
            Console.WriteLine();

            Console.Write($"   Longest ({maxLen} chars): ");
            foreach (var item in longest) Console.Write("[{0}] ", item);
            Console.WriteLine("\n");

            // b. Phân nhóm theo từ đầu tiên của tên món
            var groups = monAn
                .GroupBy(s => s.Split(' ')[0])
                .OrderBy(g => g.Key);

            Console.WriteLine("b. Group by first word:");
            foreach (var group in groups)
            {
                Console.Write($"  Group [{group.Key}]: ");
                foreach (var item in group)
                {
                    Console.Write("[{0}] ", item);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // c. Đếm số phần tử có từ đầu tiên là "Bánh"
            int countBanh = monAn.Count(s => s.StartsWith("Bánh", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"c. Items starting with 'Bánh': {countBanh}\n");
        }
    }
}