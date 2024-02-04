using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class Student
    {
        public string name;
        public int mMarks;
        public int fMarks;
        public int eMarks;
        public float agg;
        public Student(string name, int mMarks, int fMarks, int eMarks)
        {
            this.name = name;
            this.mMarks = mMarks;
            this.fMarks = fMarks;
            this.eMarks = eMarks;
        }
        public float calculateAggregate()
        {      
            return ((mMarks / 1100.0f) * 17) + ((fMarks / 520.0f) * 50) + ((eMarks / 400.0f) * 33);
        }
        public void displayStudents()
        {
            Console.WriteLine(name + "\t" + mMarks + "\t \t" + fMarks + "\t \t" + eMarks);
        }
    }
}
