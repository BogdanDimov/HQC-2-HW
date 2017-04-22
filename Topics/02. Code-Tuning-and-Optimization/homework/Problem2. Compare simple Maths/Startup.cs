using System;

namespace Problem2.Compare_simple_Maths
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("***Addition***");
            Add.TestAddDecimal();
            Add.TestAddDouble();
            Add.TestAddFloat();
            Add.TestAddInt();
            Add.TestAddLong();

            Console.WriteLine("\n***Multiplication***");
            Multiply.TestMultiplyDecimal();
            Multiply.TestMultiplyDouble();
            Multiply.TestMultiplyFloat();
            Multiply.TestMultiplyInt();
            Multiply.TestMultiplyLong();

            Console.WriteLine("\n***Incrementation***");
            Increment.TestIncrementDecimal();
            Increment.TestIncrementDouble();
            Increment.TestIncrementFloat();
            Increment.TestIncrementInt();
            Increment.TestIncrementLong();

            Console.WriteLine("\n***Division***");
            Divide.TestDivideDecimal();
            Divide.TestDivideDouble();
            Divide.TestDivideFloat();
            Divide.TestDivideInt();
            Divide.TestDivideLong();

            Console.WriteLine("\n***Subtraction***");
            Subtract.TestSubtractDecimal();
            Subtract.TestSubtractDouble();
            Subtract.TestSubtractFloat();
            Subtract.TestSubtractInt();
            Subtract.TestSubtractLong();
        }
    }
}
