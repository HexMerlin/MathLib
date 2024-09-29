#nullable enable
using System.Reflection;

namespace MathLib;

/// <summary>
/// Static class for general assembly methods
/// </summary>
public static class Lib
{
    /// <summary>
    /// Retrieves assebly information. 
    /// </summary>
    /// <returns>
    /// A string representing the version, target .NET framework, and build configuration (e.g. Debug, Release) of the assembly.
    /// The format of the returned string is "Version: 'X.Y.Z.W' Build:'FrameworkName' Configuration:'BuildConfiguration'".
    /// </returns>
    /// <example>
    /// <code>
    /// Console.WriteLine(Lib.BuildVersion);
    /// // Example output:
    /// // "Version: 1.0.0.0 Build:.NET Standard 2.1 Configuration:Release"
    /// </code>
    /// </example>
    public static string BuildVersion
    {
        get
        {
            Assembly assembly = typeof(Lib).Assembly;  // Ensure we're getting the assembly of the current type (the class library)            

            var framework = assembly
               .GetCustomAttribute<System.Runtime.Versioning.TargetFrameworkAttribute>()?.FrameworkDisplayName ?? "Unknown";

            // Retrieve the build configuration (e.g., Debug, Release)
            string configuration = assembly
                .GetCustomAttribute<AssemblyConfigurationAttribute>()?
                .Configuration ?? "Unknown";

            // Retrieve the assembly version
            string version = assembly.GetName().Version?.ToString() ?? "Unknown";

            // Return the combined configuration and version information
            return $"Version: {version} Build:{framework} Configuration:{configuration}";
        }
    }
}





