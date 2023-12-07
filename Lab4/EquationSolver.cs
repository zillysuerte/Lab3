using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab4
{
    /// <summary>
    /// Решалка уравнений
    /// </summary>
    public class EquationSolver
    {
        private List<Solution> solutions;

        public EquationSolver()
        {
            this.solutions = new List<Solution>();
        }


        /*
        /// <summary>
        /// Получает коллекцию уравнений, с которыми работал пользователь.
        /// </summary>
        public IEnumerable<Equation> Equations
        {
            get
            {
                throw new NotImplementedException("");
            }
        }

        */

       /*
        
        /// <summary>
        /// Возвращает уравнение по заданному индексу.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Equation this[int index]
        {
            get
            {
                throw new NotImplementedException("");
            }
        }
       */


        /// <summary>
        /// Добавляет уравнение в коллекцию.
        /// </summary>
        /// <param name="equation"></param>
        public void Add(Solution solution)
        {
            solutions.Add(solution);
        }


        public int Size()
        {
            return solutions.Count;
        }


        /*
        /// <summary>
        /// Удаляет уравнение из коллекции
        /// </summary>
        /// <param name="equation"></param>
        public void Remove(Equation equation)
        {
            throw new NotImplementedException("");
        }*/

        /// <summary>
        /// Получает уравнение по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Solution GetEquationAt(int index)
        {
            return solutions.ElementAt(index);
        }
    }
}
