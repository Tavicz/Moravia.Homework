using Moravia.Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Moravia.Homework.Models
{
    public class XmlFormat : IDocumentFormat
    {
        public Document Parse(string content)
        {
            var xdoc = XDocument.Parse(content);

            if (xdoc?.Root is null)
            {
                throw new InvalidOperationException("The XML document is invalid or missing a root element.");
            }

            var titleElement = xdoc.Root.Element("title");
            var textElement = xdoc.Root.Element("text");

            if (titleElement == null || textElement == null)
            {
                throw new InvalidOperationException("The XML document is missing required elements.");
            }

            return new Document
            {
                Title = titleElement.Value,
                Text = textElement.Value
            };
        }

        public string Serialize(Document doc)
        {
            var xdoc = new XDocument(
                new XElement("document",
                    new XElement("title", doc.Title),
                    new XElement("text", doc.Text)
                )
            );
            return xdoc.ToString();
        }
    }
}
