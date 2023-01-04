namespace PDFProducer.Templates.Serializer;

public class ProducerPageWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public ProducerPageWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        if (obj is not ProducerPage page)
            return;

        writer.WriteStartElement(ProducerPageConstants.ProducerPageElementName);

        var nameWriter = _templateWriterFactory.GetWriter(nameof(TemplateElement));
        nameWriter?.Write(page, writer);

        WriterUtilities.WriteElementString(writer, ProducerPageConstants.Description, page.Description);
        WriterUtilities.WriteElementContainerNodes(_templateWriterFactory, page, writer);

        writer.WriteEndElement();
    }
}
