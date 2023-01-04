namespace PDFProducer.Templates.Serializer;

public interface IProducerReader
{
    object Read(XmlReader reader);
}
