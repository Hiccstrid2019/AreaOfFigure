using System.Reflection;

namespace Area
{
    public class Figure
    {
        public double AutoDetectArea()
        {
            if (this.GetType().GetProperty("Radius") != null) // если есть свойство радиус значит эта фигура круг
            {
                return (double) this.GetType().GetProperty("Area")!.GetValue(this)!;
            }
            else
            {
                if (this.GetType().GetProperty("IsRectangular") != null) // если есть свойство IsRectangular, значит эта фигура квадрат
                {
                    return (double) this.GetType().GetProperty("Area")!.GetValue(this)!;
                }
            }

            return 0;
        }
    }
}