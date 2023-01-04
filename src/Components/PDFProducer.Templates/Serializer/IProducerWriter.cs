namespace PDFProducer.Templates.Serializer;

public interface IProducerWriter
{
    void Write(object obj, XmlWriter writer);
}
