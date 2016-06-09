using System;

namespace ParenthesesBalancing
{
    /* Calculates if the parenthesis of the input string are balanced. See the tests for more information. */

    public class ParenthesesBalancing
    {
        public bool IsBalanced(string input)
        {

            int balance = 0;
            foreach (char c in input)
            {

                switch (c)
                {
                    case '(':
                        balance++;
                        break;

                    case ')':
                        if (--balance < 0)
                            return false;
                        break;
                }

            }

            return balance == 0;
        }
    }
}