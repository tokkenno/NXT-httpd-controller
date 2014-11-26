namespace NXTRemoteSC
{
    partial class fPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbRemoteControl = new System.Windows.Forms.GroupBox();
            this.bParar = new System.Windows.Forms.Button();
            this.bDerecha = new System.Windows.Forms.Button();
            this.bIzquierda = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bStop = new System.Windows.Forms.Button();
            this.tbAcce = new System.Windows.Forms.TrackBar();
            this.tbCOM = new System.Windows.Forms.TextBox();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.tbHttpPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bIDAndroid = new System.Windows.Forms.Button();
            this.bIDHTTP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bConectar = new System.Windows.Forms.Button();
            this.gbRemoteControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAcce)).BeginInit();
            this.gbAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRemoteControl
            // 
            this.gbRemoteControl.Controls.Add(this.bParar);
            this.gbRemoteControl.Controls.Add(this.bDerecha);
            this.gbRemoteControl.Controls.Add(this.bIzquierda);
            this.gbRemoteControl.Location = new System.Drawing.Point(12, 12);
            this.gbRemoteControl.Name = "gbRemoteControl";
            this.gbRemoteControl.Size = new System.Drawing.Size(198, 50);
            this.gbRemoteControl.TabIndex = 0;
            this.gbRemoteControl.TabStop = false;
            this.gbRemoteControl.Text = "Direccion";
            // 
            // bParar
            // 
            this.bParar.Location = new System.Drawing.Point(87, 19);
            this.bParar.Name = "bParar";
            this.bParar.Size = new System.Drawing.Size(23, 23);
            this.bParar.TabIndex = 2;
            this.bParar.Text = "X";
            this.bParar.UseVisualStyleBackColor = true;
            this.bParar.Click += new System.EventHandler(this.bParar_Click);
            // 
            // bDerecha
            // 
            this.bDerecha.Location = new System.Drawing.Point(116, 19);
            this.bDerecha.Name = "bDerecha";
            this.bDerecha.Size = new System.Drawing.Size(75, 23);
            this.bDerecha.TabIndex = 1;
            this.bDerecha.Text = "-->";
            this.bDerecha.UseVisualStyleBackColor = true;
            this.bDerecha.Click += new System.EventHandler(this.bDerecha_Click);
            // 
            // bIzquierda
            // 
            this.bIzquierda.Location = new System.Drawing.Point(6, 19);
            this.bIzquierda.Name = "bIzquierda";
            this.bIzquierda.Size = new System.Drawing.Size(75, 23);
            this.bIzquierda.TabIndex = 0;
            this.bIzquierda.Text = "<--";
            this.bIzquierda.UseVisualStyleBackColor = true;
            this.bIzquierda.Click += new System.EventHandler(this.bIzquierda_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bStop);
            this.groupBox1.Controls.Add(this.tbAcce);
            this.groupBox1.Location = new System.Drawing.Point(216, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(62, 167);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accel.";
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(6, 129);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(45, 23);
            this.bStop.TabIndex = 1;
            this.bStop.Text = "STOP";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // tbAcce
            // 
            this.tbAcce.LargeChange = 1;
            this.tbAcce.Location = new System.Drawing.Point(6, 19);
            this.tbAcce.Maximum = 2;
            this.tbAcce.Name = "tbAcce";
            this.tbAcce.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbAcce.Size = new System.Drawing.Size(45, 104);
            this.tbAcce.TabIndex = 0;
            this.tbAcce.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbAcce.Value = 1;
            this.tbAcce.ValueChanged += new System.EventHandler(this.tbAcce_ValueChanged);
            // 
            // tbCOM
            // 
            this.tbCOM.Location = new System.Drawing.Point(91, 19);
            this.tbCOM.Name = "tbCOM";
            this.tbCOM.Size = new System.Drawing.Size(30, 20);
            this.tbCOM.TabIndex = 2;
            // 
            // gbAcciones
            // 
            this.gbAcciones.Controls.Add(this.tbHttpPort);
            this.gbAcciones.Controls.Add(this.label2);
            this.gbAcciones.Controls.Add(this.bIDAndroid);
            this.gbAcciones.Controls.Add(this.bIDHTTP);
            this.gbAcciones.Controls.Add(this.label1);
            this.gbAcciones.Controls.Add(this.bConectar);
            this.gbAcciones.Controls.Add(this.tbCOM);
            this.gbAcciones.Location = new System.Drawing.Point(13, 69);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(197, 110);
            this.gbAcciones.TabIndex = 3;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // tbHttpPort
            // 
            this.tbHttpPort.Location = new System.Drawing.Point(91, 49);
            this.tbHttpPort.Name = "tbHttpPort";
            this.tbHttpPort.Size = new System.Drawing.Size(30, 20);
            this.tbHttpPort.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Puerto HTTPd";
            // 
            // bIDAndroid
            // 
            this.bIDAndroid.Location = new System.Drawing.Point(10, 76);
            this.bIDAndroid.Name = "bIDAndroid";
            this.bIDAndroid.Size = new System.Drawing.Size(180, 23);
            this.bIDAndroid.TabIndex = 6;
            this.bIDAndroid.Text = "Iniciar demonio Android";
            this.bIDAndroid.UseVisualStyleBackColor = true;
            // 
            // bIDHTTP
            // 
            this.bIDHTTP.Location = new System.Drawing.Point(127, 46);
            this.bIDHTTP.Name = "bIDHTTP";
            this.bIDHTTP.Size = new System.Drawing.Size(64, 24);
            this.bIDHTTP.TabIndex = 5;
            this.bIDHTTP.Text = "Conectar";
            this.bIDHTTP.UseVisualStyleBackColor = true;
            this.bIDHTTP.Click += new System.EventHandler(this.bIDHTTP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Puerto COM";
            // 
            // bConectar
            // 
            this.bConectar.Location = new System.Drawing.Point(127, 17);
            this.bConectar.Name = "bConectar";
            this.bConectar.Size = new System.Drawing.Size(63, 23);
            this.bConectar.TabIndex = 3;
            this.bConectar.Text = "Conectar";
            this.bConectar.UseVisualStyleBackColor = true;
            this.bConectar.Click += new System.EventHandler(this.bConectar_Click);
            // 
            // fPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 190);
            this.Controls.Add(this.gbAcciones);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRemoteControl);
            this.Name = "fPrincipal";
            this.Text = "NXT Server";
            this.gbRemoteControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAcce)).EndInit();
            this.gbAcciones.ResumeLayout(false);
            this.gbAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRemoteControl;
        private System.Windows.Forms.Button bParar;
        private System.Windows.Forms.Button bDerecha;
        private System.Windows.Forms.Button bIzquierda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.TrackBar tbAcce;
        private System.Windows.Forms.TextBox tbCOM;
        private System.Windows.Forms.GroupBox gbAcciones;
        private System.Windows.Forms.Button bIDAndroid;
        private System.Windows.Forms.Button bIDHTTP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bConectar;
        private System.Windows.Forms.TextBox tbHttpPort;
        private System.Windows.Forms.Label label2;
    }
}

