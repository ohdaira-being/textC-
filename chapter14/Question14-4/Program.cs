﻿using System;
using System.IO;
using System.Net;
using System.Text;

namespace Question14_4 {

    // あなたがよく訪れるWebページのHTMLを取得し、ファイルに保存するプログラムを書いてください。

    class Program {
        static void Main(string[] args) {
            var wWebClient = new WebClient();
            wWebClient.Encoding = Encoding.UTF8;
            string wHtmlText = wWebClient.DownloadString("https://qiita.com/yutorisan/items/d28386f168f2f3ab166d");

            var wSaveFilePath = @"../../../Sample14-4.txt";
            using (var wWriter = new StreamWriter(wSaveFilePath)) {
                wWriter.WriteLine(wHtmlText);
            }

            Console.ReadLine();
        }
    }
}
