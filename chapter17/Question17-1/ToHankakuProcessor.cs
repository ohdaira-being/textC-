using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TextFileProcessor;

namespace Question17_1 {
    public class ToHankakuProcessor : TextProcessor {
        private List<string> FLines = new List<string>();
        /// <summary>
        /// 読み込んだ行を半角にするメソッド
        /// </summary>
        /// <param name="vLine">読み込んだ行</param>
        protected override void Execute(string vLine) => FLines.Add(Regex.Replace(vLine, "[０-９]", p => ((char)(p.Value[0] - '０' + '0')).ToString()));
        /// <summary>
        /// コンソールに出力する
        /// </summary>
        protected override void Terminate() {
            // 変換した結果をコンソールに出力する
            foreach (string wLine in FLines) {
                Console.WriteLine(wLine);
            }
            Console.ReadLine();
        }
    }
}
