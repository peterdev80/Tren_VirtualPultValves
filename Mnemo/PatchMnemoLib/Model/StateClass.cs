
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Diagnostics;

namespace PatchMnemoLib.Model
{
    public interface IStates
    {
        void AddState(string NodeName, int MaxSitutation, IProp atribute);
        void RemoveState(string NodeName);
        StateGraphic GetState();
    }
    public abstract class StateGraphic : IComparable<StateGraphic>
    {
        public String NodeName { get; set; }
        public int Situtation { get; set; }
        public bool SitutationActive { get; set; }
        

        int IComparable<StateGraphic>.CompareTo(StateGraphic other)
        {
            int sumOther = other.Situtation;
            int sumThis = this.Situtation;
            if (!other.SitutationActive) sumOther = -1;
            if (!this.SitutationActive) sumThis = -1;

            if (sumOther > sumThis)
                return -1;
            else if (sumOther == sumThis)
                return 0;
            else
                return 1;
        }


    }
    public class StatePatch : StateGraphic
    {
       
      
       public Pen MPen { get; set; }
      
       
       public StatePatch(string nam, Pen pen, int prior)
       {
           NodeName = nam;
           MPen = pen;
           Situtation = prior;
           //Debug.WriteLine(String.Format("Create StateClass {0}, Prioritet={1}, Active={2}", NodeName, Situtation, SitutationActive));

       }

        
      
    }
    public class StatesPatch : IStates
   {
       private List<StatePatch> _lst = new List<StatePatch>();
       

       public StatesPatch()
       {
          
       }
      
       /// <summary>
       /// Добовляем элемент в новый маршрут
       /// </summary>
       /// <param name="NameState">имя маршрута</param>
       /// <param name="priormax">сколько состояний имеет маршрут</param>
       /// <param name="pl">список кистей для каждого состояния от 0-диактив и до максимального </param>
       public void AddState(string NameState, int priormax, IProp _pc)
       {
           var pc = (PropClass)_pc;

           if (pc.pl.Count!=(priormax)) new Exception("Нет соответсвия пен и состояний");
           for (int i=0;i<priormax;i++)
               _lst.Add(new StatePatch(NameState, pc.pl[i], i));
       }
       public void AddState(StatePatch val)
       {
           _lst.Add(val);
       }
       public void RemoveState(StatePatch val)
       {
           _lst.Remove(val);
          
       }
       public void ReplaceStatePen(string NameState,int situtax, Pen val)
       {
           List<StatePatch> lst = _lst.FindAll(delegate(StatePatch sc) { return ((sc.NodeName == NameState) && (sc.Situtation == situtax)); });

           if (lst.Count > 0)
               lst[0].MPen = val;
           else
              new Exception("Нет такого состояния");

       }
       public void RemoveState(string NameState)
       {
           List<StatePatch> lst = _lst.FindAll(delegate(StatePatch sc) { return (sc.NodeName == NameState); });
           foreach (StatePatch st in lst)
           {
               _lst.Remove(st);

           }

       }
     
       /// <summary>
       /// возвращает StatePatch
       /// </summary>
       /// <returns></returns>
       public StateGraphic GetState()
       {
           StateGraphic st = _lst.Max<StateGraphic>();
          // if (st!=null)
         //  Debug.WriteLine(String.Format("GetClass {0}, Prioritet={1}, Active={2}", st.NodeName, st.Situtation, st.SitutationActive));
           
           return st;
       }
       public StatePatch StateG
       {
           get { return (StatePatch)GetState(); }
       }
       public void SetState(int val, string Mname)
       {


        //  List< StatePatch> lst = _lst.FindAll(delegate(StatePatch sc) { return (sc.NodeName == Mname) ; });
          foreach (StatePatch st in _lst)
          {
              if (st.NodeName == Mname)
              {
                  st.SitutationActive = false;
                  if (st.Situtation == val) st.SitutationActive = true;
              }

          }



       }

       

   }
}
