using System.Collections.Generic;
using Scuti.Lexicon;

namespace Scuti.AST.Internals
{
    public static class ObjectArrayExtensions
    {
        public static object[] Classify(this object[] input)
        {
            List<object> buffer = new List<object>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] is Keywords keyword)
                {
                    switch (keyword)
                    {
                        case Keywords.FUNCTION:
                            buffer.Add(new Function(input.readFunction(ref i), buffer.getAttributes()));
                            break;
                        case Keywords.IMPORT:
                            buffer.Add(new Import(input.readImport(ref i)));
                            break;
                    }
                }
                else if(input[i] is Tokens token) {
                    switch(token) {
                        case Tokens.AT_SIGN:
                            buffer.Add(input.readAttribute(ref i));
                            break;
                    }
                }
            }
            return buffer.ToArray();
        }
        private static object[] getAttributes(this List<object> input) {
            List<object> buffer = new List<object>();
            for(int i = input.Count - 1; i >= 0; i--) {
                if(!(input[i] is object[])) {
                    break;
                }
                buffer.Add(input[i]);
                input.RemoveAt(i);
            }
            buffer.Reverse();
            return buffer.ToArray();
        }
        private static object[] readImport(this object[] input, ref int offset)
        {
            List<object> import = new List<object>();
            for (; offset < input.Length; offset++)
            {
                if (input[offset] is Tokens token && token == Tokens.SEMICOLON)
                {
                    break;
                }
                import.Add(input[offset]);
            }
            return import.ToArray();
        }
        private static object[] readAttribute(this object[] input, ref int offset)
        {
            List<object> import = new List<object>();
            import.Add(input[offset++]);
            for (; offset < input.Length; offset++)
            {
                if (input[offset] is Keywords || (input[offset] is Tokens token && token == Tokens.AT_SIGN))
                {
                    offset--;
                    break;
                }
                import.Add(input[offset]);
            }
            var ttt = input[offset];
            return import.ToArray();
        }
        private static object[] readFunction(this object[] input, ref int offset)
        {
            List<object> function = new List<object>();
            int parameters_validator = 0;
            int function_type = -1;
            for (int i = -1; offset < input.Length; offset++)
            {
                if(i == 0) {
                    offset--;
                    break;
                }
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
                                if (!(input[offset + 1] is Tokens _token && _token == Tokens.GREATER_THAN))
                                {
                                    throw new System.Exception("Invalid short function definition exception");
                                }
                                function_type = 2;
                            }
                            else
                            {
                                throw new System.Exception("Invalid function definition exception");
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
            return function.ToArray();
        }
    }
}