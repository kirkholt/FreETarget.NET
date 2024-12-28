using System.Xml;

namespace FreeTargetWeb01.Models.Svg
{
    public class SvgImage
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public string BackgroundColor { get; set; } = "#FFE4B5";
        public string TextColor { get; set; } = "black";

        public String TextFont { get; set; } = "Arial";
        public List<SvgElement> Elements { get; set; } = new List<SvgElement>();

        public void AddCircle(int x, int y, int r, string? fill = null, string? stroke = null, int? strokeWidth = null)
        {
            SvgElement svgElement = new SvgElement
            {
                ElementType = SvgElementType.Circle,
                X = x,
                Y = y,
                R = r,
                Fill = fill,
                Stroke = stroke,
                StrokeWidth = strokeWidth
            };
            Elements.Add(svgElement);
        }

        public void AddRectangle(int x, int y, int width, int height, string? fill = null)
        {
            SvgElement svgElement = new SvgElement
            {
                ElementType = SvgElementType.Rectangle,
                X = x,
                Y = y,
                Width = width,
                Height = height
            };
            if (fill != null)
            {
                svgElement.Fill = fill;
            }
            Elements.Add(svgElement);
        }

        public void AddText(int x, int y, string text, int fontSize, string? fill = null, string? fontWeight = null )
        {
            SvgElement svgElement = new SvgElement
            {
                ElementType = SvgElementType.Text,
                X = x,
                Y = y,
                Text = text,
                FontSize = fontSize,
                FontWeight = fontWeight
            };
            if (fill != null)
            {
                svgElement.Fill = fill;
            }
            Elements.Add(svgElement);
        }

        public override string ToString()
        {
            string resultat = "";
            using (var sw = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(sw))
                {
                    const string svgNs = "http://www.w3.org/2000/svg";
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("svg", svgNs);
                    //xmlWriter.WriteAttributeString("width", Width.ToString());
                    //xmlWriter.WriteAttributeString("height", Height.ToString());
                    xmlWriter.WriteAttributeString("viewBox", $"0 0 {Width} {Height}");

                    if (TextFont != null)
                    {
                        xmlWriter.WriteStartElement("style");
                        xmlWriter.WriteString($"text {{font-family: {TextFont} }}");
                        xmlWriter.WriteEndElement();
                    }

                    foreach (var element in Elements)
                    {
                        switch (element.ElementType)
                        {
                            case SvgElementType.Circle:
                                xmlWriter.WriteStartElement("circle");
                                xmlWriter.WriteAttributeString("cx", element.X.ToString());
                                xmlWriter.WriteAttributeString("cy", element.Y.ToString());
                                xmlWriter.WriteAttributeString("r", element.R.ToString());
                                if (element.Fill != null)
                                {
                                    xmlWriter.WriteAttributeString("fill", element.Fill);
                                }
                                if (element.Stroke != null)
                                {
                                    xmlWriter.WriteAttributeString("stroke", element.Stroke);
                                }
                                if (element.StrokeWidth != null)
                                {
                                    xmlWriter.WriteAttributeString("stroke-width", element.StrokeWidth.ToString());
                                }
                                xmlWriter.WriteEndElement();
                                break;
                            case SvgElementType.Rectangle:
                                xmlWriter.WriteStartElement("rect");
                                xmlWriter.WriteAttributeString("x", element.X.ToString());
                                xmlWriter.WriteAttributeString("y", element.Y.ToString());
                                xmlWriter.WriteAttributeString("width", element.Width.ToString());
                                xmlWriter.WriteAttributeString("height", element.Height.ToString());
                                if (element.Fill != null)
                                {
                                    xmlWriter.WriteAttributeString("fill", element.Fill);
                                }
                                xmlWriter.WriteEndElement();
                                break;
                            case SvgElementType.Text:
                                xmlWriter.WriteStartElement("text");
                                xmlWriter.WriteAttributeString("x", element.X.ToString());
                                xmlWriter.WriteAttributeString("y", element.Y.ToString());
                                xmlWriter.WriteAttributeString("font-size", element.FontSize.ToString());
                                xmlWriter.WriteAttributeString("dominant-baseline", "middle");
                                xmlWriter.WriteAttributeString("text-anchor", "middle");

                                if (element.Fill != null)
                                {
                                    xmlWriter.WriteAttributeString("fill", element.Fill);
                                }

                                if (element.FontWeight != null)
                                {
                                    xmlWriter.WriteAttributeString("font-weight", element.FontWeight);
                                }

                                xmlWriter.WriteString(element.Text);
                                xmlWriter.WriteEndElement();
                                break;
                        }
                    }
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();

                }
                resultat = sw.ToString();
                resultat = resultat.Substring(resultat.IndexOf("?>") + 2);

            }
            return resultat;
        }
    }
}
