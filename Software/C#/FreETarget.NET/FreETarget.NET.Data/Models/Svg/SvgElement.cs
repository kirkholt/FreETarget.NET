namespace FreeTargetWeb01.Models.Svg
{
    public class SvgElement
    {
        public  SvgElementType ElementType { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? R { get; set; }
        public int? Width { get; set; }
        public int ?Height { get; set; }
        public string? Fill { get; set; }
        public string? Text { get; set; }
        public int? FontSize { get; set; }
        public string? FontWeight { get; set; }
        public string? Stroke { get; set; }
        public int? StrokeWidth { get;set; }


    }
}
