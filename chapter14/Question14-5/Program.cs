using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;

namespace Question14_5 {

    // 指定されたZIPファイルから、拡張子が.txtのファイルだけを抽出するコンソールアプリケーションを作成してください。
    // ZIPファイルと出力先フォルダは以下に示すようにパラメータで指定します。
    // 第1パラメータがZIPファイルのパス、第2パラメータが出力先フォルダです。
    // 出力先フォルダが存在しない場合は、新たに作成してください。

    // uniziptxt.exe d:\temp\sample.zip d:\work

    class Program {
        // コマンドライン引数argsにパスを設定してます。
        static void Main(string[] args) {
            using (ZipArchive wZipFile = ZipFile.OpenRead(args[0])) {
                var wRegex = new Regex(@"\.txt$");
                IEnumerable<ZipArchiveEntry> wTxtFiles = wZipFile.Entries.Where(x => wRegex.IsMatch(x.Name));
                foreach (var wTxtFile in wTxtFiles) {
                    if (wTxtFile != null) {
                        var wFilePath = Path.Combine(args[1], wTxtFile.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(wFilePath));
                        wTxtFile.ExtractToFile(wFilePath, overwrite: true);
                    }
                }
            }
        }
    }
}
