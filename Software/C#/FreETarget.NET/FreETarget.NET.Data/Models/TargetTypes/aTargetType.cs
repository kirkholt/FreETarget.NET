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
    public abstract class aTargetType
    {
        public aTargetType(TargetType targetType)
        {
            TargetType = targetType;
            SvgImage = new SvgImage();
        }

        protected SvgImage SvgImage { get; set; }
        public TargetType TargetType { get;  private set; }
        public abstract decimal Get10Radius();
        public virtual decimal GetScore(decimal radius)
        {
            return 11 - (radius / Get10Radius());
        }

        public virtual void AddShotToSvg(Shot shot)
        {
            int x = (int)(shot.X * 10.0m);
            int y = (int)(shot.Y * 10.0m);
            SvgImage.AddCircle(x,y, 23, "red");
        }
    }
}
