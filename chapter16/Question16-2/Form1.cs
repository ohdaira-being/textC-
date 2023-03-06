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

        private void button1_Click(object sender, EventArgs e) {
            textBox3.Text = ChoiceDirectory();
        }

        /// <summary>
        /// ディレクトリを選択するメソッド
        /// </summary>
        /// <returns>選択したディレクトリのフルパス</returns>
        private static string ChoiceDirectory() {
            FolderBrowserDialog wFbDialog = new FolderBrowserDialog();
            wFbDialog.Description = "検索するディレクトリの選択";
            wFbDialog.SelectedPath = @"C:";
            if (wFbDialog.ShowDialog() == DialogResult.OK) {
                return wFbDialog.SelectedPath;
            } else {
                return "キャンセルされました";
            }
        }

        private async void button2_Click(object sender, EventArgs e) {
            if (textBox3.Text == "") return;
            label8.Text = "検索中";
            // 並列処理検索と非並列処理検索を、並列処理で行う
            var wParallelRun = Task.Run(() => ParallelReadLine());
            var wNormalRun = Task.Run(() => NormalReadLine());
            var wParallelText = await wParallelRun;
            var wNormalText = await wNormalRun;
            textBox4.Text = wParallelText.Item1.ToString();
            label7.Text = wParallelText.Item2;
            textBox5.Text = wNormalText.Item1.ToString();
            label13.Text = wNormalText.Item2;
            label8.Text = "完了";
        }

        /// <summary>
        /// 並列処理で検索するメソッド
        /// </summary>
        /// <returns>マッチしたパスと処理時間</returns>
        private (StringBuilder, string) ParallelReadLine() {
            var wTimer = Stopwatch.StartNew();
            StringBuilder wPath = new StringBuilder();
            IEnumerable<string> wFiles = Directory.EnumerateFiles(textBox3.Text, "*", SearchOption.AllDirectories);
            foreach (string wFile in wFiles.AsParallel()
                                        .Where(x => IsMatchText(x, textBox1.Text) && IsMatchText(x, textBox2.Text))) {
                wPath.Append($"{wFile}\n");
            };
            wTimer.Stop();
            return (wPath, wTimer.ElapsedMilliseconds.ToString());
        }

        /// <summary>
        /// 非並列処理で検索するメソッド
        /// </summary>
        /// <returns>マッチしたパスと処理時間</returns>
        private (StringBuilder, string) NormalReadLine() {
            var wTimer = Stopwatch.StartNew();
            StringBuilder wPath = new StringBuilder();
            IEnumerable<string> wFiles = Directory.EnumerateFiles(textBox3.Text, "*", SearchOption.AllDirectories);
            foreach (string wFile in wFiles.Where(x => IsMatchText(x, textBox1.Text) && IsMatchText(x, textBox2.Text))) {
                wPath.Append($"{wFile}\n");
            };
            wTimer.Stop();
            return (wPath, wTimer.ElapsedMilliseconds.ToString());
        }

        /// <summary>
        /// 検索ワードにマッチするか判定するメソッド
        /// </summary>
        /// <param name="vPath">検索先のフルパス</param>
        /// <param name="vText">検索ワード</param>
        /// <returns>マッチしたかどうかの真偽</returns>
        private bool IsMatchText(string vPath, string vText) => Regex.IsMatch(File.ReadAllText(vPath, Encoding.UTF8), $@"\b{vText}\b");

        private void textBox4_TextChanged(object sender, EventArgs e) {

        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e) {
            this.textBox4.ScrollBars = ScrollBars.Vertical;
        }

        private void textBox5_TextChanged(object sender, EventArgs e) {
            this.textBox5.ScrollBars = ScrollBars.Vertical;
        }

        private void label9_Click(object sender, EventArgs e) {

        }

        private void label12_Click(object sender, EventArgs e) {

        }
    }
}
