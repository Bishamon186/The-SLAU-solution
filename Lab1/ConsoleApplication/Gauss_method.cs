using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Gauss_method
    {
        public double[] method(double[,] sole, int dimension, out double[] result, out double[,] triangularMatrix)
            {
                int xCount, yCount, Count = 0;
                int maxIndexX = 0, maxIndexY = 0;
                double tmp;
               
                int srtCo;
                double Coeff;
                double[] str = new double[dimension + 1];
                double maxValue = 0;
                double[] flag = new double[dimension];
                double sum = 0;
                double[] result_el = new double[3];

                for (int i = 0; i < dimension; i++)
                {
                    flag[i] = -1;
                }
                while (Count < dimension - 1)
                {

                    //Проверка на конкретные случаи
                    // CheckNULL(sole,dimension);

                    //Вычисление главного элемента
                    result_el = glav_el(sole, dimension, Count);
                    maxValue = result_el[0];
                    maxIndexX = (int) result_el[1];
                    maxIndexY = (int) result_el[2];


                    /*if (maxValue == 0) {
                        for (xCount = 0; xCount < dimension - 1; xCount++) {
    
                        }
    
                    }*/
                    //Меняем  строки и столбцы местами (для более удобного вычисления)
                    //столбцы
                    if (Count != maxIndexX)
                    {
                        for (yCount = 0; yCount <= dimension - 1; yCount++)
                        {
                            tmp = sole[yCount,Count];
                            sole[yCount,Count] = sole[yCount,maxIndexX];
                            sole[yCount,maxIndexX] = tmp;
                        }
                        flag[Count] = maxIndexX;
                    }
// строки
                    if (Count != maxIndexY)
                    {
                        for (xCount = Count; xCount <= dimension; xCount++)
                        {
                            tmp = sole[Count,xCount];
                            sole[Count,xCount] = sole[maxIndexY,xCount];
                            sole[maxIndexY,xCount] = tmp;
                        }
                    }

                    //Обнуление
                    //сохраняем первый ряд
                    srtCo = 0;
                    for (xCount = 0; xCount <= dimension; xCount++)
                    {
                        str[srtCo] = sole[Count,xCount];
                        srtCo++;
                    }

                    for (yCount = Count + 1; yCount <= dimension - 1; yCount++)
                    {
                        //находим коэффицент
                        Coeff = -(sole[yCount,Count] / maxValue);
                        
                        //Coeff = formatDouble(Coeff,1000);
                        //Coeff = (double)(Coeff/100);


                        //домножаем первый ряд на коэффицент
                        for (xCount = Count; xCount <= dimension; xCount++)
                        {
                            
                            sole[Count,xCount] =  sole[Count,xCount] * Coeff;

                        }
                        //вычитаем из след ряда первый

                        for (xCount = Count; xCount <= dimension; xCount++)
                        {
                            sole[yCount,xCount] = sole[yCount,xCount] + sole[Count,xCount];
                        }
                        //восстанавливаем первый ряд
                        srtCo = 0;
                        for (xCount = 0; xCount <= dimension; xCount++)
                        {

                            sole[Count,xCount] = str[srtCo];
                            srtCo++;
                        }

                    }
                    for (yCount = Count + 1; yCount <= dimension - 1; yCount++)
                    {
                        sole[yCount,Count] = 0;
                    }

                    /*for (xCount = Count; xCount <= dimension; xCount++) {
                        double tmp2 = sole[Count+1,xCount] - Math.Round((sole[Count,xCount] * sole[Count+1,Count]) / sole[Count,Count]);
                        sole[Count+1,Count] = tmp2;
                    }
                    for (yCount = Count + 1; yCount <= dimension - 1; yCount++)
                    {
                        sole[yCount,Count] = 0;
                    }*/

                    Count++;
                }
                //треугольная матрица
                triangularMatrix = new double[dimension,dimension+1];
                for (yCount = 0; yCount <= dimension - 1; yCount++)
                {
                    for (xCount = 0; xCount <= dimension; xCount++)
                        triangularMatrix[yCount,xCount] = sole[yCount,xCount];
                }
                // Обратный проход
                result = back_stroke(dimension, sole);
                //меняем местами неизветные
                for (int i = 0; i < dimension; i++)
                {
                    if (flag[i] != -1)
                    {
                        tmp = result[(int)flag[i]];
                        result[(int)flag[i]] = result[i];
                        result[i] = tmp;
                    }
                }
                
                return result;
            }

            public double[] glav_el(double[,] sole, int dimension, int Count)
            {
                int xCount = Count, yCount = Count;
                double maxValue = 0;
                int maxIndexX = 0, maxIndexY = 0;
                double[] max = new double[3];
                maxValue = sole[yCount,xCount];
                for (xCount = Count; xCount <= dimension - 1; xCount++)
                {
                    for (yCount = Count; yCount <= dimension - 1; yCount++)
                    {
                        if (maxValue < sole[yCount,xCount])
                        {
                            maxValue = sole[yCount,xCount];
                            maxIndexX = xCount;
                            maxIndexY = yCount;
                        }
                    }
                }
                max[0] = maxValue;
                max[1] = maxIndexX;
                max[2] = maxIndexY;
                return max;
            }

            double[] back_stroke(int dimension, double[,] sole)
            {
                double[] result = new double[dimension];
                int yCount, xCount;
                double sum;
                result[dimension - 1] = sole[dimension - 1,dimension] / sole[dimension - 1,dimension - 1];
                for (yCount = dimension - 2; yCount >= 0; yCount--)
                {
                    sum = 0;
                    for (xCount = dimension - 1; xCount >= yCount; xCount--)
                    {
                        sum += sole[yCount,xCount] * result[xCount];
                    }
                    result[yCount] = (sole[yCount,dimension] - sum) / sole[yCount,yCount];
                }

                return result;

            }

        
        

            /*  double formatDouble(double d, int dz)
              {
                  double dd=Math.pow(10,dz);
                  return Math.round(d*dd)/dd;
              }*/
            /*private int CheckNULL (double[][] sole,int dimension){
                int check = 0;
                int sum;
                int xCount, yCount;
                for (xCount = 0; xCount < dimension - 1; xCount++) {
        
                    for (yCount = 0; yCount < dimension; yCount++) {
        
                    }
                }
                return check;
            }*/
    }

    
}