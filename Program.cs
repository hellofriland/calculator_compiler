namespace calculator_compiler {
    class Program {
        public static void Main() {
            string text;
            text = "1+5+8+(10*7-100)+6*8";
            // text = Console.ReadLine();
            Console.WriteLine($"I will calculate : {text}");
            CIL cil = new CIL();

            /* 将输入的字符解析成词汇流*/
            List<string> lexicalList = LexicalParser.GenerateLexicalList(text);
            IOFile.OutputTextLine(lexicalList, "../../../IO/lexicalList.txt");

            /* 将词汇流转换成中间语言*/
            List<string> cliList = cil.GenerateCIL(IOFile.InputTextLine("../../../IO/lexicalList.txt"));
            IOFile.OutputTextLine(cliList, "../../../IO/cil.txt");

            /*运行中间语言*/
            Console.WriteLine(cil.RunCIL(cliList));
        }
    }
}