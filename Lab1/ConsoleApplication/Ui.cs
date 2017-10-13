using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication
{
    public class Ui {
        public  int menu_1 (){
            int menu;
            
            Console.WriteLine("Привет! Выберете способ ввода матрицы:\n\t 1-Из файла\n\t 2-Вручную");
            menu = Convert.ToInt32(Console.ReadLine()); //Доделать защиту от дурака
            if (menu !=1 && menu !=2)
            {
                menu = 3;
            }
            return menu;
        }

        public int menu_dimension (){
            int dimension;
                
            Console.WriteLine("Введите размерность матрицы (от 1 до 20)");//Доделать защиту от дурака
            dimension = Convert.ToInt32(Console.ReadLine());
            return dimension;
        }

        public double[,] menu_matrix (int dimension){
            int i,j;
            double [,] matrix ;
            int[] count = new int[dimension];
            matrix = new double[dimension,dimension+1];
            Console.WriteLine("Введите кэффиценты");
            
            for (int q = 0; q < dimension; q++)
            {
                count[q] = q;
            }
             
            for (i=0;i<=dimension-1;i++)
            {
                for (j=0;j<=dimension;j++)
                {
                    if (j != dimension)
                    {
                        Console.Write("X" + count[j]+ " = " );
                        
                    }
                    else
                    {
                        Console.Write("B" + " = " );
                        
                    }
                    matrix[i,j]=Convert.ToDouble(Console.ReadLine());  //Доделать защиту от дурака
                    Console.WriteLine("");
                    
                }
            }

            return matrix;

        }

        public void output_result(double[]result, int dimension, double[] discrep, double[,]start_matrix,double[,]triangularMatrix) {
            int xCount;
            int yCount;
            int[] count = new int[dimension];
            for (int i = 0; i<=dimension-1;i++)
            {
                count[i]=i;
            }
                
            Console.WriteLine("Исходная матрица:");
            for (yCount = 0; yCount <= dimension - 1; yCount++)
            {
                for (xCount = 0; xCount <= dimension ; xCount++)
                {
                    Console.Write("{0,10:f3}",start_matrix[yCount,xCount]);
                    Console.Write((" "));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("Треугольная матрица:");
            for (yCount = 0; yCount <= dimension - 1; yCount++)
            {
                for (xCount = 0; xCount <= dimension ; xCount++)
                {
                    Console.Write("{0,10:f3}",triangularMatrix[yCount,xCount]);
                    Console.Write(("          "));

                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("Результат:");
            for (xCount = 0; xCount <= dimension-1; xCount++) {
                Console.WriteLine("X" + count[xCount]+ " = " + result[xCount]);
            }
            Console.WriteLine("Погрешность:");
            for (xCount = 0; xCount <= dimension-1; xCount++) {
                Console.WriteLine("X" + count[xCount]+ " = " + discrep[xCount]);
            }
        }

        public double[,] file(int dem)
        {
            string fileName,line;
            string[] line2;
            double[,] matrix = new double[dem,dem+1];
            double[,] rmatrix;
            char[] charr = new char[] {' '};
            Console.WriteLine("Введите путь к файлу:");
            fileName = Console.ReadLine();
            StreamReader file = new StreamReader(fileName);
            
                
                for (int i = 0; i < dem; i++)
                { 
                    line = file.ReadLine();
                    line2 = line.Split(charr);
                    for (int j = 0; j <= dem; j++)
                    {
                        matrix[i,j] = Convert.ToDouble(line2[j]);
                    }
                    
                }
            
            
            return matrix;
        }
    }
    
    
}