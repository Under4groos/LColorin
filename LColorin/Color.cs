using System.Runtime.InteropServices;

namespace LColorin
{
    public struct Color
    {
        public int R;
        public int G;
        public int B;
        public int A;

        public int ToDWORD()
        {
            return (int)this.R + (((int)this.G) << 8) + (((int)this.B) << 16); ;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct COLORREF
    {
        Color _color = new Color();
        public COLORREF(Color color)
        {
            _color = color;
        }
        public int ToDWORD()
        {
            return _color.ToDWORD();
        }
    }
}
