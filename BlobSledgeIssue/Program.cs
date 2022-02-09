using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlobSledgeIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            var pointns = GetListofPoints();
            pointns.Insert(0, 0);
            pointns.Add(0);
            Console.WriteLine("Please Enter the starting point or press enter button to get the Optimal starting point");
            int startingPoint;
            if (int.TryParse(Console.ReadLine(), out startingPoint))
            {
                TheFarthestDistance(startingPoint, pointns);
            }
            else
            {
                

                TheFarthestDistancestartingPoint(pointns);
            }
            


        }
        private static List<int> GetListofPoints()
        {
            var listofPoints = new List<int>();
            var exitValue = 0;
            do
            {
                Console.WriteLine("Enter sledge point or  press 0 to end of the Sledge Points...");
                exitValue = Convert.ToInt32(Console.ReadLine());
                if (exitValue == 0)
                {
                    break;
                }
                listofPoints.Add(exitValue);

            } while (exitValue != 0);
            return listofPoints;
        }
        private static void TheFarthestDistance(int startingPoint, List<int> points)
        {
            int stepsToGoLeft = 0;
            int stepsToGoRight = 0;
            StringBuilder steptoFollow = new StringBuilder("Bob can travel steps sideways");
            
               
            if (startingPoint + 1 < points.Count && startingPoint - 1 > 0)
            {
                
                if (points[startingPoint + 1] >= points[startingPoint] && points[startingPoint - 1] >= points[startingPoint])
                {
                   Console.WriteLine(steptoFollow.Insert(15,0));
                }
                else
                {
                    if (points[startingPoint] > points[startingPoint + 1])
                    {
                        stepsToGoRight += 1;
                        for (int i = startingPoint+1; i < points.Count-1; i++)
                        {
                            if (points[i] > points[i + 1])
                            {
                                stepsToGoRight += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (points[startingPoint] > points[startingPoint - 1])
                    {
                        stepsToGoLeft += 1;
                        for (int i = startingPoint-1; i > 0; i--)
                        {
                            if (points[i] > points[i - 1])
                            {
                                stepsToGoLeft += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine(steptoFollow.Insert(15,(stepsToGoLeft >= stepsToGoRight ? stepsToGoLeft: stepsToGoRight)));
                    
                }
            }
            
           
            
            
        }
        private static void TheFarthestDistancestartingPoint(List<int> points)
        {
            
                int startingPoint
        = !points.Any() ? -1 :
        points
        .Select((value, index) => new { Value = value, Index = index })
        .Aggregate((a, b) => (a.Value > b.Value) ? a : b)
        .Index;
                int stepsToGoLeft = 0;
                int stepsToGoRight = 0;
               
                
                StringBuilder steptoFollow = new StringBuilder("Bob can travel steps sideways");


                if (startingPoint + 1 < points.Count && startingPoint - 1 > 0)

                {
                    int actualstartpoint = startingPoint;
                    int leftstartingPoint = startingPoint;
                    for (int star=1; star < startingPoint; star++)
                    {
                        
                       if( points[startingPoint - star] == points[startingPoint] && actualstartpoint != 0)
                        {
                            actualstartpoint = startingPoint - star;
                        }
                       else
                        {
                            break;
                        }
                    }
               
                List<int> ListRight = points.GetRange(startingPoint, points.Count - startingPoint);
                List<int> ListLeft = points.GetRange(0, actualstartpoint+1);

                    int steptogonextleft = 0;
                    int leftstartingPoints = 0;
                    int steptogonextright = 0;
                    int rightstartingPoints = 0;
                for (int i = actualstartpoint; i > 0; i--)
                {
                    
                    if (ListLeft[i] > ListLeft[i - 1])
                    {
                        stepsToGoLeft = steptogonextleft;
                        steptogonextleft += 1;
                    }
                    else
                    {

                        if (steptogonextleft < i && steptogonextleft > stepsToGoLeft)
                        {
                            stepsToGoLeft = steptogonextleft;
                            steptogonextleft = 0;
                        }
                    }
                    leftstartingPoints = i + stepsToGoLeft;
                    
                }
                        
                      
                for (int i = 0; i < ListRight.Count-1; i++)
                {

                    if (ListRight[i] > ListRight[i + 1])
                    {
                        stepsToGoRight = steptogonextright;
                        steptogonextright += 1;
                        

                    }
                    else
                    {

                        if (steptogonextright < ListRight.Count - i && steptogonextright > stepsToGoRight)
                        {
                            stepsToGoRight = steptogonextright;
                            steptogonextright = 0;
                            
                        }
                    }
                  
                    rightstartingPoints = startingPoint + stepsToGoRight - i;

                }
                    
                    if(stepsToGoLeft >= stepsToGoRight)                    
                        Console.WriteLine("The starting Index should be" + leftstartingPoints);                    
                    else
                        Console.WriteLine("The starting Index should be" + rightstartingPoints);
                
            }

        }
    }
}
