using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab4
{
    /// <summary>
    /// Описывает уравнение
    /// </summary>
    public class Equation
    {
        private IEnumerable<EquationMember> members;
        private Solution solution;

        public Equation(params EquationMember[] members)
        {
            this.members = members;
        }

        /// <summary>
        /// Получает коллекцию элементов полинома.
        /// </summary>
        public IEnumerable<EquationMember> Members
        {
            get
            {
                return members;
            }
        }

        /// <summary>
        /// Получает решения уравнения.
        /// </summary>
        public Solution Result
        {
            get
            {
                if (solution == null)
                    Solve();
                
                return this.solution;
            }
            private set { this.solution = value; }
        }

        /// <summary>
        /// Выполняет решение уравнения.
        /// </summary>
        public void Solve()
        {
            var x0 = members.ElementAt(0).Factor;
            var x1 = members.ElementAt(1).Factor;
            double x2 = -1;
            if (members.Count() == 3)
            {
                x2 = members.ElementAt(2).Factor;
            }
            if (members.Count() == 2 || x2 == 0)
            {
                if (x1 == 0 && x0 != 0)
                {
                    Result = new Solution(new Equation((EquationMember[])members));
                } else if (x1 == 0 && x0 == 0)
                {
                    Result = new Solution(new Equation((EquationMember[])members), double.MaxValue);
                } else {
                    Result = new Solution(new Equation((EquationMember[])members), -x0/ x1);
                }
            } else if (members.Count() == 3)
            {
                double D = x1*x1-4*x0*x2;
                if (D < 0)
                {
                    Result = new Solution(new Equation((EquationMember[])members));
                }
                else if (D == 0) 
                {
                    Result = new Solution(new Equation((EquationMember[])members), -x1/(2*x2));
                } else
                {
                    Result = new Solution(new Equation((EquationMember[])members), (-x1-Math.Sqrt(D) )/ (2 * x2), (-x1 + Math.Sqrt(D)) / (2 * x2));
                }
            }
            
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (members.Count() == 3 && members.ElementAt(2).Factor != 0)
            {
                sb.Append(members.ElementAt(2).Factor + " * x^2 ");
            }
            if (members.ElementAt(1).Factor != 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" + ");
                }
                sb.Append(members.ElementAt(1).Factor + " * x ");
            }
            if (members.ElementAt(0).Factor != 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" + ");
                }
                sb.Append(members.ElementAt(0).Factor + " ");
            }
            if (sb.Length == 0)
            {
                sb.Append("0 ");
            }
            sb.Append("= 0");
            return sb.ToString();
        }
    }
}