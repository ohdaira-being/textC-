using System;
using System.IO;
using System.Linq;

namespace Question9_2 {

    //テキストファイルを読み込み、行の先頭に行番号を振り、その結果を別のテキストファイルに出力するプログラムを書いてください。
    //書式と出力先のファイル名は自由に決めてかまいません。
    //出力するファイル名と同名のファイルがあった場合は、上書きしてください。

    class Program {
        static void Main(string[] args) {

            string wInputFilePath = @"../../../../CountClass.txt";
            string wOutputFilePath = @"../../../../Copy.txt";
            string[] wLines = File.ReadLines(wInputFilePath).Select((x, ix) => String.Format($"{ix + 1,2}行目：{x}")).ToArray();

            foreach (string wLine in wLines) {
                Console.WriteLine(wLine);
            }

            File.WriteAllLines(wOutputFilePath, wLines);
        }
    }
}
