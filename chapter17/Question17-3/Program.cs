namespace Question17_3 {
    class Program {
        static void Main(string[] args) {
            new TextFileProcessor(new ToHankakuService()).Run(args[0]);
        }
    }
}
