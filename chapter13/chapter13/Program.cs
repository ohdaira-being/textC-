using chapter13.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            Console.WriteLine("初期化しますか？\nYes　　→　　Y\nNo 　　→　　Y以外");
            if (Console.ReadLine() == "Y") InitializeDB();

            var wSosekiNatsume = new Author("夏目漱石", new DateTime(1867, 2, 9), "男性");
            var wOsamuDazai = new Author("太宰治", new DateTime(1909, 6, 19), "男性");
            var wAkikoYosano = new Author("与謝野晶子", new DateTime(1878, 12, 7), "女性");
            var wKenjiMiyazawa = new Author("宮沢賢治", new DateTime(1896, 8, 27), "男性");

            // 1. の回答
            var wKanKikuchi = new Author("菊池寛", new DateTime(1888, 12, 26), "男性");
            var wYasunariKawabata = new Author("川端康成", new DateTime(1899, 6, 14), "男性");
            var wAuthors = new List<Author> { wKanKikuchi, wYasunariKawabata };

            var wBooks = new List<Book>{
                new Book("こころ", 1991, wSosekiNatsume),
                new Book("伊豆の踊子", 2003, wYasunariKawabata),
                new Book("真珠夫人", 2002, wKanKikuchi),
                new Book("注文の多い料理店", 2000, wKenjiMiyazawa),
                new Book("坊ちゃん", 2003, wSosekiNatsume),
                new Book("人間失格", 1990, wOsamuDazai),
                new Book("みだれ髪", 2000, wAkikoYosano),
                new Book("銀河鉄道の夜", 1989, wKenjiMiyazawa),
                new Book("ワン", 2000, wSosekiNatsume),
                new Book("ワン222", 2000, wSosekiNatsume),
                new Book("ワンピース", 2000, wSosekiNatsume),
                new Book("ワンピース", 2000, wSosekiNatsume),
                new Book("ワンピース", 2000, wAkikoYosano),
                new Book("ワンピース", 1999, wSosekiNatsume),
                new Book("ワンピースRED", 2000, wSosekiNatsume),
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
                DbSet<Book> wDbBooks = wDb.Books;
                foreach (Book wBook in wDbBooks) {
                    if (wBook.Title.Length == wDbBooks.Max(x => x.Title.Length)) Console.WriteLine($"{wBook.Id}：{wBook.Title}");
                }
                // 4. の回答
                Console.WriteLine("\n～問題４の回答～");
                foreach (Book wBook in wDbBooks.OrderBy(x => x.PublishedYear).Take(3)) {
                    Console.WriteLine($"ID：{wBook.Id}　→　「{wBook.Title}」（{wBook.Author.Name}）");
                }
                // 5. の回答
                Console.WriteLine("\n～問題５の回答～");
                foreach (Author wAuthor in wDb.Authors.OrderBy(x => x.Birthday)) {
                    Console.WriteLine($"著者【{wAuthor.Name}】");
                    foreach (Book wBook in wDbBooks.Where(x => x.Author.Name == wAuthor.Name)) {
                        Console.WriteLine($"　・ID：{wBook.Id}　→　「{wBook.Title}」（{wBook.PublishedYear}年）");

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
                    $"著者名：{wBook.Author.Name} " +
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
        private static void AddBookList(IReadOnlyCollection<Book> vBooks) {
            try {
                using (var wDb = new BooksDbContext()) {
                    foreach (Book wBook in vBooks) {
                        // TitleまたはAuthorがnullの場合、例外をスローする
                        if (wBook.Title == null || wBook.Author == null) throw new ArgumentException();
                        // 追加するBookのタイトルが既にDBにある場合は、次のループに行く
                        if (wDb.Books.Any(x => (x.Title == wBook.Title)
                                               && (x.PublishedYear == wBook.PublishedYear)
                                               && (x.Author.Name == wBook.Author.Name)
                                               && (x.Author.Birthday == wBook.Author.Birthday)
                                               && (x.Author.Gender == wBook.Author.Gender))) continue;
                        wDb.Books.Add(CheckBook(wDb, wBook));
                        wDb.SaveChanges();
                    }
                }
            } catch (ArgumentException wBookLackDate) {
                Console.WriteLine("追加できませんでした。（書籍情報は、タイトル名と著者情報の入力が必要です。）");
                Console.WriteLine(wBookLackDate);
            }
        }

        // 追加するBookのAuthorが既にDBにないかNameでチェックするメソッド
        private static Book CheckBook(BooksDbContext vDb, Book vBook) {
            Author wAuthor = vBook.Author;
            // DBにある場合は、DBのAuthorに置き換える（IDを一致させる）
            if (vDb.Authors.Any(x => (x.Name == wAuthor.Name)
                                     && (x.Birthday == wAuthor.Birthday)
                                     && (x.Gender == wAuthor.Gender))) vBook.Author = vDb.Authors.Single(x => x.Name == wAuthor.Name);
            return vBook;
        }

        // 著者リストを追加する
        private static void AddAuthorList(IReadOnlyCollection<Author> vAuthors) {
            List<Author> Authors = new List<Author>();
            try {
                using (var wDb = new BooksDbContext()) {
                    foreach (Author wAuthor in vAuthors) {
                        // Nameがnullの場合、例外をスローする
                        if (wAuthor.Name == null) throw new ArgumentException();
                        // 追加するAuthorがDbにあるかチェック。ある場合は、追加しない
                        if (wDb.Authors.Any(x => x.Name == wAuthor.Name)) continue;
                        wDb.Authors.Add(wAuthor);
                        wDb.SaveChanges();
                    }
                }
            } catch (ArgumentException wAuthorLackDate) {
                Console.WriteLine("追加できませんでした。（著者情報は、著者名の入力が必要です。）");
                Console.WriteLine(wAuthorLackDate);
            }
        }

        // テーブル初期化
        private static void InitializeDB() {
            using (var wDb = new BooksDbContext()) {
                wDb.Books.RemoveRange(wDb.Books);
                wDb.Authors.RemoveRange(wDb.Authors);
                wDb.SaveChanges();
            }
        }
    }
}
