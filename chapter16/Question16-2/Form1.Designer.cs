
namespace Question16_2 {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.BtnSelectFile = new System.Windows.Forms.Button();
            this.BtnSearchFile = new System.Windows.Forms.Button();
            this.LblFile = new System.Windows.Forms.Label();
            this.LblResult = new System.Windows.Forms.Label();
            this.TxtWord1 = new System.Windows.Forms.TextBox();
            this.TxtWord2 = new System.Windows.Forms.TextBox();
            this.LblWord1 = new System.Windows.Forms.Label();
            this.LblWord2 = new System.Windows.Forms.Label();
            this.TxtFile = new System.Windows.Forms.TextBox();
            this.LblParallelTime = new System.Windows.Forms.Label();
            this.LblState = new System.Windows.Forms.Label();
            this.LblParallel = new System.Windows.Forms.Label();
            this.LblUnParallel = new System.Windows.Forms.Label();
            this.LblUnParallelTime = new System.Windows.Forms.Label();
            this.TxtResult = new System.Windows.Forms.TextBox();
            this.TxtState = new System.Windows.Forms.TextBox();
            this.TxtParallelTime = new System.Windows.Forms.TextBox();
            this.TxtUnParallelTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnSelectFile
            // 
            this.BtnSelectFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSelectFile.Location = new System.Drawing.Point(594, 12);
            this.BtnSelectFile.Name = "BtnSelectFile";
            this.BtnSelectFile.Size = new System.Drawing.Size(133, 22);
            this.BtnSelectFile.TabIndex = 0;
            this.BtnSelectFile.Text = "参照";
            this.BtnSelectFile.UseVisualStyleBackColor = true;
            this.BtnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // BtnSearchFile
            // 
            this.BtnSearchFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearchFile.Location = new System.Drawing.Point(594, 46);
            this.BtnSearchFile.Name = "BtnSearchFile";
            this.BtnSearchFile.Size = new System.Drawing.Size(133, 53);
            this.BtnSearchFile.TabIndex = 1;
            this.BtnSearchFile.Text = "検索";
            this.BtnSearchFile.UseVisualStyleBackColor = true;
            this.BtnSearchFile.Click += new System.EventHandler(this.BtnSearchFile_Click);
            // 
            // LblFile
            // 
            this.LblFile.AutoSize = true;
            this.LblFile.Location = new System.Drawing.Point(9, 15);
            this.LblFile.Name = "LblFile";
            this.LblFile.Size = new System.Drawing.Size(75, 15);
            this.LblFile.TabIndex = 2;
            this.LblFile.Text = "検索対象：";
            // 
            // LblResult
            // 
            this.LblResult.AutoSize = true;
            this.LblResult.Location = new System.Drawing.Point(9, 128);
            this.LblResult.Name = "LblResult";
            this.LblResult.Size = new System.Drawing.Size(75, 15);
            this.LblResult.TabIndex = 3;
            this.LblResult.Text = "検索結果：";
            // 
            // TxtWord1
            // 
            this.TxtWord1.Location = new System.Drawing.Point(124, 46);
            this.TxtWord1.Name = "TxtWord1";
            this.TxtWord1.Size = new System.Drawing.Size(282, 22);
            this.TxtWord1.TabIndex = 4;
            this.TxtWord1.Text = "async";
            // 
            // TxtWord2
            // 
            this.TxtWord2.Location = new System.Drawing.Point(124, 74);
            this.TxtWord2.Multiline = true;
            this.TxtWord2.Name = "TxtWord2";
            this.TxtWord2.Size = new System.Drawing.Size(282, 25);
            this.TxtWord2.TabIndex = 5;
            this.TxtWord2.Text = "await";
            // 
            // LblWord1
            // 
            this.LblWord1.AutoSize = true;
            this.LblWord1.Location = new System.Drawing.Point(9, 49);
            this.LblWord1.Name = "LblWord1";
            this.LblWord1.Size = new System.Drawing.Size(87, 15);
            this.LblWord1.TabIndex = 6;
            this.LblWord1.Text = "検索ワード1：";
            // 
            // LblWord2
            // 
            this.LblWord2.AutoSize = true;
            this.LblWord2.Location = new System.Drawing.Point(9, 80);
            this.LblWord2.Name = "LblWord2";
            this.LblWord2.Size = new System.Drawing.Size(87, 15);
            this.LblWord2.TabIndex = 7;
            this.LblWord2.Text = "検索ワード2：";
            // 
            // TxtFile
            // 
            this.TxtFile.Location = new System.Drawing.Point(124, 12);
            this.TxtFile.Name = "TxtFile";
            this.TxtFile.Size = new System.Drawing.Size(453, 22);
            this.TxtFile.TabIndex = 8;
            // 
            // LblParallelTime
            // 
            this.LblParallelTime.AutoSize = true;
            this.LblParallelTime.Location = new System.Drawing.Point(591, 247);
            this.LblParallelTime.Name = "LblParallelTime";
            this.LblParallelTime.Size = new System.Drawing.Size(124, 15);
            this.LblParallelTime.TabIndex = 12;
            this.LblParallelTime.Text = "処理時間（ミリ秒）：";
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Location = new System.Drawing.Point(591, 108);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(75, 15);
            this.LblState.TabIndex = 13;
            this.LblState.Text = "動作状況：";
            // 
            // LblParallel
            // 
            this.LblParallel.AutoSize = true;
            this.LblParallel.Location = new System.Drawing.Point(591, 228);
            this.LblParallel.Name = "LblParallel";
            this.LblParallel.Size = new System.Drawing.Size(83, 15);
            this.LblParallel.TabIndex = 16;
            this.LblParallel.Text = "【並列処理】";
            // 
            // LblUnParallel
            // 
            this.LblUnParallel.AutoSize = true;
            this.LblUnParallel.Location = new System.Drawing.Point(591, 307);
            this.LblUnParallel.Name = "LblUnParallel";
            this.LblUnParallel.Size = new System.Drawing.Size(98, 15);
            this.LblUnParallel.TabIndex = 19;
            this.LblUnParallel.Text = "【非並列処理】";
            // 
            // LblUnParallelTime
            // 
            this.LblUnParallelTime.AutoSize = true;
            this.LblUnParallelTime.Location = new System.Drawing.Point(591, 330);
            this.LblUnParallelTime.Name = "LblUnParallelTime";
            this.LblUnParallelTime.Size = new System.Drawing.Size(124, 15);
            this.LblUnParallelTime.TabIndex = 20;
            this.LblUnParallelTime.Text = "処理時間（ミリ秒）：";
            // 
            // TxtResult
            // 
            this.TxtResult.AcceptsReturn = true;
            this.TxtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.TxtResult.Location = new System.Drawing.Point(124, 132);
            this.TxtResult.Multiline = true;
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.ReadOnly = true;
            this.TxtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtResult.Size = new System.Drawing.Size(452, 304);
            this.TxtResult.TabIndex = 24;
            // 
            // TxtState
            // 
            this.TxtState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtState.Location = new System.Drawing.Point(672, 108);
            this.TxtState.Name = "TxtState";
            this.TxtState.ReadOnly = true;
            this.TxtState.Size = new System.Drawing.Size(76, 15);
            this.TxtState.TabIndex = 25;
            this.TxtState.Text = "未動作";
            // 
            // TxtParallelTime
            // 
            this.TxtParallelTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtParallelTime.Location = new System.Drawing.Point(716, 247);
            this.TxtParallelTime.Name = "TxtParallelTime";
            this.TxtParallelTime.ReadOnly = true;
            this.TxtParallelTime.Size = new System.Drawing.Size(80, 15);
            this.TxtParallelTime.TabIndex = 26;
            this.TxtParallelTime.Text = "0";
            // 
            // TxtUnParallelTime
            // 
            this.TxtUnParallelTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtUnParallelTime.Location = new System.Drawing.Point(716, 330);
            this.TxtUnParallelTime.Name = "TxtUnParallelTime";
            this.TxtUnParallelTime.ReadOnly = true;
            this.TxtUnParallelTime.Size = new System.Drawing.Size(80, 15);
            this.TxtUnParallelTime.TabIndex = 27;
            this.TxtUnParallelTime.Text = "0";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtUnParallelTime);
            this.Controls.Add(this.TxtParallelTime);
            this.Controls.Add(this.TxtState);
            this.Controls.Add(this.TxtResult);
            this.Controls.Add(this.LblUnParallelTime);
            this.Controls.Add(this.LblUnParallel);
            this.Controls.Add(this.LblParallel);
            this.Controls.Add(this.LblState);
            this.Controls.Add(this.LblParallelTime);
            this.Controls.Add(this.TxtFile);
            this.Controls.Add(this.LblWord2);
            this.Controls.Add(this.LblWord1);
            this.Controls.Add(this.TxtWord2);
            this.Controls.Add(this.TxtWord1);
            this.Controls.Add(this.LblResult);
            this.Controls.Add(this.LblFile);
            this.Controls.Add(this.BtnSearchFile);
            this.Controls.Add(this.BtnSelectFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSelectFile;
        private System.Windows.Forms.Button BtnSearchFile;
        private System.Windows.Forms.Label LblFile;
        private System.Windows.Forms.Label LblResult;
        private System.Windows.Forms.TextBox TxtWord1;
        private System.Windows.Forms.TextBox TxtWord2;
        private System.Windows.Forms.Label LblWord1;
        private System.Windows.Forms.Label LblWord2;
        private System.Windows.Forms.TextBox TxtFile;
        private System.Windows.Forms.Label LblParallelTime;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.Label LblParallel;
        private System.Windows.Forms.Label LblUnParallel;
        private System.Windows.Forms.Label LblUnParallelTime;
        private System.Windows.Forms.TextBox TxtResult;
        private System.Windows.Forms.TextBox TxtState;
        private System.Windows.Forms.TextBox TxtParallelTime;
        private System.Windows.Forms.TextBox TxtUnParallelTime;
    }
}

