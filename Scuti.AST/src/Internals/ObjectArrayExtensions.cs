using System.Collections.Generic;
using Scuti.Lexicon;

namespace Scuti.ASP.Internals
{
    public static class ObjectArrayExtensions
    {
        public static IEnumerable<object[]> Classify(this object[] input)
        {
            List<object> buffer = new List<object>();
            for (int i = 0, c = -1; i < input.Length; i++)
            {
                if (input[i] is Keywords keyword)
                {
                    switch (keyword)
                    {
                        case Keywords.FUNCTION:
                            yield return input.readFunction(ref i);
                            break;
                    }
                }
            }
        }
        private static object[] readFunction(this object[] input, ref int offset)
        {
            List<object> function = new List<object>();
            int parameters_validator = 0;
            int function_type = -1;
            for (int i = -1; offset < input.Length && i != 0; offset++)
            {
                if (input[offset] is Tokens token)
                {
                    if (parameters_validator != -1)
                    {
                        if (token == Tokens.LEFT_P)
                        {
                            if (parameters_validator != 0)
                            {
                                throw new System.Exception("Invalid function definition exception");
                            }
                            parameters_validator += 1;
                        }
                        else if (token == Tokens.RIGHT_P)
                        {
                            parameters_validator -= 1;
                            if (parameters_validator == 0)
                            {
                                parameters_validator = -1;
                            }
                        }
                    }
                    else
                    {
                        if (function_type == -1)
                        {
                            if (i == -1 && token == Tokens.LEFT_CB)
                            {
                                i = 1;
                                function_type = 1;
                            }
                            else if (token == Tokens.EQUALS)
                            {
                                function_type = 2;
                            }
                        }
                        else if (function_type == 1 && token == Tokens.LEFT_CB)
                        {
                            i++;
                        }
                        else if (function_type == 1 && token == Tokens.RIGHT_CB)
                        {
                            i--;
                        }
                        else if (function_type == 2 && token == Tokens.SEMICOLON)
                        {
                            break;
                        }
                    }
                }
                function.Add(input[offset]);
            }
            // var test = input[offset];
            return function.ToArray();
        }
    }
}