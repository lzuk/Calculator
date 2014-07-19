﻿using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Calculator.MathOperations;

namespace Calculator.Extensions
{
    static class StringExtenstions
    {
        public static bool IsParseable(this string expression)
        {
            var numbers = new Regex("^[0-9]*$");
            var matchOnlyOperation = new Regex(BuildMatchOnlyOperationsRegex());
            expression = expression.Replace(" ", string.Empty);

            return !string.IsNullOrEmpty(expression) && (expression.ToCharArray().All(c => numbers.IsMatch(c.ToString()) || matchOnlyOperation.IsMatch(c.ToString())));
        }

        private static string BuildMatchOnlyOperationsRegex()
        {
            var matchOperatorsRegexBuilder = new StringBuilder();
            matchOperatorsRegexBuilder.Append("([");

            foreach (var key in OperationsMapper.Get().Keys)
            {
                matchOperatorsRegexBuilder.Append(@"\");
                matchOperatorsRegexBuilder.Append(key);
            }

            matchOperatorsRegexBuilder.Append("])");
            return matchOperatorsRegexBuilder.ToString();
        }
    }
}
