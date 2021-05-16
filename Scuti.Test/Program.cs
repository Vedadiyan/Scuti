using System;

namespace Scuti.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Scuti.Lexicon.Parser parser = new Lexicon.Parser(
@"
        function test (a, b, c) {
            if( a == b) {
                return true;
            }
            else {
                return 'aaaa' + a + b;
            }
        }
"
            );
            var test = parser.Parse();
            Console.WriteLine("Hello World!");
        }
    }
}
