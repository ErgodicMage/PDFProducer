namespace PDFProducer.Templates.Types;

public class MetaData
{
    public MetaDataProperties Properties { get; set; }

    public MetaDataDescription Description { get; set; }
}

public class MetaDataProperties
{
    public string Version { get; set; }

    public string Compression { get; set; }
}

public class MetaDataDescription
{
    public string Title { get; set; }

    public string Author { get; set; }

    public string Subject { get; set; }

    public string Keywords { get; set; }
}
