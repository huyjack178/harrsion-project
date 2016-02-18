using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Drawing;

namespace Excel.Helper
{
    public struct RTFHelper
    {
        public IFont NormalFont { get; set; }

        public IFont PosFont { get; set; }

        public IFont NegFont { get; set; }

        public IFont NormalFontCrossed { get; set; }

        public IFont PosFontCrossed { get; set; }

        public IFont NegFontCrossed { get; set; }

        public HSSFPalette Pallete { get; set; }

        public RtfTextRender RTFRenderer { get; set; }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>RTFHelper object.</returns>
        public RTFHelper Clone()
        {
            RTFHelper tmp = new RTFHelper();

            tmp.PosFont = PosFont;
            tmp.NegFont = NegFont;
            tmp.NormalFont = NormalFont;

            tmp.NormalFontCrossed = NormalFontCrossed;
            tmp.PosFontCrossed = PosFontCrossed;
            tmp.NegFontCrossed = NegFontCrossed;

            tmp.Pallete = Pallete;

            tmp.RTFRenderer = new RtfTextRender();

            return tmp;
        }

        public void MakeColor()
        {
            Color c = Color.FromArgb(202, 44, 130);
            byte
                red = (byte)(c.R & 0XFF)
          , blue = (byte)(c.B & 0XFF)
          , green = (byte)(c.G & 0XFF);

            Pallete.SetColorAtIndex(100, red, green, blue);
        }

    }
}
