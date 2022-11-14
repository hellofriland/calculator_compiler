namespace calculator_compiler {
    public class IOFile {
        /// <summary>
        /// 从指定文件中导入所有行
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> InputTextLine(string path) {
            List<string> list;
            list = new List<string>(File.ReadAllLines(path));

            return list;
        }

        /// <summary>
        /// 将列表的内容以行为单位输出到指定txt文件中
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public static void OutputTextLine(List<string> list, string path) {
            FileInfo fl = new FileInfo(path);
            FileStream fs = fl.Create();
            fs.Close();
            fl.Delete();

            using (StreamWriter sw = new StreamWriter(path)) {
                for (int i = 0; i < list.Count; i++) {
                    sw.WriteLine(list[i]);
                }
            }
        }
    }
}