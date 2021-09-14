/*
 * file header
 * Your Name
 * ITSE 1430 Fall 2021
 */
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demoing the logical operators
            static void DemoLogicalOperators()
            {
                // Logical AND - true if both operands are true
                // Logical OR - true if either operand is true
                //   X   Y   &&    ||
                //--------------------------
                //   F   F    F    F
                //   F   T    F    T
                //   T   F    F    T
                //   T   T    T    T

                // NOT 
                //   F   !F = T
                //   T   !T = F
            }

            static void DemoRelationalOperators ()
            {
                int x = 10, y = 20;

                bool isLessThan = x < y;
                bool isLessThanOrEqual = x <= y;

                bool isGreaterThan = x > y;
                bool isGreaterThanOrEqual = x >= y;

                bool isEqual = x == y;
                bool isNotEqual = x != y;
            }

            static void DemoCombinationOperators ()
            {
                //Works for more than just arithmetic
                int x = 10;

                x += 10;  // x = x + 10;
                x -= 20;  // x = x - 20;
                x *= 3;   // x = x * 3;
                x /= 5;   // x = x / 5;
                x %= 2;   // x = x % 2;
            }

            static void DemoPrefixPostfixOperators()
            {
                int x = 10, y;

                //Prefix increment
                y = ++x; // x = 11, y = 11

                //Prefix decrement
                y = --x; // x = 10, y = 10

                //Postfix increment
                y = x++; // x = 11, y = 10

                //Postfix decrement
                y = x--; // x = 10, y = 11
            }

            static void DemoAssignmentOperator ()
            {
                int x;
                int y;
                int z;

                x = 10;
                y = 10;
                z = 10;

                //left associative (E1 op E2) => E1, E2, op
                //right associative operators (E1 op E2) => E2, E1, op
                x = y = z = 20; //x = (y = (z = 20))
            }

            static void DemoConditionalOperator ()
            {
                int grade = 70;

                string passStatus;

                if (grade < 60)
                    passStatus = "Not Passing";
                else
                    passStatus = "Passing";

                //Terninary - 3 operands
                // E(bool) ? E(true) : E(false)
                string passStatus2 = (grade < 60) ? "Not Passing" : "Passing";
            }

            static void DemoStrings()
            {
                string firstName = "Bob";

                //Relationals work, case sensitive
                bool isBob = firstName == "Bob";

                //String literals
                string literal1 = "Hello World";

                //Escape sequence - \?, only work in string literals
                // \n => newline
                // \t => horizontal tab
                // \\ => slash
                // \" => double quote
                // \' => character literal, single quote
                literal1 = "Hello\nWorld";
                string quoteString = "Hello \"Bob\"";

                string filePath = "C:\\windows\\system32\\tasks";
                string verbatimFilePath = @"C:\windows\system32\tasks";

                //String length `Length` => how many characters
                int length = literal1.Length;

                //Empty string
                string emptyString = "";  //.Length = 0
                string emptyString2 = String.Empty;  //Length = 0
                bool areEmptyStringsEqual = String.Empty == "";  //True

                // null != empty string
                // default value of strings is null
                string nullString = null;
                bool areEqualNull = "" == null;  // false

                // string is the univerals type in C#
                // all expressions are convertable to string using .ToString
                string asString = length.ToString();  // length as a string
                asString = 10.ToString();  // "10
                asString = areEqualNull.ToString();  //"False"
            }
        }
    }
}
