using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString = "#AB1234";
            Regex myFirstRegex = new Regex("/#[ABCDEF0123456789]/"); // this would match "#A"
            myFirstRegex = new Regex("/#[ABCDEF0123456789]?/"); // this would match "#A" - ? match 0 or 1 times
            myFirstRegex = new Regex("/#[ABCDEF0123456789]*/"); // this would match "#AB1234" - * match 0 or more times
            myFirstRegex = new Regex("/#[ABCDEF0123456789]+/"); // this would match "#AB1234" - + match 1 or more times
            myFirstRegex = new Regex("/#[A-F0-9]+/"); // this would match "#AB1234" - - used to fill in empty sequential spaces

            testString = "AB1234";
            myFirstRegex = new Regex("/#[A-F0-9]+/"); // this would not match
            myFirstRegex = new Regex("/#?[A-F0-9]+/"); // this would match "AB1234"

            testString = "AB";
            myFirstRegex = new Regex("/#?[A-F0-9]+/"); // this would match "AB"
            myFirstRegex = new Regex("/#?[A-F0-9]{6}/"); // this would not match - {x} match x times

            testString = "#FFF";
            myFirstRegex = new Regex("/#?[A-F0-9]{6}/"); // this would not match
            myFirstRegex = new Regex("/#?([A-F0-9]{6}|[A-F0-9]{3})/"); // this would match "#FFF" and "FFF"

            testString = "#AB1234";
            myFirstRegex = new Regex("/#?([A-F0-9]{6}|[A-F0-9]{3})/"); // this would match "#AB1234" and "AB1234"

            testString = "#Ab1234";
            myFirstRegex = new Regex("/#?([A-F0-9]{6}|[A-F0-9]{3})/"); // this would not match
            myFirstRegex = new Regex("/#?([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})/"); // this would match "#Ab1234" and "Ab1234"
            myFirstRegex = new Regex("/#?([A-F0-9]{6}|[A-F0-9]{3})/i"); // this would match "#Ab1234" and "Ab1234" - i match case insensitive

            testString = "asdfghjABCDEF0123";
            myFirstRegex = new Regex("/#?([A-F0-9]{6}|[A-F0-9]{3})/i"); //this would match "ABCDEF" and "ABCDEF"
            myFirstRegex = new Regex("/^#?([A-F0-9]{6}|[A-F0-9]{3})/i"); //this would not match - ^ the expression has to start at the beginning of testString

            testString = "ABCDEFxyz";
            myFirstRegex = new Regex("/^#?([A-F0-9]{6}|[A-F0-9]{3})/i"); //this would match "ABCDEF" and "ABCDEF"
            myFirstRegex = new Regex("/^#?([A-F0-9]{6}|[A-F0-9]{3})$/i"); //this would not match - $ the expression has to end at the ending of testString

            testString = "    #Abc123   ";
            myFirstRegex = new Regex("/^#?([A-F0-9]{6}|[A-F0-9]{3})$/i"); //this would not match
            myFirstRegex = new Regex("/^[\t\f\n\r]*#?([A-F0-9]{6}|[A-F0-9]{3})[\t\f\n\r]*$/i"); //this would match "#Abc123" and "Abc123" 
            myFirstRegex = new Regex("/^\s*#?([A-F0-9]{6}|[A-F0-9]{3})\s*$/i"); //this would match "#Abc123" and "Abc123" - \s matches any whitespace

            /* MetaCharacters
             * [] - character classes - empty is invalid
             * [a-f_%0-9] - match the a-f, 0-9 sequences and _ or %
             * [^abcdef] - match everything but a-f
             * [-a-f^] - match a-f and - or ^
             * [--/a-f] or [a-f+--0-1] - match ranges that begin or end in - 
             * [[] [a-f\[\]] - match [ and ]
             * 
             * . - wildcard match everything apart from \n (add dotall modifier to match that too)
             * 
             * ? match 0 or 1
             * * match 0 or many //goes for the most matches
             * + match 1 or many //goes for the most matches
             * ?? *? +? {}? //goes for the fewest matches, even 0
             * {n} match n times
             * {n,} match n or more times
             * {n,m} match between n and m times
             * 
             * | or
             * \bbe\b - word delimiter, matches " be " doesnt match "begin"
             * 
             **Shortcodes
             * [0-9] = \d - digits
             * [A-Za-z0-9_] = \w wordchars
             * [\t\f\r\n] = \s - whitespaces
             * ^[0-9] = \D
             * same for \W and \S
             * 
             **Modifies
             * g - global - 
             * i - case insensitive
             * m - multiline - changes ^ and $ to go over lines
             * s - dotall or singleline - makes . wildcard to match \n
             * x - extended - ignores all whitespaces
             * 
             **Delimiters
             * // - default
             * you can use alternative ones like '' for example 'http://' bc you have // in the http?
             * 
             */


        }
    }
}
