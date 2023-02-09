using System;
using System.IO;
using System.Linq;

namespace Question9_3 {

    //あるテキストファイルの最後に別のテキストファイルの内容を追加するコンソールアプリケーションを書いてください。
    //コマンドラインで2つのテキストファイルのパス名を指定できるようにしてください。

    class Program {
        static void Main(string[] args) {

            //変更を加えるファイルを取得し、変数に格納する
            Console.WriteLine(
                "編集したいファイルの絶対パスを入力してください。\n" +
                "（ファイルの最後の行に別のファイルの内容を追加します。）"
                );
            string wEditFilePath = Console.ReadLine();

            //変更を加えるファイルに追加するファイルを取得し、各行を配列で持つ変数に格納する
            Console.WriteLine("追加するファイルの絶対パスを入力してください。");
            string wAddFilePath = Console.ReadLine();
            string[] wLines = File.ReadLines(wEditFilePath).ToArray();

            //ファイルに変更を加える。
            using (var wWriter = new StreamWriter(wAddFilePath, append: true)) {
                foreach (string wLine in wLines) {
                    wWriter.WriteLine(wLine);
                }
            }
        }
    }
}
