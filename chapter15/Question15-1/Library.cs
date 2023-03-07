using System.Collections.Generic;

namespace Question15_1 {
    /// <summary>
    /// ライブラリクラス
    /// </summary>
    public static class Library {
        /// <summary>
        /// カテゴリプロパティ
        /// </summary>
        public static IEnumerable<Category> Categories { get; private set; }

        /// <summary>
        /// 書籍プロパティ
        /// </summary>
        public static IEnumerable<Book> Books { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static Library() {
            // 1. の回答
            Categories = new Category[]{
                new Category(1, "Development"),
                new Category(2, "Server"),
                new Category(3, "Web Design"),
                new Category(4, "Windows"),
                new Category(5, "Application"),
            };
            Books = new Book[]{
                new Book("Writing C# Solid Code", 1, 2500, 2016),
                new Book("C#開発指南", 1, 3800, 2014),
                new Book("Visual C# 再入門", 1, 2780, 2016),
                new Book("フレーズで学ぶC# Book", 1, 2400, 2016),
                new Book("TypeScript初級講座", 1, 2500, 2015),
                new Book("PowerShell 実線レシピ", 2, 4200, 2013),
                new Book("SQL Server 完全入門", 2, 3800, 2014),
                new Book("IIS Webサーバー運用ガイド", 2, 3180, 2015),
                new Book("Microsoft Azure サーバー構築", 2, 4800, 2016),
                new Book("Web デザイン講座 HTML5 & CSS", 3, 2800, 2013),
                new Book("HTML5 Web 大百科", 3, 3800, 2015),
                new Book("CSS デザイン 逆引き辞典", 3, 3550, 2015),
                new Book("Windows10 で楽しくお仕事", 4, 2280, 2016),
                new Book("Windows10 使いこなし術", 4, 1890, 2015),
                new Book("続Windows10 使いこなし術", 4, 2080, 2016),
                new Book("Windows10 やさしい操作入門", 4, 2300, 2015),
                new Book("まるわかりMicro Office入門", 5, 1890, 2015),
                new Book("Word・Excel 実践テンプレート集", 5, 2600, 2016),
                new Book("楽しく学ぶExcel 初級編", 5, 2800, 2015),
            };
        }
    }
}
