using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextIntCalculator
{
    public interface IIntCalculator
    {
        public int Result { get; }
        void Reset();
        void Add(int x);
        void Sub(int x);
        void Mul(int x);
        void Div(int x);
        void Mod(int x);
    }
}
