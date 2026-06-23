USE adodb;

DROP TABLE LecturerCourses;
DROP TABLE Courses;
DROP TABLE Lecturers;

CREATE TABLE Courses (
	Id INT PRIMARY KEY NOT NULL,
	Code VARCHAR(10) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Description VARCHAR(300) NOT NULL
);

CREATE TABLE Lecturers (
	Id INT PRIMARY KEY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Username VARCHAR(50) NOT NULL
);

CREATE TABLE LecturerCourses (
	LecturerId INT NOT NULL,
	CourseId INT NOT NULL,
	CONSTRAINT fk_lecturer FOREIGN KEY (LecturerId) REFERENCES Lecturers,
	CONSTRAINT fk_courses FOREIGN KEY (CourseId) REFERENCES Courses,
	CONSTRAINT pk_lecturer_course PRIMARY KEY (LecturerId, CourseId)
);

INSERT INTO Courses VALUES 
	(1, 'FOPCS', 'Foundations of Programming with C#', 'Write programmes using C# with Visual Studio'),
	(2, 'OOPCS', 'Object Oriented with C#', 'Understand and programming on main Object Oriented concepts.'),
	(3, 'MVC.NET', 'ASP.NET MVC Programming', 'Understand and develop web applications using ASP.NET MVC.');

INSERT INTO Lecturers VALUES
	(1, 'Yuen Kwan', 'Chia', 'isscyk'),
	(2, 'Bin', 'Peng', 'isspb'),
	(3, 'Fan', 'Liu', 'isslf'),
	(4, 'Vincent', 'Chung', 'issvc');

INSERT INTO LecturerCourses VALUES
	(1, 2),
	(1, 3),
	(2, 2),
	(2, 3),
	(3, 2);

SELECT * FROM Courses;
SELECT * FROM Lecturers;
SELECT * FROM LecturerCourses;