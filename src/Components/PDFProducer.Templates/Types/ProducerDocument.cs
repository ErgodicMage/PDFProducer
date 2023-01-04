namespace PDFProducer.Templates.Types;

public class ProducerDocument : TemplateContainer
{
    public IList<ProducerFont> Fonts { get; set; } = new List<ProducerFont>();
}
