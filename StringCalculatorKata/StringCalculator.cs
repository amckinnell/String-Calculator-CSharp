using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private const string DelimiterParseRegExp = "//(.*)\n(.*)";
        private const string CustomDelimiterRegExp = "\\[(.*?)\\]";

        private readonly List<string> negatives = new List<string>();

        public int Add(string numbers)
        {
            int sum = 0;

            foreach (var number in Parse(numbers))
            {
                sum += ToNumber(number);
            }

            CheckForNegativeNumbers();

            return sum;
        }

        private string[] Parse(string numbers)
        {
            if (IsMultipleCustomDelimiters(numbers))
                return ParseMultipleCustomDelimiters(numbers);

            if (IsCustomDelimiter(numbers))
                return ParseCustomDelimiter(numbers);

            return ParseStandardDelimiter(numbers);
        }

        private bool IsMultipleCustomDelimiters(string numbers)
        {
            return numbers.StartsWith("//[");
        }

        private string[] ParseMultipleCustomDelimiters(string numbers)
        {
            Regex regex = new Regex(DelimiterParseRegExp);
            MatchCollection matches = regex.Matches(numbers);

            return matches[0].Groups[2].Value
                .Split(ExtractCustomDelimiters(matches[0].Groups[1].Value), StringSplitOptions.None);
        }

        private string[] ExtractCustomDelimiters(string customDelimiters)
        {
            Regex regex = new Regex(CustomDelimiterRegExp);
            MatchCollection matches = regex.Matches(customDelimiters);

            string[] result = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].Groups[1].Value;
            }

            return result;
        }

        private bool IsCustomDelimiter(string numbers)
        {
            return numbers.StartsWith("//");
        }

        private string[] ParseCustomDelimiter(string numbers)
        {
            Regex regex = new Regex(DelimiterParseRegExp);
            MatchCollection matches = regex.Matches(numbers);

            string customDelimiter = matches[0].Groups[1].Value;
            string numberList = matches[0].Groups[2].Value;

            return numberList.Split(new string[] { customDelimiter },
                StringSplitOptions.None);
        }

        private string[] ParseStandardDelimiter(string numbers)
        {
            return numbers.Split(new string[] { ",", "\n" },
                StringSplitOptions.RemoveEmptyEntries);
        }

        private int ToNumber(string number)
        {
            int convertedValue = int.Parse(number);

            if (convertedValue < 0)
            {
                negatives.Add(number);
            }

            return convertedValue <= 1000 ? convertedValue : 0;
        }

        private void CheckForNegativeNumbers()
        {
            if (0 == negatives.Capacity) return;

            throw new SystemException("Negatives not allowed: " + string.Join(",", negatives.ToArray()));
        }
    }
}
