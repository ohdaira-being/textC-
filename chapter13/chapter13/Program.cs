using chapter13.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace chapter13 {

    // 本文で利用したデータベースを利用し、以下のコードを書いてください。

    // 1. 2名の著者と4冊の書籍を追加してください。

    // 2. 全ての書籍情報を著者名とともに表示するコードを書き、
    //    上記1のデータが正しく表示されたか確認してください。

    // 3. タイトルの最も長い書籍を求めてください。
    //    複数ある場合は、全てを求めて表示してください。

    // 4. 発行年の古い順に3冊だけ書籍を取得し、そのタイトルと著者名を求めてください。

    // 5. 著者ごとに書籍のタイトルと発行年を表示してください。
    //    なお、著者は誕生日の遅い順（降順）に並べてください。

    class Program {
        static void Main(string[] args) {
            var wSosekiNatsume = new Author("夏目漱石", new DateTime(1867, 2, 9), "男性");
            var wOsamuDazai = new Author("太宰治", new DateTime(1909, 6, 19), "男性");
            var wAkikoYosano = new Author("与謝野晶子", new DateTime(1878, 12, 7), "女性");
            var wKenjiMiyazawa = new Author("宮沢賢治", new DateTime(1896, 8, 27), "男性");
            // 1. の回答
            var wKanKikuchi = new Author("菊池寛", new DateTime(1888, 12, 26), "男性");
            var wYasunariKawabata = new Author("川端康成", new DateTime(1899, 6, 14), "男性");
            List<Author> wAuthors = new List<Author> { wKanKikuchi, wYasunariKawabata };
            List<Book> wBooks = new List<Book>{
                new Book("こころ", 1991, "夏目漱石", null),
                new Book("伊豆の踊子", 2003, null, wYasunariKawabata),
                new Book("真珠夫人", 2002, null, wKanKikuchi),
                new Book("注文の多い料理店", 2000, null, wKenjiMiyazawa),
                new Book("ワンピース", 2000, null, wSosekiNatsume),
                new Book("坊ちゃん", 2003, null, wSosekiNatsume),
                new Book("人間失格", 1990, null, wOsamuDazai),
                new Book("111", 1212, "2222", null),
                new Book("みだれ髪", 2000, null, wAkikoYosano),
                new Book("銀河鉄道の夜", 1989, null, wKenjiMiyazawa),
                new Book("ワン", 2000, null, wSosekiNatsume),
                new Book("ワン222", 2000, "夏目漱石", null),
            };
            AddAuthorList(wAuthors);
            AddBookList(wBooks);

            using (var wDb = new BooksDbContext()) {
                // 2. の回答
                Console.WriteLine("\n～問題２の回答～");
                DisplayAllBooks(wDb);
                DisplayAllAuthors(wDb);
                // 3. の回答
                Console.WriteLine("\n～問題３の回答～");
                foreach (Book wBook in wDb.Books) {
                    if (wBook.Title.Length == wDb.Books.Max(x => x.Title.Length)) Console.WriteLine(wBook.Title);
                }
                // 4. の回答
                Console.WriteLine("\n～問題４の回答～");
                foreach (Book wBook in wDb.Books.OrderBy(x => x.PublishedYear).Take(3)) {
                    Console.WriteLine($"タイトル：{wBook.Title}　著者名：{ wBook.Author?.Name ?? wBook.Publisher }");
                }
                // 5. の回答
                Console.WriteLine("\n～問題５の回答～");
                foreach (Author wAuthor in wDb.Authors.OrderBy(x => x.Birthday)) {
                    Console.WriteLine($"【{wAuthor.Name}】");
                    foreach (Book wBook in wDb.Books.Where(x => x.Author.Name == wAuthor.Name)) {
                        Console.WriteLine($"　・タイトル：{wBook.Title}　発行年：{wBook.PublishedYear}");

                    }
                }
            }
            Console.ReadLine();
        }
        // 全てのBookを読み込み、出力する
        private static void DisplayAllBooks(BooksDbContext vDb) {
            string wNoAuthorMessage = "著書のデータはありません。";
            foreach (Book wBook in vDb.Books) {
                Console.WriteLine(
                    $"ID：{wBook.Id} タイトル：{wBook.Title}　発行年：{wBook.PublishedYear} " +
                    $"著者名：{ wBook.Author?.Name ?? wBook.Publisher } " +
                    $"著書のID：{wBook.Author?.Id.ToString() ?? wNoAuthorMessage} "
                    );
            }

        }
        // 全ての著者テーブルを読み込み、出力する
        private static void DisplayAllAuthors(BooksDbContext vDb) {
            foreach (Author wAuthor in vDb.Authors) {
                Console.WriteLine(
                    $"ID：{wAuthor.Id}　著者名：{wAuthor.Name}　" +
                    $"発行年：{wAuthor.Birthday.ToString("D")}　" +
                    $"性別：{wAuthor.Gender}"
                    );
            }

        }
        // ブックのリストをDbに追加するメソッド
        private static void AddBookList(List<Book> vBooks) {
            var wBooks = new List<Book>();
            using (var wDb = new BooksDbContext()) {
                foreach (Book wBook in vBooks) {
                    if (wDb.Books.Any(x => x.Title == wBook.Title)) continue;
                    wBooks.Add(CheckBook(wDb, wBook));
                }
                wDb.Books.AddRange(wBooks).Distinct();
                wDb.SaveChanges();
            }
        }
        // Bookテーブルに著者と書籍のデータを追加する
        private static void AddBook(Book vBook) {
            using (var wDb = new BooksDbContext()) {
                if (wDb.Books.Any(x => x.Title == vBook.Title)) return;
                wDb.Books.Add(CheckBook(wDb, vBook));
                wDb.SaveChanges();
            }
        }
        // Bookをチェックするメソッド
        private static Book CheckBook(BooksDbContext vDb, Book vBook) {
            string wAuthorName = vBook.Author?.Name ?? vBook.Publisher;
            if (vDb.Authors.Any(x => x.Name == wAuthorName)) vBook.Author = vDb.Authors.Single(x => x.Name == wAuthorName);
            return vBook;
        }
        // Bookデータの削除
        private static void DeleteBook(int vId) {
            using (var wDb = new BooksDbContext()) {
                Book wBook = wDb.Books.Single(x => x.Id == vId);
                if (wBook != null) {
                    wDb.Books.Remove(wBook);
                    wDb.SaveChanges();
                }
            }
        }
        // 著者テーブルを追加する
        private static void AddAuthor(Author vAuthor) {
            using (var wDb = new BooksDbContext()) {
                if (wDb.Authors.Any(x => x.Name == vAuthor.Name)) return;
                wDb.Authors.Add(vAuthor);
                wDb.SaveChanges();
            }
        }
        // 著者リストを追加する
        private static void AddAuthorList(List<Author> vAuthors) {
            var Authors = new List<Author>();
            using (var wDb = new BooksDbContext()) {
                foreach (Author wAuthor in vAuthors) {
                    if (wDb.Authors.Any(x => x.Name == wAuthor.Name)) continue;
                    wDb.Authors.Add(wAuthor);
                }
                wDb.SaveChanges();
            }
        }
        // 著者テーブルの削除
        private static void DeleteAuthor(int vId) {
            using (var wDb = new BooksDbContext()) {
                Author wAuthor = wDb.Authors.Single(x => x.Id == vId);
                if (wAuthor != null) {
                    wDb.Authors.Remove(wAuthor);
                    wDb.SaveChanges();
                }
            }
        }
    }
}
