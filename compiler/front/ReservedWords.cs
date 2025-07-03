using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler.front
{
    public class ReservedWords
    {
        public static Dictionary<string, TokenType> dict = new Dictionary<string, TokenType>()
        {
            { "if", TokenType.IF },
            { "and", TokenType.AND },
            { "class", TokenType.CLASS },
            { "else", TokenType.ELSE },
            { "false", TokenType.FALSE },
            { "for", TokenType.FOR },
            { "fun", TokenType.FUN },
            { "nil", TokenType.NIL },
            { "or", TokenType.OR },
            { "print", TokenType.PRINT },
            { "return", TokenType.RETURN },
            { "super", TokenType.SUPER },
            { "this", TokenType.THIS },
            { "true", TokenType.TRUE },
            { "var", TokenType.VAR },
            { "while", TokenType.WHILE },
        };

        public static TokenType? getTypeOrNull(string type)
        {
            if(dict.ContainsKey(type)) return dict[type]; 
            return null;
        }

    }
}
