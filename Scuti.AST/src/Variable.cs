using Scuti.Lexicon;

namespace Scuti.AST {
    public readonly struct Variable {
        private readonly string name;
        public Variable(object[] lexi) {
            if(lexi.Length == 0 || !(lexi[0] is Keywords keyword && keyword == Keywords.LET)) {
                throw new System.Exception("Invalid variable definition");
            }
            name = lexi[1] as string;
            // To be implemeted
        }
    }
}