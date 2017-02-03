namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ClickMeBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MaintextBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SlavetextBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ClickMeBtn
            // 
            this.ClickMeBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ClickMeBtn.Location = new System.Drawing.Point(148, 22);
            this.ClickMeBtn.Name = "ClickMeBtn";
            this.ClickMeBtn.Size = new System.Drawing.Size(75, 23);
            this.ClickMeBtn.TabIndex = 0;
            this.ClickMeBtn.Text = "点击我";
            this.ClickMeBtn.UseVisualStyleBackColor = true;
            this.ClickMeBtn.Click += new System.EventHandler(this.ClickMeBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(22, 63);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(328, 165);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "主线程ID为";
            // 
            // MaintextBox1
            // 
            this.MaintextBox1.Location = new System.Drawing.Point(177, 269);
            this.MaintextBox1.Name = "MaintextBox1";
            this.MaintextBox1.Size = new System.Drawing.Size(100, 21);
            this.MaintextBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "运行异步方法的线程ID为";
            // 
            // SlavetextBox2
            // 
            this.SlavetextBox2.Location = new System.Drawing.Point(177, 325);
            this.SlavetextBox2.Name = "SlavetextBox2";
            this.SlavetextBox2.Size = new System.Drawing.Size(100, 21);
            this.SlavetextBox2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 368);
            this.Controls.Add(this.SlavetextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaintextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ClickMeBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClickMeBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MaintextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SlavetextBox2;
    }
}

