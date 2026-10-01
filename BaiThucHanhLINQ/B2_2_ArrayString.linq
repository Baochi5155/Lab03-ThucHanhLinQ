<Query Kind="Program" />

using System;
using System.Collections;
using System.Linq;

void Main()
{
    B2.ArrayString_B2_2 app = new B2.ArrayString_B2_2();
    app.Input();
    app.Output();
}

namespace B2
{
    public class ArrayString_B2_2
    {
        // Khởi tạo Field
        private string[] mangChuoi;
        private int n;

        // Khởi tạo Default Constructor
        public ArrayString_B2_2()
        {
            mangChuoi = new string[] 
            { 
                "đầu", "lòng", "hai", "ả", "tố", "nga", 
                "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" 
            };
            n = mangChuoi.Length;
        }

        // Khởi tạo Constructor có tham số
        public ArrayString_B2_2(string[] arr)
        {
            this.mangChuoi = arr;
            this.n = arr != null ? arr.Length : 0;
        }

        // Khởi tạo Methods
        public void Input()
        {
            Console.Write("Original array = ");
            for (int i = 0; i < n; i++)
            {
                Console.Write("[{0}] ", mangChuoi[i]);
            }
            Console.WriteLine("\n");
        }

        public void Output()
        {
            // a. Liệt kê các phần tử có 4 ký tự và sắp xếp tăng dần theo ký tự đầu tiên
            var queryA = mangChuoi
                .Where(s => s.Length == 4)
                .OrderBy(s => s[0]);
            Console.Write("a. 4 characters (sorted by 1st char) = ");
            foreach (var item in queryA) Console.Write("[{0}] ", item);
            Console.WriteLine();

            // b. Biến đổi mỗi phần tử thành dạng: <chữ thường> - <CHỮ HOA>
            var queryB = mangChuoi
                .Select(s => $"{s.ToLower()} - {s.ToUpper()}");
            Console.WriteLine("b. Transform to <lower> - <UPPER>:");
            foreach (var item in queryB) Console.WriteLine("  [{0}]", item);
            Console.WriteLine();

            // c. Liệt kê các phần tử có chứa ký tự "u"
            var queryC = mangChuoi
                .Where(s => s.Contains("u", StringComparison.OrdinalIgnoreCase));
            Console.Write("c. Contains character 'u' = ");
            foreach (var item in queryC) Console.Write("[{0}] ", item);
            Console.WriteLine();

            // d. Liệt kê các từ bắt đầu bằng chữ in hoa
            var queryD = mangChuoi
                .Where(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0]));
            Console.Write("d. Starts with uppercase letter = ");
            foreach (var item in queryD) Console.Write("[{0}] ", item);
            Console.WriteLine("\n");
        }
    }
}