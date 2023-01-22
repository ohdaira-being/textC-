using System;
using System.Collections.Generic;
using System.Linq;

namespace Question6_2 {
    //次のようなリストが定義されています。
    //var wBooks = new List<Book>{
    //            new Book{ Title = "C#プログラミングの新常識", Price = 3800, Pages = 378},
    //            new Book{ Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312},
    //            new Book{ Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385},
    //            new Book{ Title = "1人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464},
    //            new Book{ Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604},
    //            new Book{ Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453},
    //            new Book{ Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348},
    //        };
    //このwBooksリストに対して、以下のコードを書いてください。
    //1.wBooksの中で、タイトルが"ワンダフル・C#ライフ"である書籍の価格とページ数を表示するコードを書いてください。
    //2.wBooksの中で、タイトルに"C#"が含まれている書籍が何冊あるのかカウントするコードを書いてください。
    //3.wBooksの中で、タイトルに"C#"が含まれている書籍の平均ページ数を求めるコードを書いてください。
    //4.wBooksの中で、価格が4000円以上の本で最初に見つかった書籍のタイトルを表示するコードを書いてください。
    //5.wBooksの中で、価格が4000円未満の本の中で最大のページ数を求めるコードを書いてください。
    //6.wBooksの中で、ページ数が400ページ以上の書籍を、価格の高い順に表示（タイトルと価格を表示）するコードを書いてください。
    //7.wBooksの中で、タイトルに"C#"が含まれていてかつ500ページ以下の本を見つけ、本のタイトルを表示するコードを書いてください。
    //　複数見つかった場合は、その全てを表示してください。

    class Program {
        static void Main(string[] args) {
            var wBooks = new List<Book>{
                new Book{ Title = "C#プログラミングの新常識", Price = 3800, Pages = 378},
                new Book{ Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312},
                new Book{ Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385},
                new Book{ Title = "1人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464},
                new Book{ Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604},
                new Book{ Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453},
                new Book{ Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348},
            };
            //1.　の回答
            Console.WriteLine(
                $"タイトルが「ワンダフル・C#ライフ」である書籍の" +
                $"価格は、{wBooks.FirstOrDefault(x => x.Title == "ワンダフル・C#ライフ").Price}円、" +
                $"ページ数は、{wBooks.FirstOrDefault(x => x.Title == "ワンダフル・C#ライフ").Pages}ページです。"
                );

            //2.　の回答
            Console.WriteLine(
                $"タイトルに「C#」が含まれている書籍は、" +
                $"{wBooks.Count(x => x.Title.Contains("C#"))}冊あります。"
                );

            //3.　の回答
            Console.WriteLine(
                $"タイトルに「C#」が含まれている書籍の平均ページ数は、" +
                $"{Math.Ceiling(wBooks.Where(x => x.Title.Contains("C#")).Average(y => y.Pages))}ページです。"
                );

            //4.　の回答
            Console.WriteLine(
                $"価格が4000円以上の本で最初に見つかった書籍のタイトルは、" +
                $"「{wBooks.FirstOrDefault(x => x.Price >= 4000).Title}」です。"
                );

            //5.　の回答
            Console.WriteLine(
                $"価格が4000円未満の本の中で最大のページ数は、" +
                $"{wBooks.Where(x => x.Price < 4000).Max(y => y.Pages)}ページです。"
                );

            //6.　の回答
            foreach (Book wBook in wBooks.Where(x => x.Pages >= 400).OrderByDescending(y => y.Price)) {
                Console.WriteLine($"タイトル：{wBook.Title}　価格：{wBook.Price}円");
            }

            //7.　の回答
            foreach (Book wBook in wBooks.Where(x => x.Title.Contains("C#")).Where(y => y.Pages <= 500)) {
                Console.WriteLine($"タイトル：{wBook.Title}");
            };
        }
    }
}
