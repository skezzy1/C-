using System;

class Employee
{
    internal string name;
    private DateTime hiringDate;

    public Employee(string name, DateTime hiringDate)
    {
        this.name = name;
        this.hiringDate = hiringDate;
    }

    public int Experience()
    {
        DateTime currentDate = DateTime.Now;
        int experience = currentDate.Year - hiringDate.Year;
        if (currentDate.Month < hiringDate.Month || (currentDate.Month == hiringDate.Month && currentDate.Day < hiringDate.Day))
        {
            experience--;
        }
        return experience;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{name} has {Experience()} years of experience");
    }
}

class Developer : Employee
{
    private string programmingLanguage;

    public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
    {
        this.programmingLanguage = programmingLanguage;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"{name} is {programmingLanguage} programmer");
    }
}

class Tester : Employee
{
    private bool isAutomation;

    public Tester(string name, DateTime hiringDate, bool isAutomation) : base(name, hiringDate)
    {
        this.isAutomation = isAutomation;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        string type = isAutomation ? "automated" : "manual";
        Console.WriteLine($"{name} is {type} tester and has {Experience()} year(s) of experience");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Developer dev = new Developer("Mega John", new DateTime(2018, 5, 15), "C#");
        dev.ShowInfo();


        Tester tester1 = new Tester("Super Bob", new DateTime(2016, 8, 20), false);
        tester1.ShowInfo();

        Tester tester2 = new Tester("and Serhii", new DateTime(2017, 3, 10), true);
        tester2.ShowInfo();
    }
}
