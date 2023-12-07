using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Lab4
{
    /// <summary>
    /// Информация о решении уравнения.
    /// </summary>
    public class Solution
    {
        private Equation equation;
        private double[] roots;
        public Solution(Equation equation, params double[] roots)
        {
            this.equation = equation;
            this.roots = roots;
        }

        /// <summary>
        /// Показывает, если корни у уравнения (действительные числа).
        /// </summary>
        public bool HasRoots
        {
            get
            {
                if (roots.Length == 0)
                {
                    return false;
                } else { return true; }
            }
        }

        /// <summary>
        /// Уравнение, для которого это решение.
        /// </summary>
        public Equation Equation
        {
            get
            {
                return equation;
            }
        }

        /// <summary>
        /// Коллекция действительных решений.
        /// </summary>
        public IEnumerable<double> Roots
        {
            get
            {
                return roots;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(equation.ToString());
            if (HasRoots) {
                if (roots[0] != double.MaxValue)
                {

                    sb.Append(" solution: x = " + roots[0]);
                    for (int i = 1; i < roots.Length; i++)
                    {
                        sb.Append("; " + roots[i]);
                    }
                } else {
                    sb.Append(" solution: x = infinitely many solutions");
                }
            } else 
            {
                sb.Append(" no solutions");
            }
            return sb.ToString();
        }

        /*void Save(string fileName, int method)
        {
            Solution objectOfSerializing = new Solution(this.equation, this.roots);
            switch (method)
            {
                case 1:
                    string jsonString = JsonSerializer.Serialize(objectOfSerializing);
                    File.WriteAllText(fileName, jsonString);
                    break;
                case 2:
                    XmlSerializer mySerializer = new XmlSerializer(typeof(Solution));
                    StreamWriter myWriter = new StreamWriter(fileName);
                    mySerializer.Serialize(myWriter, objectOfSerializing);
                    myWriter.Close();
                    break;
            }
        }*/
    }
}
