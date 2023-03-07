using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Question14_1 {

    // ファイルにプログラムのパスとパラメータが複数行書かれています。
    // このファイルを読み込み、プログラムを順に起動するプログラムを書いてください。
    // 1つのプログラムが終わるのを待って、次のプログラムを起動してください。
    // 入力するファイルの形式は、通常のテキストファイルでもXMLファイルでも、好みの形式でもかまいません。

    class Program {
        static void Main(string[] args) {
            var wFilePath = @"..\..\..\Sample14-1.txt";
            foreach (string wLine in File.ReadAllLines(wFilePath, Encoding.UTF8)) {
                Console.WriteLine(wLine);
                string[] wTextArray = wLine.Split(' ');
                RunAndWait(wTextArray.FirstOrDefault(x => Path.HasExtension(x)), wTextArray[1]);
            }
            Console.WriteLine("テキストファイルのパスの実行を完了しました。");
            Console.ReadLine();
        }
        private static void RunAndWait(string vPath, string vText) {
            using (var wProcess = Process.Start(vPath, vText)) {
                wProcess.WaitForExit();
            }
        }
    }
}
