using System.IO;
using System.Text;
using System.Xml;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PDFProducer.Templates.Types;
using PDFProducer.Templates.Serializer;

namespace TemplateTests;

[TestClass]
public class Serialization
{
    [TestMethod]
    [TestCategory(TestCategories.ExperimentTest)]
    public void DirectSerialization()
    {
        ProducerTemplate template = TemplateBuilder.GenerateTemplate();

        XmlWriterSettings settings = new XmlWriterSettings()
        {
            Encoding = new UTF8Encoding(false),
            Indent = true
        };

        using TextWriter textWriter = new StreamWriter(@"C:\Development\EM\PDFProducer\Template.xml");
        using XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings);

        DefaultTemplateWriterFactory factory = new();

        var templateWriter = factory.GetWriter(nameof(ProducerTemplate));
        templateWriter?.Write(template, xmlWriter);
    }

    [TestMethod]
    [TestCategory(TestCategories.ExperimentTest)]
    public void DirectDeserialization()
    {
        using TextReader reader = new StreamReader(@"C:\Development\EM\PDFProducer\Template.xml");
        XmlReader xmlReader = XmlReader.Create(reader);

        DefaultTemplateReaderFactory factory = new();
        IProducerReader producerReader = factory.GetReader(TemplateConstants.TemplateElementName);
        ProducerTemplate template = producerReader?.Read(xmlReader) as ProducerTemplate;
    }
}
