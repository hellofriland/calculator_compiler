namespace calculator_compiler {
    public partial class CIL {
        private List<IdValueMap> IdValueDatabase = new List<IdValueMap>();

        public double RunCIL(List<string> cilList) {
            for (int i = 0; i < cilList.Count; i++) {
                RunALine(cilList[i]);
            }

            return GetIdValue("id1");
        }

        private void RunALine(string line) {
            CilLineElem lineElem = SplitLine(line);

            switch (lineElem.Op) {
                case "=": {
                    if (ExistId(lineElem.Ln)) {
                        SetValue(lineElem.Ln, lineElem.Rn);
                    }
                    else {
                        AddData(lineElem.Ln, lineElem.Rn);
                    }

                    break;
                }
                case "+=": {
                    double temp = GetIdValue(lineElem.Ln) + GetIdValue(lineElem.Rn);
                    SetValue(lineElem.Ln, temp);
                    RemoveData(lineElem.Rn);
                    break;
                }
                case "-=": {
                    double temp = GetIdValue(lineElem.Ln) - GetIdValue(lineElem.Rn);
                    SetValue(lineElem.Ln, temp);
                    RemoveData(lineElem.Rn);
                    break;
                }
                case "*=": {
                    double temp = GetIdValue(lineElem.Ln) * GetIdValue(lineElem.Rn);
                    SetValue(lineElem.Ln, temp);
                    RemoveData(lineElem.Rn);
                    break;
                }
                case "/=": {
                    double temp = GetIdValue(lineElem.Ln) / GetIdValue(lineElem.Rn);
                    SetValue(lineElem.Ln, temp);
                    RemoveData(lineElem.Rn);
                    break;
                }
                default: {
                    Console.WriteLine($"UnKnowSymbol: {lineElem.Op} in CIL");
                    break;
                }
            }
        }

        private CilLineElem SplitLine(string line) {
            CilLineElem lineElem = new CilLineElem();
            int sub_line_index = 0;


            for (int i = 0; i < line.Length; i++) {
                /* 获取左操作数 */
                while (i < line.Length && Common.IsDigitOrLetter(line[i])) {
                    i++;
                    sub_line_index++;
                }

                lineElem.Ln = line.Substring(0, sub_line_index);
                line = line.Substring(sub_line_index);
                i = 0;
                sub_line_index = 0;

                /* 获取操作符 */
                while (i < line.Length && Common.IsOperator(line[i])) {
                    i++;
                    sub_line_index++;
                }

                lineElem.Op = line.Substring(0, sub_line_index);
                line = line.Substring(sub_line_index);
                i = 0;
                sub_line_index = 0;

                /* 获取右操作数 */
                while (i < line.Length && Common.IsDigitOrLetter(line[i])) {
                    i++;
                    sub_line_index++;
                }

                lineElem.Rn = line.Substring(0, sub_line_index);
                line = line.Substring(sub_line_index);
                i = 0;
                sub_line_index = 0;
            }

            return lineElem;
        }

        int SearchIdPos(string id) {
            int index;
            for (index = 0; index < IdValueDatabase.Count; index++) {
                if (IdValueDatabase[index].Id == id) {
                    return index;
                }
            }

            Console.WriteLine($"No {id} found");
            return -1;
        }

        bool ExistId(string id) {
            bool isExist = false;
            for (int i = 0; i < IdValueDatabase.Count; i++) {
                isExist = IdValueDatabase[i].Id == id;
            }

            return isExist;
        }

        void SetValue(string id, string value) {
            int index = SearchIdPos(id);
            IdValueDatabase[index].Value = Convert.ToDouble(value);
        }

        void SetValue(string id, double value) {
            int index = SearchIdPos(id);
            IdValueDatabase[index].Value = value;
        }

        double GetIdValue(string id) {
            return IdValueDatabase[SearchIdPos(id)].Value;
        }

        void AddData(string id, string value) {
            IdValueMap idv = new IdValueMap(id, Convert.ToDouble(value));
            IdValueDatabase.Add(idv);
        }

        void RemoveData(string id) {
            IdValueDatabase.RemoveAt(SearchIdPos(id));
        }
    }
}
