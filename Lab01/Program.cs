using System;
using System.Text;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ép hiển thị tiếng Việt có dấu không bị lỗi font
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("--- BẮT ĐẦU TEST VALIDATION (KIỂM DUYỆT NĂM) --- \n");

            // =================================================================
            // TRƯỜNG HỢP 1: NHẬP NĂM ĐÚNG QUY ĐỊNH (2020) -> Chạy mượt mà
            // =================================================================
            try
            {
                Console.WriteLine("1. Thử tạo cuốn sách với năm xuất bản hợp lệ (2020)...");
                Book sachDung = new Book("Nhà Giả Kim", "Paulo Coelho", "978-2", 2020);
                Console.WriteLine($"=> THÀNH CÔNG! Đã tạo được sách xuất bản năm: {sachDung.YearPublished}\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"=> THẤT BẠI: {ex.Message}\n");
            }

            // =================================================================
            // TRƯỜNG HỢP 2: CỐ TÌNH NHẬP NĂM SAI (999) -> Vệ sĩ sẽ chặn lại
            // =================================================================
            try
            {
                Console.WriteLine("2. Thử cố tình tạo cuốn sách với năm xuất bản sai (999)...");
                // Năm 999 nhỏ hơn 1000, chàng vệ sĩ trong Book.cs sẽ "ném" ra lỗi
                Book sachSai = new Book("Sách Cổ Đại", "Người Tiền Sử", "0000", 999); 
                
                // Dòng dưới này sẽ KHÔNG BAO GIỜ được chạy tới vì máy đã nhảy vào mục catch ở dưới
                Console.WriteLine($"=> THÀNH CÔNG! Đã tạo được sách xuất bản năm: {sachSai.YearPublished}\n");
            }
            catch (ArgumentException ex)
            {
                // Máy sẽ nhảy thẳng vào đây và bốc cái câu thông báo lỗi anh viết bên Book.cs ra in lên màn hình
                Console.ForegroundColor = ConsoleColor.Red; // Đổi chữ sang màu đỏ cho chuẩn giao diện báo lỗi
                Console.WriteLine($"=> BỊ CHẶN LẠI THÀNH CÔNG! Nội dung lỗi: {ex.Message}");
                Console.ResetColor(); // Trả màu chữ về bình thường
            }

            Console.WriteLine("\n--- KẾT THÚC BÀI TEST ---");
        }
    }
}