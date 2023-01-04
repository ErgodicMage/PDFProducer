namespace PDFProducer.Templates.Serializer;

public static class WriterUtilities
{
    public static void WriteElementString(XmlWriter writer, string element, string val)
    {
        if (!string.IsNullOrEmpty(val))
            writer.WriteElementString(element, val);
    }

    public static void WriteElementContainerNodes(ITemplateWriterFactory _templateWriterFactory, TemplateContainer container, XmlWriter writer)
    {
        if (container is null || container.Nodes is null)
            return;

        foreach (TemplateElement element in container.Nodes)
        {
            var elementwriter = _templateWriterFactory.GetWriter(element);
            elementwriter?.Write(element, writer);
        }
    }
}
