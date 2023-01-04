using System.Xml;

using PDFProducer.Templates.Types;
using PDFProducer.Templates.Serializer;

namespace TemplateTests;

/// Custom Type code - ChapterSection
/// This custom type simulates a section in a chapter such as Chapter 2.1. It is not implemented as a page because a pae will always start
/// on a new page. For this we want it to be on a Chapter page
public class ChapterSection : TemplateContainer
{
    public string SectionNumber { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
}

// create a writer to insert into the writer factory
public class ChapterSectionWriter : IProducerWriter
{
    private readonly ITemplateWriterFactory _templateWriterFactory;

    public ChapterSectionWriter(ITemplateWriterFactory templateWriterFactory)
    {
        _templateWriterFactory = templateWriterFactory;
    }

    public void Write(object obj, XmlWriter writer)
    {
        ChapterSection section = obj as ChapterSection;
        if (section is null)
            return;

        writer.WriteStartElement("ChapterSection");

        var nameWriter = _templateWriterFactory.GetWriter(typeof(TemplateElement).Name);
        nameWriter?.Write(section, writer);

        WriterUtilities.WriteElementString(writer, "SectionNumber", section.SectionNumber);
        WriterUtilities.WriteElementString(writer, "Title", section.Title);
        WriterUtilities.WriteElementString(writer, "Description", section.Description);
        WriterUtilities.WriteElementContainerNodes(_templateWriterFactory, section, writer);

        writer.WriteEndElement();
    }
}
