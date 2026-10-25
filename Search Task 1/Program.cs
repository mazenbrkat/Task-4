namespace Search_Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a C# program that read a list of integers from the user and throws an exception if any numbers are duplicates.
            /*
             * throw => means to throw an exception if a certain condition is met. 
             * How to throw an exception in C#? 
             * => throw new Exception("Custom error message");
             */
            Console.Write("Enter count of numbers: ");
            int n=Convert.ToInt32(Console.ReadLine());
            int[] arr=new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"number[{i+1}]: ");
                arr[i]=Convert.ToInt32(Console.ReadLine());

            }

            for (int i = 0; i < arr.Length; i++)
            {
                for(int j=i+1;j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        throw new Exception("Duplicate numbers found!.");
                    }
                }
            }
        }
    }
}
