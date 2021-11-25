using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace pr_32_prakt17_3_OAP_ZhuravlevTimofeyVasilievich
{
    class Program
    {
        static void Main(string[] args)
        {
            string curFile1 = "input.txt";
            Console.WriteLine(File.Exists(curFile1) ? "Файл уже создан" : "Создан файл 'input.txt'");
            StreamReader sr = new StreamReader("input.txt");

            string curFile2 = "output.txt";
            Console.WriteLine(File.Exists(curFile2) ? "Файл уже создан" : "Создан файл 'output.txt'");
            StreamWriter sw = new StreamWriter("output.txt");

            List<Student> students = new List<Student>();
            string str;
            while ((str = sr.ReadLine()) != null)
            {
                string[] t = str.Split(' ');
                students.Add(new Student { F = t[0], I = t[1], O = t[2], GROUP = t[3], BALL = Convert.ToDouble(t[4]) });
            }

            double max = students.Max(point => point.BALL);
            Console.WriteLine("\nМаксимальный средний балл= " + max);
            sw.WriteLine("Минимальный средний балл= " + max);

            double min = students.Min(point => point.BALL);
            Console.WriteLine("\nМинимальный средний балл= " + min);
            sw.WriteLine("Минимальный средний балл= " + min);

            Console.WriteLine("Произвести сортировку по:('1'-убывание '2'-возрастание)");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    var sortedStudents = from s in students
                                         orderby s.BALL descending
                                         select s;
                    Console.WriteLine("\nСортировка по среднему баллу(убывание):");
                    sw.WriteLine("Сортировка по среднему баллу(убывание):");
                    foreach (Student s in sortedStudents)
                    {
                        Console.WriteLine($"{s.F} - {s.I} - {s.O} - {s.GROUP} - {s.BALL}");
                        sw.WriteLine($"{s.F} - {s.I} - {s.O} - {s.GROUP} - {s.BALL}");
                    }
                    break;
                case 2:
                    var sortedStudents1 = from s in students
                                          orderby s.BALL ascending
                                          select s;
                    Console.WriteLine("\nСортировка по среднему баллу (возрастание):");
                    sw.WriteLine("Сортировка по среднему баллу (возрастание):");
                    foreach (Student s in sortedStudents1)
                    {
                        Console.WriteLine($"{s.F} - {s.I} - {s.O} - {s.GROUP} - {s.BALL}");
                        sw.WriteLine($"{s.F} - {s.I} - {s.O} - {s.GROUP} - {s.BALL}");
                    }
                    break;
            }
            sw.Close();
            Console.ReadLine();
        }
    }
    internal class Student
    {
        public string F { get; set; }
        public string I { get; set; }
        public string O { get; set; }
        public string GROUP { get; set; }
        public double BALL { get; set; }
    }

}