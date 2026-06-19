using System;

namespace Lab01
{
    public class Book
    {
        // 1. Khai báo các thuộc tính của cuốn sách (Yêu cầu 1)
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        // 1.1. Biến ẩn dùng để lưu giá trị thực sự (Người ngoài không thấy)
        private int _yearPublished;

        // 1.2. Thuộc tính công khai làm vệ sĩ gác cửa kiểm duyệt
        public int YearPublished
        {
            get 
            {
                return _yearPublished; // Ai hỏi thì trả về giá trị đang lưu trong biến ẩn
            }
            set
            {
                // 'value' chính là con số mà người ta đang muốn gán cho năm xuất bản
                if (value >= 1000 && value <= 2026)
                {
                    _yearPublished = value; // Hợp lệ thì đồng ý lưu!
                }
                else
                {
                    // Không hợp lệ thì ném ra một thông báo lỗi và chặn đứng chương trình
                    throw new ArgumentException("Lỗi rồi: Năm xuất bản phải từ 1000 đến 2026!");
                }
            }
        }

        // 2. Viết Constructor đầy đủ tham số để khởi tạo (Yêu cầu 2)
        public Book(string title, string author, string isbn, int yearPublished)
        {
            // Gán giá trị từ bên ngoài truyền vào cho các thuộc tính của Class
            Title = title;
            Author = author;
            ISBN = isbn;
            YearPublished = yearPublished;
        }
    }
}