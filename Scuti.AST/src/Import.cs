using Scuti.Lexicon;

namespace Scuti.AST
{
    public readonly struct Import
    {
        private readonly string module;
        public Import(object[] lexi)
        {
            if (lexi.Length == 2 && lexi[0] is Keywords keyword && keyword == Keywords.IMPORT && lexi[1] is string str)
            {
                module = str;
            }
            else {
                throw new System.Exception("Invalid import statement");
            }
        }
    }
}