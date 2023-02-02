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

            //指定したディレクトリ直下のファイルを表示する。
            foreach (FileInfo wDirectoryFile in OrMoreBytesFiles(wLookUpDirectory)) {
                Console.WriteLine(wDirectoryFile.Name);
            }

            //サブディレクトリ内のファイルを表示する。
            DirectoryInfo[] wSubDirectories = wLookUpDirectory.GetDirectories("*", SearchOption.AllDirectories);
            foreach (DirectoryInfo wSubDirectory in wSubDirectories) {
                foreach (FileInfo wInSubDirectoryFile in OrMoreBytesFiles(wSubDirectory)) {
                    Console.WriteLine(wInSubDirectoryFile.Name);
                }
            }
        }

        private static IEnumerable<FileInfo> OrMoreBytesFiles(DirectoryInfo vDirectory) {
            int wBytes = 1048576;//バイト数
            return vDirectory.GetFiles().Where(x => x.Length >= wBytes);
        }
    }
}
