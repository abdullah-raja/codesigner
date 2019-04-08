using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class HTML
    {
        string tag;
        string value;
        Attribute attributeList;
        //private string value;

        public HTML()
        { 
            
            tag = "h1";
            //value = "TextLayer";
            attributeList = new Attribute("h1");
        }

        public HTML(string tag)
        {
            this.tag = tag;
            //value = "TextLayer";
            attributeList = new Attribute(tag);
        }

        public Attribute getAttributeList()
        {
            return attributeList;
        }

        public string getTag()
        {
            return tag;
        }

        virtual public void setValue(string s)
        {
            this.value = s;
        }

        virtual public string getValue()
        {
            return value;
        }


        public string writeHTML()
        {
            String code;
            if(tag == "input")
            {
                if (attributeList.getAttributes()["type"] == "text")
                    code = value + " <" + tag + " " + attributeList.getAttributeString() + "> ";
                else
                {
                    if (attributeList.getAttributes()["type"] == "submit")
                        code = "<" + tag + attributeList.getAttributeString() + ">";

                    else
                        code =  "<" + tag + " " + attributeList.getAttributeString() + ">" + value;
                }

            }

            else
                code = "<" + tag + " " + attributeList.getAttributeString() +  ">" + value + "</" + tag + ">";

            return code;
        }

       /* virtual public Layer AddLi()
        {
            return null;
        }

        virtual public void deleteLi()
        {

        }*/

        

      /*  virtual public Layer getLiAt()
        {
            return null;
        }

        virtual public int getCurrentLi()
        {
            return 0;
        }

        virtual public void setCurrentLi(int i)
        {

        }
        */

    }
}
