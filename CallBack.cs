using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace font_converter
{
    public static class CallBack
    {
        public delegate void DocumentsLoaded(List<string> usedFonts);

        public delegate void FontsConvertFinished();
    }
}
