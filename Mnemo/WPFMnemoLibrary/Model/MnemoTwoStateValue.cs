using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.Model
{
    public class MnemoValStateValue : Valuer<bool>

    {
        private Brush pc = Brushes.Black, ac = Brushes.Blue, cc = Brushes.Black;
        private bool sl = false;

        public Brush PasivColor
        {
            get { return pc; }
            set
            {
                if (value == pc) return;
                pc = value;
                if (!StateElement) CurentColor = pc;
            }
        }
        public Brush ActivColor
        {
            get { return ac; }
            set
            {
                if (value == ac) return;
                ac = value;
                if (StateElement) CurentColor = ac;
            }
        }
        public Brush CurentColor
        {
            get { return cc; }
            set
            {
                if (cc == value) return;
                cc = value;
                base.OnPropertyChanged("CurentColor");
            }
        }
        public bool StateElement
        {
            get { return sl; }
            set
            {
                if (value == sl) return;
                sl = value;
                if (sl) CurentColor = ActivColor;
                else
                    CurentColor = PasivColor;
                base.OnPropertyChanged("StateElement");
            }
        }


        public MnemoValStateValue()
        {
        }


    }
}
