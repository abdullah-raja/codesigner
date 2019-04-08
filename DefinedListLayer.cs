using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class DefinedListLayer : ListLayer
    {
        Layer[] dd = new Layer[100];
        public DefinedListLayer()
        {

        }

        public DefinedListLayer(int ind, string tag) : base(ind, tag)
        {
            
        }

        public override void addLi(string tag)
        {
            noOfLi++;
            currentLi = noOfLi;
            li[currentLi] = new TextLayer("dt", currentLi);
            dd[currentLi] = new TextLayer("dd", currentLi);

            p.Controls.Add(li[currentLi].getDesign());
            p.Controls.Add(dd[currentLi].getDesign());

            li[currentLi].getDesign().Click += (s, er) =>
            {
                IndexedFlowLayout f = (IndexedFlowLayout)li[currentLi].getDesign().Parent;
                Form1.currentLayer = f.getIndex();
            };

            dd[currentLi].getDesign().Click += (s, er) =>
            {
                IndexedFlowLayout f = (IndexedFlowLayout)li[currentLi].getDesign().Parent;
                Form1.currentLayer = f.getIndex();
            };

        }

        public override void deleteLi()
        {
            dd[currentLi].Delete();
            dd[currentLi] = null;
            base.deleteLi();
        }

        public override Layer getDd()
        {
            return dd[currentLi];
        }

        public override string writeHTMLCode()
        {
            string temp = "\n";
            for (int i = 0; i < li.Length; i++)
            {
                if (li[i] == null && dd[i] == null)
                    continue;

                if (dd[i] != null)
                    temp += dd[i].writeHTMLCode() + "\n";

                if(li[i] != null)
                    temp += li[i].writeHTMLCode() + "\n";
            }

            this.code.getHTML().setValue(temp);
            return code.getHtmlCode();
        }

        public override void Delete()
        {
            for (int i = 0; i < li.Length; i++)
            {
                if (li[i] == null && dd[i] == null)
                    continue;

                if (dd[i] != null)
                    this.dd[i].Delete();

                if (li[i] != null)
                    this.li[i].Delete();
            }
            this.code = null;
            this.li = null;
            this.dd = null;
        }
    }
}
