using BLEConsole;
using CommonLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using static CommonLib.PlumpDeviceStatusStruct;

namespace STSFWTestTool
{
    public partial class frmMain : Form
    {
        BaseDevice pd;
       

        [System.Runtime.InteropServices.DllImport("kernel32")]
        extern static UInt64 GetTickCount64();

        private UInt64 samplingStartTime = 0;
        private UInt64 samplesReceived = 0;

        private int fastFps, slowFps;
        public List<SamplesObj> lastVec;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ble.GetBLE.StartBleScan();
            
            cmbxFreePorts.SelectedItem = null;
            cmbxFreePorts.SelectedText = "--select--";
            CreateGraph(zedGraphControl, "Samples");

            if (radioBtnSerial.Checked)
                UpdateCurrentAvailableProts();
            else
                UpdateCurrentAvailableDevices();

            lblStatus.Text = String.Empty;

            Text = "STS Tech tool: v" + Application.ProductVersion;
        }

        private double cnt = 0;

        int SAMPLES_SHOWN = 3000;
        const int SAMPLE_TYPE_MULTIPLIER = 1;

        private ESampleType lastType;

        private void pd_OnNewData(PlumpDeviceStatusStruct obj, double avg)
        {
            this.InvokeIfRequired(() =>
            {
                if (obj.SampleType == ESampleType.FreeSampling)
                    lblAvg.Text = $"{(int)avg}";

                if ((obj.SampleType == ESampleType.PreRecording) && (obj.SampleCounter == 0))
                {
                    // clean graphs on acquire
                    zedGraphControl.GraphPane.CurveList[0].Clear();
                    zedGraphControl.GraphPane.CurveList[1].Clear();

                    cnt = 0;
                }
                else
                {
                    // clean gas temp graph
                    while ((zedGraphControl.GraphPane.CurveList[0].Points.Count + obj.NumOfSamples) > SAMPLES_SHOWN)
                    {
                        zedGraphControl.GraphPane.CurveList[0].RemovePoint(0);
                    }

                    // clean sample type graph
                    while (zedGraphControl.GraphPane.CurveList[1].Points.Count > 0)
                    {
                        if (zedGraphControl.GraphPane.CurveList[1].Points[0].X < zedGraphControl.GraphPane.CurveList[0].Points[0].X)
                            zedGraphControl.GraphPane.CurveList[1].RemovePoint(0);
                        else
                            break;
                    }
                }

                // update sample type graph
                if (obj.NumOfSamples > 0)
                {
                    if (lastType == 0 && obj.SampleType > 0)
                    {
                        lastType = obj.SampleType;
                        // clear Graphs, started active phase.
                        zedGraphControl.GraphPane.CurveList[0].Clear();
                        zedGraphControl.GraphPane.CurveList[1].Clear();
                    }
                    zedGraphControl.GraphPane.CurveList[1].AddPoint(cnt, (int)obj.SampleType * SAMPLE_TYPE_MULTIPLIER);
                    lblPhase.Text = PlumpDeviceStatusStruct.BuildPhaseText(obj.SampleType);
                    if (obj.SampleType > ESampleType.PreRecording && obj.SampleType < ESampleType.EndRecording)
                        lblPhase.BackColor = Color.Yellow;
                    else
                        lblPhase.BackColor = SystemColors.Control;

                    if (obj.SampleType == ESampleType.EndRecording)
                    {
                        SaveToFile(pd.SessionSamplesList);
                        lastVec = new List<SamplesObj>();
                        lastVec?.AddRange(pd.SessionSamplesList);

                        //pd.ClearSessionSamplesList();
                    }
                }

                // update pressure
                for (int i = 0; i < obj.NumOfSamples; i++)
                {
                    // assume cnt is in ms;
                    zedGraphControl.GraphPane.CurveList[0].AddPoint(cnt, obj.Samples[i]);

                    cnt += ClaclTimeInterval(obj.SampleType);
                    //zedGraphControl.GraphPane.CurveList[0].AddPoint(cnt++, obj.Samples[i]);
                }

                // update type graph
                if (obj.NumOfSamples > 1)
                    zedGraphControl.GraphPane.CurveList[1].AddPoint(cnt - 1, (int)obj.SampleType * SAMPLE_TYPE_MULTIPLIER);

                // show updated graphs
                zedGraphControl.AxisChange();
                zedGraphControl.Invalidate();

                // update statistics
                if (samplingStartTime == 0)
                {
                    samplesReceived = 0;
                    samplingStartTime = GetTickCount64();
                }
                else
                {
                    samplesReceived += obj.NumOfSamples;
                    UInt64 now = GetTickCount64(), rate;
                    now -= samplingStartTime;
                    if (now != 0)
                    {
                        rate = (samplesReceived * 1000) / now;
                        String msg = String.Format("Rate: {0} samples/sec", rate);
                        lblStatus.Text = msg;
                    }
                }
            });
        }

        private void SaveToFile(List<SamplesObj> sessionSamplesList, string fileName = @"rec.csv")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Raw,Avg,Lpf");

            foreach (var d in sessionSamplesList)
                sb.AppendLine($"{d.Raw},{d.RunAvg},{d.Lpf}");

            File.WriteAllText(fileName, sb.ToString());
        }

        /*private void SaveToFile(List<short> sessionSamplesList, string fileName = @"rec.csv")
        {
            StringBuilder sb = new StringBuilder();

            foreach (var d in sessionSamplesList)            
                sb.AppendLine($"{d}");
                        
            File.WriteAllText(fileName, sb.ToString());
        }*/

        private double ClaclTimeInterval(ESampleType objSampleType)
        {
            switch (objSampleType)
            {

                case ESampleType.FreeSampling:
                    return 1;
                case ESampleType.PreRecording:
                    return 1;
                case ESampleType.RecordingMaxFreqPosMax:
                case ESampleType.RecordingMaxFreqPosMin:
                case ESampleType.RecordingMaxFreqTillMax:
                    return 1000.0 / fastFps;
                case ESampleType.RecoringTrailSlowFreq:
                    return 1000.0 / slowFps;
                case ESampleType.EndRecording:
                    return 1;
            }

            return 1;
        }

        private void pd_ConnectionFailed()
        {
            this.InvokeIfRequired(() =>
            {
                lblStatus.Text = "Status: Failed";
            });
        }

        private void pd_ConnectedSuccessfully()
        {
            this.InvokeIfRequired(() =>
            {
                lblStatus.Text = "Status: Connected";
                btnConnect.Text = "Disconnect";
                groupBox1.Enabled = true;

                // TODO: try to get the calib file name and load automatically
            });
        }

        private void pd_Disconnected()
        {
            this.InvokeIfRequired(() =>
            {
                lblStatus.Text = "Status: Disconnected";
                btnConnect.Text = "Connect";
                groupBox1.Enabled = false;
            });
        }

        private void UpdateCurrentAvailableProts()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            cmbxFreePorts.Items.Clear();
            foreach (string port in ports)
                cmbxFreePorts.Items.Add(port);

            if (cmbxFreePorts.Items.Count > 0)
                cmbxFreePorts.SelectedIndex = 0;

        }

        private void UpdateCurrentAvailableDevices()
        {
            List<string> allBleDevicesName = new List<string>();
            for(int i = 0; i < Ble.GetBLE.KnownDevices.Count; i++)
                allBleDevicesName.Add(Ble.GetBLE.KnownDevices[i].Name);

            cmbxFreePorts.Items.Clear();
            foreach (string device in allBleDevicesName)
                cmbxFreePorts.Items.Add(device);

            if (cmbxFreePorts.Items.Count > 0)
                cmbxFreePorts.SelectedIndex = 0;
        }

        private void cmbxFreePorts_DropDown(object sender, EventArgs e)
        {
            if(radioBtnSerial.Checked)
                UpdateCurrentAvailableProts();
            else
                UpdateCurrentAvailableDevices();
        }

        private void cmbxFreePorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnect.Enabled = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(radioBtnSerial.Checked)
                pd = new PlumpDeviceSerial();
            else
                pd = new PlumpDeviceBlueTooth();

            pd.ConnectedSuccessfully += pd_ConnectedSuccessfully;
            pd.ConnectionFailed += pd_ConnectionFailed;
            pd.Disconnected += pd_Disconnected;
            pd.OnNewData += pd_OnNewData;

            if (cmbxFreePorts.SelectedItem != null)
                pd.Init(cmbxFreePorts.SelectedItem.ToString());
            else if (radioBtnBlueTooth.Checked)
                pd.Init(cmbxFreePorts.SelectedItem.ToString());
        }

        private void CreateGraph(ZedGraphControl zgc, string title)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = title;

            myPane.XAxis.Title.Text = "Time";
            myPane.XAxis.Type = AxisType.Linear;
            myPane.XAxis.Scale.MinAuto = true;
            myPane.XAxis.Scale.MajorStepAuto = true;
            myPane.XAxis.Scale.MaxAuto = true;

            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MajorStepAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.YAxis.Title.Text = "Samples";

            int y2idx = myPane.AddYAxis("Phase");
            myPane.YAxisList[y2idx].Scale.Max = 10;
            myPane.YAxisList[y2idx].Scale.Min = 0;
            myPane.YAxisList[y2idx].Scale.MinAuto = true;
            myPane.YAxisList[y2idx].Scale.MaxAuto = true;
            myPane.YAxisList[y2idx].IsVisible = true;

            var c1 = myPane.AddCurve("Lung ", new PointPairList(), Color.Red, SymbolType.None);
            c1.YAxisIndex = 0;

            var c2 = myPane.AddCurve("Phase ", new PointPairList(), Color.Blue, SymbolType.None);
            c2.YAxisIndex = 1;

            myPane.Chart.Fill.Color = System.Drawing.Color.Gray;
            myPane.Fill.Color = System.Drawing.Color.LightGray;

            zgc.AxisChange();
            zgc.Refresh();

        }

        private void btnStartCommand_Click(object sender, EventArgs e)
        {
            samplingStartTime = 0;
            SAMPLES_SHOWN = 3000;

            pd.Lpf = (double)numLpf.Value;

            pd.SendStartCommandMessage((int)nudFreq.Value);
        }

        private void btnStopCommand_Click(object sender, EventArgs e)
        {
            pd.SendStopCommandMessage();
            samplingStartTime = 0;
            // save to file!
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveToFile(pd.SessionSamplesList, saveFileDialog1.FileName);
            }

            ucCalibPanel1.SetVector(pd.SessionSamplesList);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(pd != null)
                pd.SendStopCommandMessage();

            Ble.DisconnectBLE();
        }

        //int TEST_DURATION = 6;
        private void btnAcquireCommand_Click(object sender, EventArgs e)
        {
            lastType = 0;
            slowFps = fastFps = (int)fastFreq.Value;
            //slowFps = (int)fastFreq.Value;// (int)slowFreq.Value;
            int TEST_DURATION = (int)fastDur.Value;
            SAMPLES_SHOWN = fastFps * TEST_DURATION /*(int) fastDur.Value + slowFps * (int) slowDur.Value*/ + 1000;

            pd.ClearSessionSamplesList();

            pd.SendAcquireCommandMessage(
                fastFps, TEST_DURATION,
                slowFps, 0,
                (int)rawThresh.Value,  (int)nudMinTrsh.Value
                );
        }

        private void buttonShutterOpen_Click(object sender, EventArgs e)
        {
            pd.SendShutterOpenMessage();
        }

        private void buttonShutterClose_Click(object sender, EventArgs e)
        {
            pd.SendShutterCloseMessage();
        }

        private void zedGraphControl_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            zedGraphControl.GraphPane.CurveList[0].Clear();
            zedGraphControl.GraphPane.CurveList[1].Clear();
            zedGraphControl.AxisChange();
            zedGraphControl.Refresh();

        }

        private void comboBoxInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioBtnBlueTooth.Checked)
            {
                cmbxFreePorts.SelectedItem = "";
                btnConnect.Enabled = true;
            }
        }

        private void radioBtnBlueTooth_CheckedChanged(object sender, EventArgs e)
        {
            Ble.GetBLE.StartBleScan();
        }

        private void radioBtnSerial_CheckedChanged(object sender, EventArgs e)
        {
            Ble.GetBLE.StopBleScan();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ucCalibPanel1_Load(object sender, EventArgs e)
        {

        }

        private void btnDoCalc_Click(object sender, EventArgs e)
        {
            if (lastVec?.Count == 0)
                return;

            DoCalCForm dcf = new DoCalCForm();
            
            dcf.SetVctor(lastVec, pd != null?pd.SolenoidTime:-1);
            dcf.SetFreq((int)fastFreq.Value);

            //dcf.LoadPressure(zedGraphControl.GraphPane.CurveList[0].GetXAxis);
            dcf.ShowDialog();
        }
    }
}
