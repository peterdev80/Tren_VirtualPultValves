using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Serialization;

namespace PatchMnemoLib.Model
{
      [Serializable]
    public abstract class VisualBase : DrawingVisual
    {
          private double _TransX;
          private double _TransY;
          private double _RotateAngle;
          private double _ScaleX;
          private double _ScaleY;
          private double _CentrX;
          private double _CentrY;
          private TranslateTransform _tt=new TranslateTransform(0,0);
          private ScaleTransform _st=new ScaleTransform(0,0);
          private RotateTransform _rt=new RotateTransform(0);
          protected List<Transform> lstTransf=new List<Transform>();

          public VisualBase()
          {
              ReDrawType = false;
             // graphicsBrush = Brushes.Transparent;
          }
          /// <summary>
          /// Цвет пера риссования
          /// </summary>
          [XmlIgnore]
          public Pen graphicsPen { get; set; }

          /*[XmlIgnore]
          public Brush graphicsBrush { get; set; }*/
       /// <summary>
       /// Свойство возвращающие объект для сохранения/чтения
       /// </summary>
       /// <returns></returns>
          public abstract PropertiesGraphicsBase CreateSerializedObject();
        
          /// <summary>
          /// Имя примитива
          /// </summary>
          public string Name { get; set; }
          public bool ReDrawType { get; set; }
          #region Position Transform
          public double TransX
          {
              get { return _TransX; }
              set
              {
                  _TransX = value;
                  _tt = new TranslateTransform(_TransX, _TransY);
                  TransformCompile();
                 
              }
          }
          public double TransY
          {
              get { return _TransY; }
              set {
                  _TransY = value; 
                  _tt = new TranslateTransform(_TransX, _TransY);
                  TransformCompile(); 
                 
              }
          }
          public double RotateAngle
          {
              get { return _RotateAngle; }
              set 
              {
                  _RotateAngle = value;
                  _rt = new RotateTransform(_RotateAngle, _CentrX, _CentrY);
                  TransformCompile(); 
                 
              }
          }
          public double ScaleX
          {
              get { return _ScaleX; }
              set
              {
                  _ScaleX = value;
                  _st = new ScaleTransform(_ScaleX, _ScaleY, _CentrX, _CentrY);
                  TransformCompile(); 
                 
              }
          }
          public double ScaleY 
          {
              get { return _ScaleY; }
              set {
                  _ScaleY = value;
                  _st = new ScaleTransform(_ScaleX, _ScaleY, _CentrX, _CentrY); 
                  TransformCompile();
                
              }
          }
          public double CentrX
          {
              get { return _CentrX; } 
              set 
              {
                  _CentrX = value;
                  _rt = new RotateTransform(_RotateAngle, _CentrX, _CentrY);
                  _st = new ScaleTransform(_ScaleX, _ScaleY, _CentrX, _CentrY);
                  TransformCompile(); 
                 
              }
          }
          public double CentrY 
          { 
              get 
              { 
                  return _CentrY; 
              } 
              set 
              { 
                  _CentrY = value; 
                  _rt = new RotateTransform(_RotateAngle, _CentrX, _CentrY);
                  _st = new ScaleTransform(_ScaleX, _ScaleY, _CentrX, _CentrY);
                  TransformCompile();
                 
              }
          }


          //Создание трансформации
           private void TransformCompile()
           {
               lstTransf = new List<Transform>();
               if (_st.ScaleX != 0 || _st.ScaleY != 0) lstTransf.Add(_st);
               if (_rt.Angle != 0) lstTransf.Add(_rt);
               if (_tt.X != 0 || _tt.Y != 0) lstTransf.Add(_tt);

           }

          #endregion
        
          /// <summary>
          /// Отрисовка конкретного элемента
          /// </summary>
          public abstract void Draw();   
          /// <summary>
          /// Индентификатор примитива
          /// </summary>
           public abstract int TVisual { get; }

    }
}
