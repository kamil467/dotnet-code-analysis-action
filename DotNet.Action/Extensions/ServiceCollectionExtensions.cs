using Microsoft.Extensions.DependencyInjection;
using DotNet.Action.Analyzers;
using CodeAnalysis;
namespace DotNet.Action.Extensions;


static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddGitHubActionServices(
        this IServiceCollection services) =>
        services.AddSingleton<ProjectMetricDataAnalyzer>()
                .AddDotNetCodeAnalysisServices();
}