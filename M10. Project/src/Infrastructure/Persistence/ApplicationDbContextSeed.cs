using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    /// <summary>
    /// Заполняет тестовыми данными таблицу Students.
    /// </summary>
    /// <param name="context"></param>
    public static async Task SeedStudentDataAsync(ApplicationDbContext context)
    {
        if (!context.Students.Any())
        {
            context.Students.Add(new Student {Name = "Student1", Email = "Email1", Phone = "Phone1"});

            context.Students.Add(new Student {Name = "Student2", Email = "Email2", Phone = "Phone2"});

            context.Students.Add(new Student {Name = "Student3", Email = "Email3", Phone = "Phone3"});

            await context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Заполняет тестовыми данными таблицу Lecturers.
    /// </summary>
    /// <param name="context"></param>
    public static async Task SeedLecturerDataAsync(ApplicationDbContext context)
    {
        if (!context.Lecturers.Any())
        {
            context.Lecturers.Add(new Lecturer {Name = "Lecturer1", Email = "LecturerEmail1"});

            context.Lecturers.Add(new Lecturer {Name = "Lecturer2", Email = "LecturerEmail2"});

            context.Lecturers.Add(new Lecturer {Name = "Lecturer3", Email = "LecturerEmail3"});
            
            await context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Заполняет тестовыми данными таблицу Lectures.
    /// </summary>
    /// <param name="context"></param>
    public static async Task SeedLectureDataAsync(ApplicationDbContext context)
    {
        if (!context.Lectures.Any())
        {
            context.Lectures.Add(new Lecture {Title = "Lecture1", Date = DateTime.Now, LecturerId = 1});

            context.Lectures.Add(new Lecture {Title = "Lecture2", Date = DateTime.Now, LecturerId = 2});

            context.Lectures.Add(new Lecture {Title = "Lecture3", Date = DateTime.Now, LecturerId = 3});
            
            await context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Заполняет тестовыми данными таблицу Homeworks.
    /// </summary>
    /// <param name="context"></param>
    public static async Task SeedHomeworkDataAsync(ApplicationDbContext context)
    {
        if (!context.Homeworks.Any())
        {
            context.Homeworks.Add(new Homework
            {
                Id = 1, StudentId = 1
            });

            context.Homeworks.Add(new Homework
            {
                Id = 2, StudentId = 2
            });

            context.Homeworks.Add(new Homework
            {
                Id = 3, StudentId = 2
            });

            context.Homeworks.Add(new Homework
            {
                Id = 4, StudentId = 3
            });

            context.Homeworks.Add(new Homework
            {
                Id = 5, StudentId = 3
            });

            await context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Заполняет тестовыми данными таблицу Homeworks.
    /// </summary>
    /// <param name="context"></param>
    public static async Task SeedAttendanceDataAsync(ApplicationDbContext context)
    {
        if (!context.Attendance.Any())
        {
            context.Attendance.Add(new LectureAttendance
            {
                Id = 1,
                LectureId = 1,
                StudentId = 1,
                HomeworkId = 1,
                Assessment = 5,
                Presence = true
            });
            
            context.Attendance.Add(new LectureAttendance
            {
                Id = 2,
                LectureId = 1,
                StudentId = 2,
                HomeworkId = 2,
                Assessment = 3,
                Presence = true
            });
            
            context.Attendance.Add(new LectureAttendance
            {
                Id = 3,
                LectureId = 1,
                StudentId = 3,
                HomeworkId = 4,
                Assessment = 4,
                Presence = true
            });
            
            context.Attendance.Add(new LectureAttendance
            {
                Id = 4,
                LectureId = 2,
                StudentId = 2,
                HomeworkId = 3,
                Assessment = 4,
                Presence = true
            });
            
            context.Attendance.Add(new LectureAttendance
            {
                Id = 5,
                LectureId = 2,
                StudentId = 3,
                HomeworkId = 5,
                Assessment = 4,
                Presence = true
            });
            
            context.Attendance.Add(new LectureAttendance
            {
                Id = 6,
                LectureId = 3,
                StudentId = 1,
                HomeworkId = null,
                Assessment = 0,
                Presence = false
            });
            
            context.Attendance.Add(new LectureAttendance
            {
                Id = 7,
                LectureId = 3,
                StudentId = 2,
                HomeworkId = null,
                Assessment = 0,
                Presence = false
            });
            
            context.Attendance.Add(new LectureAttendance
            {
                Id = 8,
                LectureId = 3,
                StudentId = 3,
                HomeworkId = null,
                Assessment = 0,
                Presence = false
            });
            
            await context.SaveChangesAsync();
        }
    }

    public static async Task ClearDbDataAsync(ApplicationDbContext context)
    {
        if (context.Students.Any())
        {
            foreach (var student in context.Students)
            {
                context.Students.Remove(student);
            }
        }

        if (context.Lecturers.Any())
        {
            foreach (var lecturer in context.Lecturers)
            {
                context.Lecturers.Remove(lecturer);
            }
        }

        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Заполняет тестовыми данными базу данных.
    /// </summary>
    /// <param name="context"></param>
    public static async Task SeedDBDataAsync(ApplicationDbContext context)
    {
        await ClearDbDataAsync(context);
        
        var student1 = new Student {Name = "Student1", Email = "Email1", Phone = "Phone1"};
        var student2 = new Student {Name = "Student2", Email = "Email2", Phone = "Phone2"};
        var student3 = new Student {Name = "Student3", Email = "Email3", Phone = "Phone3"};

        var lecturer1 = new Lecturer {Name = "Lecturer1", Email = "LecturerEmail1"};
        var lecturer2 = new Lecturer {Name = "Lecturer2", Email = "LecturerEmail2"};
        var lecturer3 = new Lecturer {Name = "Lecturer3", Email = "LecturerEmail3"};

        if (!context.Lecturers.Any())
        {
            context.Lecturers.Add(lecturer1);
            context.Lecturers.Add(lecturer2);
            context.Lecturers.Add(lecturer3);
        }

        if (!context.Students.Any())
        {
            context.Students.Add(student1);
            context.Students.Add(student2);
            context.Students.Add(student3);
        }

        await context.SaveChangesAsync();

        var homework1 = new Homework {StudentId = student1.Id};
        var homework2 = new Homework {StudentId = student2.Id};
        var homework3 = new Homework {StudentId = student2.Id};
        var homework4 = new Homework {StudentId = student3.Id};
        var homework5 = new Homework {StudentId = student3.Id};

        if (!context.Homeworks.Any())
        {
            context.Homeworks.Add(homework1);
            context.Homeworks.Add(homework2);
            context.Homeworks.Add(homework3);
            context.Homeworks.Add(homework4);
            context.Homeworks.Add(homework5);
        }

        var lecture1 = new Lecture {Title = "Lecture1", Date = DateTime.Now, LecturerId = lecturer1.Id};
        var lecture2 = new Lecture {Title = "Lecture2", Date = DateTime.Now, LecturerId = lecturer2.Id};
        var lecture3 = new Lecture {Title = "Lecture3", Date = DateTime.Now, LecturerId = lecturer3.Id};

        if (!context.Lectures.Any())
        {
            context.Lectures.Add(lecture1);
            context.Lectures.Add(lecture2);
            context.Lectures.Add(lecture3);
        }

        await context.SaveChangesAsync();
        
        context.Attendance.Add(new LectureAttendance
        {
            LectureId = lecture1.Id,
            StudentId = student1.Id,
            HomeworkId = homework1.Id,
            Assessment = 5,
            Presence = true
        });

        context.Attendance.Add(new LectureAttendance
        {
            LectureId = lecture1.Id,
            StudentId = student2.Id,
            HomeworkId = homework2.Id,
            Assessment = 3,
            Presence = true
        });

        context.Attendance.Add(new LectureAttendance
        {
            LectureId = lecture1.Id,
            StudentId = student3.Id,
            HomeworkId = homework4.Id,
            Assessment = 4,
            Presence = true
        });

        context.Attendance.Add(new LectureAttendance
        {
            LectureId = lecture2.Id, StudentId = student1.Id, Assessment = 4, Presence = false
        });

        context.Attendance.Add(new LectureAttendance
        {
            LectureId = lecture2.Id,
            StudentId = student2.Id,
            HomeworkId = homework3.Id,
            Assessment = 4,
            Presence = true
        });

        context.Attendance.Add(new LectureAttendance
        {
            LectureId = lecture2.Id,
            StudentId = student3.Id,
            HomeworkId = homework5.Id,
            Assessment = 4,
            Presence = true
        });

        context.Attendance.Add(new LectureAttendance
        {
            LectureId = lecture3.Id,
            StudentId = student1.Id,
            HomeworkId = null,
            Assessment = 0,
            Presence = false
        });

        context.Attendance.Add(new LectureAttendance
        {
            LectureId = lecture3.Id,
            StudentId = student2.Id,
            HomeworkId = null,
            Assessment = 0,
            Presence = false
        });

        context.Attendance.Add(new LectureAttendance
        {
            LectureId = lecture3.Id,
            StudentId = student3.Id,
            HomeworkId = null,
            Assessment = 0,
            Presence = false
        });

        await context.SaveChangesAsync();
    }

}
