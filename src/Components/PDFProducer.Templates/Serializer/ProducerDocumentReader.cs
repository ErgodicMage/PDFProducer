namespace PDFProducer.Templates.Serializer;

public class ProducerDocumentReader : IProducerReader
{
    private readonly ITemplateReaderFactory _templateReaderFactory;

    public ProducerDocumentReader(ITemplateReaderFactory templateReaderFactory)
    {
        _templateReaderFactory = templateReaderFactory;
    }

    public object Read(XmlReader reader)
    {
        ArgumentNullException.ThrowIfNull(reader);

        if (reader.Name != ProducerDocumentConstants.ProducerDocumenetElementName)
            return null;

        reader.Skip();

        return null;
    }
}
