using System;
using System.IO;
using System.Linq;

namespace Question9_3 {
    //あるテキストファイルの最後に別のテキストファイルの内容を追加するコンソールアプリケーションを書いてください。
    //コマンドラインで2つのテキストファイルのパス名を指定できるようにしてください。
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(
                "編集したいファイルの絶対パスを入力してください。\n（ファイルの最後の行に別のファイルの内容を追加します。）"
                );
            var wEditFilePath = Console.ReadLine();
            Console.WriteLine("追加するファイルの絶対パスを入力してください。");
            var wAddFilePath = Console.ReadLine();
            var wLines = File.ReadLines(wEditFilePath).ToArray();
            using (var wWriter = new StreamWriter(wAddFilePath, append: true)) {
                foreach (var wLine in wLines) {
                    wWriter.WriteLine(wLine);
                }
            }
        }
    }
}
