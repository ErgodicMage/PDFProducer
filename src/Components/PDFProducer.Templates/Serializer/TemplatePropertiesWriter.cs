namespace PDFProducer.Templates.Serializer;

public class TemplatePropertiesWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public TemplatePropertiesWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        TemplateProperties properties = obj as TemplateProperties;

        if (properties is null)
            return;

        writer.WriteStartElement(nameof(TemplateProperties));
        WriterUtilities.WriteElementString(writer, TemplatePropertiesConstants.PDFProducerVersion, properties.PDFProducerVersion);
        WriterUtilities.WriteElementString(writer, TemplatePropertiesConstants.TemplateVersion, properties.TemplateVersion);
        WriterUtilities.WriteElementString(writer, TemplatePropertiesConstants.Author, properties.Author);
        WriterUtilities.WriteElementString(writer, TemplatePropertiesConstants.Description, properties.Description);
        WriterUtilities.WriteElementString(writer, TemplatePropertiesConstants.Notes, properties.Notes);
        writer.WriteEndElement();
    }
}
