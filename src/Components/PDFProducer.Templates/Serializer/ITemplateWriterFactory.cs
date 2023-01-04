namespace PDFProducer.Templates.Serializer
{
    public interface ITemplateWriterFactory
    {
        IProducerWriter GetWriter(string className);
        IProducerWriter GetWriter(object obj);

        void AddWriter(string className, IProducerWriter writer);

        void RemoveWriter(string className);
    }
}