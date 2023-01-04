using System.IO;
using System.Text;
using System.Xml;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PDFProducer.Templates.Types;
using PDFProducer.Templates.Serializer;

namespace TemplateTests;

[TestClass]
public class CustomTypeTests
{
    [TestMethod]
    public void TestAddingCustomType()
    {
        ProducerTemplate template = TemplateBuilder.GenerateTemplate();
        // this is a bit tricky for right now - area for improments;
        ProducerChapter chapter = template.Document.Nodes[1] as ProducerChapter;

        Assert.IsNotNull(chapter);

        ChapterSection section = new ChapterSection()
        {
            SectionNumber = "1.1",
            Title = "Section 1 Title"
        };

        chapter.Add(section);

        ChapterSection checkedsection = chapter.Nodes[1] as ChapterSection;

        Assert.IsNotNull(checkedsection);
        Assert.AreEqual(section.SectionNumber, checkedsection.SectionNumber);
        Assert.AreEqual(section.Title, checkedsection.Title);
    }

    [TestMethod]
    [TestCategory(TestCategories.ExperimentTest)]
    public void CustomTypeSerialization()
    {
        ProducerTemplate template = TemplateBuilder.GenerateTemplate();
        // this is a bit tricky for right now - area for improments;
        ProducerChapter chapter = template.Document.Nodes[1] as ProducerChapter;

        Assert.IsNotNull(chapter);

        ChapterSection section = new ChapterSection()
        {
            SectionNumber = "1.1",
            Title = "Section 1 Title"
        };

        chapter.Add(section);

        DefaultTemplateWriterFactory factory = new();

        factory.AddWriter(nameof(ChapterSection), new ChapterSectionWriter(factory));

        XmlWriterSettings settings = new XmlWriterSettings()
        {
            Encoding = new UTF8Encoding(false),
            Indent = true
        };

        using TextWriter textWriter = new StreamWriter(@"C:\Development\EM\PDFProducer\TemplateCustomType.xml");
        using XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings);

        var templateWriter = factory.GetWriter(nameof(ProducerTemplate));
        templateWriter?.Write(template, xmlWriter);
    }

}
