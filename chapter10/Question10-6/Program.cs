using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Question10_6 {

    //5文字の回文とマッチする正規表現を書いてください。
    //数字や記号だけからなる回文を除外するには、どうしたらいいかも考えてください。

    class Program {
        static void Main(string[] args) {

            //やり直し
            //wWordsから"しんぶんし"、"*トマト*"、level"、"k121k" のみを取り出すようなコードを書いてください。

            var wWords = new List<string>() { "しるし", "こもじ", "しんぶんし", "*トマト*", "level", "noon", "k121k", "12321", "<<*<<", };
            string wPalindrome = @"^(.)(.).\2\1$";//5文字の回文を表す
            string wExcept = @"[^^\W|\d*$]";//記号または数字だけでできた単語を除く

            foreach (string wWord in wWords) {
                if (!Regex.IsMatch(wWord, wPalindrome) || !Regex.IsMatch(wWord, wExcept)) continue;
                Console.WriteLine(wWord);
            }
        }
    }
}
