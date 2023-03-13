using System.IO;

// テキスト引用（使用するフレームワーク）
namespace TextFileProcessor {
    public abstract class TextProcessor {
        public static void Run<T>(string wFileName) where T : TextProcessor, new() {
            var wSelf = new T();
            wSelf.Process(wFileName);
        }
        private void Process(string vFileName) {
            Initialize(vFileName);
            using (var wSr = new StreamReader(vFileName)) {
                while (!wSr.EndOfStream) {
                    string wLine = wSr.ReadLine();
                    Execute(wLine);
                }
            }
            Terminate();
        }
        protected virtual void Initialize(string vFname) { }
        protected virtual void Execute(string vLine) { }
        protected virtual void Terminate() { }
    }
}
