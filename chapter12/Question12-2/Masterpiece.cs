using System.Xml.Serialization;

namespace Question12_2 {

    /// <summary>
    /// 名作クラス
    /// </summary>
    [XmlRoot("masterpiece")]
    public class Masterpiece {

        /// <summary>
        /// 名作タイトルプロパティ
        /// </summary>
        [XmlElement(ElementName ="title")]
        public string Title { get; set; }

        /// <summary>
        /// 空のコンストラクタ
        /// </summary>
        public Masterpiece() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vTitle">タイトル名</param>
        public Masterpiece(string vTitle) {
            this.Title = vTitle;
        }
    }
}
