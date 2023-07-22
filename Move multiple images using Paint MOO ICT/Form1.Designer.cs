namespace Move_multiple_images_using_Paint_MOO_ICT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            temporizador = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(250, 480);
            label1.Name = "label1";
            label1.Size = new Size(281, 55);
            label1.TabIndex = 0;
            label1.Text = "Naipe de 1 a 10";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // temporizador
            // 
            temporizador.Enabled = true;
            temporizador.Interval = 20;
            temporizador.Tick += FormTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(778, 544);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "Form1";
            ShowIcon = false;
            Text = "Mover imágenes múltiples";
            Paint += FormPaintEvent;
            MouseDown += FormMouseDown;
            MouseMove += FormMouseMove;
            MouseUp += FormMouseUp;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private System.Windows.Forms.Timer temporizador;
    }
}