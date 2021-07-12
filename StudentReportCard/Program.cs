using System;

namespace StudentReportCard
{
    class Program
    {
        static string[] infoWriteRepordCard = new string[4]
        {
            "\nEnter Student Name : ",
            "\nEnter English Marks (out of 100) : ",
            "\nEnter Math Marks (out of 100) : ",
            "\nEnter Computer Marks (out of 100) : "
        };

        static string[,] EnterInfoStudents(int numStudents)
        {
            string[,] reportCardArray = new string[numStudents, infoWriteRepordCard.Length];
            for (int row = 0; row < reportCardArray.GetLength(0); row++)
            {
                for (int col = 0; col < reportCardArray.GetLength(1); col++)
                {
                    Console.Write($"{infoWriteRepordCard[col]}");
                    string input = Console.ReadLine();
                    reportCardArray[row, col] = input;
                }   
                if (row != (reportCardArray.GetLength(0) - 1))
                { Console.WriteLine("\n*************************************************************"); }
            }
            return reportCardArray;
        }

        static string[,] ReportCardSumOutput(string[,] array, int numberOfStudents)
        {
            string[,] arrayFinal = new string[numberOfStudents, 2];
            int sum = 0;
            for (int row = 0; row < array.GetLength(0); row++)
            {
                sum = 0;
                for (int col = 1; col < array.GetLength(1); col++)
                {
                    sum += (int.Parse(array[row, (col)]));
                }
                arrayFinal[row, 0] = array[row, 0];
                arrayFinal[row, 1] = sum.ToString();
            }
            return arrayFinal;
        }

        static string[,] ReportCardOutputPosition(string[,] array)
        {
            string tempInt = "";
            string tempString = "";
            for (int row = 0; row < array.GetLength(0) - 1; row++)
            {
                for (int j = 0; j < array.GetLength(0) - 1 - row; j++)
                {
                    if (int.Parse(array[j, 1]) < int.Parse(array[j + 1, 1]))
                    {
                        tempString = array[j, 0];
                        array[j, 0] = array[j + 1, 0];
                        array[j + 1, 0] = tempString;

                        tempInt = array[j, 1];
                        array[j, 1] = array[j + 1, 1];
                        array[j + 1, 1] = tempInt;
                    }
                }           
            }     
            return array;
        }
        static void ReportOutputFinal(string[,] array)
        {
            Console.WriteLine("\n********************Report Card********************");
            for (int row = 0; row < array.GetLength(0); row++)
            {
                Console.WriteLine($"\nStudent Name: {array[row, 0]}, Position : {row+1}, Total: {array[row, 1]}");
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter Total Students: ");

            int input = int.Parse(Console.ReadLine());

            var infoStudent = EnterInfoStudents(input);

            string[,] arrayAperFinal = ReportCardSumOutput(infoStudent, input);

            string[,] arrayOutput = ReportCardOutputPosition(arrayAperFinal);

            ReportOutputFinal(arrayOutput);
        }
    }
}
