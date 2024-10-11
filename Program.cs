using System;

public class Program
{
    // Method to find the ranks of the students based on their marks.
    public int[] FindStudentsRank(int[,] stdMarks)
    {
        int numStudents = stdMarks.GetLength(0);  // Get number of students
        int[] totalMarks = new int[numStudents];  // To store total marks of each student
        int[] ranks = new int[numStudents];       // To store the rank of each student

        // Calculate total marks for each student
        for (int i = 0; i < numStudents; i++)
        {
            int sum = 0;
            for (int j = 0; j < 5; j++) // Assuming 5 subjects
            {
                sum += stdMarks[i, j];
            }
            totalMarks[i] = sum; // Store total marks
        }

        // Assign ranks based on total marks
        for (int i = 0; i < numStudents; i++)
        {
            int rank = 1;
            for (int j = 0; j < numStudents; j++)
            {
                if (totalMarks[j] > totalMarks[i]) // Compare marks with other students
                {
                    rank++;
                }
            }
            ranks[i] = rank; // Store the rank of the current student
        }

        return ranks; // Return the ranks
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter number of students: ");
        int numStudents = int.Parse(Console.ReadLine());

        int[,] stdMarks = new int[numStudents, 5]; // 2D array to store marks of students

        // Input the marks of each student
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"Enter marks for student {i + 1} (5 subjects): ");
            for (int j = 0; j < 5; j++)
            {
                stdMarks[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Create an instance of Program class to call the method
        Program program = new Program();
        int[] ranks = program.FindStudentsRank(stdMarks);

        // Output the ranks of the students
        Console.WriteLine("Ranks of the students:");
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"Student {i + 1}: Rank {ranks[i]}");
        }
    }
}