using System;

namespace MyNextIntCalculator
{
    public class IntCalculator : IIntCalculator
    {
        public int Result { get; private set;}

        public IntCalculator()
        {
            Reset();
        }

        public void Add(int x)
        {
            if (x >= 0 && (Result + x) < Result)
            { 
                throw new InvalidOperationException("Overflow while adding");
            }
            
            if (x < 0 && (Result + x) > Result)
            { 
                throw new InvalidOperationException("Underflow while adding");
            }
            
            Result += x;
        }

        public void Div(int x)
        {
            if (x == 0)
                throw new InvalidOperationException("Division by zero is undefined");
            Result /= x;
        }

        public void Mod(int x)
        {
            Result %= x;
        }

        public void Mul(int x)
        {
           if (Result > 0 && x > int.MaxValue / Result )
                throw new InvalidOperationException("Overflow while multiplying");
            if (Result < 0 && x < int.MinValue / Result)
                throw new InvalidOperationException("Underflow while multiplying");
            Result *= x;
        }

        public void Reset()
        {
            Result = 0;
        }

        public void Sub(int x)
        {
            if (x > 0 && Result - x > Result)
                throw new InvalidOperationException("Underflow while subtracting");
            if (x < 0 && Result - x < Result)
                throw new InvalidOperationException("Overflow while subtracting");
            Result -= x;
        }
    }
}
