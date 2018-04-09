using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace PatchMnemoLib.Model
{
    public interface IProp 
    {
        string NamePenNode { get; set; }
    };

    public class PropClass : IProp
    {
        public List<Pen> pl { get; set; }

        public string NamePenNode { get; set; }
        public PropClass(string name,List<Pen> p)
        {
            pl = p;
            NamePenNode = name;
        }
        public void AddPen(Pen p)
        {
            pl.Add(p);
        }
        

    }
    public class PenClass : IProp
    {

        public string NamePenNode { get; set; }
        public Pen sPen { get; set; }
        public PenClass(string _name, Pen val)
        {
            NamePenNode = _name;
            sPen = val;
        }
    }
}
