using PS.Build.Nuget.Attributes;
using PS.Presentation.Properties;

[assembly: Nuget(
    ID = Constants.ID,
    Title = Constants.Title,
    Copyright = Constants.Copyright,
    Description = Constants.Description,
    ProjectUrl = Constants.ProjectUrl,
    LicenseUrl = Constants.LicenseUrl,
    Tags = Constants.Tags
    )]
[assembly: NugetAuthor(Constants.Author, ID = Constants.ID)]
[assembly: NugetFiles(@"{dir.target}\PS.Presentation.dll", @"lib\net452", ID = Constants.ID)]
[assembly: NugetFrameworkReference("PresentationCore", ID = Constants.ID)]
[assembly: NugetFrameworkReference("PresentationFramework", ID = Constants.ID)]
[assembly: NugetFrameworkReference("System.Xaml", ID = Constants.ID)]
[assembly: NugetFrameworkReference("WindowsBase", ID = Constants.ID)]
[assembly: NugetBuild(ID = Constants.ID)]
[assembly: NugetDebugSubstitution(ID = Constants.ID)]