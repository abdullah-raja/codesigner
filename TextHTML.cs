using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class TextHTML : HTML
    {
        string value;

        public TextHTML():base()
        {
            value = "TextLayer";
        }

        public TextHTML(String tag) : base(tag)
        {
            value = "TextLayer";
        }

        



        public override string getValue()
        {
            return value;
        }

        public override void setValue(string s)
        {
            value = s;
        }

        public override string writeHTML()
        {
            string code = "<" + tag + ">" + value + "</" + tag + ">";

            return code;
        }
    }
}
