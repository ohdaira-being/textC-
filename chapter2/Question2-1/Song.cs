using System;
using System.Collections.Generic;
using System.Text;

namespace Question2_1 {
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
        public string Length { get; set; }

        /// <summary>
        /// 曲のコンストラクタ
        /// </summary>
        /// <param name="vTitle"></param>
        /// <param name="vArtistName"></param>
        /// <param name="vLength"></param>
        public Song(string vTitle, string vArtistName, int vLength) {
            this.Title = vTitle;
            this.ArtistName = vArtistName;
            this.Length = new TimeSpan(0,0,vLength).ToString(@"mm\:ss");
        }
    }
}
