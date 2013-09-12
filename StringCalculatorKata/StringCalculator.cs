using System;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int sum = 0;

            foreach (var number in Parse(numbers))
            {
                sum += ToNumber(number);
            }

            return sum;
        }

        private string[] Parse(string numbers)
        {
            return numbers.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }

        private int ToNumber(string number)
        {
            return int.Parse(number);
        }
    }
}

