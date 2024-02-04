using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> stu = new List<Student>();
            int opt;
            do
            {
                Console.WriteLine("Enter 1 to add students");
                Console.WriteLine("Enter 2 to display students");
                Console.WriteLine("Enter 3 to calculate aggregate");
                Console.WriteLine("Enter 4 to watch top students");
                Console.WriteLine("Enter 0 to exit");
                Console.Write("Choose an option...");
                opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    addStudent(stu);
                }
                else if (opt == 2)
                {
                    Console.WriteLine("Name \t Matric Marks \t Fsc Marks \t Ecat Marks ");
                    for (int i = 0; i < stu.Count; i++)
                    {
                        stu[i].displayStudents();
                    }
                }
                else if(opt == 3)
                {
                    for(int i=0; i<stu.Count;i++)
                    {
                        stu[i].agg = stu[i].calculateAggregate();
                    }
                }
                else if(opt==4)
                {
                    top3Students(stu);
                }
                Console.ReadKey();

            } while (opt != 0);
        }
        static void addStudent(List<Student> stu)
        {
            string name;
            int mM, fM, eM;
            name = Console.ReadLine();
            mM = int.Parse(Console.ReadLine());
            fM = int.Parse(Console.ReadLine());
            eM = int.Parse(Console.ReadLine());
            Student student = new Student(name, mM, fM, eM);
            stu.Add(student);
            Console.WriteLine("Student added");
        }
        static void top3Students(List<Student> stu)
        {
            stu.Sort((student1, student2) => student2.agg.CompareTo(student1.agg));
            Console.WriteLine("<-------------------TOP STUDENTS----------------->");
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(stu[i].name + "\t \t \t " + stu[i].agg);
            }

        }
    }
}
