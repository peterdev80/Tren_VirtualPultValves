using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using PatchMnemoLib.ViewModel;
using PatchMnemoLib.Model;
using PatchMnemoLib.ViewModelMElement;

namespace PatchMnemoLib
{
     [XmlRoot("Graphics")]
   public class SerializationHelper
    {
         PropertiesGraphicsBase[] graphics;
         public SerializationHelper()
         {

         }
         public SerializationHelper(List<ViewModelGraphics> collection)
         {
             if (collection == null)
             {
                 throw new ArgumentNullException("collection");
             }

             graphics = new PropertiesGraphicsBase[collection.Count];

             int i = 0;

             foreach (ViewModelGraphics g in collection)
             {
                 graphics[i++] = g.GetGP().CreateSerializedObject();
             }
         }
         [XmlArrayItem(typeof(PropertyPatchGraphics)),
       XmlArrayItem(typeof(PropertyDPGraphics)),
         XmlArrayItem(typeof(PropertyKlapanGraphics)),
         XmlArrayItem(typeof(PropertyValueLabelGraphics)),
         XmlArrayItem(typeof(PropertyarcBalon)),
         XmlArrayItem(typeof(PropertyVoltmetr)),
         XmlArrayItem(typeof(PropertyColorInd)),
             XmlArrayItem(typeof(PropertyLispKlapanGraphics)),
            XmlArrayItem(typeof(PropertyAnimKlapanGraphics))]
         public PropertiesGraphicsBase[] Graphics
         {
             get { return graphics; }
             set { graphics = value; }
         }
    }
}
