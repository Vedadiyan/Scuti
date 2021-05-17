using Scuti.Lexicon;

namespace Scuti.AST {
    public readonly struct Function {
        private readonly object[] function;
        private readonly object[] attributes;
        public Function(object[] function, object[] attributes) {
           this.function = function;
           this.attributes = attributes;
        }
    }
}