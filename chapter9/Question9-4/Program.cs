using System;
using System.IO;

namespace Question9_4 {
    //指定したディレクトリ直下にあるファイルを別のディレクトリにコピーするプログラムを作成してください。
    //その際、コピーするファイル名は、拡張子を含まないファイル名の後ろに、_bakを付加してください。
    //つまり、元のファイル名がGreeting.txtならば、コピー先のファイル名はGreeting_bak.txtという名前にします。
    //コピー先に同名のファイルがある場合は、置き換えてください。
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("ディレクトリ内のファイルをコピーします。\nファイルの絶対パスを入力してください。");
            string wCopyFromDirectory = Console.ReadLine();
            Console.WriteLine("コピー先のディレクトリ名を入力してください。");
            string wCopyToDirectory = Console.ReadLine();
            string wCopiedFileName = $"{wCopyToDirectory}" +
                @"\" +
                $"{Path.GetFileNameWithoutExtension(wCopyFromDirectory)}_bak" +
                $"{Path.GetExtension(wCopyFromDirectory)}";
            File.Copy(wCopyFromDirectory, wCopiedFileName, overwrite: true);
        }
    }
}
