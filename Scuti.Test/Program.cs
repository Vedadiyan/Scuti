using System;
using System.Linq;
using Scuti.ASP.Internals;
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
            try {
                return a + b;
            }
            catch($error) {
                throw error;
            }
        }

        @singleton
        func const_value() => sum(1000,2000);

        func short_function(a,b) => a * b;
        
        func run() {
            $task_example = new sum(1,2);
            $lock_example = new sync sum(1,2);
            $sum_task = new async sum(1,2);
            if(sneak sum_task == 0) {
                $sum_result = await sum_task;
            }
            delete sum_task;
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
            $var = 25.6;
            if(a == b) {
                return true;
            }
            else {
                return 'aaaa' + a + b;
            }
        }
"
            );
            var zzz = parser.Parse();
            var test = parser.Parse().Classify().ToArray();
            Console.WriteLine("Hello World!");
        }
    }
}
