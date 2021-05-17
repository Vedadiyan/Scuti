using System.Collections.Generic;
using System.Text;

namespace Scuti.Lexicon.Internals
{
    internal static class StringExtensions
    {
        public static IEnumerable<object> Parse(this string str)
        {
            StringBuilder buffer = new StringBuilder();
            string tmp = null;
            for (int i = 0; i < str.Length; i++)
            {
                if (Mappers.GetTokens.TryGetValue(str[i], out Tokens token))
                {
                    if (token == Tokens.SINGLE_QUOT)
                    {
                        while (++i < str.Length && (str[i] != '\'' || buffer.Previous() == '\\'))
                        {
                            buffer.Append(str[i]);
                        }
                        yield return buffer.ToString().ToCharArray();
                        buffer.Clear();
                    }
                    else if (token == Tokens.HASH)
                    {
                        while (++i < str.Length && str[i] != '\n') ;
                        buffer.Clear();
                    }
                    else
                    {
                        if (buffer.Length > 0)
                        {
                            tmp = buffer.ToString();
                            buffer.Clear();
                            if (Mappers.GetKeywords.TryGetValue(tmp, out Keywords keyword))
                            {
                                yield return keyword;
                            }
                            else
                            {
                                tmp.ParseValue(out object value);
                                yield return value;
                            }
                        }
                        if (token > 0)
                        {
                            if (token == Tokens.DOLLAR_SIGN)
                            {
                                yield return Keywords.LET;
                            }
                            else
                            {
                                yield return token;
                            }
                        }
                    }
                }
                else
                {
                    buffer.Append(str[i]);
                }
            }
            if (buffer.Length > 0)
            {
                // Replace these with proper exceptions
                throw new System.Exception("Invalid Syntax");
            }
        }
        public static Types ParseValue(this string str, out object value)
        {
            if(str.Length == 0) {
                // Replace these with proper exceptions
                throw new System.Exception("Invalid Syntax");
            }
            if (!char.IsDigit(str[str.Length - 1]))
            {
                value = str;
                return Types.REFERENCE;
            }
            if (str.Contains('.'))
            {
                value = decimal.Parse(str);
                return Types.DECIMAL;
            }
            else
            {
                value = int.Parse(str);
                return Types.INT;
            }
        }
    }
}