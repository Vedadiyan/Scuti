namespace Scuti.Lexicon
{
    public enum Tokens : int
    {
        DEFAULT
        = 0,
        HASH // Comment
        = 10,
        AT_SIGN // Attribute
        = 20,

        #region White Spaces 
        WHITE_SPACE
        = -1000,
        TAB
        = -1010,
        NEW_LINE
        = -1020,
        REFRESH
        = -1030,
        #endregion

        #region Code Blocks 
        LEFT_CB
        = 2000,
        RIGHT_CB
        = 2010,
        RIGHT_B
        = 2020,
        LEFT_B
        = 2030,
        RIGHT_P
        = 2040,
        LEFT_P
        = 2050,
        #endregion

        #region Delimiters
        COMMA
        = 3000,
        COLON
        = 3010,
        SEMICOLON
        = 3020,
        #endregion

        #region Flags 
        SINGLE_QUOT
        = 4000,
        // DOUBLE_QUOT
        // = 4000,
        #endregion

        #region Arithmetics    
        PLUS
        = 9000,
        MINUS
        = 9010,
        DIVIDE
        = 9020,
        MULTIPLY
        = 9030,
        REMAINDER
        = 9040,
        #endregion

        #region Assignment & Comparison
        EQUALS
        = 5000,
        NOT
        = 5010,
        GREATER_THAN
        = 5020,
        LOWER_THAN
        = 5030,
        #endregion

        #region Logical
        AND
        = 6000,
        OR
        = 6010,
        XOR
        = 6020,
        NAND
        = 6030,
        #endregion

        #region Language Features
        QUESTION_MARK // NULL Check
        = 10000,
        #endregion

        #region Symbolic Interpretations
        DOLLAR_SIGN  // Symbolic Variable Declaration 
        = 30,
        #endregion
    }
}