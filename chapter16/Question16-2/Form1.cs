using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question16_2 {
    /// <summary>
    /// フォームクラス
    /// </summary>
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void BtnSelectFile_Click(object sender, EventArgs e) {
            using (var wFbDialog = new FolderBrowserDialog()) {
                wFbDialog.Description = "検索対象（フォルダ）の選択";
                wFbDialog.SelectedPath = @"C:";
                if (wFbDialog.ShowDialog() != DialogResult.OK) return;
                TxtDirectoryPath.Text = wFbDialog.SelectedPath;
            }
        }

        private async void BtnSearchFile_Click(object sender, EventArgs e) {
            if (!Directory.Exists(TxtDirectoryPath.Text)) {
                TxtParallelTime.Text = "未検索";
                TxtUnParallelTime.Text = "未検索";
                TxtResult.Text = "フォルダー未選択　or　パスが間違っています。";
                return;
            }
            TxtState.Text = "検索中";
            this.Cursor = Cursors.AppStarting;
            // ファイル取得を非同期にする
            var wFilePaths = await SearchFiles(); 
            (string, string) wParallelText = ParallelSearchPaths(wFilePaths);
            (string, string) wNormalText = NormalSearchPaths(wFilePaths);
            TxtResult.Text = (wParallelText.Item1 != String.Empty) ? wParallelText.Item1 : "検索ワードを含むファイルは、ありませんでした";
            TxtParallelTime.Text = wParallelText.Item2;
            TxtUnParallelTime.Text = wNormalText.Item2;
            this.Cursor = Cursors.Default;
            TxtState.Text = "完了";
        }

        /// <summary>
        /// TxtDirectoryPathテキストボックスのディレクトリパス内の.csファイルを取得する
        /// </summary>
        /// <returns>.csファイルのリスト</returns>
        private async Task<List<string>> SearchFiles() {
            List<string> wPaths = new List<string>();
            await Task.Run(() => {
                wPaths = Directory.EnumerateFiles(TxtDirectoryPath.Text, "*.cs", SearchOption.AllDirectories).ToList();
            });
            return wPaths;
        }

        /// <summary>
        /// 並列処理で検索するメソッド
        /// </summary>
        /// <returns>マッチしたパスと処理時間</returns>
        private (string, string) ParallelSearchPaths(IEnumerable<string> vFilePaths) {
            var wTimer = Stopwatch.StartNew();
            var wSearchedPaths = new StringBuilder();
            foreach (string wPath in vFilePaths.AsParallel().Where(x => IsMatchText(x, TxtWord1.Text) && IsMatchText(x, TxtWord2.Text))) {
                wSearchedPaths.AppendLine($"・{wPath}");
            };
            wTimer.Stop();
            return (wSearchedPaths.ToString(), wTimer.ElapsedMilliseconds.ToString());
        }

        /// <summary>
        /// 非並列処理で検索するメソッド
        /// </summary>
        /// <returns>マッチしたパスと処理時間</returns>
        private (string, string) NormalSearchPaths(IEnumerable<string> vFilePaths) {
            var wTimer = Stopwatch.StartNew();
            var wSearchedPaths = new StringBuilder();
            foreach (string wPath in vFilePaths.Where(x => IsMatchText(x, TxtWord1.Text) && IsMatchText(x, TxtWord2.Text))) {
                wSearchedPaths.AppendLine($"・{wPath}\n");
            };
            wTimer.Stop();
            return (wSearchedPaths.ToString(), wTimer.ElapsedMilliseconds.ToString());
        }

        /// <summary>
        /// 検索ワードにマッチするか判定するメソッド
        /// </summary>
        /// <param name="vPath">検索先のフルパス</param>
        /// <param name="vText">検索ワード</param>
        /// <returns>マッチしたかどうかの真偽</returns>
        private bool IsMatchText(string vPath, string vText) => Regex.IsMatch(File.ReadAllText(vPath, Encoding.UTF8), $@"\b{vText}\b");

        private void TxtDirectoryPath_TextChanged(object sender, EventArgs e) {
            if (Directory.Exists(TxtDirectoryPath.Text)) {
                TxtDirectoryPath.ForeColor = Color.Black;
                BtnSearchFile.Enabled = true;
            } else {
                TxtDirectoryPath.ForeColor = Color.Red;
                BtnSearchFile.Enabled = false;
            }
        }
    }
}
