using FreETarget.NET.Data.Entities;
using FreETarget.NET.Data.Enums;
using FreeTargetWeb01.Models.Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreETarget.NET.Data.Models.TargetTypes
{
    [Serializable]
    public class Dgi15mRiffel : aTargetType
    {
        public Dgi15mRiffel() : base(TargetType.Dgi15Riffel)
        {
            int width = 2000;
            int center = width / 2;


      
            SvgImage.Width = width;
            SvgImage.Height = width;

            SvgImage.AddRectangle(0, 0, width, width,SvgImage.BackgroundColor);
            SvgImage.AddText(40, 20, "Modeltype: M90", 30, SvgImage.TextColor);
            SvgImage.AddText(40, 60, "Rifle target 50m, cal 5.6mm", 30, SvgImage.TextColor);
            SvgImage.AddCircle(center, center, 857,SvgImage.BackgroundColor, SvgImage.TextColor, 1); // 4
            SvgImage.AddCircle(center, center, 732, SvgImage.TextColor); //5
            SvgImage.AddCircle(center, center, 607, SvgImage.TextColor,SvgImage.BackgroundColor, 1); // 6
            SvgImage.AddCircle(center, center, 482, SvgImage.TextColor,SvgImage.BackgroundColor, 1); // 7
            SvgImage.AddCircle(center, center, 357, SvgImage.TextColor,SvgImage.BackgroundColor, 1); // 8
            SvgImage.AddCircle(center, center, 232, SvgImage.TextColor,SvgImage.BackgroundColor, 1); // 9
            SvgImage.AddCircle(center, center, 107, SvgImage.TextColor,SvgImage.BackgroundColor, 1); // 10
            SvgImage.AddCircle(center, center, 44, SvgImage.TextColor,SvgImage.BackgroundColor, 1); // X

            SvgImage.AddText(center, 1169, "9", 50,SvgImage.BackgroundColor);
            SvgImage.AddText(center, 1294, "8", 50,SvgImage.BackgroundColor);
            SvgImage.AddText(center, 1419, "7", 50,SvgImage.BackgroundColor);
            SvgImage.AddText(center, 1544, "6", 50,SvgImage.BackgroundColor);
            SvgImage.AddText(center, 1669, "5", 50,SvgImage.BackgroundColor);
        }

        public override decimal Get10Radius()
        {
            return 0.5m;
        }
    }
  
}
