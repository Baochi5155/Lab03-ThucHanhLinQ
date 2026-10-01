<Query Kind="Program" />

using System;
using System.Collections;
using System.Linq;

void Main()
{
    B3.Array1D_B3_1 app = new B3.Array1D_B3_1();
    app.Input();
    app.Output();
}

namespace B3
{
    public class Array1D_B3_1
    {
        // Khởi tạo Field
        private int[] mangSo;
        private int n;

        // Khởi tạo Default Constructor
        public Array1D_B3_1()
        {
            mangSo = new int[] { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };
            n = mangSo.Length;
        }

        // Khởi tạo Constructor có tham số
        public Array1D_B3_1(int[] arr)
        {
            this.mangSo = arr;
            this.n = arr != null ? arr.Length : 0;
        }

        // Khởi tạo Methods
        public void Input()
        {
            Console.Write("Original array = ");
            for (int i = 0; i < n; i++)
            {
                Console.Write("[{0}] ", mangSo[i]);
            }
            Console.WriteLine("\n");
        }

        public void Output()
        {
            // a. Tổng số phần tử, số phần tử chẵn và số phần tử lẻ
            int totalCount = mangSo.Count();
            int evenCount = mangSo.Count(x => x % 2 == 0);
            int oddCount = mangSo.Count(x => x % 2 != 0);
            Console.WriteLine($"a. Total elements: {totalCount}, Even count: {evenCount}, Odd count: {oddCount}");

            // b. Tổng các giá trị, giá trị lớn nhất và nhỏ nhất
            int sum = mangSo.Sum();
            int max = mangSo.Max();
            int min = mangSo.Min();
            Console.WriteLine($"b. Sum: {sum}, Max: {max}, Min: {min}");

            // c. Số lượng giá trị khác nhau trong mảng
            int distinctCount = mangSo.Distinct().Count();
            Console.WriteLine($"c. Distinct values count: {distinctCount}");

            // d. Phân nhóm theo số dư khi chia cho 5
            var groups = mangSo.GroupBy(x => x % 5).OrderBy(g => g.Key);
            Console.WriteLine("d. Group by remainder when divided by 5:");
            foreach (var group in groups)
            {
                Console.Write($"  Remainder {group.Key}: ");
                foreach (var item in group)
                {
                    Console.Write("[{0}] ", item);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}