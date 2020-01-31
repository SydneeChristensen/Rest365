using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    /*  created by: Sydnee Christensen
        January 2020
        Requirements: 
        1. Support a maximum of 2 numbers using a comma delimiter. Throw an exception when more than 2 numbers are provided
        2.Empty input or missing numbers should be converted to 0
        3. Invalid numbers should be converted to 0 e.g. 5,tytyt will return 5
        4. Remove the maximum constraint for numbers e.g. 1,2,3,4,5,6,7,8,9,10,11,12 
        5. Deny negative numbers by throwing an exception that includes all of the negative numbers provided
        6. Make any value greater than 1000 an invalid number e.g. 2,1001,6 will return 8
        7. Support 1 custom delimiter of a single character using the format: //{delimiter}\n{numbers}
        8. Support 1 custom delimiter of any length using the format: //[{delimiter}]\n{numbers}
        9. Support multiple delimiters of any length using the format: //[{delimiter1}][{delimiter2}]...\n{numbers}
        10. All previous formats should also be supported
   */

   public class Program
    {
        static void Main(string[] args)
        {

            //Ask user for numbers
            Console.WriteLine("What numbers would you like to add together?");
            var line = Console.ReadLine();

            List<string> delLists = new List<string>();

            //if statement to see if we are working with the custom delimiters
            if (line.StartsWith("//"))
            {
                //finds the custom delimiter
                var dels = line.Split(new string[] { "//[", "[", "][","//", "]" , "\\"}, StringSplitOptions.None);
                
                //sorts out the delimiter according to the formats            
                int iNum = 0;
                foreach (string item in dels)
                {
                    if (item.StartsWith("n"))
                    {
                        continue;
                    }

                    else
                    {
                        delLists.Add(dels[iNum]);
                    }
                    iNum++;
                }
                line = line.Substring(line.IndexOf("n") + 1);
            }
            //adds the comma and newline delimiters
            delLists.Add(",");
            delLists.Add("\\n");
            delLists.Add("]\\n");
            
            //changes the list to an array
            string[] delimiters = delLists.ToArray();
            //cuts the string down to just the inputs split by the delimiters
            

            //split the numbers by the delimiters by commas, newline character, or custom delimiter
            string[] data = line.Split(delimiters, StringSplitOptions.None);

            int iCount = 0;
            //Create an empty arraylist
            ArrayList numbers = new ArrayList();
            //Create an empty arraylist for negative numbers
            ArrayList negatives = new ArrayList();

            //foreach loop to take out any empty inputs or replace letters with zeros
            foreach (string item in data)
                {
                //fills in any empty variable with a zero
                if (item == "")
                {
                    numbers.Add(0);
                }

                //turns any input into an interger
                else if (Int32.TryParse(data[iCount], out _))
                {
                    //create a variable to check if the int is negative
                    int num = int.Parse(data[iCount]);

                    if (num > 1000)
                    {
                        numbers.Add(0);
                    }
                    else
                    {
                        numbers.Add(int.Parse(data[iCount]));
                    }

                    //if statement to check if the number is negative
                    if (num<0)
                    {
                        //adds the negative value to an arraylist to later display 
                        negatives.Add(num);
                    }

                }

                //clean up after the custom delimiters
                else if (data[iCount] == "//"  || data[iCount] == "//[" || data[iCount] == "]" || data[iCount] == "][")  
                {
                    data[iCount] = "0";
                }

                //if the value can't be converted to an interger it gets turned into a zero
                else
                {
                    numbers.Add(0);
                }
                iCount++;
            }

            //the exception that is ouput if the user inputs negative numbers
            if (negatives.Count > 0)
            {
                Console.Write("This application does not allow negative numbers. You input the following negative numbers: ");
                foreach (int neg in negatives)
                {
                    Console.Write(neg);
                }
                Console.ReadLine();
            }

            else
            {
                iCount = 0;
                int total = 0;
                //Combine the values for a total
                foreach (int item in numbers)
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
}
