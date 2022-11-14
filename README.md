# Calculator_Compiler

## 一、运行逻辑

Step 1: 从终端读入一个字符串

Step 2: 将字符串传递给LexicalParser类的GenerateLexicalList方法，该方法会将字符串解析成符号流然后返回

Step 3: 将符号流传入CIL类的GenerateCIL方法，该方法会将符号流转换成中间语言(CIL: Common Intermediate Language)

Step 4: 将中间代码传入CIL类的RunCIL方法，该方法会运行CLI，并返回运算的结果
