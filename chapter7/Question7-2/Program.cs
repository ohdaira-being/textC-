using System;
using System.Collections.Generic;

namespace Question7_2 {
    //「7.3：ディクショナリを使ったサンプルプログラム」で作成したプログラムに、以下の機能を追加してください。

    //1.ディクショナリに登録されている用語の数を返すCountプロパティをAddreviationsクラスに追加してください。

    //2.省略語を引数に受け取るRemoveメソッドをAddreviationsクラスに追加してください。
    //要素が見つからない場合はfalseを、削除できた場合はtrueを返してください。

    //3.CountプロパティとRemoveプロパティを利用するコードを書いてください。

    //4.3文字の省略語だけを取り出し、以下の形式でコンソールに出力するコードを書いてください。
    //必要ならAddreviationsクラスに新たなメソッドを追加してください。
    //ILO=国際労働基幹
    //IMF=国際通貨基金
    //    ：
    //    ：

    class Program {
        static void Main(string[] args) {

            //1と2の回答は、Abbreviationsクラスの上の方に書いています。
            //Abbreviationsクラスは、教科書のコピーに問題1.2の回答と問題４で使うメソッドを定義したクラスです。

            //3.の回答
            Console.WriteLine("～３の回答～");
            Abbreviations wSampleDict = new Abbreviations();
            Console.WriteLine($"ディクショナリに追加前の用語数は、{wSampleDict.Count}語");
            wSampleDict.Add("本シス", "本社システム課");
            Console.WriteLine($"ディクショナリに追加後の用語数は、{wSampleDict.Count}語");
            if (wSampleDict.Remove("本シス")) {
                Console.WriteLine("削除されました。");
            } else {
                Console.WriteLine("削除できませんでした。");
            }
            Console.WriteLine($"ディクショナリから削除語の用語数は、{wSampleDict.Count}語");

            //4.の回答
            //Abbreviationsクラスの一番下にFindKeyAllAtNumメソッドを定義しました。
            Console.WriteLine("～４の回答～");
            foreach (KeyValuePair<string, string> wItemAtNum in wSampleDict.FindKeyAllAtNum(3)) {
                Console.WriteLine($"{wItemAtNum.Key}={wItemAtNum.Value}");
            }
        }
    }
}
