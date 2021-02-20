using Binarysharp.MemoryManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Binarysharp.MemoryManagement.Memory;
using System.Runtime.InteropServices;

namespace Unlocked
{
    public partial class mainForm : Form
    {
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        Process Roblox = null;
        int WrittenBytes, CurrentPID = 0;
        IntPtr Threadscheduler;
        int DelayOffset;
        public MemorySharp Sharp;
        Thread WatchThread = null;
        public mainForm()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
            MessageBox.Show("join the server: discord.gg/thVEBw4jWj", "made by cyclically");
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                activatedBox.Checked = !activatedBox.Checked;
            }
            base.WndProc(ref m);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            keybindBox.Items.Add(new { Text = "Tab", Value = Keys.Tab });
            keybindBox.Items.Add(new { Text = "Left Control", Value = Keys.LControlKey });
            keybindBox.Items.Add(new { Text = "Right Control", Value = Keys.RControlKey });
            keybindBox.Items.Add(new { Text = "Alt", Value = Keys.Alt });
            keybindBox.Items.Add(new { Text = "Caps Lock", Value = Keys.CapsLock });
            keybindBox.Items.Add(new { Text = "Page Up", Value = Keys.PageUp });
            keybindBox.Items.Add(new { Text = "Page Down", Value = Keys.PageDown });
            keybindBox.Items.Add(new { Text = "A", Value = Keys.A });
            keybindBox.Items.Add(new { Text = "B", Value = Keys.B });
            keybindBox.Items.Add(new { Text = "C", Value = Keys.C });
            keybindBox.Items.Add(new { Text = "D", Value = Keys.D });
            keybindBox.Items.Add(new { Text = "E", Value = Keys.E });
            keybindBox.Items.Add(new { Text = "F", Value = Keys.F });
            keybindBox.Items.Add(new { Text = "G", Value = Keys.G });
            keybindBox.Items.Add(new { Text = "H", Value = Keys.H });
            keybindBox.Items.Add(new { Text = "I", Value = Keys.I });
            keybindBox.Items.Add(new { Text = "J", Value = Keys.J });
            keybindBox.Items.Add(new { Text = "K", Value = Keys.K });
            keybindBox.Items.Add(new { Text = "L", Value = Keys.L });
            keybindBox.Items.Add(new { Text = "M", Value = Keys.M });
            keybindBox.Items.Add(new { Text = "N", Value = Keys.N });
            keybindBox.Items.Add(new { Text = "O", Value = Keys.O });
            keybindBox.Items.Add(new { Text = "P", Value = Keys.P });
            keybindBox.Items.Add(new { Text = "Q", Value = Keys.Q });
            keybindBox.Items.Add(new { Text = "R", Value = Keys.R });
            keybindBox.Items.Add(new { Text = "S", Value = Keys.S });
            keybindBox.Items.Add(new { Text = "T", Value = Keys.T });
            keybindBox.Items.Add(new { Text = "U", Value = Keys.U });
            keybindBox.Items.Add(new { Text = "V", Value = Keys.V });
            keybindBox.Items.Add(new { Text = "W", Value = Keys.W });
            keybindBox.Items.Add(new { Text = "X", Value = Keys.X });
            keybindBox.Items.Add(new { Text = "Y", Value = Keys.Y });
            keybindBox.Items.Add(new { Text = "Z", Value = Keys.Z });

            WatchThread = new Thread(new ThreadStart(WatchProcess));
            WatchThread.Start();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            setFPS(60);
            if (WatchThread != null)
            {
                WatchThread.Abort();
            }
        }

        private void fpsBox_ValueChanged(object sender, EventArgs e)
        {
            if (activatedBox.Checked)
            {
                setFPS((double)fpsBox.Value);
            }
        }

        private void keybindBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnregisterHotKey(this.Handle, 0);
            RegisterHotKey(this.Handle, 0, 0, (int)(keybindBox.SelectedItem as dynamic).Value);
        }

        private void activatedBox_CheckedChanged(object sender, EventArgs e)
        {
            if (activatedBox.Checked)
            {
                setFPS((double)fpsBox.Value);
            }
            else
            {
                setFPS(60);
            }
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
            Hide();
            hideIcon.ShowBalloonTip(5000);
        }

        private void hideIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        // main
        private void setFPS(double FPS)
        {
            if (Process.GetProcessesByName("RobloxPlayerBeta").Length > 0 && Process.GetProcessesByName("RobloxPlayerBeta").First().Id == CurrentPID)
            {
                WriteMemory<double>(Roblox.Handle, Threadscheduler + DelayOffset, 1.0 / FPS);
            }
        }   
        private void WatchProcess()
        {
            while (true)
            {
                var procs = Process.GetProcessesByName("RobloxPlayerBeta");
                if (procs.Length > 0 && procs.First().Id != CurrentPID)
                {
                    Roblox = procs.First();
                    CurrentPID = Roblox.Id;

                    Thread.Sleep(2000); // Delay

                    Sharp = new MemorySharp(Roblox);

                    SigScanSharp Sigscan = new SigScanSharp(Roblox.Handle);
                    Sigscan.SelectModule(Roblox.MainModule);

                    IntPtr GetThreadScheduler = traceRelativeCall(Roblox.Handle, (IntPtr)Sigscan.FindPattern("E8 ? ? ? ? 8A 4D 08 83 C0 04"));

                    Threadscheduler = new RemotePointer(Sharp, GetThreadScheduler).Execute<IntPtr>();
                    DelayOffset = FindTaskSchedulerFrameDelayOffset(Roblox.Handle, Threadscheduler);
                }
                Thread.Sleep(500);
            }
        }



        int FindTaskSchedulerFrameDelayOffset(IntPtr Handle, IntPtr scheduler) // Thanks to austin
        {
            for (int i = 0x100; i < 0x200; i += 4)
            {
                const double frame_delay = 1.0 / 60.0;
                double difference = ReadMemory<double>(Handle, scheduler + i) - frame_delay;
                difference = difference < 0 ? -difference : difference;
                if (difference < 0.004) return i;
            }
            return 0;
        }


        private IntPtr traceRelativeCall(IntPtr Handle, IntPtr call)
        {
            return IntPtr.Add(ReadMemory<IntPtr>(Handle, call + 1), (call.ToInt32() + 5));
        }

        public IntPtr Base(int Address)
        {
            return (IntPtr)((Address - 0x400000) + Roblox.MainModule.BaseAddress.ToInt32());
        }


        public void WriteMemory<T>(IntPtr Handle, IntPtr Address, object Value)
        {
            var buffer = StructureToByteArray(Value);

            WriteProcessMemory(Handle, Address, buffer, (uint)buffer.Length, ref WrittenBytes);
        }

        public T ReadMemory<T>(IntPtr Handle, IntPtr address) where T : struct
        {
            var ByteSize = Marshal.SizeOf(typeof(T));

            var buffer = new byte[ByteSize];

            ReadProcessMemory(Handle, address, buffer, buffer.Length, ref WrittenBytes);

            return ByteArrayToStructure<T>(buffer);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, ref int lpNumberOfBytesWritten);


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);


        private static byte[] StructureToByteArray(object obj)
        {
            var length = Marshal.SizeOf(obj);

            var array = new byte[length];

            var pointer = Marshal.AllocHGlobal(length);

            Marshal.StructureToPtr(obj, pointer, true);
            Marshal.Copy(pointer, array, 0, length);
            Marshal.FreeHGlobal(pointer);

            return array;
        }

        private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
        }
    }
}
