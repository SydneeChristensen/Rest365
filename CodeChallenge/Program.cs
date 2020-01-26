using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

                //Ask user for numbers
                Console.WriteLine("What numbers would you like to add together? Please only give two numbers and seperate the numbers by a comma.");
                var line = Console.ReadLine();

                //split the numbers
                var data = line.Split(',');
                
                // create the two variables
                var num1 = 0;
                var num2 = 0;

            //The if statements that will change any string inputs or empty intputs into a 0
            if (data[0]=="")
            {
                num1 = 0;
                num2 = 0;
            }
            else if (data.Count()== 1)
            {
                num1 = int.Parse(data[0]);
            }
            else
            {
                if (Int32.TryParse(data[0], out _))
                {
                    num1 = int.Parse(data[0]); 
                }
                else
                {
                    num1 = 0;
                    
                }

                if (Int32.TryParse(data[1], out _))
                {
                    num2 = int.Parse(data[1]); 
                }
                else
                {
                    num2 = 0;
                    
                }

            }

            //The if statement to stop the user if they input more than 2 inputs
                int c = data.Count();
                if (c > 2)
                {
                    Console.WriteLine("Please only enter two numbers.");
                    Console.ReadLine();
                }
                else
                {
                   //adding the numbers together 
                    int answer = num1 + num2;
                    
                    //printing the formula
                    Console.WriteLine(num1.ToString() + " + " + num2.ToString() + " = " + answer.ToString());
                    Console.ReadLine();
                }



        }

    }
}
