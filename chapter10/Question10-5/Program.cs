using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Question10_5 {
    //HTMLファイルを読み込み、<DIV>や<P>などのタグ名が大文字になっているものを<div>、<p>などと小文字のタグに変換してください。
    //可能ならば、<DIV class="myBox" id="myId">のように属性が記述されている場合にも対応してください。
    //属性の中には、'<'、'>'は含まれていないものとします。
    class Program {
        static void Main(string[] args) {
            string wFilePath = @"C:\Users\ohdaira\Desktop\C#成果物\idiom\chapter10\Sample10-5.html";
            var wReplacedTexts = new List<string>();
            foreach (string wLine in File.ReadLines(wFilePath)) {
                string wPattern = @"<\s*[A-Z]{1,}[>\s]";
                if (Regex.IsMatch(wLine, wPattern)) {
                    foreach (Match wMachedWord in Regex.Matches(wLine, wPattern)) {
                        wReplacedTexts.Add(Regex.Replace(wLine, wMachedWord.Value, wMachedWord.Value.ToLower()));
                    }
                } else {
                    wReplacedTexts.Add(wLine);
                }
            }
            File.WriteAllLines(wFilePath, wReplacedTexts);
        }
    }
}
