using Scuti.Lexicon;

namespace Scuti.AST {
    public readonly struct Function {
        private readonly object[] lexi;
        public Function(object[] lexi) {
            this.lexi = lexi;
        }
    }
}