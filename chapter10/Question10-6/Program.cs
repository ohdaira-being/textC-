using System;
using System.Text.RegularExpressions;

namespace Question10_6 {
    //5文字の回文とマッチする正規表現を書いてください。
    //数字や記号だけからなる回文を除外するには、どうしたらいいかも考えてください。
    class Program {
        static void Main(string[] args) {
            string wPattern = @"\b(\w)(\w)\w\2\1\b[^(\b(\d)(\d)\d\2\1\b)|(_____)]";
            string wExample = "いろしろいｚ あ232あｚ _____ isasi";
            Console.WriteLine(Regex.IsMatch(wExample, wPattern));
        }
    }
}
