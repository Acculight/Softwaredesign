using System;

namespace L04_Zahlensysteme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConvertDecimalToHexal: " + ConvertDecimalToHexal(Convert.ToInt32(args[0])));
            Console.WriteLine("ConvertHexalToDezimal: " + ConvertHexalToDezimal(Convert.ToInt32(args[0])));
            Console.WriteLine("ConvertToBaseFromDecimal: " + ConvertToBaseFromDecimal(Convert.ToInt32(args[1]), Convert.ToInt32(args[0])));
            Console.WriteLine("ConvertToDecimalFromBase: " + ConvertToDecimalFromBase(Convert.ToInt32(args[2]), Convert.ToInt32(args[0])));
            Console.WriteLine("ConvertNumberToBaseFromBase: " + ConvertNumberToBaseFromBase(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]), Convert.ToInt32(args[2])));
        }
        public static int ConvertDecimalToHexal(int dec)
        {
            if (dec >= 0 && dec <= 1023)
            {
                return ConvertToBaseFromDecimal(6, dec);
            }
            else
            {
                return -1;
            }
        }
        public static int ConvertHexalToDezimal(int hexal)
        { 
            return ConvertToDecimalFromBase(6, hexal);
        }
        public static int ConvertToBaseFromDecimal(int toBase, int number)
        {
            int newValue = number / toBase;
            int[] arr = new int[4];

            for (int i = 0; i <= number.ToString().Length + 2; i++)
            {
                newValue = number / toBase;
                int rest = number % toBase;
                arr[i] = rest;
                number = newValue;
            }
            Array.Reverse(arr);
            int newArray = Convert.ToInt32(string.Join("", arr));

            return newArray;
        }
        public static int ConvertToDecimalFromBase(int fromBase, int number)
        {

            int length = number.ToString().Length;
            int[] array = new int[length];
            int[] newArray = new int[length];
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                array[i] = number % 10;
                number /= 10;
                newArray[i] += array[i] * Convert.ToInt32(Math.Pow(fromBase, i));
            }
            for (int x = 0; x < newArray.Length; x++)
            {
                sum += newArray[x];
            }
            return sum;
        }
        public static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase)
        {
            if (toBase > 2 && toBase < 10 && fromBase > 2 && fromBase < 10)
            {
                int dec = ConvertToDecimalFromBase(fromBase, number);
                int newValue = ConvertToBaseFromDecimal(toBase, dec);

                return newValue;
            }
            else
            {
                return -1;
            }
        }
    }
}