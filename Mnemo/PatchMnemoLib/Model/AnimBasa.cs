using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;

namespace PatchMnemoLib.Model
{
    /// <summary>
    /// Класс который предостовляет доступ к базе анимациям
    /// </summary>
    class AnimBasa
    {
        private static volatile AnimBasa instance;
        private static object syncRoot = new Object();
        public static AnimBasa Instance
        {
            get
            {


                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new AnimBasa();
                    }
                }

                return instance;
            }
        }

        public AnimBasa()
        {
            lstAnim = new List<GraphicsAnimation>();
            GraphicsAnimation gan = new GraphicsAnimation(360, 1, 4, 1, "a1");
            SimulateAnimLoad(gan);
            GraphicsAnimation gan1 = new GraphicsAnimation(-360, 1, 0, -1, "a2");
            SimulateAnimLoad(gan1);
            GraphicsAnimation gan2 = new GraphicsAnimation(0, 1,360,900, "a90");
            SimulateAnimLoad2(gan2);
            GraphicsAnimation gan3 = new GraphicsAnimation(-100, 1, 100, 9, "a100");
            SimulateAnimLoad2(gan3);

        }
        private void SimulateAnimLoad(GraphicsAnimation gan)
        {

            DoubleAnimation _AnimationS = new DoubleAnimation(gan.To, gan.ToValue, new Duration(TimeSpan.FromSeconds(gan.Dooration)));
             _AnimationS.By = gan.By;
            _AnimationS.RepeatBehavior = RepeatBehavior.Forever;
           
           
            Timeline.SetDesiredFrameRate(_AnimationS,30);
            gan.AnimationS = _AnimationS;
            lstAnim.Add(gan);

        }
        private void SimulateAnimLoad2(GraphicsAnimation gan)
        {

            DoubleAnimation _AnimationS = new DoubleAnimation(gan.To, gan.ToValue, new Duration(TimeSpan.FromSeconds(gan.Dooration)));
            _AnimationS.By = gan.By;
            _AnimationS.RepeatBehavior = RepeatBehavior.Forever;


            Timeline.SetDesiredFrameRate(_AnimationS, 2);
            gan.AnimationS = _AnimationS;
            lstAnim.Add(gan);

        }



        private List<GraphicsAnimation> lstAnim;

        public DoubleAnimation GetAnim(string name)
        {

            var an = lstAnim.Find(x => x.Name == name);
            if (an != null) return an.AnimationS;

            return null;
        }

    }
}
