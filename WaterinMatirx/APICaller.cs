using System;
using System.Collections.Generic;

namespace WaterinMatirx
{
    public class APICaller
    {
        int[,] array2Da = new int[4, 4] { { 1, 2, 3, 2 }, { 3, 4, 5, 1 }, { 5, 6, 8, 9 }, { 7, 8, 2, 6 } };
        internal int GetStartX()
        {
           return 2;
        }

        internal int GetStartY()
        {
            return 2;
        }

        internal int GetMatrixWidth()
        {
            return 4;
        }

        internal int GetMatrixHeight()
        {
            return 4;
        }

        internal List<int> GetRow(int x)
        {
            List<int> singleRow = new List<int>();
            
                for (int j = 0; j < array2Da.GetLength(1); j++)
                {
                singleRow.Add(array2Da[x, j]);
                }
                Console.WriteLine("\n");
            
            return singleRow;

            //throw new NotImpleentedException();
        }

        internal int GetValue(int x, int y)
        {
            

            return array2Da[x,y];

        }

        
    }
}