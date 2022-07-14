using System;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Sadari
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnInit;
		internal System.Windows.Forms.PictureBox picUser;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.NumericUpDown nudSpeed;
		internal System.Windows.Forms.Button btnStart;
		internal System.Windows.Forms.Button btnReCreate;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.NumericUpDown nudUserCnt;
		internal System.Windows.Forms.Panel panMain;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		int[,] m_nSadari; //��ٸ� ���� ����
		int[,] m_nVisit; //�湮�� ������ ����
		int m_nSelUser; //������ ����

		Pen m_penSadari;
		Pen[] m_penVisit = new Pen[10];

		const int SADARI_WIDTH = 80; //��ٸ� ��ĭ �ʺ�
		const int START_X = 35; //x ������ġ
        private TextBox textBox1;
        const int START_Y = 30; //y ������ġ
		
		public frmMain()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent�� ȣ���� ���� ������ �ڵ带 �߰��մϴ�.
			//
		}

		//��==================================================================================================================================================��
		//��    ��  ��   ��   ��   ��   ��   ��   ��   ��   ��   ��    ��Ű�κ�  1   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   �� ��
		[DllImport("user32.dll")]
		public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, System.Windows.Forms.Keys vk);

		[DllImport("user32.dll")]
		public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		const int HOTKEY_ID = 31198; //Any number to use to identify the hotkey instance 
		public enum KeyModifiers
		{
			None = 0,
			Alt = 1,
			Control = 2,
			Shift = 4,
			Windows = 8
		}
		const int WM_HOTKEY = 0x0312;
		//��    ��  ��   ��   ��   ��   ��   ��   ��   ��   ��   ��    ��Ű�κ�  1   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   �� ��
		//��==================================================================================================================================================�� 
		 
		int cheat = -1;
		int cheat2 = 0;

		List<int> lotto = new List<int>();
		int iSelect;

		//��==================================================================================================================================================��
		//��    ��  ��   ��   ��   ��   ��   ��   ��   ��   ��   ��    ��Ű�κ�  2   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   �� ��
		protected override void WndProc(ref Message message)
		{
			switch (message.Msg)
			{
				case WM_HOTKEY:
					System.Windows.Forms.Keys key = (System.Windows.Forms.Keys)(((int)message.LParam >> 16) & 0xFFFF);
					KeyModifiers modifier = (KeyModifiers)((int)message.LParam & 0xFFFF);
					//if ((KeyModifiers.Control | KeyModifiers.Shift) == modifier && Keys.N == key)
					if (System.Windows.Forms.Keys.F1 == key)                                          //  F1 ��Ű
					{
						if (cheat != -1)
						{
							var tmp = string.Empty;
							while (true)
							{
								InitSadari_cheat();
								tmp = FindWay_cheat(cheat);
								if (tmp != "")
									break;
							}

                            //MakeLabel_cheat((int)nudUserCnt.Value);
                            picUser.Location = GetPos(0, 0);
							panMain.Invalidate();

							cheat = -1;
							cheat2 = cheat; 
						}
					}
					if (System.Windows.Forms.Keys.Enter == key)                                          //  F1 ��Ű
					{ 
					}
					if ((KeyModifiers.Control) == modifier && Keys.NumPad0 == key)                                                        //  F1 ��Ű
					{
						cheat = -1;
						cheat2 = cheat;
					}
					if ((KeyModifiers.Control) == modifier && Keys.NumPad1 == key)                                                        //  F1 ��Ű
					{
						cheat = 0;
						cheat2 = cheat;
						lotto.Add(0);
					}
					if ((KeyModifiers.Control) == modifier && Keys.NumPad2 == key)                                                        //  F1 ��Ű
					{
						cheat = 1;
						cheat2 = cheat;
						lotto.Add(1);
					}
					if ((KeyModifiers.Control) == modifier && Keys.NumPad3 == key)                                                        //  F1 ��Ű
					{
						cheat = 2;
						cheat2 = cheat;
						lotto.Add(2);
					}
					if ((KeyModifiers.Control) == modifier && Keys.NumPad4 == key)                                                        //  F1 ��Ű
					{
						cheat = 3;
						cheat2 = cheat;
						lotto.Add(3);
					}
					if ((KeyModifiers.Control) == modifier && Keys.NumPad5 == key)                                                        //  F1 ��Ű
					{
						cheat = 4;
						cheat2 = cheat;
						lotto.Add(4);
					}
					if ((KeyModifiers.Control) == modifier && Keys.NumPad6 == key)                                                        //  F1 ��Ű
					{
						cheat = 5;
						cheat2 = cheat;
						lotto.Add(5);
					}
					if ((KeyModifiers.Control) == modifier && Keys.NumPad7 == key)                                                        //  F1 ��Ű
					{
						cheat = 6;
						cheat2 = cheat;
						lotto.Add(6);
					}
					if ((KeyModifiers.Control) == modifier && Keys.NumPad8 == key)                                                        //  F1 ��Ű
					{
						cheat = 7;
						cheat2 = cheat;
						lotto.Add(7);
					}
					if ((KeyModifiers.Control) == modifier && Keys.NumPad9 == key)                                                        //  F1 ��Ű
					{
						cheat = 8;
						cheat2 = cheat;
						lotto.Add(8);
					}
					break;
			}
			base.WndProc(ref message);
		}
		//��    ��  ��   ��   ��   ��   ��   ��   ��   ��   ��   ��    ��Ű�κ�  2   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   �� ��
		//��==================================================================================================================================================��

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnInit = new System.Windows.Forms.Button();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReCreate = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.nudUserCnt = new System.Windows.Forms.NumericUpDown();
            this.panMain = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUserCnt)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(816, 310);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(80, 25);
            this.btnInit.TabIndex = 17;
            this.btnInit.Text = "�ʱ�ȭ";
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // picUser
            // 
            this.picUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picUser.Image = ((System.Drawing.Image)(resources.GetObject("picUser.Image")));
            this.picUser.Location = new System.Drawing.Point(816, 5);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(24, 24);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 16;
            this.picUser.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(816, 285);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(29, 12);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "�ӵ�";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(851, 280);
            this.nudSpeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(45, 21);
            this.nudSpeed.TabIndex = 14;
            this.nudSpeed.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(816, 340);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 25);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "����";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReCreate
            // 
            this.btnReCreate.Location = new System.Drawing.Point(816, 137);
            this.btnReCreate.Name = "btnReCreate";
            this.btnReCreate.Size = new System.Drawing.Size(80, 25);
            this.btnReCreate.TabIndex = 12;
            this.btnReCreate.Text = "�ٽø����";
            this.btnReCreate.Click += new System.EventHandler(this.btnReCreate_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(866, 112);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(29, 12);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "�ο�";
            // 
            // nudUserCnt
            // 
            this.nudUserCnt.Location = new System.Drawing.Point(816, 107);
            this.nudUserCnt.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudUserCnt.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudUserCnt.Name = "nudUserCnt";
            this.nudUserCnt.Size = new System.Drawing.Size(45, 21);
            this.nudUserCnt.TabIndex = 10;
            this.nudUserCnt.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudUserCnt.ValueChanged += new System.EventHandler(this.nudUserCnt_ValueChanged);
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panMain.Location = new System.Drawing.Point(5, 5);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(805, 360);
            this.panMain.TabIndex = 9;
            this.panMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panMain_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(905, 8);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 357);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "1.���ϸ��� �ϴ��� ��÷�� �� �Ѱ��� �����ּ���.\r\n\r\n2.�״��� �ٽø���� ��ư�� ������ �������� �����ּ���.\r\n\r\n3. ���ϴ� ��ȣ�� ������ " +
    "������ �����ָ� ��ٸ��� Ÿ���ϴ�.";
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1057, 373);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.nudSpeed);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnReCreate);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.nudUserCnt);
            this.Controls.Add(this.panMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "��ٸ� ~~";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUserCnt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}


		// ��ٸ� �ʱ�ȭ
		private void InitSadari()
		{
			MakeSadari((int)nudUserCnt.Value);

			//MakeLabel((int)nudUserCnt.Value);
			picUser.Location = GetPos(0, 0);
		}

		// ��ٸ� ����
		private void MakeSadari(int nUserCnt)
		{
			int i, j, k;

			m_nSadari = new int[nUserCnt, 100];
			m_nVisit = new int[nUserCnt, 100];

			// �켱 1�� ����(������)�Ѵ�.
			// ��湮(0)�� �����Ѵ�.
			for (i = 0; i < nUserCnt; i++)
			{
				for (j = 0; j < 100; j++)
				{
					m_nSadari[i, j] = 1;
					m_nVisit[i, j] = 0;
				}
			}

			// ������ �߻����� ������(2 ����)�� �����.
			// �ϳ��� �����ٿ� 7���� �������� �����.
			int nRnd;
			int nCnt;

			Random rnd = new Random();

			for (i = 0; i <= nUserCnt - 2; i++)
			{

				nCnt = 0;
				while (true)
				{
				AAA:
					nRnd = rnd.Next(4, 95); // 4 ���� 95 ���� ���ڸ� ����

					//�������� ����� �ִ� ������ �˻��Ѵ�.
					for (k = 0; k < 4; k++)
					{
						// ���Ʒ��� 3ĭ �˻�
						if (m_nSadari[i, nRnd + k] != 1 || m_nSadari[i, nRnd - k] != 1)
							goto AAA;
					}

					//������ ���
					nCnt += 1;
					m_nSadari[i, nRnd] = 2;//�˻��� �ڸ����� 2(���ʿ��� ������)�� ����
					m_nSadari[i + 1, nRnd] = 3; //�˻��� �ڸ��� ������ ������ 3(�����ʿ��� ����) ����

					if (nCnt >= 3)// 7�� ������ ���� ������.
						break;
				}
			}
		}

		// ��ٸ� �ʱ�ȭ
		private void InitSadari_cheat()
		{
			MakeSadari((int)nudUserCnt.Value);

		}

		//Label �����
		private void MakeLabel_cheat(int nUserCnt)
		{
			int i;

			// �켱 panMain�� ��� ��Ʈ���� �����Ѵ�.
			panMain.Controls.Clear();

			for (i = 0; i < nUserCnt; i++)
			{
				Label lbl1, lbl2;

				//���� label ����
				lbl1 = new Label();
				panMain.Controls.Add(lbl1);

				lbl1.Size = new Size(65, 20);
				lbl1.Location = new Point(5 + i * SADARI_WIDTH, 5);

				lbl1.Text = "��ȣ " + (i + 1).ToString();
				lbl1.Tag = "0" + i.ToString();

				lbl1.BorderStyle = BorderStyle.FixedSingle;
				lbl1.TextAlign = ContentAlignment.MiddleCenter;
				lbl1.BackColor = Color.WhiteSmoke;

				if (i == 0)// ���� ���� ǥ��
				{
					m_nSelUser = 0;
					lbl1.BackColor = Color.Yellow;
				}

				//�Ʒ� label ����
				lbl2 = new Label();
				panMain.Controls.Add(lbl2);

				lbl2.Size = new Size(65, 20);
				lbl2.Location = new Point(5 + i * SADARI_WIDTH, 305 + START_Y);

				lbl2.Text = "";
				lbl2.Tag = "1" + i.ToString();

				lbl2.BorderStyle = BorderStyle.FixedSingle;
				lbl2.TextAlign = ContentAlignment.MiddleCenter;
				lbl2.BackColor = Color.WhiteSmoke;

				// Ŭ��/����Ŭ�� �̺�Ʈ�� �����Ѵ�.
				// Ŭ��/����Ŭ�� �̺�Ʈ�� �����Ѵ�.
				lbl1.Click += new System.EventHandler(lbl_Click);
				lbl1.DoubleClick += new System.EventHandler(lbl_DClick);
				lbl2.DoubleClick += new System.EventHandler(lbl_DClick);
			}
		}

		//Label �����
		private void MakeLabel(int nUserCnt)
		{
			int i;

			// �켱 panMain�� ��� ��Ʈ���� �����Ѵ�.
			panMain.Controls.Clear();

			for (i = 0; i < nUserCnt; i++)
			{
				Label lbl1, lbl2;

				//���� label ����
				lbl1 = new Label();
				panMain.Controls.Add(lbl1);

				lbl1.Size = new Size(65, 20);
				lbl1.Location = new Point(5 + i * SADARI_WIDTH, 5);

				lbl1.Text = "��ȣ " + (i + 1).ToString();
				lbl1.Tag = "0" + i.ToString();

				lbl1.BorderStyle = BorderStyle.FixedSingle;
				lbl1.TextAlign = ContentAlignment.MiddleCenter;
				lbl1.BackColor = Color.WhiteSmoke;

				if (i == 0)// ���� ���� ǥ��
				{
					m_nSelUser = 0;
					lbl1.BackColor = Color.Yellow;
				}

				//�Ʒ� label ����
				lbl2 = new Label();
				panMain.Controls.Add(lbl2);

				lbl2.Size = new Size(65, 20);
				lbl2.Location = new Point(5 + i * SADARI_WIDTH, 305 + START_Y);

				lbl2.Text = "";
				lbl2.Tag = "1" + i.ToString();

				lbl2.BorderStyle = BorderStyle.FixedSingle;
				lbl2.TextAlign = ContentAlignment.MiddleCenter;
				lbl2.BackColor = Color.WhiteSmoke;

				// Ŭ��/����Ŭ�� �̺�Ʈ�� �����Ѵ�.
				// Ŭ��/����Ŭ�� �̺�Ʈ�� �����Ѵ�.
				lbl1.Click += new System.EventHandler(lbl_Click);
				lbl1.DoubleClick += new System.EventHandler(lbl_DClick);
				lbl2.DoubleClick += new System.EventHandler(lbl_DClick);
			}
		}

		// Tag ���� �̿��� ���ϴ� Label ��Ʈ���� ��´�.
		private Label GetLblCtrl(String strTag)
		{
			int i;

			for(i = 0 ; i < panMain.Controls.Count ; i++)
			{
				if (panMain.Controls[i].Tag.ToString().Equals(strTag))
					return (Label)panMain.Controls[i];
			}

			return null;
		}

		// �̵��� ���� ã�´�.
		private void FindWay(int nStartX)
		{
			int i, j = 0, k = 0;
			Point pos1, pos2;
			i = nStartX;

			while (true)
			{
				m_nVisit[i, j] = m_nSelUser + 1;
				picUser.Location = GetPos(i, j); // ���� ��ǥ�� �°� �������� �̵���Ų��.
				if (m_nSadari[i, j] == 1)  // 1�� ��쿣 ��� �������� Ÿ�� ��������.
					j += 1;
				else if (m_nSadari[i, j] == 2)//2�� ��쿣 ������ �����ٷ� �̵��Ѵ�.
				{
					pos1 = GetPos(i, j); // ���� ��ǥ�� ���Ѵ�.
					i += 1; // �������� �ű��
					m_nVisit[i, j] = m_nSelUser + 1; // �湮 ǥ�ø� �Ѵ�.
					pos2 = GetPos(i, j); // �ű� ��ǥ�� ���Ѵ�.

					for (k = pos1.X; k <= pos2.X; k += 10)// �������� ���� �̵��� �����ش�.
					{
						//Application.DoEvents();
						//Thread.Sleep(50 - (int)nudSpeed.Value);
						picUser.Location = new Point(k, pos1.Y);
					}
					j += 1;
				}
				else if (m_nSadari[i, j] == 3) //3�� ��쿣 ���� �����ٷ� �̵��Ѵ�.
				{
					pos2 = GetPos(i, j);
					i -= 1;
					pos1 = GetPos(i, j);
					m_nVisit[i, j] = m_nSelUser + 1;

					for (k = pos2.X; k >= pos1.X; k -= 10)
					{
						//Application.DoEvents();
						//Thread.Sleep(50 - (int)nudSpeed.Value);
						picUser.Location = new Point(k, pos1.Y);
					}
					j += 1;
				}
				//Application.DoEvents();
				//Thread.Sleep(50 - (int)nudSpeed.Value);

				if (j >= 99) break; // �̵� ��
			}
			try
			{
				// ����� �޽��� �ڽ��� ���
				String strUser, strResult;

				strUser = GetLblCtrl("0" + m_nSelUser.ToString()).Text;
				strResult = GetLblCtrl("1" + i.ToString()).Text;

				if (strResult == "")
					strResult = "��!";
				else
					strResult = "��ó�����!! " + strResult;
				MessageBox.Show(strUser + " : " + strResult);
			}
			catch { }
		}


		// �̵��� ���� ã�´�.
		private string FindWay_cheat(int nStartX)
		{
			int i, j = 0, k = 0;
			Point pos1, pos2;
			i = nStartX;

			while (true)
			{  
				if (m_nSadari[i, j] == 1)  // 1�� ��쿣 ��� �������� Ÿ�� ��������.
					j += 1;
				else if (m_nSadari[i, j] == 2)//2�� ��쿣 ������ �����ٷ� �̵��Ѵ�.
				{
					pos1 = GetPos(i, j); // ���� ��ǥ�� ���Ѵ�.
					i += 1; // �������� �ű�� 
					pos2 = GetPos(i, j); // �ű� ��ǥ�� ���Ѵ�.
					 
					j += 1;
				}
				else if (m_nSadari[i, j] == 3) //3�� ��쿣 ���� �����ٷ� �̵��Ѵ�.
				{
					pos2 = GetPos(i, j);
					i -= 1;
					pos1 = GetPos(i, j); 
					 
					j += 1;
				}
				//Application.DoEvents();
				//Thread.Sleep(50 - (int)nudSpeed.Value);

				if (j >= 99) break; // �̵� ��
			}
			try
			{
				// ����� �޽��� �ڽ��� ���
				String strUser, strResult;

				strUser = GetLblCtrl("0" + m_nSelUser.ToString()).Text;
				strResult = GetLblCtrl("1" + i.ToString()).Text;

				return strResult;
			}
			catch { }
			return null;
		}

		// X, Y �� �´� ��ǥ�� ��´�.
		private Point GetPos(int nX, int nY)
		{
			return new Point(nX * SADARI_WIDTH + START_X - 10, nY * 3 + START_Y - 10);
		}
		
		
		
		// �� �ε�
		private void frmMain_Load(object sender, System.EventArgs e)
		{

			//��==================================================================================================================================================��
			//��    ��  ��   ��   ��   ��   ��   ��   ��   ��   ��   ��    ��Ű�κ�  3   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   ��   �� ��
			RegisterHotKey(this.Handle, HOTKEY_ID, 0x0, System.Windows.Forms.Keys.F1);
			RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control, Keys.NumPad0); // shift + A  
			RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control, Keys.NumPad1); // shift + A  
			RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control, Keys.NumPad2); // shift + A  
			RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control, Keys.NumPad3); // shift + A  
			RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control, Keys.NumPad4); // shift + A  
			RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control, Keys.NumPad5); // shift + A  
			RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control, Keys.NumPad6); // shift + A  
			RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control, Keys.NumPad7); // shift + A  
			RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control, Keys.NumPad8); // shift + A  
			RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control, Keys.NumPad9); // shift + A  
																						//RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control | KeyModifiers.Shift, Keys.N);    // Hotkeyset ��Ű���� [ Ư��Ű 0x0�� �Է¾ȹ޴»��� ]
																						//UnregisterHotKey(this.Handle, HOTKEY_ID);                                                     // Hotkeyset ��Ű���� [ HOTKEY_ID ��ȣ�� ��Ű ���� ]

			// �� ����
			m_penSadari = new Pen(Color.Blue, 3);

			m_penVisit[0] = new Pen(Color.FromArgb(255, 0, 0), 3);
			m_penVisit[1] = new Pen(Color.FromArgb(0, 255, 0), 3);
			m_penVisit[2] = new Pen(Color.FromArgb(255, 0, 255), 3);
			m_penVisit[3] = new Pen(Color.FromArgb(255, 255, 0), 3);
			m_penVisit[4] = new Pen(Color.FromArgb(0, 255, 255), 3);
			m_penVisit[5] = new Pen(Color.FromArgb(125, 125, 125), 3);
			m_penVisit[6] = new Pen(Color.FromArgb(188, 127, 157), 3);
			m_penVisit[7] = new Pen(Color.FromArgb(82, 71, 21), 3);
			m_penVisit[8] = new Pen(Color.FromArgb(184, 92, 48), 3);
			m_penVisit[9] = new Pen(Color.FromArgb(25, 145, 69), 3);

			InitSadari();
			MakeLabel((int)nudUserCnt.Value);
			panMain.Invalidate();
		}

		// �������� ������ ��Ʈ���� Ŭ�� �̺�Ʈ
		private void lbl_Click(object sender, System.EventArgs e)
		{
			// ���� ���õ� ���� ������ WhiteSmoke(���� �ȵ� ����)�� �����.

			Label lbl;

			lbl = GetLblCtrl("0" + m_nSelUser);
			lbl.BackColor = Color.WhiteSmoke;

			// ������ ���� ������ Yellow�� ����� �����Ѵ�.
			String strTag;
			((Label)sender).BackColor = Color.Yellow;
			strTag = ((Label)sender).Tag.ToString();
			m_nSelUser = Convert.ToInt32(strTag.Substring(1, 1));
			picUser.Location = GetPos(m_nSelUser, 0);
		}

		frmInput frm = new frmInput();
		//�������� ������ ��Ʈ���� ����Ŭ�� �̺�Ʈ
		private void lbl_DClick(object sender, System.EventArgs e)
		{
			frm = new frmInput();
			String strTag;
			strTag = ((Label)sender).Tag.ToString();

			if (strTag.Substring(0, 1) == "0")//����ڸ� ����Ŭ���� ���
			{
				frm.Text = "����� �Է�";
				frm.lblStatus.Text = "������� �̸��� �Է��ϼ���";
			}
			else
			{
				frm.Text = "���� �Է�";
				frm.lblStatus.Text = "������ �Է��ϼ���";
			}

			Console.WriteLine(frm.Controls.Find("txtInput", false)[0].Focused);
			if (frm.ShowDialog(this) == DialogResult.OK)
				((Label)sender).Text = frm.txtInput.Text;
		}

		//�ٽø����
		private void btnReCreate_Click(object sender, System.EventArgs e)
		{
			//InitSadari();
			//panMain.Invalidate();

			if (cheat != -1)
			{
				var tmp = string.Empty;
				while (true)
				{
					InitSadari_cheat();
					tmp = FindWay_cheat(cheat);
					if (tmp != "")
						break;
				}

				//MakeLabel_cheat((int)nudUserCnt.Value);
				picUser.Location = GetPos(0, 0);
				panMain.Invalidate();

				//cheat = -1;
				//cheat2 = cheat;
				nudSpeed.Value = 500;
			}
			else
			{
                InitSadari();
                panMain.Invalidate();
                nudSpeed.Value = 50;
			}
		}

		private void btnInit_Click(object sender, System.EventArgs e)
		{
			int i, j;

			// �湮 ǥ�ø� ��� 0����
			for(i = 0 ; i < nudUserCnt.Value ; i++)
			{
				for(j = 0 ; j< 100 ; j++)
					m_nVisit[i, j] = 0;
            
			}

			// ȭ���� �ٽ� �׷��ش�.
			panMain.Invalidate();
		}

		//��ٸ� ����
		private void btnStart_Click(object sender, System.EventArgs e)
		{

			FindWay(m_nSelUser);
		}

		// �ο뺯ȭ
		private void nudUserCnt_ValueChanged(object sender, System.EventArgs e)
		{
			InitSadari();
			MakeLabel((int)nudUserCnt.Value);
			panMain.Invalidate();

		}

		// ��ٸ� �׸���
		private void panMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			int i, j;
			int x1, y1, x2, y2;

			for(i = 0 ; i < (int)nudUserCnt.Value ; i++)
			{
				for(j = 0 ; j < 100 ; j++)
				{
					// ������ �׸���
					if (m_nSadari[i, j] == 2)
					{
						// ��ǥ ���
						x1 = i * SADARI_WIDTH + START_X;
						y1 = START_Y + j * 3;
						x2 = i * SADARI_WIDTH + START_X + SADARI_WIDTH;
						y2 = START_Y + j * 3;

						try
						{
							if (m_nVisit[i, j] != 0)
								e.Graphics.DrawLine(m_penVisit[m_nVisit[i, j] - 1], x1, y1, x2, y2);
							else
								e.Graphics.DrawLine(m_penSadari, x1, y1, x2, y2);
						}
						catch { }
					}
                
					//������(�׸���)
					if (j != 99)
					{
						// ��ǥ���
						x1 = i * SADARI_WIDTH + START_X;
						y1 = START_Y + j * 3 - 1;
						x2 = i * SADARI_WIDTH + START_X;
						y2 = START_Y + (j + 1) * 3;

						try
						{
							if (m_nVisit[i, j] != 0)
								e.Graphics.DrawLine(m_penVisit[m_nVisit[i, j] - 1], x1, y1, x2, y2);
							else
								e.Graphics.DrawLine(m_penSadari, x1, y1, x2, y2);
						}
						catch { }
					}
				}

			}

		}

	}
}
