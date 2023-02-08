using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Question7_2 {
    /// <summary>
    /// 略語と対応する日本語を管理するクラス
    /// </summary>
    class Abbreviations {
        /// <summary>
        /// 読み込んだファイルからキーと値を取得するディクショナリ
        /// </summary>
        private Dictionary<string, string> FDict = new Dictionary<string, string>();

        //1.の回答
        /// <summary>
        /// カウントプロパティ
        /// </summary>
        public int Count => FDict.Count();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Abbreviations() {
            string[] wLines = File.ReadAllLines("Abbreviations.txt");
            FDict = wLines.Select(line => line.Split('=')).ToDictionary(x => x[0], x => x[1]);
        }

        //2.の回答
        /// <summary>
        /// 要素を削除
        /// </summary>
        /// <param name="vRemoveText">省略語</param>
        /// <returns>削除後のディクショナリDict</returns>
        public bool Remove(string vRemoveText) {
            return FDict.Remove(vRemoveText);
        }

        /// <summary>
        /// 要素を追加
        /// </summary>
        /// <param name="vAbbr">ディクショナリDictに追加するキー</param>
        /// <param name="vJapanese">ディクショナリDictに追加する値</param>
        public void Add(string vAbbr, string vJapanese) {
            FDict[vAbbr] = vJapanese;
        }

        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="vAbbr">検索するキー</param>
        /// <returns>ディクショナリwDictのキー[vAbbr]に対応する値。なければ、nullを返す。</returns>
        public string this[string vAbbr] => FDict.ContainsKey(vAbbr) ? FDict[vAbbr] : null;

        /// <summary>
        /// 日本語から対応する省略語を取り出す
        /// </summary>
        /// <param name="vJapanese">検索する値</param>
        /// <returns>ディクショナリDictの値[vJapanese]に対応する値。なければ、nullを返す。</returns>
        public string ToAddreviations(string vJapanese) {
            return FDict.FirstOrDefault(x => x.Value == vJapanese).Key;
        }

        /// <summary>
        /// 日本語の一部を引数に与え、それが含まれる要素(Key, Value)を全て取り出す
        /// </summary>
        /// <param name="vSubstring">検索するワード</param>
        /// <returns>値に検索ワードを含む全てのディクショナリの要素を返す。</returns>
        public IEnumerable<KeyValuePair<string, string>> FindAll(string vSubstring) {
            foreach (KeyValuePair<string, string> wItem in FDict) {
                if (wItem.Value.Contains(vSubstring)) {
                    yield return wItem;
                }
            }
        }

        /// <summary>
        /// 追加したメソッド。文字数を引数に取り、その文字数のKeyを持ったディクショナリの要素を返す。
        /// </summary>
        /// <param name="vCharNums">文字数int</param>
        /// <returns>指定された文字数のKeyを持ったディクショナリの要素を全て返す。</returns>
        public IEnumerable<KeyValuePair<string, string>> FindDictAtCharNums(int vCharNums) {
            foreach (KeyValuePair<string, string> wDict in FDict.Where(x => x.Key.Length == vCharNums)) {
                yield return wDict;
            }
        }
    }
}
