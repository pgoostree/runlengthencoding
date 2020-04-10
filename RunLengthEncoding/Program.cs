using System;
using System.Linq;
using System.Text;

namespace PeterTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = EncodeString("aabccd");
            Console.WriteLine(result);

            var result1 = EncodeString1("aabccd");
            Console.WriteLine(result1);
            Console.Read();
        }

        /// <summary>
        /// Encodes a string using RunLength encoding algorithm
        ///
        /// Example: Given the following input:
        ///     aaabbbccddda
        /// The output would be:
        ///     3a2b2c3d1a
        /// 
        /// </summary>
        /// <param name="input">A string to be encoded</param>
        /// <returns>A RunLength encoded string</returns>
        private static string EncodeString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";
            
            StringBuilder sb = new StringBuilder();
            var inputChars = input.ToCharArray();

            var index = 0;

            for (int i = 0; i < inputChars.Length; i++)
            {
                if (inputChars[i] != inputChars[index])
                {
                    sb.Append(i - index);
                    sb.Append(inputChars[index]);
                    index = i;
                }
            }
            
            sb.Append(inputChars.Length - index);
            sb.Append(inputChars[index]);
            
            return sb.ToString();
        }

        /// <summary>
        /// Encodes a string using RunLength encoding algorithm
        ///
        /// Example: Given the following input:
        ///     aaabbbccddda
        /// The output would be:
        ///     3a2b2c3d1a
        /// 
        /// </summary>
        /// <param name="input">A string to be encoded</param>
        /// <returns>A RunLength encoded string</returns>
        private static string EncodeString1(string input)
        {
            StringBuilder sb = new StringBuilder();
            var group = input.GroupBy(x => x);

            foreach (var item in group)
            {
                sb.AppendFormat("{0}{1}", item.Count(), item.Key);
            }

            return sb.ToString();
        }
    }
}