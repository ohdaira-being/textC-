using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Question10_4 {

    //テキストファイルを読み込み、version="v4.0"と書かれた箇所を、version="v5.0"に置き換え、同じファイルに保存してください。
    //なお、入力ファイルの=の前後には任意の数の空白文字が入っていることもあります。
    //出力時には、=の前後の空白は削除してください。
    //"version"は、"Version"である可能性もあります。

    class Program {
        static void Main(string[] args) {

            string wFilePath = @"C:\Users\ohdaira\Desktop\C#成果物\idiom\chapter10\Sample10-4.txt";
            var wReplacedTexts = new List<string>();

            foreach (string wLine in File.ReadLines(wFilePath)) {
                string wPattern = @"([Vv]ersion)(\s*=\s*)" + "\"v4.0\"";
                wReplacedTexts.Add(Regex.Replace(wLine, wPattern, "version=\"v5.0\""));
            }
            File.WriteAllLines(wFilePath, wReplacedTexts);
        }
    }
}
