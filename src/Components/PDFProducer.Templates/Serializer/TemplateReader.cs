namespace PDFProducer.Templates.Serializer;

public class TemplateReader : IProducerReader
{
    private readonly ITemplateReaderFactory _templateReaderFactory;

    public TemplateReader(ITemplateReaderFactory templateReaderFactory)
    {
        _templateReaderFactory = templateReaderFactory;
    }

    public object Read(XmlReader reader)
    {
        ArgumentNullException.ThrowIfNull(reader);

        reader.MoveToContent();
        if (reader.Name != TemplateConstants.TemplateElementName)
            return null;

        ProducerTemplate template = new();

        while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
        {
            IProducerReader elementReader = reader.NodeType switch
            {
                XmlNodeType.Element => _templateReaderFactory.GetReader(reader.Name),
                _ => null
            };

            var elementObj = elementReader?.Read(reader);
            if (elementObj is null)
                continue;

            switch (elementObj)
            {
                case ProducerDocument:
                    template.Document = elementObj as ProducerDocument;
                    break;
                case MetaData:
                    template.MetaData = elementObj as MetaData;
                    break;
                default:
                    break;
            }
        }

        return template;
    }
}
