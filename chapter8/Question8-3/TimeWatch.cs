using System;

namespace Question8_3 {

    /// <summary>
    /// TimeWatchクラス
    /// </summary>
    class TimeWatch {
        private DateTime FStartedTime;
        /// <summary>
        /// 計測開始するメソッド
        /// </summary>
        public void Start() => FStartedTime = DateTime.Now;//現在時刻を開始時刻として記録

        /// <summary>
        /// 計測停止するメソッド
        /// </summary>
        public TimeSpan Stop() => DateTime.Now - FStartedTime;//開始時刻と現在時刻の時間差を記録
    }
}

