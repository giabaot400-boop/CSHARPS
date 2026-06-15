-- 1. Tạo Database
CREATE DATABASE SchoolDB;
GO
USE SchoolDB;
GO

-- 2. Tạo bảng Students (Đã bao gồm cột Email của Bài tập mở rộng 1)
CREATE TABLE Students
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Age INT,
    Email NVARCHAR(150)
);

-- Thêm dữ liệu mẫu cho Students
INSERT INTO Students (Name, Age) VALUES
    (N'Nguyễn Văn An', 21),
    (N'Trần Thị Bình', 22),
    (N'Lê Minh Châu', 20);

-- 3. Tạo bảng Courses (Bài tập mở rộng 2)
CREATE TABLE Courses (
    Id INT PRIMARY KEY IDENTITY,
    CourseName NVARCHAR(100) NOT NULL
);

-- 4. Tạo bảng StudentCourses (Bài tập mở rộng 2)
CREATE TABLE StudentCourses (
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    PRIMARY KEY (StudentId, CourseId),
    FOREIGN KEY (StudentId) REFERENCES Students(Id),
    FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

INSERT INTO Courses (CourseName) VALUES
    (N'Lập trình .NET'), (N'Cơ sở dữ liệu'), (N'Kiến trúc phần mềm');

INSERT INTO StudentCourses VALUES
    (1,1), (1,2), (2,2), (2,3), (3,1), (3,3);