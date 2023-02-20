using chapter13.Models;
using System;
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
            InitializBooks();
            InitializAuthors();


            var wSosekiNatsume = new Author("夏目漱石", new DateTime(1867, 2, 9), "男性");
            var wOsamuDazai = new Author("太宰治", new DateTime(1909, 6, 19), "男性");
            var wAkikoYosano = new Author("与謝野晶子", new DateTime(1878, 12, 7), "女性");
            var wKenjiMiyazawa = new Author("宮沢賢治", new DateTime(1896, 8, 27), "男性");


            // 1. の回答
            var wKanKikuchi = new Author("菊池寛", new DateTime(1888, 12, 26), "男性");
            var wYasunariKawabata = new Author("川端康成", new DateTime(1899, 6, 14), "男性");
            AddAuthor(wKanKikuchi);
            AddAuthor(wYasunariKawabata);

            AddBooks(new Book("こころ", 1991, "夏目漱石"));
            AddBooks(new Book("伊豆の踊子", 2003, wYasunariKawabata));
            AddBooks(new Book("真珠夫人", 2002, wKanKikuchi));
            AddBooks(new Book("注文の多い料理店", 2000, wKenjiMiyazawa));

            // DBに追加する（テキスト参考）
            AddBooks(new Book("ワンピース", 2000, wSosekiNatsume));
            AddBooks(new Book("坊ちゃん", 2003, wSosekiNatsume));
            AddBooks(new Book("人間失格", 1990, wOsamuDazai));
            AddBooks(new Book("111", 1212, "2222"));
            AddBooks(new Book("みだれ髪", 2000, wAkikoYosano));
            AddBooks(new Book("銀河鉄道の夜", 1989, wKenjiMiyazawa));

            // 2. の回答
            DisplayAllBooks();
            DisplayAllAuthors();


            // 3. の回答
            using (var wDb = new BooksDbContext()) {
                foreach (var wBook in wDb.Books) {
                    if (wBook.Title.Length == wDb.Books.Max(x => x.Title.Length)) Console.WriteLine(wBook.Title);
                }
            }

            // 4. の回答
            using (var wDb = new BooksDbContext()) {
                foreach (var wBook in wDb.Books.OrderBy(x => x.PublishedYear).Take(3)) {
                    Console.WriteLine($"タイトル：{wBook.Title} 著者名：{ wBook.Author?.Name ?? wBook.Publisher }");
                }
            }

            // 5. の回答
            using (var wDb = new BooksDbContext()) {
                foreach (var wBook in wDb.Authors.OrderBy(x => x.Birthday)) {
                    Console.WriteLine($"【{wBook.Name}】");
                    foreach (var oo in wDb.Books.Where(x => x.Author.Name == wBook.Name)) {
                        Console.WriteLine($"　・タイトル：{oo.Title}　発行年：{oo.PublishedYear}");
                    }
                }
            }

            Console.ReadLine();
        }

        // 全てのBookを読み込み、出力する
        static void DisplayAllBooks() {
            using (var wDb = new BooksDbContext()) {
                string wNoAuthorMessage = "著書のデータがありません。";
                foreach (Book wBook in wDb.Books) {
                    Console.WriteLine(
                        $"ID：{wBook.Id} タイトル：{wBook.Title}発行年：{wBook.PublishedYear} " +
                        $"著者名：{ wBook.Author?.Name ?? wBook.Publisher } " +
                        $"著書のID：{wBook.Author?.Id.ToString() ?? wNoAuthorMessage} "
                        );
                }
            }
        }

        // 全ての著者テーブルを読み込み、出力する
        static void DisplayAllAuthors() {
            using (var wDb = new BooksDbContext()) {
                foreach (Author wAuthor in wDb.Authors) {
                    Console.WriteLine(
                        $"ID：{wAuthor.Id} 著者名：{wAuthor.Name} " +
                        $"発行年：{wAuthor.Birthday.ToString("D")} " +
                        $"性別：{wAuthor.Gender}"
                        );
                }
            }
        }

        // Bookテーブルに著者と書籍のデータを追加する
        private static void AddBooks(Book vBook) {
            using (var db = new BooksDbContext()) {
                // vBookがAuthorをもつ場合
                if (vBook.Publisher == null) {
                    // DBに登録済の著者とヒットしなかった場合
                    if (db.Authors.All(x => x.Name != vBook.Author.Name)) {
                        db.Books.Add(vBook);
                        // DBに登録済みの著書とヒットした場合
                    } else {
                        Author wAuthor = db.Authors.Single(x => x.Name == vBook.Author.Name);
                        vBook.Author = wAuthor;
                        db.Books.Add(vBook);
                    }
                    // vBookがAuthorを持たず、Publisherを持つ場合
                } else {
                    // DBに登録済みの著書とヒットしなかった場合
                    if (db.Authors.All(x => x.Name != vBook.Publisher)) {
                        db.Books.Add(vBook);
                        // DBに登録済みの著書とヒットした場合
                    } else {
                        Author wAuthor = db.Authors.Single(x => x.Name == vBook.Publisher);
                        vBook.Author = wAuthor;
                        db.Books.Add(vBook);
                    }
                }
                db.SaveChanges();
            }
        }

        // データの変更
        private static void UpdateBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.Single(x => x.Title == "");
                book.PublishedYear = 111;
                db.SaveChanges();
            }
        }

        // Bookデータの削除
        private static void DeleteBook(int vId) {
            using (var wDb = new BooksDbContext()) {
                var wBook = wDb.Books.Single(x => x.Id == vId);
                if (wBook != null) {
                    wDb.Books.Remove(wBook);
                    wDb.SaveChanges();
                }
            }
        }

        // Bookテーブルの初期化
        private static void InitializBooks() {
            using (var wDb = new BooksDbContext()) {
                foreach (Book wBook in wDb.Books) {
                    DeleteBook(wBook.Id);
                }
            }
        }

        // 著者テーブルにデータを追加する
        private static void AddAuthor(Author vAuthor) {
            using (var wDb = new BooksDbContext()) {
                wDb.Authors.Add(vAuthor);
                wDb.SaveChanges();
            }
        }

        // 著者テーブルの削除
        private static void DeleteAuthor(int vId) {
            using (var wDb = new BooksDbContext()) {
                var wAuthor = wDb.Authors.Single(x => x.Id == vId);
                if (wAuthor != null) {
                    wDb.Authors.Remove(wAuthor);
                    wDb.SaveChanges();
                }
            }
        }

        // Authorテーブルの初期化
        private static void InitializAuthors() {
            using (var wDb = new BooksDbContext()) {
                foreach (Author wAuthor in wDb.Authors) {
                    DeleteAuthor(wAuthor.Id);
                }
            }
        }
    }
}
