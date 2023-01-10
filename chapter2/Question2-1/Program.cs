using System;

//問題2.1
//1.以下のプロパティを持つ、Songクラスを定義してください。
//Title:string型（歌のタイトル）
//ArtistName:string型（アーティスト名）
//Length:int型（演奏時間、単位は秒）

//2.このとき、3つの引数を持つコンストラクタも定義してください。

//3.作成したsongクラスのインスタンスを複数生成し、配列songsに格納してください。

//4.配列に格納されたすべてのSongオブジェクトの内容をコンソールに出力してください。
//演奏時間の表示は「4:16」のような書式にしてください。
//ただし、演奏時間は必ず60分未満と仮定してかまいません。

namespace Question2_1 {
    public class Song {
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Length { get; set; }


        public Song(string x, string y, int z) {
            this.Title = x;
            this.ArtistName = y;
            this.Length = z;
        }


    }
    class Program {
        static void Main(string[] args) {
            Song song1 = new Song("1つ目", "アーティスト1", 120);
            Song song2 = new Song("2つ目", "アーティスト2", 180);
            Song song3 = new Song("3つ目", "アーティスト3", 240);

            object[] songs = new object[]{
                (song1.Title, song1.ArtistName, song1.Length),
                (song2.Title, song2.ArtistName, song2.Length),
                (song3.Title, song3.ArtistName, song3.Length)};

            foreach (var s in songs) {
                Console.WriteLine(s);
            }
        }
    }
}
