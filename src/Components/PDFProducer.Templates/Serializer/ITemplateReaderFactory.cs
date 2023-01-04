namespace PDFProducer.Templates.Serializer
{
    public interface ITemplateReaderFactory
    {
        IProducerReader GetReader(string className);
        void AddReader(string className, IProducerReader reader);
        void RemoveReader(string className);
    }
}