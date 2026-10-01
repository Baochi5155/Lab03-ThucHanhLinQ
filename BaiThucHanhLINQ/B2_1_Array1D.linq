<Query Kind="Program">
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

using System;
using System.Collections;
using System.Linq;

void Main()
{
    B2.Array1D_B2_1 app = new B2.Array1D_B2_1();
    app.Input();
    app.Output();
}

namespace B2
{
    public class Array1D_B2_1
    {
        // Khởi tạo Field
        private int[] mangSo;
        private int n;

        // Khởi tạo Default Constructor
        public Array1D_B2_1()
        {
            mangSo = new int[] { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };
            n = mangSo.Length;
        }

        // Khởi tạo Constructor có tham số
        public Array1D_B2_1(int[] arr)
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
            // a. Liệt kê các phần tử chia hết cho 4 và 3
            var queryA = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);
            Console.Write("a. Divisible by 4 and 3 = ");
            foreach (var item in queryA) Console.Write("[{0}] ", item);
            Console.WriteLine();

            // b. Liệt kê các phần tử nhỏ hơn hoặc bằng 3
            var queryB = mangSo.Where(x => x <= 3);
            Console.Write("b. Less than or equal to 3 = ");
            foreach (var item in queryB) Console.Write("[{0}] ", item);
            Console.WriteLine();

            // c. Tạo dãy mới: số chẵn chia đôi, số lẻ giữ nguyên
            var queryC = mangSo.Select(x => (x % 2 == 0) ? (x / 2) : x);
            Console.Write("c. Transform array = ");
            foreach (var item in queryC) Console.Write("[{0}] ", item);
            Console.WriteLine("\n");
        }
    }
}