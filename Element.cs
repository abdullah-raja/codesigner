using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class Element
    {
       // public IndexedTextBox design;
       // public IndexedTextBox layerinfo;

        HTML html;
        string htmlCode;

        public Element()
        {
            html = new HTML();
            htmlCode = html.writeHTML();

        }

        public Element(string tag)
        {
            
                html = new HTML(tag);
            

                htmlCode = html.writeHTML();
        }


        
       

        public string getHtmlCode()
        {
            htmlCode = html.writeHTML();
            return htmlCode;
        }

        public HTML getHTML()
        {
            return html;
        }
        
    }
}
