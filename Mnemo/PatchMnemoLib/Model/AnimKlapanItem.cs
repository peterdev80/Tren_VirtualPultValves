using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatchMnemoLib.Model
{
    /// <summary>
    /// Класс хранит всю информацию о клапане и ссылку на анимацию
    /// </summary>
    [Serializable]
    public class AnimKlapanItem : KlapanItem
    {


        public bool IsAnimate { get; set; }
        public double Xrotate { get; set; }
        public double Yrotate { get; set; }
        public bool IsRevers { get; set; }
        public AnimKlapanItem() : base()
        {
            IsAnimate = false;
            Xrotate = 0;
            Yrotate = 0;
        }


    }
}
