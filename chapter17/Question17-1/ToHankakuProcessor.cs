using System;
using System.Text;
using System.Text.RegularExpressions;
using TextFileProcessor;

namespace Question17_1 {
    /// <summary>
    /// ファイル内の全角数字を半角に置き換えて、コンソールに出力するクラス
    /// </summary>
    public class ToHankakuProcessor : TextProcessor {
        private StringBuilder FHankakuText;

        /// <summary>
        /// FHankakuLinesの初期値設定
        /// </summary>
        /// <param name="vFPath">読み込んだ行</param>
        protected override void Initialize(string vFPath) {
            FHankakuText = new StringBuilder();
        }

        /// <summary>
        /// 半角にしてFHankakuLinesに格納する
        /// </summary>
        /// <param name="vLine">読み込んだ行</param>
        protected override void Execute(string vLine) => FHankakuText.Append($"{Regex.Replace(vLine, "[０-９]", p => ((char)(p.Value[0] - '０' + '0')).ToString())}\n");

        /// <summary>
        /// コンソールに出力する
        /// </summary>
        protected override void Terminate() {
            Console.WriteLine(FHankakuText);
            Console.ReadLine();
        }
    }
}
