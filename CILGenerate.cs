namespace calculator_compiler {
    /// <summary>
    /// Common Intermediate Language
    /// </summary>
    public partial class CIL {
        private List<string> cilList = new List<string>();

        private List<Common.Token> lexicalList = new List<Common.Token>();
        private int lexicalListPos = 0;
        private Common.Token currentToken;

        private string[] idPool = { "id1", "id2", "id3", "id4", "id5", "id6", "id7", "id8" };
        private int idPoolPos = 0;

        private string GetId() {
            if (idPoolPos >= idPool.Length) {
                Console.WriteLine("IdPool is exhausted");
            }

            string id = idPool[idPoolPos];
            idPoolPos++;
            return id;
        }

        private void ReleaseId(string id) {
            if (idPoolPos > 0) {
                idPoolPos--;
            }
        }

        public List<string> GenerateCIL(List<string> lexicalText) {
            ConvertToToken(lexicalText);
            NextToken();
            MyStatements();

            return cilList;
        }

        private void ConvertToToken(List<string> lexicalText) {
            for (int i = 0; i < lexicalText.Count; i++) {
                string[] str = lexicalText[i].Split(',');
                lexicalList.Add(new Common.Token(str[0], str[1]));
            }
        }

        private void NextToken() {
            currentToken = lexicalList[lexicalListPos];
            lexicalListPos++;
        }


        private void MyStatements() {
            string id = GetId();
            MyExpression(id);

            while ((currentToken.Type == "Eoi") == false) {
                MyExpression(id);
                ReleaseId(id);
            }
        }

        private void MyExpression(string tempId) {
            string id;
            MyTerm(tempId);

            if (currentToken.Type == "Operator") {
                while (currentToken.Value == "+") {
                    NextToken();
                    id = GetId();
                    MyTerm(id);
                    cilList.Add($"{tempId}+={id}");
                    ReleaseId(id);
                }

                while (currentToken.Value == "-") {
                    NextToken();
                    id = GetId();
                    MyTerm(id);
                    cilList.Add($"{tempId}-={id}");
                    ReleaseId(id);
                }
            }
        }

        private void MyTerm(string tempId) {
            string id;
            MyFactor(tempId);

            if (currentToken.Type == "Operator") {
                while (currentToken.Value == "*") {
                    NextToken();
                    id = GetId();
                    MyFactor(id);
                    cilList.Add($"{tempId}*={id}");
                    ReleaseId(id);
                }

                while (currentToken.Value == "/") {
                    NextToken();
                    id = GetId();
                    MyFactor(id);
                    cilList.Add($"{tempId}/={id}");
                    ReleaseId(id);
                }
            }
        }

        private void MyFactor(string tempId) {
            if (currentToken.Type == "Num") {
                cilList.Add($"{tempId}={currentToken.Value}");
                NextToken();
            }
            else if (currentToken.Type == "Separator") {
                if (currentToken.Value == "(") {
                    NextToken();
                    MyExpression(tempId);

                    if (currentToken.Value == ")") {
                        NextToken();
                    }
                }
            }
        }
    } // class CIL
} // namespace calculator_compiler
