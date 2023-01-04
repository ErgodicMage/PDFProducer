namespace PDFProducer.Templates.Serializer;

public class MetaDataReader : IProducerReader
{
    private readonly ITemplateReaderFactory _templateReaderFactory;

    public MetaDataReader(ITemplateReaderFactory templateReaderFactory)
    {
        _templateReaderFactory = templateReaderFactory;
    }

    public object Read(XmlReader reader)
    {
        ArgumentNullException.ThrowIfNull(reader);

        if (reader.Name != nameof(MetaData))
            return null;

        MetaData metaData = new();

        while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
        {
            IProducerReader metaDataReader = reader.NodeType switch
            {
                XmlNodeType.Element => _templateReaderFactory.GetReader(reader.Name),
                _ => null
            };

            object obj = metaDataReader?.Read(reader);
            if (obj is null)
                continue;

            switch (obj)
            {
                case MetaDataProperties:
                    metaData.Properties = obj as MetaDataProperties;
                    break;
                case MetaDataDescription:
                    metaData.Description = obj as MetaDataDescription;
                    break;
                default:
                    break;
            }
        }

        return metaData;
    }
}

public class MetaDataPropertiesReader : IProducerReader
{
    private readonly ITemplateReaderFactory _templateReaderFactory;

    public MetaDataPropertiesReader(ITemplateReaderFactory templateReaderFactory)
    {
        _templateReaderFactory = templateReaderFactory;
    }

    public object Read(XmlReader reader)
    {
        ArgumentNullException.ThrowIfNull(reader);

        if (reader.Name != MetaDataConstants.PropertiesElementName)
            return null;

        MetaDataProperties properties = new();

        while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
        {
            switch (reader.Name)
            {
                case MetaDataConstants.Version:
                    properties.Version = reader.ReadElementContentAsString();
                    break;
                case MetaDataConstants.Compression:
                    properties.Compression = reader.ReadElementContentAsString();
                    break;
                default:
                    break;
            }
        }

        return properties;
    }
}

public class MetaDataDescriptionReader : IProducerReader
{
    private readonly ITemplateReaderFactory _templateReaderFactory;

    public MetaDataDescriptionReader(ITemplateReaderFactory templateReaderFactory)
    {
        _templateReaderFactory = templateReaderFactory;
    }

    public object Read(XmlReader reader)
    {
        ArgumentNullException.ThrowIfNull(reader);
        
        if (reader.Name != MetaDataConstants.DescriptionElementName)
            return null;

        MetaDataDescription description = new();

        while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
        {
            switch (reader.Name)
            {
                case MetaDataConstants.Title:
                    description.Title = reader.ReadElementContentAsString();
                    break;
                case MetaDataConstants.Author:
                    description.Author = reader.ReadElementContentAsString();
                    break;
                case MetaDataConstants.Subject:
                    description.Subject = reader.ReadElementContentAsString();
                    break;
                case MetaDataConstants.Keywords:
                    description.Keywords = reader.ReadElementContentAsString();
                    break;
                default:
                    break;
            }
        }

        return description;
    }
}
