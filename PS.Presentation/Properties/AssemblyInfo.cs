using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Markup;
using PS.Presentation.Properties;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle(Constants.Title)]
[assembly: AssemblyDescription(Constants.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct(Constants.Product)]
[assembly: AssemblyCopyright(Constants.Copyright)]
[assembly: AssemblyCulture("")]
[assembly: AssemblyCompany(Constants.Author)]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("c5268a54-8e6f-4765-aa59-a201710339a6")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: XmlnsDefinition("http://schemas.ps.com/2018/xaml", "PS.Presentation.DataTemplate")]
[assembly: XmlnsDefinition("http://schemas.ps.com/2018/xaml", "PS.Presentation.Resources")]
[assembly: XmlnsPrefix("http://schemas.ps.com/2018/xaml", "ps")]