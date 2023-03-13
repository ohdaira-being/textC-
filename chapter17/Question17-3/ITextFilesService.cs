namespace Question17_3 {
    /// <summary>
    /// インターフェース
    /// </summary>
    public interface ITextFilesService {
        void Initialize(string vFname);
        void Execute(string vLine);
        void Terminate();
    }
}
