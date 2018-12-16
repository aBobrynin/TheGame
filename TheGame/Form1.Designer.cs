namespace TheGame
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gl = new OpenTK.GLControl();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mtimer = new System.Windows.Forms.Timer(this.components);
            this.lrtimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gl
            // 
            this.gl.BackColor = System.Drawing.Color.Black;
            this.gl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gl.Location = new System.Drawing.Point(0, 0);
            this.gl.Name = "gl";
            this.gl.Size = new System.Drawing.Size(686, 620);
            this.gl.TabIndex = 0;
            this.gl.VSync = false;
            this.gl.Load += new System.EventHandler(this.gl_Load);
            this.gl.Paint += new System.Windows.Forms.PaintEventHandler(this.gl_Paint);
            this.gl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gl_KeyDown);
            // 
            // timer
            // 
            this.timer.Interval = 40;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // mtimer
            // 
            this.mtimer.Enabled = true;
            this.mtimer.Interval = 36;
            this.mtimer.Tick += new System.EventHandler(this.mtimer_Tick);
            // 
            // lrtimer
            // 
            this.lrtimer.Interval = 1;
            this.lrtimer.Tick += new System.EventHandler(this.lrtimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheGame.Properties.Resources.GameOver;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(686, 620);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 620);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl gl;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer mtimer;
        private System.Windows.Forms.Timer lrtimer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

