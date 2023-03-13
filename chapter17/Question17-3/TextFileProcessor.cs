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
        /// <param name="vFileName">ファイルパス</param>
        public void Run(string vFileName){
            this.FService.Initialize(vFileName);
            using( var wSr = new StreamReader(vFileName)){
                while(!wSr.EndOfStream){
                    string wLine = wSr.ReadLine();
                    FService.Execute(wLine);
                }
            }
            FService.Terminate();
        }
    }
}
