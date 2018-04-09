using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Xml.Serialization;
using System.Windows.Media.Animation;
using System.Windows;

namespace PatchMnemoLib.Model
{
     [Serializable]
    public class GraphicsPen 
    {
       
      

        #region Constructor
         public GraphicsPen()
        {

        }
         public GraphicsPen(Color _cp, Double _ps, String _an, string _pn, bool _anim)
        {
            ColorPen = _cp;
            PenSize = _ps;
            AnimateName = _an;
            PenName = _pn;
            Animate = _anim;

        }
        #endregion
         //свойства DashStyle
         public double LineDas
         {
             get;
             set;
         }
         public double SpaceDash
         {
             get;
             set;
         }

         public Color ColorPen
         {
             get;
             set;
         }
         public Double PenSize
         {
             get;
             set;
         }
         public String AnimateName
         {
             get;
             set;
         }
         public string PenName
         {
             get;
             set;
         }
         public bool Animate
         {
             get;
             set;
         }
         
    }
}
