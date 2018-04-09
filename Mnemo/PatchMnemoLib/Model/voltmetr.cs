using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PatchMnemoLib.Model
{
    public class Voltmetr : VisualBase
    {
        [XmlIgnore]
        public override int TVisual
        {
            get { return 6; }
        }
    }
}
