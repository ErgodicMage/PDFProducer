namespace PDFProducer.Templates.Serializer;

public class TemplateWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public TemplateWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        writer.WriteStartElement(TemplateConstants.TemplateElementName, TemplateConstants.Namespace);

        if (obj is not ProducerTemplate template)
            return;

        if (template.Properties is not null)
        {
            var propwriter = _templateWriterFactory.GetWriter(nameof(TemplateProperties));
            propwriter?.Write(template.Properties, writer);
        }

        if (template.MetaData is not null)
        {
            var metadatawriter = _templateWriterFactory.GetWriter(nameof(MetaData));
            metadatawriter?.Write(template.MetaData, writer);
        }

        if (template.Document is not null)
        {
            var docwriter = _templateWriterFactory.GetWriter(nameof(ProducerDocument));
            docwriter?.Write(template.Document, writer);
        }

        if (template.Fonts is not null && template.Fonts.Count > 0)
        {
            writer.WriteStartElement(TemplateConstants.Fonts);

            var fontwriter = _templateWriterFactory.GetWriter(nameof(ProducerFont));

            if (fontwriter != null)
            {
                foreach (ProducerFont font in template.Fonts)
                    fontwriter.Write(font, writer);
            }

            writer.WriteEndElement();
        }

        writer.WriteEndElement();
    }
}
