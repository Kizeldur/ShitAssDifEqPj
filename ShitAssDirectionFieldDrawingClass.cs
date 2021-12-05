using System;

namespace ShitAssDirectionFieldDrawingNamespace
{
    public class ShitAssDirectionFieldDrawingClass
    {
        public delegate double Difur(int x, Solution solution);
        
        public delegate double Solution(int x);

        static public double[] GiveMeSolution(Difur difur, Solution solution, int x)
        {
            double[] result = new double[x];
            for (int i = 0; i < x; i++)
            {
                var temp = difur(i, solution);
                var res = Math.Atan(temp);
                result[i] = temp;
            }
            return result;
        }

    }
}
