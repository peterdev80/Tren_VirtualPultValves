using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using System.Windows;

namespace PatchMnemoLib.ViewModel
{
   public class LoaderClass
    {
       public delegate Stream LoadData(string fname);
       public static LoadData LoadFromResource
       {
          get
          {
               //return p => Application.GetResourceStream(new Uri(p, UriKind.RelativeOrAbsolute)).Stream;
              return
                  p =>
                  new GZipStream(Application.GetResourceStream(new Uri(p, UriKind.RelativeOrAbsolute)).Stream,
                      CompressionMode.Decompress);
          }
       }
       public static void LoadResource<T>(LoadData dat, out T Seriaz, string fname) where T : class
       {
          
          
           try
           {
               
               XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
               using (Stream fstram = dat(fname))
               {
                   Seriaz= xmlFormat.Deserialize(fstram) as T;
               }

              

           }
           catch
           {

               throw new Exception(String.Format("File {0} not Found",fname));
           }

       }

    }











}
