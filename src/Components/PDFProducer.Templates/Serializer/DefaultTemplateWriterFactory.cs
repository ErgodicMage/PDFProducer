namespace PDFProducer.Templates.Serializer;

public sealed class DefaultTemplateWriterFactory : ITemplateWriterFactory
{
    public DefaultTemplateWriterFactory()
    {
        Writers.Add(nameof(TemplateElement), new TemplateElementWriter(this));
        Writers.Add(nameof(ProducerTemplate), new TemplateWriter(this));
        Writers.Add(nameof(MetaData), new MetaDataWriter(this));
        Writers.Add(nameof(MetaDataProperties), new MetaDataPropertiesWriter(this));
        Writers.Add(nameof(MetaDataDescription), new MetaDataDescriptionWriter(this));
        Writers.Add(nameof(ProducerDocument), new ProducerDocumentWriter(this));
        Writers.Add(nameof(ProducerPage), new ProducerPageWriter(this));
        Writers.Add(nameof(ProducerChapter), new ProducerChapterWriter(this));

        Writers.Add(nameof(ProducerFont), new ProducerFontWriter(this));
    }

    private IDictionary<string, IProducerWriter> Writers { get; } = new Dictionary<string, IProducerWriter>();

    public IProducerWriter GetWriter(string className) => Writers.ContainsKey(className) ? Writers[className] : null;

    public IProducerWriter GetWriter(object obj)
    {
        Type type = obj.GetType();

        if (Writers.ContainsKey(type.Name))
            return Writers[type.Name];
        return null;
    }

    public void AddWriter(string className, IProducerWriter writer)
    {
        if (string.IsNullOrEmpty(className) || writer is null)
            return;

        if (Writers.ContainsKey(className))
            Writers[className] = writer;
        else
            Writers.Add(className, writer);
    }

    public void RemoveWriter(string className)
    {
        if (!string.IsNullOrEmpty(className) && Writers.ContainsKey(className))
            Writers.Remove(className);
    }
}
