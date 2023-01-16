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
    class Program {
        static void Main(string[] args) {
            var wSongs = new Song[]{
                new Song("1つ目", "アーティスト1", 120),
                new Song("2つ目", "アーティスト2", 180),
                new Song("3つ目", "アーティスト3", 240),
            };

            foreach (var s in wSongs) {
                Console.WriteLine(s);
            }
        }
    }
}
