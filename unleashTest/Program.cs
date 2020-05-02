using System;

namespace unleashTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please Enter a Number to convert to Words");
                string number = Console.ReadLine();
                string strResult = NumberToWordConverter.ConvertToWords(number);
                if (string.IsNullOrEmpty(strResult))
                {
                    Console.WriteLine("Please Enter a valid number");
                }
                else
                {
                    Console.WriteLine("{0}", strResult);
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
