using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MorseTranslator
{
	public class Form1 : Form
	{
		internal struct INPUT
		{
			public uint Type;

			public MOUSEKEYBDHARDWAREINPUT Data;
		}

		[StructLayout(LayoutKind.Explicit)]
		internal struct MOUSEKEYBDHARDWAREINPUT
		{
			[FieldOffset(0)]
			public HARDWAREINPUT Hardware;

			[FieldOffset(0)]
			public KEYBDINPUT Keyboard;

			[FieldOffset(0)]
			public MOUSEINPUT Mouse;
		}

		internal struct HARDWAREINPUT
		{
			public uint Msg;

			public ushort ParamL;

			public ushort ParamH;
		}

		internal struct KEYBDINPUT
		{
			public ushort Vk;

			public ushort Scan;

			public uint Flags;

			public uint Time;

			public IntPtr ExtraInfo;
		}

		internal struct MOUSEINPUT
		{
			public int X;

			public int Y;

			public uint MouseData;

			public uint Flags;

			public uint Time;

			public IntPtr ExtraInfo;
		}

		public enum KeyCode : ushort
		{
			MEDIA_NEXT_TRACK = 176,
			MEDIA_PLAY_PAUSE = 179,
			MEDIA_PREV_TRACK = 177,
			MEDIA_STOP = 178,
			ADD = 107,
			MULTIPLY = 106,
			DIVIDE = 111,
			SUBTRACT = 109,
			BROWSER_BACK = 166,
			BROWSER_FAVORITES = 171,
			BROWSER_FORWARD = 167,
			BROWSER_HOME = 172,
			BROWSER_REFRESH = 168,
			BROWSER_SEARCH = 170,
			BROWSER_STOP = 169,
			NUMPAD0 = 96,
			NUMPAD1 = 97,
			NUMPAD2 = 98,
			NUMPAD3 = 99,
			NUMPAD4 = 100,
			NUMPAD5 = 101,
			NUMPAD6 = 102,
			NUMPAD7 = 103,
			NUMPAD8 = 104,
			NUMPAD9 = 105,
			F1 = 112,
			F10 = 121,
			F11 = 122,
			F12 = 123,
			F13 = 124,
			F14 = 125,
			F15 = 126,
			F16 = 0x7F,
			F17 = 0x80,
			F18 = 129,
			F19 = 130,
			F2 = 113,
			F20 = 131,
			F21 = 132,
			F22 = 133,
			F23 = 134,
			F24 = 135,
			F3 = 114,
			F4 = 115,
			F5 = 116,
			F6 = 117,
			F7 = 118,
			F8 = 119,
			F9 = 120,
			OEM_1 = 186,
			OEM_102 = 226,
			OEM_2 = 191,
			OEM_3 = 192,
			OEM_4 = 219,
			OEM_5 = 220,
			OEM_6 = 221,
			OEM_7 = 222,
			OEM_8 = 223,
			OEM_CLEAR = 254,
			OEM_COMMA = 188,
			OEM_MINUS = 189,
			OEM_PERIOD = 190,
			OEM_PLUS = 187,
			KEY_0 = 48,
			KEY_1 = 49,
			KEY_2 = 50,
			KEY_3 = 51,
			KEY_4 = 52,
			KEY_5 = 53,
			KEY_6 = 54,
			KEY_7 = 55,
			KEY_8 = 56,
			KEY_9 = 57,
			KEY_A = 65,
			KEY_B = 66,
			KEY_C = 67,
			KEY_D = 68,
			KEY_E = 69,
			KEY_F = 70,
			KEY_G = 71,
			KEY_H = 72,
			KEY_I = 73,
			KEY_J = 74,
			KEY_K = 75,
			KEY_L = 76,
			KEY_M = 77,
			KEY_N = 78,
			KEY_O = 79,
			KEY_P = 80,
			KEY_Q = 81,
			KEY_R = 82,
			KEY_S = 83,
			KEY_T = 84,
			KEY_U = 85,
			KEY_V = 86,
			KEY_W = 87,
			KEY_X = 88,
			KEY_Y = 89,
			KEY_Z = 90,
			VOLUME_DOWN = 174,
			VOLUME_MUTE = 173,
			VOLUME_UP = 175,
			SNAPSHOT = 44,
			RightClick = 93,
			BACKSPACE = 8,
			CANCEL = 3,
			CAPS_LOCK = 20,
			CONTROL = 17,
			ALT = 18,
			DECIMAL = 110,
			DELETE = 46,
			DOWN = 40,
			END = 35,
			ESC = 27,
			HOME = 36,
			INSERT = 45,
			LAUNCH_APP1 = 182,
			LAUNCH_APP2 = 183,
			LAUNCH_MAIL = 180,
			LAUNCH_MEDIA_SELECT = 181,
			LCONTROL = 162,
			LEFT = 37,
			LSHIFT = 160,
			LWIN = 91,
			PAGEDOWN = 34,
			NUMLOCK = 144,
			PAGE_UP = 33,
			RCONTROL = 163,
			ENTER = 13,
			RIGHT = 39,
			RSHIFT = 161,
			RWIN = 92,
			SHIFT = 0x10,
			SPACE_BAR = 0x20,
			TAB = 9,
			UP = 38
		}

		private IContainer components = null;

		private Button button1;

		private TextBox textBox1;

		private Timer timer1;

		private Label label1;

		private Label label2;

		private NumericUpDown numericUpDown1;

		private Dictionary<string, string> map = new Dictionary<string, string>();

		private int timerCountdown;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				((IDisposable)components).Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0354: Unknown result type (might be due to invalid IL or missing references)
			//IL_035e: Expected O, but got Unknown
			components = (IContainer)new Container();
			ComponentResourceManager val = new ComponentResourceManager(typeof(Form1));
			button1 = new Button();
			textBox1 = new TextBox();
			timer1 = new Timer(components);
			label1 = new Label();
			label2 = new Label();
			numericUpDown1 = new NumericUpDown();
			((ISupportInitialize)numericUpDown1).BeginInit();
			((Control)this).SuspendLayout();
			((Control)button1).set_Location(new Point(0, 86));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(286, 80));
			((Control)button1).set_TabIndex(0);
			((Control)button1).set_Text("yaz");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click);
			((Control)textBox1).set_Location(new Point(0, 0));
			((TextBoxBase)textBox1).set_Multiline(true);
			((Control)textBox1).set_Name("textBox1");
			((Control)textBox1).set_Size(new Size(286, 59));
			((Control)textBox1).set_TabIndex(1);
			timer1.add_Tick((EventHandler)timer1_Tick);
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(-3, 67));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(57, 13));
			((Control)label1).set_TabIndex(2);
			((Control)label1).set_Text("Geri Sayım");
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(122, 67));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(10, 13));
			((Control)label2).set_TabIndex(3);
			((Control)label2).set_Text("-");
			((Control)numericUpDown1).set_Location(new Point(226, 65));
			((Control)numericUpDown1).set_Name("numericUpDown1");
			((Control)numericUpDown1).set_Size(new Size(60, 20));
			((Control)numericUpDown1).set_TabIndex(5);
			numericUpDown1.set_Value(new decimal(new int[4]
			{
				20,
				0,
				0,
				0
			}));
			numericUpDown1.add_ValueChanged((EventHandler)numericUpDown1_ValueChanged);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_AutoSizeMode((AutoSizeMode)0);
			((Form)this).set_ClientSize(new Size(287, 166));
			((Control)this).get_Controls().Add((Control)(object)numericUpDown1);
			((Control)this).get_Controls().Add((Control)(object)label2);
			((Control)this).get_Controls().Add((Control)(object)label1);
			((Control)this).get_Controls().Add((Control)(object)textBox1);
			((Control)this).get_Controls().Add((Control)(object)button1);
			((Form)this).set_Icon((Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Control)this).set_Name("Form1");
			((Control)this).set_Text("MorseTranslator");
			((Form)this).add_Load((EventHandler)Form1_Load);
			((ISupportInitialize)numericUpDown1).EndInit();
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}

		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

		public static void SendKeyPress(KeyCode keyCode)
		{
			INPUT iNPUT = default(INPUT);
			iNPUT.Type = 1u;
			INPUT iNPUT2 = iNPUT;
			iNPUT2.Data.Keyboard = new KEYBDINPUT
			{
				Vk = (ushort)keyCode,
				Scan = 0,
				Flags = 0u,
				Time = 0u,
				ExtraInfo = IntPtr.Zero
			};
			INPUT iNPUT3 = default(INPUT);
			iNPUT3.Type = 1u;
			INPUT iNPUT4 = iNPUT3;
			iNPUT4.Data.Keyboard = new KEYBDINPUT
			{
				Vk = (ushort)keyCode,
				Scan = 0,
				Flags = 2u,
				Time = 0u,
				ExtraInfo = IntPtr.Zero
			};
			INPUT[] inputs = new INPUT[2]
			{
				iNPUT2,
				iNPUT4
			};
			if (SendInput(2u, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
			{
				throw new Exception();
			}
		}

		public static void SendKeyDown(KeyCode keyCode)
		{
			INPUT iNPUT = default(INPUT);
			iNPUT.Type = 1u;
			INPUT iNPUT2 = iNPUT;
			iNPUT2.Data.Keyboard = default(KEYBDINPUT);
			iNPUT2.Data.Keyboard.Vk = (ushort)keyCode;
			iNPUT2.Data.Keyboard.Scan = 0;
			iNPUT2.Data.Keyboard.Flags = 0u;
			iNPUT2.Data.Keyboard.Time = 0u;
			iNPUT2.Data.Keyboard.ExtraInfo = IntPtr.Zero;
			INPUT[] inputs = new INPUT[1]
			{
				iNPUT2
			};
			if (SendInput(1u, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
			{
				throw new Exception();
			}
		}

		public static void SendKeyUp(KeyCode keyCode)
		{
			INPUT iNPUT = default(INPUT);
			iNPUT.Type = 1u;
			INPUT iNPUT2 = iNPUT;
			iNPUT2.Data.Keyboard = default(KEYBDINPUT);
			iNPUT2.Data.Keyboard.Vk = (ushort)keyCode;
			iNPUT2.Data.Keyboard.Scan = 0;
			iNPUT2.Data.Keyboard.Flags = 2u;
			iNPUT2.Data.Keyboard.Time = 0u;
			iNPUT2.Data.Keyboard.ExtraInfo = IntPtr.Zero;
			INPUT[] inputs = new INPUT[1]
			{
				iNPUT2
			};
			if (SendInput(1u, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
			{
				throw new Exception();
			}
		}

		public Form1()
			: this()
		{
			InitializeComponent();
			map.Add("a", ".-");
			map.Add("b", "-...");
			map.Add("c", "-.-.");
			map.Add("d", "-..");
			map.Add("e", ".");
			map.Add("f", "..-.");
			map.Add("g", "--.");
			map.Add("h", "....");
			map.Add("i", "..");
			map.Add("j", ".---");
			map.Add("k", "-.-");
			map.Add("l", ".-..");
			map.Add("m", "--");
			map.Add("n", "-.");
			map.Add("o", "---");
			map.Add("p", ".--.");
			map.Add("q", "--.-");
			map.Add("r", ".-.");
			map.Add("s", "...");
			map.Add("t", "-");
			map.Add("u", "..-");
			map.Add("v", "...-");
			map.Add("w", ".--");
			map.Add("x", "-..-");
			map.Add("y", "-.--");
			map.Add("z", "--..");
			map.Add("0", "-----");
			map.Add("1", ".----");
			map.Add("2", "..---");
			map.Add("3", "...--");
			map.Add("5", ".....");
			map.Add("6", "-....");
			map.Add("7", "--...");
			map.Add("8", "---..");
			map.Add("9", "----.");
			map.Add(".", ".-.-.-");
			map.Add(",", "--..--");
			map.Add(":", "---...");
			map.Add("?", "..--..");
			map.Add("'", ".----.");
			map.Add("-", "-....-");
			map.Add("/", "-..-.");
			map.Add("@", ".--.-.");
			map.Add("=", "-...-");
			map.Add("!", "---.");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			timer1.set_Enabled(true);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			timerCountdown = Convert.ToInt32(Math.Round(numericUpDown1.get_Value(), 0));
		}

		private void sendCustomKey(bool isLong)
		{
			if (isLong)
			{
				SendKeyDown(KeyCode.SPACE_BAR);
				Thread.Sleep(400);
				SendKeyUp(KeyCode.SPACE_BAR);
				Thread.Sleep(120);
			}
			else
			{
				SendKeyDown(KeyCode.SPACE_BAR);
				Thread.Sleep(130);
				SendKeyUp(KeyCode.SPACE_BAR);
				Thread.Sleep(150);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (timerCountdown == 0)
			{
				for (int i = 0; i < ((Control)textBox1).get_Text().Length; i++)
				{
					string text = ((Control)textBox1).get_Text().Substring(i, 1).ToLower();
					if (map.ContainsKey(text))
					{
						string text2 = map[text];
						for (int j = 0; j < text2.Length; j++)
						{
							string a = map[text].Substring(j, 1);
							if (a == ".")
							{
								sendCustomKey(isLong: false);
							}
							else if (a == "-")
							{
								sendCustomKey(isLong: true);
							}
						}
						Thread.Sleep(250);
					}
					else if (text == " ")
					{
						Thread.Sleep(500);
					}
				}
				timer1.set_Enabled(false);
				timerCountdown = Convert.ToInt32(Math.Round(numericUpDown1.get_Value(), 0));
			}
			else
			{
				timerCountdown--;
			}
			((Control)label2).set_Text(timerCountdown.ToString());
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			timerCountdown = Convert.ToInt32(Math.Round(numericUpDown1.get_Value(), 0));
			if (!timer1.get_Enabled())
			{
				((Control)label2).set_Text(timerCountdown.ToString());
			}
		}
	}
}
