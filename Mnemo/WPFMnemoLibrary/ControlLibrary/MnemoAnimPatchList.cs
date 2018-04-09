using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using ValueModel.BaseType;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class MnemoAnimPatchList : FrameworkElement
    {
        public MnemoAnimPatchList()
            : base()
        {
            Width = 10;
            Height = 10;
            this.Visibility = Visibility.Hidden;
            SetValue(ListPathProperty, new List<Path>());

        }
        #region Анимированные кисти
        public static readonly DependencyProperty LDrawingProperty =
        DependencyProperty.Register("LDrawing", typeof(Brush), typeof(MnemoAnimPatchList),
        new PropertyMetadata(Brushes.Black));
        /// <summary>
        /// Свойства кисть для анимации
        /// </summary>
        public Brush LDrawing
        {
            get { return (Brush)GetValue(LDrawingProperty); }
            set { SetValue(LDrawingProperty, value); }
        }
        public static readonly DependencyProperty RDrawingProperty =
       DependencyProperty.Register("RDrawing", typeof(Brush), typeof(MnemoAnimPatchList),
       new PropertyMetadata(Brushes.Black));
        /// <summary>
        /// Свойства кисть для анимации
        /// </summary>
        public Brush RDrawing
        {
            get { return (Brush)GetValue(RDrawingProperty); }
            set { SetValue(RDrawingProperty, value); }
        }


        public static readonly DependencyProperty MColorProperty =
       DependencyProperty.Register("MColor", typeof(Brush), typeof(MnemoAnimPatchList),
       new PropertyMetadata(Brushes.Black));
        /// <summary>
        /// Текущий цвет линии
        /// </summary>
        public Brush MColor
        {
            get { return (Brush)GetValue(MColorProperty); }
            set { SetValue(MColorProperty, value); }
        }


        #endregion



        #region DependencyProperty Color Setup 3 Color

        public static readonly DependencyProperty PasivColorProperty =
       DependencyProperty.Register("PasivColor", typeof(Brush), typeof(MnemoAnimPatchList),
       new PropertyMetadata(Brushes.Black, ValuebitChanged));
        public Brush PasivColor
        {
            get { return (Brush)GetValue(PasivColorProperty); }
            set { SetValue(PasivColorProperty, value); }
        }

        public static readonly DependencyProperty ActiveColorProperty =
              DependencyProperty.Register("ActiveColor", typeof(Brush), typeof(MnemoAnimPatchList),
              new PropertyMetadata(Brushes.Black, ValuebitChanged));
        public Brush ActiveColor
        {
            get { return (Brush)GetValue(ActiveColorProperty); }
            set { SetValue(ActiveColorProperty, value); }
        }
        public static readonly DependencyProperty AlternativeColorProperty =
           DependencyProperty.Register("AlternativeColor", typeof(Brush), typeof(MnemoAnimPatchList),
           new PropertyMetadata(Brushes.Black, ValuebitChanged));
        public Brush AlternativeColor
        {
            get { return (Brush)GetValue(AlternativeColorProperty); }
            set { SetValue(AlternativeColorProperty, value); }
        }
        #endregion



        #region  DependencyProperty bit position

        public static readonly DependencyProperty ObmenPosProperty =
    DependencyProperty.Register("ObmenPos", typeof(BitPosValue), typeof(MnemoAnimPatchList),
    new PropertyMetadata(BitPosValue.None, ValuebitChanged));
        public BitPosValue ObmenPos
        {
            get { return (BitPosValue)GetValue(ObmenPosProperty); }
            set { SetValue(ObmenPosProperty, value); }
        }
        public static readonly DependencyProperty ObmenPos2bitProperty =
       DependencyProperty.Register("ObmenPos2bit", typeof(BitPosValue), typeof(MnemoAnimPatchList),
       new PropertyMetadata(BitPosValue.None, ValuebitChanged));
        public BitPosValue ObmenPos2bit
        {
            get { return (BitPosValue)GetValue(ObmenPos2bitProperty); }
            set { SetValue(ObmenPos2bitProperty, value); }
        }

        public static readonly DependencyProperty LAnimateLineProperty =
        DependencyProperty.Register("LAnimateLine", typeof(BitPosValue), typeof(MnemoAnimPatchList),
        new PropertyMetadata(BitPosValue.None, ValuebitChanged));
        /// <summary>
        /// признак анимации с лево на право
        /// </summary>
        public BitPosValue LAnimateLine
        {
            get { return (BitPosValue)GetValue(LAnimateLineProperty); }
            set { SetValue(LAnimateLineProperty, value); }
        }
        public static readonly DependencyProperty RAnimateLineProperty =
       DependencyProperty.Register("RAnimateLine", typeof(BitPosValue), typeof(MnemoAnimPatchList),
       new PropertyMetadata(BitPosValue.None, ValuebitChanged));
        /// <summary>
        /// признак анимации с право на лево
        /// </summary>
        public BitPosValue RAnimateLine
        {
            get { return (BitPosValue)GetValue(RAnimateLineProperty); }
            set { SetValue(RAnimateLineProperty, value); }
        }

        public static void ValuebitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            MnemoAnimPatchList comp = (MnemoAnimPatchList)d;
            comp.SetColor();



        }
        #endregion


        #region Property AnimFromWindows

        public bool AllAnimation
        { get; set; }

        public static readonly DependencyProperty StrokeAnimProperty =
        DependencyProperty.Register("StrokeAnim", typeof(Double), typeof(MnemoAnimPatchList),
        new PropertyMetadata(0.0, ValuebitChanged));

        public Double StrokeAnim
        {
            get { return (Double)GetValue(StrokeAnimProperty); }
            set { SetValue(StrokeAnimProperty, value); }
        }

        public static readonly DependencyProperty StrokeAnimLeftProperty =
       DependencyProperty.Register("StrokeAnimLeft", typeof(Double), typeof(MnemoAnimPatchList),
       new PropertyMetadata(0.0));

        public Double StrokeAnimLeft
        {
            get { return (Double)GetValue(StrokeAnimLeftProperty); }
            set { SetValue(StrokeAnimLeftProperty, value); }
        }

        public static readonly DependencyProperty StrokeAnimReihtProperty =
       DependencyProperty.Register("StrokeAnimReiht", typeof(Double), typeof(MnemoAnimPatchList),
       new PropertyMetadata(0.0));

        public Double StrokeAnimReiht
        {
            get { return (Double)GetValue(StrokeAnimReihtProperty); }
            set { SetValue(StrokeAnimReihtProperty, value); }
        }


        #endregion





        #region ListPath
        public static readonly DependencyProperty ListPathProperty =
       DependencyProperty.Register("ListPath", typeof(List<Path>), typeof(MnemoAnimPatchList),
       new PropertyMetadata());

        public List<Path> ListPath
        {
            get { return (List<Path>)GetValue(ListPathProperty); }
            set { SetValue(ListPathProperty, value); }
        }

        #endregion

        #region AnimPatch

        private bool _tlp;
        /// <summary>
        /// Есть ли подложка
        /// </summary>
        /// 
        public bool TwoLayersPatch
        {
            get { return _tlp; }
            set
            {//запускаем игициализацию пути подложки или очищаем его
                _tlp = value;
                if (_tlp) AddVisualPath();
                else
                {
                    Canvas mode = (Canvas)this.Parent;
                    foreach (Path pt in _contur)
                    {
                        if (mode != null) mode.Children.Remove(pt);
                    }
                    _contur.Clear();
                    _contur = null;
                }

            }
        }
        //коллекция плдложки
        private List<Path> _contur;
        //определяем был ли патч добавлен на canvas
        private bool IsInitPath = false;
        private void AddVisualPath()
        {
            Canvas mode = (Canvas)this.Parent;
            bool _fContur = false;
            if (mode != null)
            {
                if ((_contur == null) && (ListPath.Count > 0) && TwoLayersPatch)
                {
                    _fContur = true;
                    _contur = new List<Path>();
                }



                if (!IsInitPath)


                    foreach (Path pt in ListPath)
                    {

                        if (_fContur)
                            AddConturPath(mode, pt, _fContur);

                        IsInitPath = true;
                        //привязка строке

                        // BindingOperations.SetBinding(pt, Path.StrokeDashOffsetProperty,myBinding);

                        mode.Children.Add(pt);



                    }
            }
        }


        private void AddConturPath(Canvas mode, Path _pt, bool _addlist)
        {
            Path pt = new Path();
            pt.Data = _pt.Data;
            pt.Width = _pt.Width;
            pt.Height = _pt.Height;
            pt.Stretch = _pt.Stretch;
            pt.StrokeThickness = _pt.StrokeThickness;
            pt.Stroke = _pt.Stroke;
            pt.RenderTransform = _pt.RenderTransform;
            pt.RenderTransformOrigin = _pt.RenderTransformOrigin;
            Canvas.SetLeft(pt, Canvas.GetLeft(_pt));
            Canvas.SetTop(pt, Canvas.GetTop(_pt));
            mode.Children.Add(pt);
            if (_addlist) _contur.Add(pt);

        }
        #endregion


        #region UIPath


        PenLineCap _UIStrokeDashCap = PenLineCap.Flat;
        public PenLineCap UIStrokeDashCap
        {
            get { return _UIStrokeDashCap; }
            set
            {
                _UIStrokeDashCap = value;
                this.SetColor();
            }
        }



        public static readonly DependencyProperty UIStrokeDashArrayProperty =
           DependencyProperty.Register("UIStrokeDashArray", typeof(DoubleCollection), typeof(MnemoAnimPatchList),
           new PropertyMetadata(null, ValuebitChanged));

        public DoubleCollection UIStrokeDashArray
        {
            get { return (DoubleCollection)GetValue(UIStrokeDashArrayProperty); }
            set { SetValue(UIStrokeDashArrayProperty, value); }
        }



        public static readonly DependencyProperty UIFromProperty =
       DependencyProperty.Register("UIFrom", typeof(double), typeof(MnemoAnimPatchList),
       new PropertyMetadata(8.0, ValuebitChanged));

        public double UIFrom
        {
            get { return (double)GetValue(UIFromProperty); }
            set { SetValue(UIFromProperty, value); }
        }



        public static readonly DependencyProperty UIDurationProperty =
           DependencyProperty.Register("UIDuration", typeof(Duration), typeof(MnemoAnimPatchList),
           new PropertyMetadata(new Duration(new TimeSpan(0, 0, 1)), ValuebitChanged));

        public Duration UIDuration
        {
            get { return (Duration)GetValue(UIDurationProperty); }
            set { SetValue(UIDurationProperty, value); }
        }

        #endregion


        public static readonly DependencyProperty ObmenValueProperty =
         DependencyProperty.Register("ObmenValue",
        typeof(int),
        typeof(MnemoAnimPatchList),
       new PropertyMetadata(0, ValuebitChanged));
        public int ObmenValue
        {
            get { return (int)GetValue(ObmenValueProperty); }
            set { SetValue(ObmenValueProperty, value); }
        }


        /*   public static readonly DependencyProperty LPatchProperty =
           DependencyProperty.Register("LPatch",
          typeof(Path),
          typeof(MnemoAnimPatchList),
         new PropertyMetadata());
          public Path LPatch
          {
              get { return (Path)GetValue(LPatchProperty); }
              set { SetValue(LPatchProperty, value); }
          }*/


        private void SetColor()
        {
            Brush _curBrush = this.PasivColor;
            BitPosValue _curBit = (BitPosValue)Enum.Parse(typeof(BitPosValue), ObmenValue.ToString());
            if (!ObmenPos.Equals(BitPosValue.None))
            {
                if (_curBit.HasFlag(ObmenPos))
                {
                    _curBrush = ActiveColor;
                }
                else
                    _curBrush = PasivColor;
            }

            if (!ObmenPos2bit.Equals(BitPosValue.None))
                if (_curBit.HasFlag(ObmenPos2bit))
                    _curBrush = AlternativeColor;

            MColor = _curBrush;

            if (_contur != null)
                SetStrokeContur();
            bool _corect = false;



            if (!LAnimateLine.Equals(BitPosValue.None))
            {
                if (_curBit.HasFlag(LAnimateLine))
                {
                    //this.StrokeAnim
                    // Binding myBinding = new Binding("StrokeAnimLeft");
                    //myBinding.Source = this;
                    //BindingOperations.SetBinding(pt, Path.StrokeDashOffsetProperty, myBinding);
                    CreateAnimation(true);
                    _corect = true;
                }


            }
            if (!RAnimateLine.Equals(BitPosValue.None))
            {
                if (_curBit.HasFlag(RAnimateLine))
                {

                    CreateAnimation(false);
                    _corect = true;
                }

            }
            if (!_corect)
            {
                StopAnimation();
                _corect = false;
            }




        }

        private void SetStrokeContur()
        {
            if (_contur != null)
                foreach (Path pt in _contur)
                {
                    if (pt != null)
                        pt.Stroke = MColor;
                }
        }

        private void CreateAnimation(bool LPriz)
        {



            double _from = -8;
            double _to = 0;
            Brush _br;
            Binding myBinding;
            // Binding myBinding = new Binding("StrokeDashOffset");
            // myBinding.Source = this.LPatch;
            if (LPriz)
            {
                _from = 0;
                _to = UIFrom;
                _br = this.LDrawing;

                myBinding = new Binding("StrokeAnimLeft");
                myBinding.Source = this;
                myBinding.Mode = BindingMode.OneWay;




            }
            else
            {
                _from = UIFrom;
                _to = 0;
                _br = this.RDrawing;
                myBinding = new Binding("StrokeAnimReiht");
                myBinding.Source = this;
                myBinding.Mode = BindingMode.OneWay;

            }



            if (AllAnimation)
            {

                DoubleAnimation anim = new DoubleAnimation(_from, _to, UIDuration);
                anim.RepeatBehavior = RepeatBehavior.Forever;
                foreach (Path pt in ListPath)
                {
                    pt.Stroke = _br;
                    pt.StrokeDashArray = this.UIStrokeDashArray;
                    pt.BeginAnimation(Path.StrokeDashOffsetProperty, anim);



                }
            }
            else
            {


                foreach (Path pt in ListPath)
                {
                    BindingOperations.ClearBinding(pt, Path.StrokeDashOffsetProperty);
                    pt.Stroke = _br;
                    pt.StrokeDashCap = this.UIStrokeDashCap;
                    pt.StrokeDashArray = this.UIStrokeDashArray;
                    BindingOperations.SetBinding(pt, Path.StrokeDashOffsetProperty, myBinding);
                }
            }



        }


        //свойство остановки анимации при пунктирной линии
        public bool SetPunktir { get; set; }
        private void StopAnimation()
        {
            DoubleCollection dc = new DoubleCollection();
           
            dc.Add(1);
            dc.Add(0);
          



            foreach (Path pt in ListPath)
            {
                pt.Stroke = MColor;
                if (!SetPunktir)
                pt.StrokeDashArray = dc;
                if (AllAnimation)
                    pt.BeginAnimation(Path.StrokeDashOffsetProperty, null);
                else
                    BindingOperations.ClearBinding(pt, Path.StrokeDashOffsetProperty);



            }
        }
        protected override void OnInitialized(EventArgs e)
        {
            /* base.OnInitialized(e);
             AddVisualPath();
             SetColor();*/
        }
        public override void EndInit()
        {
            base.EndInit();
            // AddConturPath();
            AddVisualPath();
            SetColor();
        }





    }
}
