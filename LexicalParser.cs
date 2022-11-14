namespace calculator_compiler {
    public class LexicalParser {
        public static List<string> GenerateLexicalList(string text) {
           List<string> lexicalList = new List<string>();
            
            string sub_text = "";
            int sub_index = 0;

            for (int i = 0; i < text.Length;) {
                i = 0;
                sub_text = text.Substring(0, 1);

                switch (sub_text) {
                    case "+": { text = text.Substring(1); lexicalList.Add($"Operator,{sub_text}"); break; }
                    case "-": { text = text.Substring(1); lexicalList.Add($"Operator,{sub_text}"); break; }
                    case "*": { text = text.Substring(1); lexicalList.Add($"Operator,{sub_text}"); break; }
                    case "/": { text = text.Substring(1); lexicalList.Add($"Operator,{sub_text}"); break; }
                    case "(": { text = text.Substring(1); lexicalList.Add($"Separator,{sub_text}"); break; }
                    case ")": { text = text.Substring(1); lexicalList.Add($"Separator,{sub_text}"); break; }

                    default: {
                        if (Common.IsDigit(sub_text[0]) == false) {
                            Console.WriteLine("UnKnowSymbol");
                            break;
                        }

                        while (i < text.Length && Common.IsDigit(text[i])) {
                            sub_index++;
                            i++;
                        }

                        sub_text = text.Substring(0, sub_index);
                        text = text.Substring(sub_index);
                        lexicalList.Add($"Num,{sub_text}");
                        
                        break;
                    } 
                } // switch
                i = 0;
                sub_index = 0;
            } // for
            lexicalList.Add("Eoi,Eoi");
            return lexicalList;
        } // AnalysisText(string text)
    } // class LexicalAnalysis
} // namespace calculator_compiler