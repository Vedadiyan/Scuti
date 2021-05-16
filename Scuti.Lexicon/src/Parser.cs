using System.Linq;
using Scuti.Lexicon.Internals;

namespace Scuti.Lexicon {
    public class Parser {
        private readonly string script;
        public Parser(string script) {
            this.script = script;
        }
        public object[] Parse() {
            return script.Parse().ToArray();
        }
    }
}