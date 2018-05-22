using PatchMnemoLib.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Xml;
using ValueModel.BaseModel;

namespace WPFMnemoLibrary.Model
{
   public class LinkInpuLinux
    {
        const int LINVAR = 28;

        private static volatile LinkInpuLinux instance;
        String s_ipadress;
        int udpSendtoModel;
        int udpRecivetoKlapan;
        public static LinkInpuLinux Instance
        {
            get
            {
                if (instance == null)
                    instance = new LinkInpuLinux();

                return instance;
            }
        }

        private void findFile()
        {
            return;

            if (File.Exists("initIO.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("initIO.xml");
                foreach (XmlNode node in doc.DocumentElement)
                {

                    s_ipadress = node["ip"].InnerText;
                    udpSendtoModel = int.Parse(node["Send_to_Model"].InnerText);
                    udpRecivetoKlapan = int.Parse(node["Recive_to_Klapan"].InnerText);

                }
            }
            else
            {
                MessageBox.Show("Файл initIO.xml не найден");
            }
        }

        void StartRecive()
        {
            ThreadPool.QueueUserWorkItem(Receive);


        }
        public LinkInpuLinux()
        {
           
            findFile();

          
            StartRecive();
          



        }


        UdpClient udp = new UdpClient();
        bool stopReceive = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Receive(Object stateInfo)
        {
          //  MessageBox.Show("Paket in");

            try
            {      




                // MessageBox.Show("Start Recive");
                // Перед созданием нового объекта закрываем старый
                // для освобождения занятых ресурсов.

                if (udp != null) udp.Close();
                
                udp = new UdpClient(udpRecivetoKlapan);

                while (true)
                {
  
                    IPEndPoint ipendpoint = null;
                    byte[] message = udp.Receive(ref ipendpoint);
                    
                   
                   
                    if (BitConverter.ToUInt32(message, 0) == 2500)
                    {
                        var val = ViewModelVariableList.Instance;
                        var d = ((BitIntVar)val.GetVariable("__UKDU_1").VarM).Dispatcher;
                         //чтение и запиь сразу
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__UKDU_1").VarM).VarBitInt = BitConverter.ToInt32(message, 1 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__UKDU_2").VarM).VarBitInt = BitConverter.ToInt32(message, 2 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__MNEMO_RES_4").VarM).VarBitInt = BitConverter.ToInt32(message, 3 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__MNEMO_RES_6").VarM).VarBitInt = BitConverter.ToInt32(message, 4 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__UKDU_3").VarM).VarBitInt = BitConverter.ToInt32(message, 5 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__SEP_1").VarM).VarBitInt = BitConverter.ToInt32(message, 6 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__SEP_2").VarM).VarBitInt = BitConverter.ToInt32(message, 7 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__SEP_3").VarM).VarBitInt = BitConverter.ToInt32(message, 8 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__SEP_5").VarM).VarBitInt = BitConverter.ToInt32(message, 9 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__SEP_6").VarM).VaRStatefloat = BitConverter.ToSingle(message, 10 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__SEP_7").VarM).VaRStatefloat = BitConverter.ToSingle(message, 11 * 4)));
                        // rd.ReadUInt32();12
                        //  rd.ReadUInt32();13
                        d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__SEP_10").VarM).VaRStatefloat = BitConverter.ToSingle(message, 14 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__SOTR_1").VarM).VarBitInt = BitConverter.ToInt32(message, 15 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__SOTR_2").VarM).VarBitInt = BitConverter.ToInt32(message, 16 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__SOTR_3").VarM).VarBitInt = BitConverter.ToInt32(message, 17 * 4))); ;
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__SOTR_4").VarM).VarBitInt = BitConverter.ToInt32(message, 18 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__MNEMO_RES_5").VarM).VarBitInt = BitConverter.ToInt32(message, 19 * 4)));
                     //   ((BitIntVar)val.GetVariable("__SOTR_5").VarM).Dispatcher.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__SOTR_5").VarM).VarBitInt = BitConverter.ToInt32(message, 20 * 4)));
                      d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__SOTR_6").VarM).VaRStatefloat = BitConverter.ToSingle(message, 21 * 4)));
                      d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__SOTR_7").VarM).VaRStatefloat = BitConverter.ToSingle(message, 22 * 4)));
                      d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__SOTR_8").VarM).VaRStatefloat = BitConverter.ToSingle(message, 23 * 4)));
                      d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__SOTR_9").VarM).VaRStatefloat = BitConverter.ToSingle(message, 24 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__SOTR_10").VarM).VaRStatefloat = BitConverter.ToSingle(message, 25 * 4)));
                        //  rd.ReadUInt32();26
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__SOTR_12").VarM).VaRStatefloat = BitConverter.ToSingle(message, 27 * 4)));
                      

                        //  rd.ReadUInt32(); 28
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__KDU_1").VarM).VarBitInt = BitConverter.ToInt32(message, 29 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__KDU_2").VarM).VarBitInt = BitConverter.ToInt32(message, 30 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__KDU_3").VarM).VarBitInt = BitConverter.ToInt32(message, 31 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__KDU_4").VarM).VarBitInt = BitConverter.ToInt32(message, 32 * 4)));
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__KDU_5").VarM).VarBitInt = BitConverter.ToInt32(message, 33 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__MNEMO_RES_51").VarM).VarBitInt = BitConverter.ToInt32(message, 34 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_7").VarM).VaRStatefloat = BitConverter.ToSingle(message, 35 * 4)));
                     d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_8").VarM).VaRStatefloat = BitConverter.ToSingle(message, 36 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_15").VarM).VaRStatefloat = BitConverter.ToSingle(message, 37 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_16").VarM).VaRStatefloat = BitConverter.ToSingle(message, 38 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_17").VarM).VaRStatefloat = BitConverter.ToSingle(message, 39 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_18").VarM).VaRStatefloat = BitConverter.ToSingle(message, 40 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_9").VarM).VaRStatefloat = BitConverter.ToSingle(message, 41 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_10").VarM).VaRStatefloat = BitConverter.ToSingle(message, 42 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_13").VarM).VaRStatefloat = BitConverter.ToSingle(message, 43 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_14").VarM).VaRStatefloat = BitConverter.ToSingle(message, 44 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_11").VarM).VaRStatefloat = BitConverter.ToSingle(message, 45 * 4)));
                       d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__KDU_12").VarM).VaRStatefloat = BitConverter.ToSingle(message, 46 * 4)));
                       
                       d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__KDU_MS1").VarM).VarBitInt = BitConverter.ToInt32(message, 47 * 4)));
                        //отвод подвод
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__PTVOD_PODVOD_1").VarM).VarBitInt = BitConverter.ToInt32(message, 48 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__PTVOD_PODVOD_2").VarM).VarBitInt = BitConverter.ToInt32(message, 49 * 4)));
                        //питание ссвп
                       // d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__PTVOD_PODVOD_1").VarM).VarBitInt = BitConverter.ToInt32(message, 50 * 4)));
                       // d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__PTVOD_PODVOD_2").VarM).VarBitInt = BitConverter.ToInt32(message, 51 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__PitSSWP_1").VarM).VarBitInt = BitConverter.ToInt32(message, 50 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__PitSSWP_2").VarM).VarBitInt = BitConverter.ToInt32(message, 51 * 4)));

                        //nadduv

                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__OK39_ND_1").VarM).VarBitInt = BitConverter.ToInt32(message, 52 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__OK39_ND_2").VarM).VarBitInt = BitConverter.ToInt32(message, 53 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__OK39_ND_3").VarM).VarBitInt = BitConverter.ToInt32(message, 54 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__OK39_ND_4").VarM).VarBitInt = BitConverter.ToInt32(message, 55 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__OK39_ND_5").VarM).VarBitInt = BitConverter.ToInt32(message, 56 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__OK39_ND_6").VarM).VarBitInt = BitConverter.ToInt32(message, 57 * 4)));

                        //PR12
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__PR12_MC_F").VarM).VarBitInt = BitConverter.ToInt32(message, 58 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__PR12_MC_1").VarM).VarBitInt = BitConverter.ToInt32(message, 59 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__PR12_MC_2").VarM).VarBitInt = BitConverter.ToInt32(message, 60 * 4)));
                        d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__PR12_MC_3").VarM).VaRStatefloat = BitConverter.ToSingle(message, 61 * 4)));
                        //управление переменными
                        d.Invoke(new Action(() => ((IntVar)val.GetVariable("__select_MFL").VarM).VaRStateInt = BitConverter.ToInt32(message, 62 * 4)));
                        //PR12 add
                        d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__PR12_MC_4").VarM).VaRStatefloat = BitConverter.ToSingle(message, 63 * 4)));
                        //std
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__STD_1").VarM).VarBitInt = BitConverter.ToInt32(message, 64 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__STD_2").VarM).VarBitInt = BitConverter.ToInt32(message, 65 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__MNEMO_RES_52").VarM).VarBitInt = BitConverter.ToInt32(message, 66 * 4)));

                        //sr
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__URO_1").VarM).VarBitInt = BitConverter.ToInt32(message, 67 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__URO_2").VarM).VarBitInt = BitConverter.ToInt32(message, 68 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__URO_3").VarM).VarBitInt = BitConverter.ToInt32(message, 69 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__URO_4").VarM).VarBitInt = BitConverter.ToInt32(message, 70 * 4)));
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__URO_5").VarM).VarBitInt = BitConverter.ToInt32(message, 71 * 4)));
                        //PitSSwp add
                        d.Invoke(new Action(() => ((FloatVar)val.GetVariable("__PIT_SSWP").VarM).VaRStatefloat = BitConverter.ToSingle(message, 72 * 4)));
                        //sr add rez
                        d.Invoke(new Action(() => ((BitIntVar)val.GetVariable("__URO_6").VarM).VarBitInt = BitConverter.ToInt32(message, 73 * 4)));
                        //переменные мнемосхем
                        // Если дана команда остановить поток, останавливаем бесконечный цикл.
                        if (stopReceive == true) break;

                        
                    }
                  
                    
                }
               udp.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Main EROR _ " + e.Message);
            }
        }

    }
          
}

