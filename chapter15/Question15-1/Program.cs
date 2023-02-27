using System;
using System.Linq;

namespace Question15_1 {

    // Book、Category、Libraryクラスを利用し、以下のコードを書いてください。

    // 1. Libraryクラスにコンストラクタを追加し、本省の最初に示した書籍のカテゴリデータと書籍データの値を、
    // CategoriesプロパティとBooksプロパティにセットするコードを書いてください。

    // 2. 最も価格の高い書籍を抽出し、その書籍の情報をコンソールに出力してください。

    // 3. 発行年ごとに書籍の数をカウントして、その結果をコンソールに出力してください。

    // 4. 発行年、価格の順（それぞれ値の大きい順）に並べ替え、その結果をコンソールに出力してください。

    // 5. 2016年に発行された書籍のカテゴリ一覧を取得し、コンソールに出力してください。

    // 6. GroupByメソッドを使い、カテゴリごとに書籍を分類しカテゴリ名をアルファベット順に並べ替え、
    // その結果をコンソールに出力してください。

    // 7. カテゴリ"Development"の書籍に対して、発行年ごとに分類し、その結果をコンソールに出力してください。

    // 8. GroupJoinメソッドを使って、4冊以上発行されているカテゴリ名を求め、
    // そのカテゴリ名をコンソールに出力してください。

    class Program {
        static void Main(string[] args) {
            // 1. の回答はLibraryクラスに記載しています。

            // 2. の回答
            int wMaxPrice = Library.Books.Max(x => x.Price);
            foreach (Book wBook in Library.Books.Where(x => x.Price == wMaxPrice)) {
                Console.WriteLine(wBook);
            }

            // 3. の回答
            foreach (var wGroupingBook in Library.Books.OrderBy(x => x.PublisherYear).GroupBy(x => x.PublisherYear)) {
                Console.WriteLine(wGroupingBook.Count());
            }

            // 4. の回答
            foreach (var wBook in Library.Books.OrderByDescending(x => x.PublisherYear).ThenByDescending(x => x.Price)) {
                Console.WriteLine(wBook);
            }

            // 5. の回答
            var wBooks = Library.Books.Join(
                Library.Categories,
                x => x.CategoryId,
                y => y.Id,
                (x, y) => new {
                    Title = x.Title,
                    Category = y.Name,
                    PublisherYear = x.PublisherYear
                });
            foreach (var wBook in wBooks.Where(x => x.PublisherYear == 2016)) {
                Console.WriteLine(wBook.Category);
            }

            // 6. の回答
            foreach (var wGroupingBook in wBooks.OrderBy(x => x.Category).GroupBy(x => x.Category)) {
                Console.WriteLine($"#【{wGroupingBook.Key}】");
                foreach (var wBook in wBooks.Where(x => x.Category == wGroupingBook.Key)) {
                    Console.WriteLine($"　・{wBook.Title}");
                }
            }

            // 7. の回答

            foreach (var wGroupingBook in wBooks.Where(x => x.Category == "Development").OrderBy(x => x.PublisherYear).GroupBy(x => x.PublisherYear)) {
                Console.WriteLine($"#{wGroupingBook.Key}");
                foreach (var wBook in wGroupingBook.Where(x => x.PublisherYear == wGroupingBook.Key)) {
                    Console.WriteLine($"　・{wBook.Title}");
                }
            }

            // 8. の回答
            var wBookGroups = Library.Categories.GroupJoin(
                Library.Books,
                x => x.Id,
                y => y.CategoryId,
                (x, y) => new {
                    Category = x.Name,
                    Count = y.Count()
                });
            foreach (var wBook in wBookGroups.Where(x => x.Count >= 4)) {
                Console.WriteLine(wBook.Category);
            }

            Console.ReadLine();
        }
    }
}
