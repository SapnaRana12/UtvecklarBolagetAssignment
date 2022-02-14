using System;
using System.Collections.Generic;

namespace WaterinMatirx
{

    class Program
    {
        private APICaller api;
        public static int ways { get; set; }
        public static int allways { get; set; }
        public static Dictionary<Tuple<int, int>, int> possiblewaydict = new Dictionary<Tuple<int, int>, int>();
        static void Main(string[] args)
        {
            APICaller api = new APICaller();
            int x = api.GetStartX();
            int y = api.GetStartY();
            int matrixwidth = api.GetMatrixWidth();
            int matrixHeight = api.GetMatrixHeight();         
            

            ways = AllTheStartWay(x, y, matrixwidth, matrixHeight);
            GetAllThePossibleWays(x, y, matrixwidth, matrixHeight);
            allways = possiblewaydict.Values.Count + 1;// +1 for adding starting index 
            printarray();
            InitialDirections();
            NumberOfWetIndexes();

        }

        public static int InitialDirections()
        {
            Console.WriteLine("All the Possible Way to Start : {0}", ways);
            return ways;
        }

        /**
         * Task 2: Return the number of indexes the water can reach when flowing
         * through the matrix (including the starting point).
         */
        public static int NumberOfWetIndexes()
        {
            Console.WriteLine("Number of Indexes can Travel : {0}", allways);
            return allways;
        }
        private static int AllTheStartWay(int x, int y,
                                     int width,
                                     int height)
        {

            APICaller api = new APICaller();

            int ways = 0;
            if (x - 1 >= 0 && api.GetValue(x, y) >= api.GetValue(x - 1, y))
            {
                ways += 1;
            }
            if (x + 1 < width && api.GetValue(x, y) >= api.GetValue(x + 1, y))
            {
                ways += 1;
            }
            if (y - 1 >= 0 && api.GetValue(x, y) >= api.GetValue(x, y - 1))
            {
                ways += 1;
            }
            if (y + 1 < height && api.GetValue(x, y) >= api.GetValue(x, y + 1))
            {

                ways += 1;
            }


            return ways;
        }


        private static void GetAllThePossibleWays(int x, int y,
                                    int width,
                                    int height)
        {

            APICaller api = new APICaller();
            int[,] matrix1 = matrix();

            if (x - 1 >= 0 && api.GetValue(x, y) >= api.GetValue(x - 1, y))
            {

                if (!possiblewaydict.ContainsKey(Tuple.Create(x - 1, y)))
                {

                    possiblewaydict.Add(Tuple.Create(x - 1, y), api.GetValue(x - 1, y));

                    GetAllThePossibleWays(x - 1, y, width, height);

                }
            }
            if (x + 1 < width && api.GetValue(x, y) >= api.GetValue(x + 1, y))
            {
                if (!possiblewaydict.ContainsKey(Tuple.Create(x + 1, y)))
                {
                    possiblewaydict.Add(Tuple.Create(x + 1, y), api.GetValue(x + 1, y));

                    GetAllThePossibleWays(x + 1, y, width, height);

                }


            }
            if (y - 1 >= 0 && api.GetValue(x, y) >= api.GetValue(x, y - 1))
            {
                if (!possiblewaydict.ContainsKey(Tuple.Create(x, y - 1)))
                {
                    possiblewaydict.Add(Tuple.Create(x, y - 1), api.GetValue(x, y - 1));
                    GetAllThePossibleWays(x, y - 1, width, height);
                }


            }
            if (y + 1 < height && api.GetValue(x, y) >= api.GetValue(x, y + 1))
            {
                if (!possiblewaydict.ContainsKey(Tuple.Create(x, y + 1)))
                {
                    possiblewaydict.Add(Tuple.Create(x, y + 1), api.GetValue(x, y + 1));
                    GetAllThePossibleWays(x, y + 1, width, height);
                }


            }





        }



        static void printarray()
        {

            int[,] array2Da = matrix();
            Console.WriteLine("Elements in the Given Matrix : ");
            for (int i = 0; i < array2Da.GetLength(0); i++)
            {
                for (int j = 0; j < array2Da.GetLength(1); j++)
                {
                    Console.Write(array2Da[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }
        static int[,] matrix()
        {
            APICaller api = new APICaller();
            int matrixwidth = api.GetMatrixWidth();
            int matrixHeight = api.GetMatrixHeight();

            int[,] array2Da = new int[matrixHeight, matrixwidth];
            for (int i = 0; i < matrixHeight; i++)
            {
                List<int> possiblew = api.GetRow(i);

                for (int j = 0; j < matrixwidth; j++)
                {
                    array2Da[i, j] = possiblew[j];
                }


            }
            return array2Da;

        }
    }
}



