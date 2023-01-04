namespace PDFProducer.Templates.Serializer;

public class TemplateElementWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public TemplateElementWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        if (obj is not TemplateElement element)
            return;

        if (!string.IsNullOrEmpty(element.Name))
            writer.WriteAttributeString(TemplateElementConstants.Name, element.Name);

        var fontwriter = _templateWriterFactory.GetWriter(nameof(ProducerFont));
        fontwriter?.Write(element.Font, writer);
    }
}
