using System;
using compiler.front;

namespace compiler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string prog = readProgram("C:\\Users\\Usuario\\source\\repos\\compiler\\compiler\\demos\\addition.txt");
            run(prog);
        }

        static void run(string prog)
        {
            Scanner scanner = new Scanner(prog);
            List<Token> tokens = scanner.scan();


            foreach (Token token in tokens)
            {
                Console.WriteLine(token.ToString());
            }
        }

        static string readProgram(string path)
        {
            string result = "";

            try
            {
                result = File.ReadAllText(path);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Environment.Exit(1);
            }

            return result;
        }
        
        
    }
}