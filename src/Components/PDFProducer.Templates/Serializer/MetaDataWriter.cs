namespace PDFProducer.Templates.Serializer;

public class MetaDataWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public MetaDataWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        if (obj is not MetaData metadata)
            return;

        writer.WriteStartElement(MetaDataConstants.MetaDataElementName);

        if (metadata.Properties is not null)
        {
            var propertyWriter = _templateWriterFactory.GetWriter(nameof(MetaDataProperties));
            propertyWriter?.Write(metadata.Properties, writer);
        }

        if (metadata.Description is not null)
        {
            var descriptionWriter = _templateWriterFactory.GetWriter(nameof(MetaDataDescription));
            descriptionWriter?.Write(metadata.Description, writer);
        }

        writer.WriteEndElement();
    }
}

public class MetaDataPropertiesWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public MetaDataPropertiesWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        if (obj is not MetaDataProperties properties)
            return;

        writer.WriteStartElement(MetaDataConstants.PropertiesElementName);
        WriterUtilities.WriteElementString(writer, MetaDataConstants.Version, properties.Version);
        WriterUtilities.WriteElementString(writer, MetaDataConstants.Compression, properties.Compression);
        writer.WriteEndElement();
    }
}

public class MetaDataDescriptionWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public MetaDataDescriptionWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        if (obj is not MetaDataDescription desc)
            return;

        writer.WriteStartElement(MetaDataConstants.DescriptionElementName);
        WriterUtilities.WriteElementString(writer, MetaDataConstants.Title, desc.Title);
        WriterUtilities.WriteElementString(writer, MetaDataConstants.Author, desc.Author);
        WriterUtilities.WriteElementString(writer, MetaDataConstants.Subject, desc.Subject);
        WriterUtilities.WriteElementString(writer, MetaDataConstants.Keywords, desc.Keywords);
        writer.WriteEndElement();
    }
}
