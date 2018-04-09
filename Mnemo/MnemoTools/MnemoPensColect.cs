using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using System.Windows.Resources;
using System.Windows;

namespace MnemoTools
{
    public class MnemoPensColect : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {


            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members
        private string FileName;
        private DataSourceResorcePen _ResourcePen;
        public DataSourceResorcePen ResourcePen
        {
            get { return _ResourcePen; }
            set { _ResourcePen = value; }
        }
       public MnemoPensColect()
       {
           _ResourcePen = new DataSourceResorcePen();  
       }

       public void LoadResource(string fileName)
       {

           Uri uri = new Uri(fileName, UriKind.RelativeOrAbsolute);
          
          
           XmlSerializer xmlFormat = new XmlSerializer(typeof(DataSourceResorcePen));
           using (Stream fstram = new GZipStream(Application.GetResourceStream(uri).Stream, CompressionMode.Decompress))
           {
               ResourcePen = (DataSourceResorcePen)xmlFormat.Deserialize(fstram);
           }
           ResourcePen.RebuildPen();
           ResourcePen.ReEventPen();
           FileName = fileName;
           
           /* XmlSerializer xmlFormat = new XmlSerializer(typeof(DataSourceResorcePen));
           using (Stream fstram = File.OpenRead(fileName))
           {
               ResourcePen = (DataSourceResorcePen)xmlFormat.Deserialize(fstram);
           }
           ResourcePen.RebuildPen();
           ResourcePen.ReEventPen();
           FileName = fileName;*/
        
       }
       public void SaveResource(string fileName)
       {

           XmlSerializer xmlFormat = new XmlSerializer(typeof(DataSourceResorcePen));
           using (Stream fstream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
           {
               xmlFormat.Serialize(fstream, ResourcePen);
           }
       }
       public void AdddAnim(MnemoAnimation am)
       {
           ResourcePen.AddAnim(am);
       }
       public void AddPen(MnemoPen pm)
       {
           ResourcePen.AddPen(pm);
       }

       public void ShowAnimEditor()
       {
           WindowToolAnim wta = new WindowToolAnim(this,FileName);
           wta.ShowDialog();
       }

    }
}
