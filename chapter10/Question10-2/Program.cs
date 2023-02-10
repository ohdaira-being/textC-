using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Question10_2 {

    //テキストファイルを読み込み、3文字以上の数字だけからなる部分文字列を全て抜き出すコードを書いてください。

    class Program {
        static void Main(string[] args) {
            string wFilePath = @"../../../../Sample10-2.txt";

            foreach (string wLine in File.ReadLines(wFilePath)) {
                string wPattern = @"[0-9]{3,}";

                foreach (Match wText in Regex.Matches(wLine, wPattern)) {
                    Console.WriteLine(wText.Value);
                }
            }
        }
    }
}
