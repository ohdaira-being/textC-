namespace Question11_1 {

    /// <summary>
    /// BallSportCollectionクラス
    /// </summary>
    public class BallSportCollection {

        /// <summary>
        /// BallSportsプロパティ
        /// </summary>
        public BallSport[] BallSports { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vBallSports">BallSportのコレクション</param>
        public BallSportCollection(BallSport[] vBallSports) {
            this.BallSports = vBallSports;
        }
    }
}
