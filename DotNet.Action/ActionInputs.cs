using CommandLine;

namespace DotNet.Action;

public class ActionInputs
{
    string _repositoryName = null!;
    string _branchName = null!;

    public ActionInputs()
    {
       if (Environment.GetEnvironmentVariable("GITHUB_REPOSITORY") is { Length: > 0 } repoName)
            this.Name = repoName.Contains("/") ? repoName.Split("/")[1] : repoName;
         
        if(Environment.GetEnvironmentVariable("GITHUB_REPOSITORY_OWNER") is { Length: > 0} repoOwner)
          this.Owner = repoOwner;
 
        if(Environment.GetEnvironmentVariable("GITHUB_HEAD_REF") is { Length: > 0} branch)
        this.Branch = branch;


    }

    public string Owner { get; private set; } ;

    public string Name  { get; private set; }   
    
    public string Branch
    {
        get => _branchName;
        set => ParseAndAssign(value, str => _branchName = str);
    }

    [Option('d', "dir",
        Required = true,
        HelpText = "The root directory to start recursive searching from.")]
    public string Directory { get; set; } = null!;

    [Option('w', "workspace",
        Required = true,
        HelpText = "The workspace directory, or repository root directory.")]
    public string WorkspaceDirectory { get; set; } = null!;

    static void ParseAndAssign(string? value, Action<string> assign)
    {
        if (value is { Length: > 0 } && assign is not null)
        {
            assign(value.Split("/")[^1]);
        }
    }

    private void SetEnvironmentVariables()
    {

    }
}