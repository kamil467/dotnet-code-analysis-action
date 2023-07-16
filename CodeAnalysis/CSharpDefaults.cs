using Microsoft.CodeAnalysis.CSharp;

namespace CodeAnalysis;

static class CSharpDefaults
{
    internal static CSharpCompilationOptions CompilationOptions { get; } =
        new(OutputKind.ConsoleApplication, concurrentBuild: false);

    internal static CSharpCommandLineParser CommandLineParser { get; } =
        CSharpCommandLineParser.Default;
}
