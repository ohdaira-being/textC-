using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Question10_5 {

    //HTMLファイルを読み込み、<DIV>や<P>などのタグ名が大文字になっているものを<div>、<p>などと小文字のタグに変換してください。
    //可能ならば、<DIV class="myBox" id="myId">のように属性が記述されている場合にも対応してください。
    //属性の中には、'<'、'>'は含まれていないものとします。

    class Program {
        static void Main(string[] args) {

            string wFilePath = @"../../../../Sample10-5.html";
            var wReplacedTexts = new List<string>();

            foreach (string wLine in File.ReadLines(wFilePath)) {
                wReplacedTexts.Add(TagToLower(wLine));
            }
            File.WriteAllLines(wFilePath, wReplacedTexts);
        }

        //引数で行を受け取り、タグを全て小文字にした行を返すメソッド
        private static string TagToLower(string vLine) {
            string wPattern = @"<[/\s]*[A-Z]{1,}[>\s]";
            foreach (Match wTagWord in Regex.Matches(vLine, wPattern)) {
                string wEditedLine = Regex.Replace(vLine, wTagWord.Value, wTagWord.Value.ToLower());
                vLine = wEditedLine;
            }
            return vLine;
        }
    }
}
