using System.IO;

namespace TextFileProcessor {

    /// <summary>
    /// テキストファイルを処理する流れを実装したクラス（使用するフレームワーク）
    /// </summary>
    public abstract class TextProcessor {

        /// <summary>
        /// 実行メソッド
        /// </summary>
        /// <typeparam name="T">実行クラス型</typeparam>
        /// <param name="wFilePath">ファイルパス</param>
        public static void Run<T>(string wFilePath) where T : TextProcessor, new() {
            var wSelf = new T();
            wSelf.Process(wFilePath);
        }

        private void Process(string vFileName) {
            Initialize(vFileName);
            using (var wStreamReader = new StreamReader(vFileName)) {
                while (!wStreamReader.EndOfStream) {
                    string wLine = wStreamReader.ReadLine();
                    Execute(wLine);
                }
            }
            Terminate();
        }

        /// <summary>
        /// 初期状態を決める
        /// </summary>
        /// <param name="vFPath">ファイルパス</param>
        protected virtual void Initialize(string vFPath) { }

        /// <summary>
        /// 読み込み行の処理を決める
        /// </summary>
        /// <param name="vLine">読み込み行</param>
        protected virtual void Execute(string vLine) { }

        /// <summary>
        /// 各行の処理が終わった後の処理を決める
        /// </summary>
        protected virtual void Terminate() { }
    }
}
