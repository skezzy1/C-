using System;

namespace MyNamespace
{
    public class MyAccessModifiers
    {
        private int birthYear;
        protected string personalInfo;
        internal string IdNumber;

        public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            this.IdNumber = idNumber;
            this.personalInfo = personalInfo;
            this.Name = "";
            this.NickName = "";
        }

        public int Age
        {
            get
            {
                int currentYear = DateTime.Now.Year;
                return currentYear - birthYear;
            }
        }
        public byte averageMiddleAge { get; } = 50;
        public string Name { get; set; }

        public string NickName { get; internal set; }

        protected internal bool HasLivedHalfOfLife()
        {
            return Age >= averageMiddleAge;
        }

        public static bool operator ==(MyAccessModifiers obj1, MyAccessModifiers obj2)
        {
            if (ReferenceEquals(obj1, obj2))
                return true;

            if (obj1 is null || obj2 is null)
                return false;

            return obj1.Name == obj2.Name && obj1.Age == obj2.Age && obj1.personalInfo == obj2.personalInfo;
        }

        public static bool operator !=(MyAccessModifiers obj1, MyAccessModifiers obj2)
        {
            return !(obj1 == obj2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage:
            MyAccessModifiers person1 = new MyAccessModifiers(1990, "ID123", "John Doe");
            person1.Name = "John";
            person1.NickName = "Johnny";

            MyAccessModifiers person2 = new MyAccessModifiers(1990, "ID123", "John Doe");
            person2.Name = "Jane";
            person2.NickName = "Jenny";

            Console.WriteLine($"Person 1: {person1.Name}, Age: {person1.Age}");
            Console.WriteLine($"Person 2: {person2.Name}, Age: {person2.Age}");


            Console.WriteLine($"Are they equal? {person1 == person2}");
        }
    }
}
