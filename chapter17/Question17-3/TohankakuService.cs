using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Question17_3 {

    /// <summary>
    /// 半角に変換するクラス
    /// </summary>
    public class TohankakuService : ITextFilesService {

        private StringBuilder FHankakuText;

        /// <summary>
        /// 初期値設定クラス
        /// </summary>
        /// <param name="vFileName">ファイルパス</param>
        public void Initialize(string vFileName) => FHankakuText = new StringBuilder();

        /// <summary>
        /// 読み込んだ行を半角にする
        /// </summary>
        /// <param name="vLine">読み込んだ行</param>
        public void Execute(string vLine) => FHankakuText.Append($"{Regex.Replace(vLine, "[０-９]", p => ((char)(p.Value[0] - '０' + '0')).ToString())}\n");

        /// <summary>
        /// コンソールに出力する
        /// </summary>
        public void Terminate() {
            Console.WriteLine(FHankakuText);
            Console.ReadLine();
        }
    }
}
