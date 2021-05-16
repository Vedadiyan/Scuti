using System.Collections.Generic;

namespace Scuti.Lexicon
{
    public struct Mappers
    {
        public static Dictionary<char, Tokens> GetTokens { get; } = new Dictionary<char, Tokens>
        {
            [' '] = Tokens.WHITE_SPACE,
            ['\t'] = Tokens.TAB,
            ['\r'] = Tokens.REFRESH,
            ['\n'] = Tokens.NEW_LINE,

            ['('] = Tokens.LEFT_P,
            [')'] = Tokens.RIGHT_P,
            ['{'] = Tokens.LEFT_CB,
            ['}'] = Tokens.RIGHT_CB,
            ['['] = Tokens.LEFT_B,
            [']'] = Tokens.RIGHT_B,

            // ['"'] = Tokens.DOUBLE_QUOT,
            ['\''] = Tokens.SINGLE_QUOT,

            ['+'] = Tokens.PLUS,
            ['-'] = Tokens.MINUS,
            ['/'] = Tokens.DIVIDE,
            ['*'] = Tokens.MULTIPLY,
            ['%'] = Tokens.REMAINDER,

            ['>'] = Tokens.GREATER_THAN,
            ['<'] = Tokens.LOWER_THAN,
            ['='] = Tokens.EQUALS,
            ['!'] = Tokens.NOT,

            ['&'] = Tokens.AND,
            ['|'] = Tokens.OR,
            ['^'] = Tokens.XOR,
            ['~'] = Tokens.NAND,

            ['?'] = Tokens.QUESTION_MARK,
            ['#'] = Tokens.HASH,
            ['@'] = Tokens.AT_SIGN,

            ['$'] = Tokens.DOLLAR_SIGN,

            [':'] = Tokens.COLON,
            [','] = Tokens.COMMA,
            [';'] = Tokens.SEMICOLON
        };
        public static Dictionary<string, Keywords> GetKeywords { get; } = new Dictionary<string, Keywords>
        {
            ["function"] = Keywords.FUNCTION,
            ["func"] = Keywords.FUNCTION,
            ["return"] = Keywords.RETURN,
            ["if"] = Keywords.IF,
            ["elif"] = Keywords.ELSE_IF,
            ["else"] = Keywords.ELSE,
            ["let"] = Keywords.LET,
            ["const"] = Keywords.CONST,
            ["for"] = Keywords.FOR,
            ["while"] = Keywords.WHILE,
            ["break"] = Keywords.BREAK,
            ["true"] = Keywords.TRUE,
            ["false"] = Keywords.FALSE,
            ["null"] = Keywords.NULL,
            ["import"] = Keywords.IMPORT,
            ["async"] = Keywords.ASYNC,
            ["await"] = Keywords.AWAIT,
            ["sneak"] = Keywords.SNEAK,
            ["new"] = Keywords.NEW,
            ["of"] = Keywords.OF,
            ["in"] = Keywords.IN,
            ["try"] = Keywords.TRY,
            ["catch"] = Keywords.CATCH,
            ["throw"] = Keywords.THROW
        };
    }
}