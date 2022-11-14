namespace calculator_compiler {
    struct CLILineElem {
        public string Ln;
        public string Op;
        public string Rn;
    }

    class IdValueMap {
        public string Id;
        public double Value;

        public IdValueMap(string id, double value) {
            Id = id;
            Value = value;
        }
    }

    public class Common {
        private static string[] MyOperator = { "+", "=", "-", "*", "/" };

        public struct Token {
            public string Type;
            public string Value;

            public Token(string type, string value) {
                Type = type;
                Value = value;
            }
        }

        public static bool IsDigit(char ch) {
            if (Char.IsDigit(ch)) {
                return true;
            }

            return false;
        }

        public static bool IsDigitOrLetter(char ch) {
            if (Char.IsDigit(ch) || Char.IsLetter(ch)) {
                return true;
            }

            return false;
        }

        public static bool IsOperator(string str) {
            for (int i = 0; i < MyOperator.Length; i++) {
                if (MyOperator[i] == str) {
                    return true;
                }
            }

            return false;
        }

        public static bool IsOperator(char ch) {
            for (int i = 0; i < MyOperator.Length; i++) {
                if (MyOperator[i] == Convert.ToString(ch)) {
                    return true;
                }
            }

            return false;
        }
    }
}