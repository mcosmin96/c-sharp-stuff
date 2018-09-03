using System;
using CSScriptLibrary;

namespace CSScriptStuff
{
    public interface IScript
    {
        void Bye();
    }
    class Program
    {
        static void Main(string[] args)
        {
            string template =
                @"using System;
                                                            using CSScriptStuff;
            using OutsideOfNamespace;
                                                            public class ScriptName
            {
            public void Run(inputData, configData)
            {
                ###CustomCode###
                
            }

                    ##PrivateFunctions##
                 }";

            string fromFormatFile = @"OutsideOfScript.Write(""Hello world!"");
                OutsideClass.WriteFurther(""asd"");";

            string ScriptToRun = template.Replace("###CustomCode###", fromFormatFile);

            dynamic script = CSScript.Evaluator.LoadCode<IScript>(ScriptToRun);
            IScript fileScript = CSScript.Evaluator.LoadFile<IScript>("Script.cs");
            script.Bye();
            fileScript.Bye();
            Console.Read();
        }
    }

    public class OutsideOfScript
    {
        public static void Write(string s)
        {
            Console.WriteLine(s);
        }

    }
}

namespace OutsideOfNamespace
{
    public class OutsideClass
    {
        public static void WriteFurther(string s)
        {
            Console.WriteLine(s);
        }
    }
}
