using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Question9_5 {

    //指定したディレクトリおよびそのサブディレクトリの配下にあるファイルから
    //ファイルサイズが1Mバイト（1,048,576バイト）以上のファイル名の一覧を表示するプログラムを書いてください。

    class Program {
        static void Main(string[] args) {

            Console.WriteLine("ディレクトリを指定してください。\n（ディレクトリの絶対パスを入力）");
            var wLookUpDirectory = new DirectoryInfo(Console.ReadLine());

            foreach (FileInfo wFile in wLookUpDirectory.GetFiles("*", SearchOption.AllDirectories)
                                                       .Where(x => x.Length >= 1048576)) {
                Console.WriteLine(wFile.Name);
            }
        }
    }
}
