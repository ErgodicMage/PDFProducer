using System.Xml.Serialization;

namespace PDFProducer.Templates.Types;

[Serializable]
[XmlRoot("Template", Namespace = "https://github.com/ErgodicMage/PDFProducer")]
public class ProducerTemplate
{
    public TemplateProperties Properties { get; set; }

    public MetaData MetaData { get; set; }

    public ProducerDocument Document { get; set; }

    public IList<ProducerFont> Fonts { get; set; }
}
