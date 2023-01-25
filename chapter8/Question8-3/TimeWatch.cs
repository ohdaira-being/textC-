using System;

namespace Question8_3 {

    /// <summary>
    /// TimeWatchクラス
    /// </summary>
    class TimeWatch {
        private DateTime wStart;
        /// <summary>
        /// 計測開始するメソッド
        /// </summary>
        public void Start() {
            wStart = DateTime.Now;//現在時刻を開始時刻として記録
        }

        /// <summary>
        /// 計測停止するメソッド
        /// </summary>
        public TimeSpan Stop() {
            return (DateTime.Now - wStart);//開始時刻と現在時刻の時間差を記録
        }
    }
}

