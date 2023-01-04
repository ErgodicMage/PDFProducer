using System.Collections.Generic;

using PDFProducer.Templates.Types;

namespace TemplateTests;

public static class TemplateBuilder
{
    private const string CurrentVersion = "0.0.1";

    public static ProducerTemplate GenerateTemplate()
    {
        ProducerTemplate template = new ProducerTemplate()
        {
            Properties = new TemplateProperties()
            {
                PDFProducerVersion = "0.0.1",
                TemplateVersion = "0.1",
                Author = "Ergodic Mage",
                Description = "Building Template",
                Notes = "Work in progress"
            }
        };

        template.MetaData = new MetaData();
        template.MetaData.Properties = new MetaDataProperties();
        template.MetaData.Properties.Version = "1.7";
        template.MetaData.Description = new MetaDataDescription();
        template.MetaData.Description.Title = "Example Template";
        template.MetaData.Description.Author = "Ergodic Mage";
        template.MetaData.Description.Subject = "Experimental Serializer";
        template.MetaData.Description.Keywords = "PDFProducer Template, Serializer, Experimental";

        template.Document = new ProducerDocument();
        template.Document.Name = "Document 1";

        template.Document.Font = new ProducerFont() { Name = "arial" };

        ProducerPage page = new ProducerPage();
        page.Name = "Page 1";
        page.Description = "The first page";

        template.Document.Add(page);

        ProducerChapter chapter = new ProducerChapter();
        chapter.Name = "Chapter 1";
        chapter.Title = "Chapter Title 1";
        chapter.Description = "The first chapter";
        chapter.Font = new ProducerFont() { Name = "font1" };

        page = new ProducerPage();
        page.Name = "Page 2";
        page.Description = "The second page";
        page.Font = new ProducerFont() { Name = "arial" };

        chapter.Add(page);

        template.Document.Add(chapter);

        template.Fonts = new List<ProducerFont>();

        ProducerFont font1 = new ProducerFont()
        {
            Name = "font1",
            FontName = "Font 1",
            File = "Font1.ttf",
            Embed = true,
        };
        template.Fonts.Add(font1);

        ProducerFont font2 = new ProducerFont()
        {
            Name = "arial",
            FontName = "Arial",
            Embed = false,
        };
        template.Fonts.Add(font2);

        return template;
    }
}
