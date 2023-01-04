namespace PDFProducer.Templates.Serializer;

public static class ReaderUtilities
{
    public static void ReadObjectElements(XmlReader reader, ITemplateReaderFactory factory, object parentObj, Action<object, object, string> handleElementObject)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(parentObj);
        ArgumentNullException.ThrowIfNull(factory);

        while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
        {
            IProducerReader elementReader = reader.NodeType switch
            {
                XmlNodeType.Element => factory.GetReader(reader.Name),
                _ => null
            };

            if (elementReader is null)
            {
                //reader.Skip();
                continue;
            }

            string elementName = reader.Name;
            object elementObj = elementReader.Read(reader);
            if (elementObj is null)
                continue;

            handleElementObject?.Invoke(parentObj, elementObj, elementName);
        }
    }
}
