using KR1._2;
using System.Xml.Linq;

namespace KR1._2{
    class Program
    {
        static void Main()
        {
            List<Student> students = GetStudentList();
            PrintNames(students);
            FilterStudents(students);
            SortStudentsByAge(students);
            AggregateOperationsForStuds(students);
            GroupStudentsByAge(students);
        }

        //Выборка по имени
        private static void PrintNames(List<Student> students)
        {
            Console.WriteLine("\nВыборка:");
            var studentNames = students.Select(s => s.Name);
            foreach (var name in studentNames)
            {
                Console.WriteLine(name);
            }
        }

        //Фильтрация по условию
        private static void FilterStudents(List<Student> students)
        {
            Console.WriteLine("\nФильтрация:");
            var filteredStudents = students.Where(s => s.Score > 8);
            foreach (var student in filteredStudents) { 
                Console.WriteLine($"{student.Name} - {student.Score}");
            }
        }

        //Сортировка студентов по возрасту
        private static void SortStudentsByAge(List<Student> students)
        {
            var sortedStudents = students.OrderBy(s => s.Age);
            Console.WriteLine("\nСтуденты, отсортированные по возрасту:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.Name} - {student.Age}");
            }
        }


        //агрегатные операции
        private static void AggregateOperationsForStuds(List<Student> students)
        {
            Console.WriteLine("\nМинимальный средний балл: " + students.Min(s => s.Score));
            Console.WriteLine("\nМаксимальный средний балл: " + students.Max(s => s.Score));
            Console.WriteLine("\nСредний средний балл: " + students.Average(s => s.Score));
            Console.WriteLine("\nСуммарный средний балл: " + students.Sum(s => s.Score));
        }

        //группировка по возврасту
        private static void GroupStudentsByAge(List <Student> students)
        {
            var groupByAge = students.GroupBy(s => s.Age);
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