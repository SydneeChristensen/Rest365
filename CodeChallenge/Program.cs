using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    //created by: Sydnee Christensen
    //January 2020

    class Program
    {
        static void Main(string[] args)
        {

                //Ask user for numbers
                Console.WriteLine("What numbers would you like to add together? Please seperate the numbers by a comma.");
                var line = Console.ReadLine();

                //split the numbers
                var data = line.Split(',');

            int iCount = 0;
            //Create an empty arraylist
            ArrayList numbers = new ArrayList();
            //foreach loop to take out any empty inputs or replace letters with zeros
            foreach (string item in data)
                {
                if (item == "")
                {
                    numbers.Add(0);
                }

                else if (Int32.TryParse(data[iCount], out _))
                {
                    numbers.Add(int.Parse(data[iCount]));
                }
                else
                {
                    numbers.Add(0);

                }

                iCount++;
            }

            iCount = 0;
            int total = 0;
            //Combine the values for a total
            foreach(int item in numbers)
                    {
                        total = item + total;
                    }
                    iCount = 0;
                    int plusSigns = 1;
                    //loop to print out the numbers and the total
                    foreach (int item in numbers)
                    {
                        Console.Write(numbers[iCount].ToString());
                        iCount++;
                      if (plusSigns < numbers.Count)
                         {
                            Console.Write(" + ");
                            plusSigns++;
                        };
                                 
                    }
            Console.Write(" = " + total);
            Console.ReadLine();

        }

    }
}
