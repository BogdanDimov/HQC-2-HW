using SchoolSystem.CLI.Core;
using SchoolSystem.CLI.Core.Providers;

namespace SchoolSystem.CLI
{
    public class Startup
    {
        public static void Main()
        {
            var readerProvider = new ConsoleReaderProvider();
            var writerProvider = new ConsoleWriterProvider();
            var parserProvider = new CommandParserProvider();
            var engine = new Engine(readerProvider, writerProvider, parserProvider);
            engine.Run();
        }
    }
}
