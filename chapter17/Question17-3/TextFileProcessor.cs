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
            FService.Initialize(vFileName);
            using( var wStreamReader = new StreamReader(vFileName)){
                while(!wStreamReader.EndOfStream){
                    string wLine = wStreamReader.ReadLine();
                    FService.Execute(wLine);
                }
            }
            FService.Terminate();
        }
    }
}
