using System;

namespace Question2_1 {
    /// <summary>
    /// 曲クラス
    /// </summary>
    public class Song {
        /// <summary>
        /// 曲のタイトル
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 曲のアーティスト名
        /// </summary>
        public string ArtistName { get; set; }
        /// <summary>
        /// 曲の長さ（最長60分として、秒数で取得）
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 曲のコンストラクタ
        /// </summary>
        /// <param name="vTitle">曲のタイトル</param>
        /// <param name="vArtistName">曲のアーティスト名</param>
        /// <param name="vLength">曲の長さ</param>
        public Song(string vTitle, string vArtistName, int vLength) {
            this.Title = vTitle;
            this.ArtistName = vArtistName;
            this.Length = vLength;
        }
    }
}
