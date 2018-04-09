using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatchMnemoLib.Model
{
    [Serializable]
    public class AnimPen
    {
        public AnimPen()
        {
            ListAnimation = new List<GraphicsAnimation>();
            ListPen = new List<GraphicsPen>();
        }
        public List<GraphicsAnimation> ListAnimation { get; set; }
        public List<GraphicsPen> ListPen { get; set; }
/// <summary>
/// проверка на коректность заполнения коллекций
/// </summary>
/// <returns></returns>
        public bool verfityAnimPen()
        {
            bool flag;
            foreach (var pen in ListPen)
            {
                flag = false;
                if (pen.AnimateName == "") flag = true;
                foreach (var anim in ListAnimation)
                    if (anim.Name == pen.AnimateName) flag = true;
                if (!flag) return false;


            }
            return true;
        }






    }
}
