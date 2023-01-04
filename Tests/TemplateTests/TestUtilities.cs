using System.Collections.Generic;
using System.IO;

using Microsoft.Extensions.Configuration;

namespace TemplateTests;

public class TestCategories
{
    public const string UnitTest = "UnitTest";
    public const string FunctionalTest = "FunctionalTest";
    public const string ExperimentTest = "ExperimentTest";
}

public static class TestUtilities
{
    #region Configuration
    public static IConfiguration Config { get; private set; }

    public static void LoadAppSettings()
    {
        Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }
    #endregion

    #region Write functionality
    public static void WriteToFile(string path, IList<string> values)
    {
        if (File.Exists(path))
            File.Delete(path);

        using StreamWriter writer = new StreamWriter(path);
        WriteToStreamWriter(writer, values);
    }
    
    public static void WriteToStreamWriter(StreamWriter writer, IList<string> values)
    {
        foreach (var v in values)
            writer.WriteLine(v);
    }
    #endregion

    #region Resource Functionality
    const string testnamespace = "TemplateTests";

    public static string ReadResource(string folder, string resourcefile)
    {
        string filename = folder.Replace(" ", "_").Replace("\\", ".").Replace("/", ".") + "." + resourcefile;
        return ReadResource(filename);
    }

    public static string ReadResource(string resourcefile)
    {
        string filename = testnamespace + "." + resourcefile;

        string retString = string.Empty;
        using StreamReader reader = LoadResourceFile(filename);
        retString = reader.ReadToEnd();

        return retString;
    }
    public static StreamReader LoadResourceFile(string resourcefile)
    {
        StreamReader reader = new StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcefile));
        return reader;
    }
    #endregion
}
