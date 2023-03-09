using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            TxtFile.Text = SelectDirectory();
        }

        /// <summary>
        /// ディレクトリを選択するメソッド
        /// </summary>
        /// <returns>選択したディレクトリのフルパス</returns>
        private static string SelectDirectory() {
            using (FolderBrowserDialog wFbDialog = new FolderBrowserDialog()) {
                wFbDialog.Description = "検索対象（ファルダ）の選択";
                wFbDialog.SelectedPath = @"C:";
                return wFbDialog.ShowDialog() == DialogResult.OK ? wFbDialog.SelectedPath : null;
            }
        }

        private async void BtnSearchFile_Click(object sender, EventArgs e) {
            TxtState.Text = "検索中";
            this.Cursor = Cursors.AppStarting;
            // 並列処理検索と非並列処理検索を、並列処理で行う 
            Task<(string, string)> wParallelRun = Task.Run(() => ParallelReadLine());
            Task<(string, string)> wNormalRun = Task.Run(() => NormalReadLine());
            (string, string) wParallelText = await wParallelRun;
            (string, string) wNormalText = await wNormalRun;
            TxtResult.Text = wParallelText.Item1;
            TxtParallelTime.Text = wParallelText.Item2;
            TxtUnParallelTime.Text = wNormalText.Item2;
            this.Cursor = Cursors.Default;
            TxtState.Text = "完了";
        }

        /// <summary>
        /// 並列処理で検索するメソッド
        /// </summary>
        /// <returns>マッチしたパスと処理時間</returns>
        private (string, string) ParallelReadLine() {
            if (!Directory.Exists(TxtFile.Text)) return ("ファイル未選択　or　パスが間違っています。", "未処理");
            var wTimer = Stopwatch.StartNew();
            var wPath = new StringBuilder();
            IEnumerable<string> wFiles = Directory.EnumerateFiles(TxtFile.Text, "*.cs", SearchOption.AllDirectories);
            foreach (string wFile in wFiles.AsParallel()
                                        .Where(x => IsMatchText(x, TxtWord1.Text) && IsMatchText(x, TxtWord2.Text))) {
                wPath.AppendLine($"・{wFile}");
            };
            wTimer.Stop();
            return (wPath.ToString(), wTimer.ElapsedMilliseconds.ToString());
        }

        /// <summary>
        /// 非並列処理で検索するメソッド
        /// </summary>
        /// <returns>マッチしたパスと処理時間</returns>
        private (string, string) NormalReadLine() {
            if (!Directory.Exists(TxtFile.Text)) return ("ファイル未選択　or　パスが間違っています。", "未処理");
            var wTimer = Stopwatch.StartNew();
            var wPath = new StringBuilder();
            IEnumerable<string> wFiles = Directory.EnumerateFiles(TxtFile.Text, "*.cs", SearchOption.AllDirectories);
            foreach (string wFile in wFiles.Where(x => IsMatchText(x, TxtWord1.Text) && IsMatchText(x, TxtWord2.Text))) {
                wPath.AppendLine($"・{wFile}\n");
            };
            wTimer.Stop();
            return (wPath.ToString(), wTimer.ElapsedMilliseconds.ToString());
        }

        /// <summary>
        /// 検索ワードにマッチするか判定するメソッド
        /// </summary>
        /// <param name="vPath">検索先のフルパス</param>
        /// <param name="vText">検索ワード</param>
        /// <returns>マッチしたかどうかの真偽</returns>
        private bool IsMatchText(string vPath, string vText) => Regex.IsMatch(File.ReadAllText(vPath, Encoding.UTF8), $@"\b{vText}\b");
    }
}
