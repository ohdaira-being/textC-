namespace Question17_3 {

    /// <summary>
    /// テキストファイルを処理するためのインターフェース
    /// </summary>
    public interface ITextFilesService {

        /// <summary>
        /// 初期状態を決める
        /// </summary>
        /// <param name="vFname">ァイルパス</param>
        void Initialize(string vFname);

        /// <summary>
        /// 読み込み行の処理を決める
        /// </summary>
        /// <param name="vLine">読み込み行</param>
        void Execute(string vLine);

        /// <summary>
        /// 各行の処理が終わった後の処理を決める
        /// </summary>
        void Terminate();
    }
}
