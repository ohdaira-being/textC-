using System.IO;

namespace Question17_3 {

    /// <summary>
    /// テキストファイルプロセッサークラス
    /// </summary>
    public class TextFileProcessor {

        private ITextFilesService FService;

        /// <summary>
        /// インターフェース実装クラスを選ぶ
        /// </summary>
        /// <param name="vService">ITextFilesServiceインターフェースを実装したクラスのインスタンス</param>
        public TextFileProcessor(ITextFilesService vService) => FService = vService;

        /// <summary>
        /// 実行メソッド
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        public void Run(string vFilePath){
            FService.Initialize(vFilePath);
            using( var wStreamReader = new StreamReader(vFilePath)){
                while(!wStreamReader.EndOfStream){
                    string wLine = wStreamReader.ReadLine();
                    FService.Execute(wLine);
                }
            }
            FService.Terminate();
        }
    }
}
