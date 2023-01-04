namespace PDFProducer.Templates.Serializer;

public class ProducerFontWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public ProducerFontWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        if (obj is not ProducerFont font)
            return;

        writer.WriteStartElement(ProducerFontConstants.Font);

        if (!string.IsNullOrEmpty(font.Name))
            writer.WriteAttributeString(ProducerFontConstants.name, font.Name);

        WriterUtilities.WriteElementString(writer, ProducerFontConstants.FontName, font.FontName);
        WriterUtilities.WriteElementString(writer, ProducerFontConstants.File, font.File);
        WriterUtilities.WriteElementString(writer, ProducerFontConstants.Embed, font.Embed?.ToString());

        writer.WriteEndElement();
    }
}
