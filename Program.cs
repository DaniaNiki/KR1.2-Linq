using KR1._2;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace KR1._2
{
    class Program
    {
        static void Main()
        {
            //List<Student> students = GetStudentList();
            InitializeDatabase();
            PrintNames();
            FilterStudents();
            SortStudentsByAge();
            AggregateOperationsForStuds();
            GroupStudentsByAge();
        }

        static void InitializeDatabase()
        {
            using (var context = new SchoolContext())
            {
                // Проверка, существует ли база данных, и её создание, если необходимо
                context.Database.EnsureCreated();

                // Добавление студентов, если их еще нет
                if (!context.Students.Any())
                {
                    context.Students.AddRange(
                        GetStudentList()
                ); ;
                    context.SaveChanges();
                }
            }
        }

        //Выборка по имени
        private static void PrintNames()
        {
            using (var context = new SchoolContext())
            {
                Console.WriteLine("\nИмена студентов из БД:");
                var studentNames = context.Students.Select(s => s.Name);
                foreach (var name in studentNames)
                {
                    Console.WriteLine(name);
                }
            }
        }

        //Фильтрация по условию
        private static void FilterStudents()
        {
            using (var context = new SchoolContext())
            {
                Console.WriteLine("\nФильтрация:");
                var filteredStudents = context.Students.Where(s => s.Score > 8);
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine($"{student.Name} - {student.Score}");
                }
            }
        }

        //Сортировка студентов по возрасту
        private static void SortStudentsByAge()
        {
            using (var context = new SchoolContext())
            {
                var sortedStudents = context.Students.OrderBy(s => s.Age);
                Console.WriteLine("\nСтуденты, отсортированные по возрасту:");
                foreach (var student in sortedStudents)
                {
                    Console.WriteLine($"{student.Name} - {student.Age}");
                }
            }
        }


        //агрегатные операции
        private static void AggregateOperationsForStuds()
        {
            using (var context = new SchoolContext())
            {
                Console.WriteLine("\nМинимальный средний балл: " + context.Students.Min(s => s.Score));
                Console.WriteLine("\nМаксимальный средний балл: " + context.Students.Max(s => s.Score));
                Console.WriteLine("\nСредний средний балл: " + context.Students.Average(s => s.Score));
                Console.WriteLine("\nСуммарный средний балл: " + context.Students.Sum(s => s.Score));
            }
        }

        //группировка по возврасту
        private static void GroupStudentsByAge()
        {
            using (var context = new SchoolContext())
            {
                var groupByAge = context.Students.GroupBy(s => s.Age);
                Console.WriteLine("\nГруппировка студентов по возрасту:");
                foreach (var group in groupByAge)
                {
                    Console.WriteLine($"Возраст: {group.Key}");
                    foreach (var student in group)
                    {
                        Console.WriteLine($"{student.Name} - {student.Score}");
                    }
                }
            }
        }

        //возвращает список студентов (коллекцию)
        private static List<Student> GetStudentList()
        {
            List<Student> students =
            [
                new Student(1, "Daniil", 20, 8.5),
                new Student(2, "Alexey", 22, 9.1),
                new Student(3, "Michail", 21, 7.3),
                new Student(4, "Sophia", 20, 8.7),
                new Student(5, "Maria", 23, 6.9)
            ];

            return students;
        }
    }
}