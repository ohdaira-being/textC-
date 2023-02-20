using System.Xml.Linq;

namespace Question11_1 {

    /// <summary>
    /// BallSportクラス
    /// </summary>
    public class BallSport {

        /// <summary>
        /// 競技名プロパティ
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 競技名の漢字名称プロパティ
        /// </summary>
        public string KanjiName { get; set; }

        /// <summary>
        /// チーム人数プロパティ
        /// </summary>
        public int Teammembers { get; set; }

        /// <summary>
        /// 最初にプレイした年プロパティ
        /// </summary>
        public int Firstplayed { get; set; }

        /// <summary>
        /// BallSportのコンストラクタ
        /// </summary>
        /// <param name="vName">競技名</param>
        /// <param name="vKanjiName">競技名の漢字名称</param>
        /// <param name="vTeammembers">チーム人数</param>
        /// <param name="vFirstplayed">最初にプレイした年</param>
        public BallSport(string vName, string vKanjiName, int vTeammembers, int vFirstplayed) {
            this.Name = vName;
            this.KanjiName = vKanjiName;
            this.Teammembers = vTeammembers;
            this.Firstplayed = vFirstplayed;
        }

        /// <summary>
        /// BallSportインスタンスを受け取り、XElement型にして返すメソッド
        /// </summary>
        /// <param name="vBallSport">BallSport</param>
        /// <returns></returns>
        public static XElement ToXElement(BallSport vBallSport) {
            return new XElement("ballsport",
                new XElement("name", vBallSport.Name, new XAttribute("kanji", vBallSport.KanjiName)),
                new XElement("teammembers", vBallSport.Teammembers),
                new XElement("firstplayed", vBallSport.Firstplayed)
                );
        }
    }
}
