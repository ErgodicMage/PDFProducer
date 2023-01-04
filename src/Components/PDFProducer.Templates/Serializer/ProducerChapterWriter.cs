namespace PDFProducer.Templates.Serializer;

public class ProducerChapterWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public ProducerChapterWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        if (obj is not ProducerChapter chapter)
            return;

        writer.WriteStartElement(ProducerChapterConstants.Chapter);

        var nameWriter = _templateWriterFactory.GetWriter(nameof(TemplateElement));
        nameWriter?.Write(chapter, writer);

        WriterUtilities.WriteElementString(writer, ProducerChapterConstants.Title, chapter.Title);
        WriterUtilities.WriteElementString(writer, ProducerChapterConstants.Description, chapter.Description);

        WriterUtilities.WriteElementContainerNodes(_templateWriterFactory, chapter, writer);

        writer.WriteEndElement();
    }
}
