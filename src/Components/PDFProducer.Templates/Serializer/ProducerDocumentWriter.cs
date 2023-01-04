namespace PDFProducer.Templates.Serializer;

public class ProducerDocumentWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public ProducerDocumentWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        if (obj is not ProducerDocument document)
            return;

        writer.WriteStartElement(ProducerDocumentConstants.ProducerDocumenetElementName);

        var nameWriter = _templateWriterFactory.GetWriter(nameof(TemplateElement));
        nameWriter?.Write(document, writer);

        WriterUtilities.WriteElementContainerNodes(_templateWriterFactory, document, writer);

        writer.WriteEndElement();
    }
}
