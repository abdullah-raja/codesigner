using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner
{
    class Attribute
    {
        Dictionary<String, String> attributes = new Dictionary<string, string>();
        String attributeString;

        public string getAttributeString()
        {
            return attributeString;
        }

        public Dictionary<String,String> getAttributes()
        {
            return attributes;
        }

        public Attribute(string tag)
        {
            attributeString = "";
            attributes.Add("Id", "");
            attributes.Add("Class", "");

            if(tag == "form")
            {
                attributes.Add("action", "");
                attributes.Add("method", "");
                attributes.Add("target", "");
            }

            else
            {
                if(tag == "a")
                {
                    attributes.Add("href", "");
                    attributes.Add("target", "");
                }

                else
                {
                    if (tag == "img")
                        attributes.Add("src", "");
                    else
                    {
                        attributes.Add("name", "");
                        attributes.Add("value", "");
                        attributes.Add("type", "");
                        attributes.Add("required", "");

                    }
                }
            }

           updateAttributeString();
        }

        public void updateAttributeString()
        {
            attributeString = "";
            foreach (KeyValuePair<String, String> item in attributes)
            {
               
                if (item.Value != "")
                    attributeString += item.Key + " = \"" + item.Value + "\", ";
            }
        }
    }
}
