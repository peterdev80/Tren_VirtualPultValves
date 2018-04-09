using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PatchMnemoLib.Model
{
    public class AnimKlapan : Klapan
    {
        public new ObservableCollection<AnimKlapanItem> GDats { get; set; }
        private string _animName;
        public string AnimName { get { return _animName; } set { _animName = value; Animation = AnimBasa.Instance.GetAnim(_animName); } }
        public DoubleAnimation Animation { get; set; }

        public double rotate { get; set; }
        public AnimKlapan()
        {
            {
                rotate = 0.0d;
                GDats = new ObservableCollection<AnimKlapanItem>();
                /* AnimKlapanItem ac = new AnimKlapanItem();
                 ac.GData = " M726.213954799874 , 17.308866475512L730.808490128657 , 25.364804052137 , 721.287166010652 , 25.36474609375z";
                 ac.IsAnimate = false;
                 GDats.Add(ac);*/

                AnimKlapanItem ac1 = new AnimKlapanItem();
                ac1.GData = " M726.213954799874 , 17.308866475512L730.808490128657 , 25.364804052137 , 721.287166010652 , 25.36474609375z";
                ac1.IsAnimate = false;
                ac1.Xrotate = 722;
                ac1.Yrotate = 20;
                GDats.Add(ac1);


                AnimKlapanItem ac = new AnimKlapanItem();
                ac.GData = " M726.213954799874 , 17.308866475512L730.808490128657 , 25.364804052137 , 721.287166010652 , 25.36474609375z";
                ac.IsAnimate = true;
                ac.Xrotate = 722;
                ac.Yrotate = 20;

                GDats.Add(ac);

                AnimName = "a1";

            }


        }

        public override int TVisual
        {
            get { return 8; }
        }
        public override void Draw()
        {
            using (DrawingContext dc = this.RenderOpen())
            {
                foreach (var tr in base.lstTransf)
                    dc.PushTransform(tr);



                int posStrDr = FrameElement * StateKey;
                if (FrameElement != 0)
                {
                    int kf = GDats.Count / FrameElement;//количество фрэймов
                    if (StateKey >= kf) posStrDr = FrameElement * (kf - 1);

                }

                int posEndStr = posStrDr + FrameElement;

                for (int i = posStrDr; i < posEndStr; i++)
                {
                    RotateTransform rt = new RotateTransform();
                    if (GDats[i].IsAnimate)
                    {
                        rt = new RotateTransform(rotate, GDats[i].Xrotate, GDats[i].Yrotate);


                    }
                    dc.PushTransform(rt);
                    SolidColorBrush br = new SolidColorBrush(GDats[i].GBrush);
                    Pen gp = new Pen(new SolidColorBrush(GDats[i].GPen), GDats[i].GpenSize);
                    dc.DrawGeometry(br, gp, Geometry.Parse(GDats[i].GData));
                    dc.Pop();
                }




                foreach (var tr in base.lstTransf)
                    dc.Pop();

            }
        }
        public bool GetAnimInFame()
        {
            int posStrDr = FrameElement * StateKey;
            if (FrameElement != 0)
            {
                int kf = GDats.Count / FrameElement;//количество фрэймов
                if (StateKey >= kf) posStrDr = FrameElement * (kf - 1);

            }
            int posEndStr = posStrDr + FrameElement;
            for (int i = posStrDr; i < posEndStr; i++)
            {
                if (GDats[i].IsAnimate) return true;
            }
            return false;

        }
        public override PropertiesGraphicsBase CreateSerializedObject()
        {
            return new PropertyAnimKlapanGraphics(this);
        }

    }
}
