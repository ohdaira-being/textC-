using System;
using System.Collections.Generic;
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

        private async void button1_Click(object sender, RoutedEventArgs e) {
            var wLines = await ReadLines();
            if (wLines != null) {
                textBox1.Text = string.Join("\n", wLines);
                label1.Content = "読み込んだテキストファイルの内容を表示しています。";
            } else {
                textBox1.Text = "";
                label1.Content = "ファイル選択をキャンセルしました。";
            }
        }

        /// <summary>
        /// ファイルピッカーで選択したファイルを読み込むメソッド
        /// </summary>
        /// <returns>ファイルの内容</returns>
        private async Task<IEnumerable<string>> ReadLines() {
            var wOpenPicker = new FileOpenPicker {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            };
            // ウィンドウハンドルの指定
            ((IInitializeWithWindow)(object)wOpenPicker).Initialize(new WindowInteropHelper(this).Handle);
            wOpenPicker.FileTypeFilter.Add(".txt");
            StorageFile wFile = await wOpenPicker.PickSingleFileAsync();

            if (wFile == null) return null;

            IList<string> wLines = await FileIO.ReadLinesAsync(wFile);

            return wLines;
        }
    }
}
