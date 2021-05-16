using System;

namespace Scuti.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Scuti.Lexicon.Parser parser = new Lexicon.Parser(
@"
        import Test;
        @export
        func sum(a,b) {
            return a + b;
        }

        func run() {
            $sum_task = new async sum(1,2);
            $sum_result = await sum_task;
            $inner_function = () => {
                return true;
            };
            $array_example = [1,2, true, 'ok', ()=> true];
            if(1 in array_example) {
                return true;
            }
            for($key in array_example) {

            }
            for($value of array_example) {
                
            }
        }

        @entry_point
        func test (a, b, c) {
            $var = 25;
            if(a == b) {
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
