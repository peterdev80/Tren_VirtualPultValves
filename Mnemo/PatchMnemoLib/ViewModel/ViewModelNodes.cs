using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Windows.Media;

namespace PatchMnemoLib.ViewModel
{
    public class ViewModelNodes:ViewModelBase
    {
        private Nodes Node;
        public List<String> NodesPen
        {
            get { return Node.NodesPen; }
            set {
                Node.NodesPen = value;
                OnPropertyChanged("NodesPen");
                BuildPen(Node.NodesPen);

            
            }
        }
        private List<Pen> MPen = new List<Pen>();
        private void BuildPen(List<string> strls)
        {
            foreach (string st in strls)
                MPen.Add(viewModelMnemoAnimPen.Instance.GetPen(st));
        }
    }
}
