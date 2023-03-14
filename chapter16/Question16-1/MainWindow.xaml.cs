using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Question16_1 {

    // 問題16.1
    // .NEt Framework4.5以降のStreamReaderクラスには、非同期処理を実現するReadLineAsyncメソッドが追加されています。
    // このメソッドを使い、テキストファイルを非同期で読み込むコードを書いてください。
    // アプリケーションの形態は、WindowsFormsでもWPFでも好きなものを選択してください。

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private async void BtnSelectFile_Click(object sender, RoutedEventArgs e) {
            string wFilePath = await SelectFilePath();
            if (wFilePath == null) return;
            TxtFilePath.Text = wFilePath;
        }

        private async void BtnStartReadFile_Click(object sender, RoutedEventArgs e) {
            string wLines = await ReadLines(TxtFilePath.Text);
            LblProcessState.Content = wLines != null ? TxtFilePath.Text : "ファイル未選択　or　パスが間違っています。";
            TxtShowText.Text = wLines != null ? wLines : String.Empty;
        }

        /// <summary>
        /// ファイルピッカーを出力し、テキストファイルを選択するメソッド
        /// </summary>
        /// <returns>選択したテキストファイルのパス</returns>
        private async Task<string> SelectFilePath() {
            var wOpenPicker = new FileOpenPicker {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                FileTypeFilter = { ".txt" },
            };
            // ウィンドウハンドルの指定
            ((IInitializeWithWindow)(object)wOpenPicker).Initialize(new WindowInteropHelper(this).Handle);
            StorageFile wSelectFile = await wOpenPicker.PickSingleFileAsync();
            return wSelectFile?.Path.ToString();
        }

        /// <summary>
        /// パスからファイル内容を読み込むメソッド
        /// ファイルが見つからないとnullを返す
        /// </summary>
        /// <returns>ファイルの内容</returns>
        private async Task<string> ReadLines(string vFile) {
            if (!File.Exists(vFile)) return null;
            var wTexts = new List<string>();
            using (var wReader = new StreamReader(vFile)) {
                while (!wReader.EndOfStream) {
                    string wText = await wReader.ReadLineAsync();
                    wTexts.Add(wText);
                }
            }
            return String.Join("\n", wTexts);
        }
    }
}
