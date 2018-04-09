using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MUtilites
{
   public static class MatchGeometry
    {

       public static string MovePatch(string data, double mx, double my)
       {
           string separators = @"(?=[MZLHVCSQTAmzlhvcsqta])";
           var tokens = Regex.Split(data, separators).Where(t => !string.IsNullOrEmpty(t));
          string newparch = ""; 
           foreach (string remainingargs in tokens)
           {
               string argSeparators = @"[\s,]|(?=-)";
               var splitArgs = Regex
                 .Split(remainingargs, argSeparators)
                 .Where(t => !string.IsNullOrEmpty(t));
               
               List<string> st = splitArgs.ToList<string>();
               if (st.Count == 3)
               {                   
                   st[1] = (double.Parse(st[1], CultureInfo.InvariantCulture) + mx).ToString(CultureInfo.InvariantCulture);
                   st[2] = (double.Parse(st[2], CultureInfo.InvariantCulture) + my).ToString(CultureInfo.InvariantCulture);



               }

               for (int i = 0; i < st.Count; i++)
               {
                   if ((st.Count == 3) && (i == 1))
                       newparch += st[i] + ",";
                   else
                       newparch += st[i];
               }
           }
           return newparch;
       }
    }
}
