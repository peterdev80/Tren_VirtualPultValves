using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseType;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Data;
using System.Diagnostics;
using ValueModel.BaseModel;
using System.ComponentModel;

namespace WPFMnemoLibrary.Model
{
    public class MnemoValStateVar : VarClass
    {
        private List<BitPosValue> KeyBit;

        private ObservableCollection<MnemoValStateValue> _ValState;
       
        public ObservableCollection<MnemoValStateValue> ValState
        {
            get { return _ValState; }
            set
            {
                if (value == _ValState) return;
                _ValState = value;
            }
        }
        public static readonly DependencyProperty VaRStateProperty = DependencyProperty.Register(
            "VaRState", typeof(int), typeof(MnemoValStateVar), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender, OnVaRUpd));
        public int VaRState
        {
            get { return (int)GetValue(VaRStateProperty); }
            set { this.SetValue(VaRStateProperty, value); }
        }

      
        protected override void SetBinding(string varObmen, string varID)
        {


            VHBinding.StateBinding(this, MnemoValStateVar.VaRStateProperty,varObmen,varID);
        }
        public Brush PasivColor
        {

            set
            {
                if (value == ValState[0].PasivColor) return;
                foreach (MnemoValStateValue ts in ValState)
                    ts.PasivColor = value;
            }
        }
        public Brush ActivColor
        {

            set
            {
                if (value == ValState[0].ActivColor) return;
                foreach (MnemoValStateValue ts in ValState)
                    ts.ActivColor = value;
            }
        }
      
        public MnemoValStateVar(string varID)
            : base(varID)
        {
            
        }
        public MnemoValStateVar():this("Mnemo")
        {
          
            KeyBit = new List<BitPosValue>(){BitPosValue.key1,BitPosValue.key2,BitPosValue.key3,BitPosValue.key4,BitPosValue.key5
                ,BitPosValue.key6,BitPosValue.key7,BitPosValue.key8,BitPosValue.key9,BitPosValue.key10,BitPosValue.key11,BitPosValue.key12,
            BitPosValue.key13,BitPosValue.key14,BitPosValue.key15,BitPosValue.key16,BitPosValue.key17,BitPosValue.key18,BitPosValue.key19,
            BitPosValue.key20,BitPosValue.key21,BitPosValue.key22,BitPosValue.key23,BitPosValue.key24,BitPosValue.key25,BitPosValue.key26,
            BitPosValue.key27,BitPosValue.key28,BitPosValue.key29,BitPosValue.key30,BitPosValue.key31,BitPosValue.key32};

            _ValState = new ObservableCollection<MnemoValStateValue>();
            for (int i = 0; i < KeyBit.Count; i++) ValState.Add(new MnemoValStateValue());

        }


        private static void OnVaRUpd(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          
            
            MnemoValStateVar cls = d as MnemoValStateVar;
            if (cls.ValState != null)
            {
                for (int i = 0; i < cls.ValState.Count; i++)
                {


                    BitPosValue val = (BitPosValue)Enum.Parse(typeof(BitPosValue), ((uint)(int)e.NewValue).ToString());
                    if (val.HasFlag(cls.KeyBit[i])) cls.ValState[i].StateElement = true; else cls.ValState[i].StateElement = false;

                }
            }
#if DEBUG
             if (cls.ValState == null) Debug.WriteLine("WARNING незаплонированное изменение переменной");
#endif
        }
      






    }
}
