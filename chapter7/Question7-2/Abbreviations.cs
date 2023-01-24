using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Question7_2 {
    /// <summary>
    /// 略語と対応する日本語を管理するクラス
    /// </summary>
    class Abbreviations {
        private Dictionary<string, string> wDict = new Dictionary<string, string>();

        //1.の回答
        public int Count => wDict.Count();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Abbreviations() {
            var wLines = File.ReadAllLines("Abbreviations.txt");
            wDict = wLines.Select(line => line.Split('=')).ToDictionary(x => x[0], x => x[1]);
        }

        //2.の回答
        public bool Remove(string vRemoveText) {
            return wDict.Remove(vRemoveText);
        }

        /// <summary>
        /// 要素を追加
        /// </summary>
        /// <param name="vAbbr">ディクショナリwDictに追加するキー</param>
        /// <param name="vJapanese">ディクショナリwDictに追加する値</param>
        public void Add(string vAbbr, string vJapanese) {
            wDict[vAbbr] = vJapanese;
        }

        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="vAbbr">検索するキー</param>
        /// <returns>ディクショナリwDictのキー[vAbbr]に対応する値。なければ、nullを返す。</returns>
        public string this[string vAbbr] {
            get {
                return wDict.ContainsKey(vAbbr) ? wDict[vAbbr] : null;
            }
        }

        /// <summary>
        /// 日本語から対応する省略語を取り出す
        /// </summary>
        /// <param name="vJapanese">検索する値</param>
        /// <returns>ディクショナリwDictの値[vJapanese]に対応する値。なければ、nullを返す。</returns>
        public string ToAddreviations(string vJapanese) {
            return wDict.FirstOrDefault(x => x.Value == vJapanese).Key;
        }

        /// <summary>
        /// 日本語の位置を引数に与え、それが含まれる要素(Key, Value)を全て取り出す
        /// </summary>
        /// <param name="vSubstring">検索するワード</param>
        /// <returns>値に検索ワードを含む全てのディクショナリの要素を返す。</returns>
        public IEnumerable<KeyValuePair<string, string>> FindAll(string vSubstring) {
            foreach (var wItem in wDict) {
                if (wItem.Value.Contains(vSubstring))
                    yield return wItem;
            }
        }

        /// <summary>
        /// 追加したメソッド。文字数を引数に取り、その文字数のKeyを持ったディクショナリの要素を返す。
        /// </summary>
        /// <param name="vKeyCharNum">文字数int</param>
        /// <returns>指定された文字数のKeyを持ったディクショナリの要素を全て返す。</returns>
        public IEnumerable<KeyValuePair<string, string>> FindKeyAllAtNum(int vKeyCharNum) {
            foreach (KeyValuePair<string, string> wItemAtNum in wDict.Where(x => x.Key.Length == vKeyCharNum)) {
                yield return wItemAtNum;
            }
        }
    }
}
