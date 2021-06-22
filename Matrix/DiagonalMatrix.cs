using System;

namespace Matrix
{
    public class DiagonalMatrix : SquareMatrix
    {
        public DiagonalMatrix(double[] numbers) : base(numbers)
        {
            base.RowLength = numbers.Length;
        }


        public override double this[int i, int j]
        {
            get
            {
                if (i >= RowLength | j >= RowLength | i < 0 | j < 0)
                {
                    throw new Exception($"Exception in {this.GetType()}\nElement [{i},{j}] out of matrix size {RowLength}");
                }
                if (i == j)
                {
                    return base[0, j];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (i >= RowLength | j >= RowLength | i < 0 | j < 0)
                {
                    throw new Exception($"Exception in {this.GetType()}\nElement [{i},{j}] out of matrix size {RowLength}");
                }
                else if (i == j)
                {
                    base[0, j] = value;
                }
                else
                {
                    throw new Exception("Access denied");
                }
            }
        }
    }
}
