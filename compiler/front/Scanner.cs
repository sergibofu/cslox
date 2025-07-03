using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.front
{
    public class Scanner
    {

        private string Prog { get; set; }
        private List<Token> Tokens { get; set; }
        private int CurrentPosition { get; set; }
        private int CurrentLine { get; set; }
        private int Start { get; set; }


        public Scanner(string prog) { 
            this.Tokens = new List<Token>();
            this.Prog = prog;
            this.Start = 0;
            this.CurrentLine = 0;
            this.CurrentPosition = 0;
        }

        public List<Token> scan()
        {
            while(!isEnd())
            {
                Start = CurrentPosition;
                scanToken();


            }

            Tokens.Add(new Token(TokenType.EOF, "EOF", CurrentLine));
            return Tokens;
        }


        private void scanToken()
        {
            char currentChar = advance();
            switch(currentChar)
            {
                case '\n':
                    CurrentLine++;
                    break;
                case '\r':
                    break;
                case '\t':
                break;
                case '(':
                    addToken(TokenType.LEFT_PAREN, "(");
                    break;
                case ')':
                    addToken(TokenType.RIGHT_PAREN, ")");
                    break;
                case '{':
                    addToken(TokenType.LEFT_BRACE, "{");
                    break;
                case '}':
                    addToken(TokenType.RIGHT_BRACE, "}");
                    break;
                case ';':
                    addToken(TokenType.SEMICOLON, ";");
                    break;
                case ',':
                    addToken(TokenType.COMMA, ",");
                    break;
                case '+':
                    if (match('+')) addToken(TokenType.PLUS_PLUS, "++");
                    else addToken(TokenType.PLUS, "+");
                    break;
                case '!':
                    if (match('=')) addToken(TokenType.BANG_EQUAL, "!=");
                    else addToken(TokenType.BANG, "!");
                    break;
                case '=':
                    if (match('=')) addToken(TokenType.EQUAL_EQUAL, "==");
                    else addToken(TokenType.PLUS, "=");
                    break;
                case '"':
                    while(peek() != '"' && !isEnd()) advance();
                    
                    if (peek() == '"')
                    {
                        addToken(TokenType.STRING, Prog.Substring(Start, CurrentPosition - Start + 1));
                        
                    } else
                    {
                        // super simple error handling
                        Console.WriteLine("String must end with double quotes");
                        Environment.Exit(1);
                    }

                    // advance last char = " if not, will end in infinite loop
                    advance();
                    break;

                default:

                    if(Char.IsDigit(currentChar))
                    {
                        processNumber();
                        break;
                    } else if(Char.IsLetter(currentChar))
                    {
                        processIdentifier();
                        break;
                    }



                    break;
            }
        }

        private void processIdentifier()
        {
            while (Char.IsLetter(peek())) advance();

            string value = Prog.Substring(Start, CurrentPosition - Start);
            TokenType tokenType = ReservedWords.getTypeOrNull(value) ?? TokenType.IDENTIFIER;

            addToken(tokenType, value); 
        }

        private void processNumber()
        {
            while (Char.IsDigit(peek())) advance();
            addToken(TokenType.NUMBER, Prog.Substring(Start, CurrentPosition - Start));
        }

        private void addToken(TokenType type, string value)
        {
            this.Tokens.Add(new Token(type, value, CurrentLine));
        }

        private char advance()
        {
            return Prog[CurrentPosition++];
        }

        private char peek()
        {
            if (isEnd()) return '\0';
            return Prog[CurrentPosition];
        }
        private bool match(char expectedChar)
        {
            if(isEnd()) return false;
            if (Prog[CurrentPosition] != expectedChar) return false;
            CurrentPosition++;
            return true;
        }

        private bool isEnd()
        {
            if (CurrentPosition >= Prog.Length) return true;
            return false;
        }
    }
}
