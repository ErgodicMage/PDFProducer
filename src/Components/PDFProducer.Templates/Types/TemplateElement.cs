namespace PDFProducer.Templates.Types;

public class TemplateElement
{
    public string Name { get; set; }
    public TemplateContainer Parent { get; set; }

    public ProducerFont Font { get; set; }
}
