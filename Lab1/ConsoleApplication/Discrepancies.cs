namespace ConsoleApplication
{
    public class Discrepancies
    {
        public double[] discrepancies(double[,] smatrix, double[]res,  int dimension)
        {
            double[] B = new double[dimension];
            double[,] A = new double[dimension,dimension];
            double[] discrep = new double[dimension];
            double[] AX = new double[dimension];
            double sum;
            int yCount;
            int xCount;

            for ( yCount = 0;  yCount< dimension; yCount++)
            {
                B[yCount] = smatrix[yCount,dimension];
            }
            
            for ( yCount = 0;  yCount< dimension; yCount++)
            {
                for ( xCount = 0; xCount < dimension; xCount++)
                {
                    A[yCount, xCount] = smatrix[yCount, xCount];
                }
               
            }

            for (yCount = 0; yCount < dimension; yCount++)
            {
                sum = 0;
                for (xCount = 0; xCount < dimension; xCount++)
                {
                    sum += smatrix[yCount, xCount] * res[xCount];
                        
                }
                AX[yCount] = sum;
            }

            for (yCount = 0; yCount < dimension; yCount++)
            {
                discrep[yCount] = B[yCount] - AX[yCount];
            }

            return discrep;
        }
    }
}