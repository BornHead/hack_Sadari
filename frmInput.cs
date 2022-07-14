using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sadari
{
	/// <summary>
	/// frmInput에 대한 요약 설명입니다.
	/// </summary>
	public class frmInput : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.TextBox txtInput;
		internal System.Windows.Forms.Label lblStatus;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInput()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(219, 50);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "취소";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(219, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 25);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "확인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(9, 50);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(135, 21);
            this.txtInput.TabIndex = 5;
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 12);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Label1";
            // 
            // frmInput
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(292, 83);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblStatus);
            this.Name = "frmInput";
            this.Text = "입력";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (e.KeyChar == (char)13) // enterkey
            {
                SendKeys.Send("{TAB}");
            } 

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
