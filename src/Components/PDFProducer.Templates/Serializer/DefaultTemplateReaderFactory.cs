namespace PDFProducer.Templates.Serializer;

public class DefaultTemplateReaderFactory : ITemplateReaderFactory
{
    public DefaultTemplateReaderFactory()
    {
        Readers.Add(TemplateConstants.TemplateElementName, new TemplateReader(this));
        Readers.Add(ProducerDocumentConstants.ProducerDocumenetElementName, new ProducerDocumentReader(this));
        Readers.Add(MetaDataConstants.MetaDataElementName, new MetaDataReader(this));
        Readers.Add(MetaDataConstants.PropertiesElementName, new MetaDataPropertiesReader(this));
        Readers.Add(MetaDataConstants.DescriptionElementName, new MetaDataDescriptionReader(this));
    }

    private IDictionary<string, IProducerReader> Readers { get; } = new Dictionary<string, IProducerReader>();

    public IProducerReader GetReader(string className) => Readers.ContainsKey(className) ? Readers[className] : null;

    public void AddReader(string className, IProducerReader reader)
    {
        if (string.IsNullOrEmpty(className) || reader is null)
            return;

        if (Readers.ContainsKey(className))
            Readers[className] = reader;
        else
            Readers.Add(className, reader);
    }

    public void RemoveReader(string className)
    {
        if (!string.IsNullOrEmpty(className) && Readers.ContainsKey(className))
            Readers.Remove(className);
    }
}
