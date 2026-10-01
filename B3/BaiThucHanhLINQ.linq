<Query Kind="Statements" />

using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("================ BÀI 3.1 ================");
            Bai3_1();

            Console.WriteLine("\n================ BÀI 3.2 ================");
            Bai3_2();

            Console.ReadLine();
        }

        // ==================== BÀI 3.1: THỐNG KÊ MẢNG SỐ ====================
        static void Bai3_1()
        {
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            // a. Tổng số phần tử, số phần tử chẵn và số phần tử lẻ
            int tongSoPhanTu = mangSo.Count();
            int soChan = mangSo.Count(n => n % 2 == 0);
            int soLe = mangSo.Count(n => n % 2 != 0);

            Console.WriteLine("a. Thống kê số lượng phần tử:");
            Console.WriteLine($"   - Tổng số phần tử: {tongSoPhanTu}");
            Console.WriteLine($"   - Số phần tử chẵn: {soChan}");
            Console.WriteLine($"   - Số phần tử lẻ: {soLe}");

            // b. Tính tổng các giá trị, giá trị lớn nhất và giá trị nhỏ nhất
            int tongGiaTri = mangSo.Sum();
            int maxGiaTri = mangSo.Max();
            int minGiaTri = mangSo.Min();

            Console.WriteLine("\nb. Thống kê giá trị:");
            Console.WriteLine($"   - Tổng các giá trị: {tongGiaTri}");
            Console.WriteLine($"   - Giá trị lớn nhất: {maxGiaTri}");
            Console.WriteLine($"   - Giá trị nhỏ nhất: {minGiaTri}");

            // c. Số lượng giá trị khác nhau trong mảng
            int soGiaTriKhacNhau = mangSo.Distinct().Count();
            Console.WriteLine($"\nc. Số lượng giá trị khác nhau: {soGiaTriKhacNhau}");

            // d. Phân nhóm theo số dư khi chia cho 5
            // Method Syntax: mangSo.GroupBy(n => n % 5)
            var nhomChia5 = from n in mangSo
                            group n by n % 5 into g
                            orderby g.Key
                            select g;

            Console.WriteLine("\nd. Phân nhóm theo số dư khi chia cho 5:");
            foreach (var group in nhomChia5)
            {
                Console.WriteLine($"   - Số dư {group.Key}: {string.Join(", ", group)}");
            }
        }

        // ==================== BÀI 3.2: THỐNG KÊ MẢNG CHUỖI ====================
        static void Bai3_2()
        {
            string[] monAn = {
                "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
                "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
                "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang"
            };

            // a. Tìm các phần tử có chiều dài ngắn nhất và dài nhất
            int minLength = monAn.Min(s => s.Length);
            int maxLength = monAn.Max(s => s.Length);

            var nganNhat = monAn.Where(s => s.Length == minLength);
            var daiNhat = monAn.Where(s => s.Length == maxLength);

            Console.WriteLine("a. Phần tử có chiều dài:");
            Console.WriteLine($"   - Ngắn nhất ({minLength} ký tự): {string.Join(", ", nganNhat)}");
            Console.WriteLine($"   - Dài nhất ({maxLength} ký tự): {string.Join(", ", daiNhat)}");

            // b. Phân nhóm theo từ đầu tiên của tên món
            var nhomTuDau = from item in monAn
                            let tuDau = item.Trim().Split(' ')[0]
                            group item by tuDau into g
                            select g;

            Console.WriteLine("\nb. Phân nhóm theo từ đầu tiên:");
            foreach (var group in nhomTuDau)
            {
                Console.WriteLine($"   * [{group.Key}]: {string.Join("; ", group)}");
            }

            // c. Đếm số phần tử có từ đầu tiên là "Bánh"
            int demBanh = monAn.Count(s => s.Trim().Split(' ')[0].Equals("Bánh", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"\nc. Số phần tử có từ đầu tiên là 'Bánh': {demBanh}");
        }
    }
}