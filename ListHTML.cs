using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class ListHTML : HTML
    {
        List<Layer> list = new List<Layer>();
        Layer[] li = new Layer[100];
        int noOfLi;
        int currentLi;
  
        public ListHTML(String tag) : base(tag)
        {
            noOfLi = -1;
            currentLi = -1;

            
        }

        public override string writeHTML()
        {

            string code = "\n";
            code += "<" + this.tag + ">";
            for(int i = 0; i < li.Length;i++)
            {
                if (li[i] == null)
                    continue;

                code += li[i].code.getHTML().writeHTML() + "\n";
              //  code += list.ElementAt<Layer>(i).code.getHTML().writeHTML();
            }

            code += "</" + this.tag + ">";
            return code;
        }

        public override Layer AddLi()
        {
            currentLi = noOfLi;
            noOfLi++;
            currentLi++;
            li[currentLi] = new Layer(currentLi, "li");
            return li[currentLi];
            
            
           // list.Add(new Layer(noOfLi, "li"));
        }

        public override void deleteLi()
        {
           li[currentLi].Delete();
            li[currentLi] = null;
            noOfLi--;
            currentLi = noOfLi;
        }

        public override Layer getLiAt()
        {
            return li[currentLi];
        }

        public override int getCurrentLi()
        {
            return currentLi;
        }

        public override void setCurrentLi(int i)
        {
            this.currentLi = i;
        }

    }
}
