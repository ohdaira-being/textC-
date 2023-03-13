using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Question17_3 {
    /// <summary>
    /// 半角に変換するクラス
    /// </summary>
    public class TohankakuService : ITextFilesService {
        private List<string> FLines = new List<string>();
        /// <summary>
        /// 初期値設定クラス
        /// </summary>
        /// <param name="vFileName">ファイルパス</param>
        public void Initialize(string vFileName) {
        }
        /// <summary>
        /// 読み込んだ行を半角にする
        /// </summary>
        /// <param name="vLine">読み込んだ行</param>
        public void Execute(string vLine) => FLines.Add(Regex.Replace(vLine, "[０-９]", p => ((char)(p.Value[0] - '０' + '0')).ToString()));
        /// <summary>
        /// コンソールに出力する
        /// </summary>
        public void Terminate() {
            // 変換した結果をコンソールに出力する
            foreach (string wLine in FLines) {
                Console.WriteLine(wLine);
            }
            Console.ReadLine();
        }
    }
}
