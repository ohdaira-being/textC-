using System;
using System.Linq;
using System.IO;
using System.Text;

namespace Question9_1 {


    //1.指定したC#のソースファイルを読み込み、キーワード"class"が含まれている行数を
    //カウントするコンソールアプリケーションCountClassを作成してください。
    //このとき、StreamReaderクラスを使い、1行ずつ読み込む処理にしてください。
    //なお、以下の2点を前提としてかまいません。
    //・classキーワードの前後には、必ず空白文字がある。
    //・リテラル文字列やコメントの中には、"class"という単語は含まれていない

    //2.このプログラムをFile.ReadAllLinesメソッドを利用して書き換えてください。

    //3.このプログラムをFile.ReadLineメソッドを利用して書き換えてください。


    class CountClass {
        static void Main(string[] args) {
            string wFilePath = @"../../../../CountClass.txt";

            if (File.Exists(wFilePath)) {

                //1.の回答
                using (var wReader = new StreamReader(wFilePath, Encoding.UTF8)) {
                    int wCount = 0;
                    while (!wReader.EndOfStream) {
                        if (wReader.ReadLine().Contains("class")) wCount++;
                    }
                    Console.WriteLine(wCount);
                }

                //2.の回答
                Console.WriteLine(File.ReadAllLines(wFilePath).Count(x => x.Contains("class")));

                //3.の回答
                Console.WriteLine(File.ReadLines(wFilePath).Count(x => x.Contains("class")));

            } else {
                Console.WriteLine("指定されたファイルがありません。");
            }


        }
    }
}
