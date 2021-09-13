using System;

namespace MyNextIntCalculator
{
    public class IntCalculator : IIntCalculator
    {
        public int Result { get; private set;}

        public IntCalculator()
        {
            Result = 0;
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
            throw new NotImplementedException();
        }

        public void Mod(int x)
        {
            throw new NotImplementedException();
        }

        public void Mul(int x)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
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
