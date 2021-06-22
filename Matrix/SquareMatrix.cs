using System;
using System.Text;

namespace Matrix
{
    public class SquareMatrix
    {
        public double[] Matrix { get; protected set; }
        public int RowLength { get; protected set; }


        public SquareMatrix(double[] numbers)
        {
            this.Matrix = numbers;
            this.RowLength = (int)Math.Sqrt(numbers.Length);
        }


        public virtual double this[int i, int j]
        {
            get
            {
                if (i >= RowLength | j >= RowLength | i < 0 | j < 0)
                {
                    throw new Exception($"Exception in {this.GetType()}\nElement [{i},{j}] out of matrix size {RowLength}");
                } 
                else
                {
                    int index = RowLength * i + j;
                    return Matrix[index];
                }
            }
            set
            {
                if (i >= RowLength | j >= RowLength | i < 0 | j < 0)
                {
                    throw new Exception($"Exception in {this.GetType()}Element [{i},{j}] out of matrix size {RowLength}");
                }
                else
                {
                    int index = RowLength * i + j;
                    Matrix[index] = value;
                }
            }
        }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < RowLength; i++)
            {
                for (int j = 0; j < RowLength; j++)
                {
                    output.Append(this[i, j] + " ");
                }
                output.Append("\n");
            }
            return output.ToString();
        }
    }
}
