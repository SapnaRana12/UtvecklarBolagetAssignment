using System;
using System.Collections.Generic;

namespace SilverTrading
{
    class Program
    {
       
            public int buyDay { get; set; }
            public int sellDay { get; set; }
                Program()
                {
                Tuple<int, int> buySellDay = GetpricesoftheDays();
                buyDay = buySellDay.Item1;
                sellDay = buySellDay.Item2;

                }

        
        static void Main(string[] args)
        {
            Tuple<int, int> buySellDay = GetpricesoftheDays();
            Program program = new Program();           
            Console.WriteLine("Buy Day should be" + program.GetBuyDay());
            Console.WriteLine("Sell Day should be" + program.GetSellDay());
        }
        public  int GetBuyDay()
        {
           
            return buyDay;
           
        }
        /** 
        * Return the day to sell silver on. This day has to be after (greater * than) the buy day. The first day has number zero (although this is not * a valid sell day). This method is called second, and only once. */
        public   int GetSellDay()
        {
            return sellDay;
           
        }

        public static int GetNumDays()
        {
            return 10;
        }
        public static int GetPriceOnDay(int day)
        {
            int i = 0;
            switch (day)
            {
                case 0:
                    i = 7;
                    break;
                case 1:
                    i = 1;
                    break;
                case 2:
                    i = 5;
                    break;
                case 3:
                    i = 9;
                    break;
                case 4:
                    i = 2;
                    break;
                case 5:
                    i = 5;
                    break;
                case 6:
                    i = 4;
                    break;
                case 7:
                    i = 8;
                    break;
                case 8:
                    i = 9;
                    break;
                case 9:
                    i = 6;
                    break;
                case 10:
                    i = 9;
                    break;
                
                default:
                    i = 7;
                    break;
            }
            return i;
        }

        public static Tuple<int, int> GetpricesoftheDays()
        {
            int numberofdays = GetNumDays();
            int[] priceforthedays = new int[numberofdays];
            
            for (int i = 0; i < numberofdays; i++)
            {
                int priceoftheDay = GetPriceOnDay(i);
                priceforthedays[i] = priceoftheDay;
            }

           return maxDiff(priceforthedays, numberofdays);
            
        }

        static Tuple<int,int> maxDiff(int[] arr, int arr_size)
        {
            int max_diff = arr[1] - arr[0];
            int buyday = arr[0];
            int sellDay = arr[1];
            int i, j;
            for (i = 0; i < arr_size; i++)
            {
                for (j = i + 1; j < arr_size; j++)
                {
                    if (arr[j] - arr[i] > max_diff)
                    {
                        max_diff = arr[j] - arr[i];
                        buyday = i;
                        sellDay = j;
                    }

                }
            }
            return Tuple.Create(buyday, sellDay);

            
        }

    }
}
