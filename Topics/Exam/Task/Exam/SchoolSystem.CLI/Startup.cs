using SchoolSystem.CLI.Core;
using SchoolSystem.CLI.Core.Providers;

namespace SchoolSystem.CLI
{
    public class Startup
    {
        public static void Main()
        {
            // TODO: abstract at leest 2 mor provider like thiso ne
            var readerProvider = new ConsoleReaderProvider();
            var writerProvider = new ConsoleWriterProvider();
            var engine = new Engine(readerProvider, writerProvider/*, parserProvider*/);
            engine.Run();
        }
    }
}
