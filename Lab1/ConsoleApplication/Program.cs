using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int menu, menu_dimension;
            double[,] matrix;
            Ui ui = new Ui();
            menu = ui.menu_1();
           
           
            switch (menu)
            {
                case 1:
                    menu_dimension = ui.menu_dimension();
                    matrix = new double[menu_dimension,menu_dimension + 1];
                    matrix = ui.file(menu_dimension);
                    work(menu_dimension,matrix);
                    
                    break;
                case 2:
                    menu_dimension = ui.menu_dimension();
                    matrix = new double[menu_dimension,menu_dimension + 1];
                    matrix = ui.menu_matrix(menu_dimension);
                    work(menu_dimension,matrix);
                    break;
                case 3:
                    Console.WriteLine("Error: Choose '1' or '2' ");
                    break;


            }
            
            
        }

        static void work(int menu_dimension, double[,]matrix)
        {
            double[,] start_matrix;
            double[] matrix_2;
            double[] result;
            double[,] triangularMatrix;
            Ui ui = new Ui();
            double[] discrep;
            Discrepancies discrepancies = new Discrepancies();
            Gauss_method gauss = new Gauss_method();
            start_matrix = new double[menu_dimension,menu_dimension+1];
            for (int i = 0; i <= menu_dimension - 1; i++)
            {
                for (int j = 0; j <= menu_dimension; j++)
                    start_matrix[i,j] = matrix[i,j];
            }
            matrix_2 = new double[menu_dimension];
            result = new double[menu_dimension];
            triangularMatrix = new double[menu_dimension,menu_dimension+1];
            matrix_2 = gauss.method(matrix, menu_dimension,out result,out triangularMatrix);
                    
            discrep   = new double[menu_dimension];
            discrep = discrepancies.discrepancies(start_matrix,result,menu_dimension);
            ui.output_result(matrix_2, menu_dimension, discrep, start_matrix,triangularMatrix);
        }
        
        
        

    }
    
    
        
}