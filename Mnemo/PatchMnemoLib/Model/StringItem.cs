using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatchMnemoLib.Model
{
    public class StringItem : IEquatable<StringItem>
    {
        public string Value { get; set; }
        

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            StringItem objAsPart = obj as StringItem;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public bool Equals(StringItem other)
        {
            if (other == null) return false;
            return (this.Value.Equals(other.Value));
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
       /* public StringItem(string str)
        {
            Value = str;
        }*/
    }
}
