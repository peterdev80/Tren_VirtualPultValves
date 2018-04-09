using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Windows.Media.Animation;
using System.Windows;

namespace PatchMnemoLib.ViewModel
{
    public class ViewModelAnimation : ViewModelBase
    {
        private GraphicsAnimation ganim;
        public GraphicsAnimation Model
        {
            get { return ganim; }
        }
        public ViewModelAnimation()
        {
            ganim =new GraphicsAnimation();

        }

        public ViewModelAnimation(GraphicsAnimation _ganim)
        {
            ganim = _ganim;
            CreateAnimation();

        }
        private DoubleAnimation _AnimationS;

        public DoubleAnimation AnimationS
        {
            get { return _AnimationS; }
        }

        public String Name
        {
            get { return ganim.Name; }
            set
            {
                ganim.Name = value;
                OnPropertyChanged("Name");
                CreateAnimation();
            }
        }
        public double ToValue
        {
            get { return ganim.ToValue; }
            set
            {

                ganim.ToValue = value;
                OnPropertyChanged("ToValue");
                CreateAnimation();
            }
        }
        public Double Dooration
        {
            get { return  ganim.Dooration; }
            set 
            {
                
                 ganim.Dooration = value;
                 OnPropertyChanged("Dooration");
                CreateAnimation();
            }
        }
        public double To
        {
            get { return ganim.To; }
            set 
            {                
               ganim.To = value;
               OnPropertyChanged("To");
                CreateAnimation();
            }
        }
        public double By
        {
            get { return ganim.By; }
            set 
            {
                
                ganim.By = value;
                OnPropertyChanged("By");
                CreateAnimation();
            }
        }


          private void CreateAnimation()
        {
            _AnimationS = new DoubleAnimation(To,ToValue, new Duration(TimeSpan.FromSeconds(Dooration)));
            _AnimationS.RepeatBehavior = RepeatBehavior.Forever;           
            _AnimationS.By = By;
            Timeline.SetDesiredFrameRate(_AnimationS, 30);
            OnPropertyChanged("AnimationS");
        }
        
    }
}
