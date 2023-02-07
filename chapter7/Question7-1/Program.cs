using System;
using System.Collections.Generic;
using System.Linq;

namespace Question7_1 {
    //"Cozy lummox gives smart squid who asks for job pen"という文字列があります。
    //この文字列に対して、以下のコードを書いてください。

    //1.各アルファベット文字（空白などアルファベット意外は除外）が何文字ずつ現れるかカウントするプログラムを書いてください。
    //このときに、必ずディクショナリクラスを使ってください。
    //大文字/小文字の区別はしないでください。
    //以下の形式で出力してください。
    //'A':2
    //'B':1
    //'C':1
    //'D':1
    //  :
    //  :

    //2.上記プログラムを、SortedDictionary<TKey, TValue>を使って書き換えてください。

    class Program {
        static void Main(string[] args) {
            //1.の回答
            Console.WriteLine("～1問目の回答～");
            string wText = "Cozy lummox gives smart squid who asks for job pen";
            var wTextDict = new Dictionary<char, int>();
            foreach (char wWord in wText.ToUpper().Replace(" ", "").Distinct()) {
                wTextDict[wWord] = wText.ToUpper().Count(x => x == wWord);
            }
            foreach (KeyValuePair<char, int> wDict in wTextDict.OrderBy(x => x.Key)) {
                Console.WriteLine($"'{wDict.Key}'：{wDict.Value}");
            }

            //追加
            Console.WriteLine("～追加の回答～");
            var yyy = wText.Replace(" ","").ToUpper().GroupBy(x=>x);
            foreach(var ww in yyy){
                Console.WriteLine($"{ww.Key}：{ww.Count()}");
            }

            //2.の回答
            Console.WriteLine("～2問目の回答～");
            var wRewriteTextDict = new SortedDictionary<char, int>();
            foreach (char wWord in wText.Replace(" ", "").Distinct()) {
                wRewriteTextDict[wWord] = wText.Count(x => x == wWord);
            }
            foreach (KeyValuePair<char, int> wDict in wRewriteTextDict) {
                Console.WriteLine($"'{wDict.Key}'：{wDict.Value}");
            }
        }
    }
}
