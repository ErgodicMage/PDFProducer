namespace PDFProducer.Templates.Types;

public class TemplateContainer : TemplateElement
{
    public IList<TemplateElement> Nodes { get; set; }

    public void Add(TemplateElement node)
    {
        if (Nodes is null)
            Nodes = new List<TemplateElement>();
        node.Parent = this;
        Nodes.Add(node);
    }
}
