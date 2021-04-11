using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioRDI.Services
{
    public class TokenGenerator
    {
        public static long Generator(long cardNumber, int CVV)
        {

            string lastNumbers = cardNumber.ToString();

            lastNumbers = lastNumbers.Substring(lastNumbers.Length - 4);

            List<int> numbers = new List<int>();
            for (int i = 0; i < lastNumbers.Length; i++)
            {
                numbers.Add(Convert.ToInt32(lastNumbers.Substring(i, 1)));
            }

            for (int i = 0; i < CVV; i++)
            {

                int lastIndex = numbers.Count - 1;
                int lastValue = numbers[lastIndex];
                numbers.RemoveAt(lastIndex);
                numbers.Insert(0, lastValue);

            }
            string token = "";
            foreach (int number in numbers)
            {
                token += number;
            }

            return Convert.ToInt64(token);
        }

    }
}
