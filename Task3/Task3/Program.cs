using System;

public delegate double CalcDelegate(double num1, double num2, char op);

public class CalcProgram
{
    public static double Calc(double num1, double num2, char op)
    {
        switch (op)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                if (num2 != 0)
                    return num1 / num2;
                else
                    return 0; // Return 0 when denominator is 0
            default:
                throw new ArgumentException("Invalid operator");
        }
    }

    public CalcDelegate funcCalc;

    public CalcProgram()
    {
        funcCalc = new CalcDelegate(Calc);
    }
}

class Program
{
    static void Main(string[] args)
    {
        CalcProgram calcProgram = new CalcProgram();

        double result1 = calcProgram.funcCalc(5, 3, '+'); 
        double result2 = calcProgram.funcCalc(5, 3, '-'); 
        double result3 = calcProgram.funcCalc(5, 3, '*'); 
        double result4 = calcProgram.funcCalc(5, 0, '/'); 
        double result5 = calcProgram.funcCalc(5, 0, '+'); 

        Console.WriteLine("Result1: " + result1);
        Console.WriteLine("Result2: " + result2);
        Console.WriteLine("Result3: " + result3);
        Console.WriteLine("Result4: " + result4);
        //Console.WriteLine("Result5: " + result5);
    }
}
