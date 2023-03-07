using System;
using System.Collections.Generic;

namespace chapter13.Models {

    /// <summary>
    /// 著者クラス
    /// </summary>
    public class Author {

        /// <summary>
        /// 著者のIDプロパティ
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// 著者名プロパティ
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 著者の誕生日プロパティ
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 著者の性別プロパティ
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 書籍プロパティ
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }

        /// <summary>
        /// 空のコンストラクタ
        /// </summary>
        public Author() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vName">著者名</param>
        /// <param name="vBirthday">著者の誕生日</param>
        /// <param name="vGender">著者の性別</param>
        public Author(string vName, DateTime vBirthday, string vGender) {
            this.Name = vName;
            this.Birthday = vBirthday;
            this.Gender = vGender;
        }
    }
}
