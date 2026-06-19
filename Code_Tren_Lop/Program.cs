using System;

class Program
{
    static void Main(string[] args)
    {
        // Kiểm tra trường hợp định dạng chuỗi sai
        HandleMultipleExceptions("abc", 0); 
        
        // Kiểm tra trường hợp chỉ số mảng nằm ngoài phạm vi
        HandleMultipleExceptions("10", 36);  
        
        // Kiểm tra trường hợp hợp lệ
        HandleMultipleExceptions("20", 2);  
    }

    public static void HandleMultipleExceptions(string input, int index)
    {
        int[] numbers = { 1, 2, 3 };
        
        try
        {
            // Có thể gây ra FormatException nếu input không phải là số
            int parsedValue = int.Parse(input); 
            
            // Có thể gây ra IndexOutOfRangeException nếu index < 0 hoặc index >= 3
            Console.WriteLine($"Phần tử tại index {index}: {numbers[index]}");
            Console.WriteLine($"Giá trị parse thành công: {parsedValue}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Index out of range.");
        }
    }
}
