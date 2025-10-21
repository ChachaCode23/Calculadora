using System.Drawing;
using System.Windows.Forms;

namespace Calculadora
{
    // Aquí se crean e inicializan los controles botones y textbox y se conectan los eventos Click.
    // No contiene la lógica de la calculadora; solo la “vista”.
    partial class Form1
    {
        // Contenedor de componentes.
        private System.ComponentModel.IContainer components = null;

        // Patrón Dispose: libera recursos cuando el formulario se cierra o se destruye.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        // Método llamado por el Diseñador: crea, posiciona y configura cada control.
        // También conecta los eventos Click con los handlers del código (Digit_Click, Oper_Click, etc.).
        private void InitializeComponent()
        {
            // ======= Declaración/instanciación de controles =======
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button0 = new Button();
            buttonPlus = new Button();
            buttonSub = new Button();
            buttonMult = new Button();
            buttonDiv = new Button();
            buttonDot = new Button();
            buttonClear = new Button();
            buttonEqual = new Button();
            txtDisplay = new TextBox();

            // Indica que se suspende el “layout” mientras configuramos todo (optimiza)
            SuspendLayout();

            // ===================== TextBox de display =====================
            // Muestra el número actual y los resultados.
            txtDisplay.Location = new Point(20, 20);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.Size = new Size(355, 39);
            txtDisplay.TabIndex = 0;
            txtDisplay.Text = "0";                            // Empieza en 0
            txtDisplay.ReadOnly = true;                        // Solo lectura 
            txtDisplay.TextAlign = HorizontalAlignment.Right;  // Alineado a la derecha

            // ===================== Botones numéricos (7-8-9) =====================
            button7.Location = new Point(20, 80);
            button7.Name = "button7";
            button7.Size = new Size(80, 50);
            button7.TabIndex = 1;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Digit_Click;   // Conecta con handler

            button8.Location = new Point(110, 80);
            button8.Name = "button8";
            button8.Size = new Size(80, 50);
            button8.TabIndex = 2;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Digit_Click;

            button9.Location = new Point(200, 80);
            button9.Name = "button9";
            button9.Size = new Size(80, 50);
            button9.TabIndex = 3;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Digit_Click;

            // ===================== Botones numéricos (4–5–6) =====================
            button4.Location = new Point(20, 135);
            button4.Name = "button4";
            button4.Size = new Size(80, 50);
            button4.TabIndex = 4;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Digit_Click;

            button5.Location = new Point(110, 135);
            button5.Name = "button5";
            button5.Size = new Size(80, 50);
            button5.TabIndex = 5;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Digit_Click;

            button6.Location = new Point(200, 135);
            button6.Name = "button6";
            button6.Size = new Size(80, 50);
            button6.TabIndex = 6;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Digit_Click;

            // ===================== Botones numéricos (1–2–3) =====================
            button1.Location = new Point(20, 190);
            button1.Name = "button1";
            button1.Size = new Size(80, 50);
            button1.TabIndex = 7;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Digit_Click;

            button2.Location = new Point(110, 190);
            button2.Name = "button2";
            button2.Size = new Size(80, 50);
            button2.TabIndex = 8;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Digit_Click;

            button3.Location = new Point(200, 190);
            button3.Name = "button3";
            button3.Size = new Size(80, 50);
            button3.TabIndex = 9;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Digit_Click;

            // ===================== Botón 0 =====================
            button0.Location = new Point(110, 245);
            button0.Name = "button0";
            button0.Size = new Size(80, 50);
            button0.TabIndex = 10;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.Click += Digit_Click;

            // ===================== Operadores (/, *, -, +) =====================
            buttonDiv.Location = new Point(295, 80);
            buttonDiv.Name = "buttonDiv";
            buttonDiv.Size = new Size(80, 50);
            buttonDiv.TabIndex = 11;
            buttonDiv.Text = "/";
            buttonDiv.UseVisualStyleBackColor = true;
            buttonDiv.Click += Oper_Click;

            buttonMult.Location = new Point(295, 135);
            buttonMult.Name = "buttonMult";
            buttonMult.Size = new Size(80, 50);
            buttonMult.TabIndex = 12;
            buttonMult.Text = "*";
            buttonMult.UseVisualStyleBackColor = true;
            buttonMult.Click += Oper_Click;

            buttonSub.Location = new Point(295, 190);
            buttonSub.Name = "buttonSub";
            buttonSub.Size = new Size(80, 50);
            buttonSub.TabIndex = 13;
            buttonSub.Text = "-";
            buttonSub.UseVisualStyleBackColor = true;
            buttonSub.Click += Oper_Click;

            buttonPlus.Location = new Point(295, 245);
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Size = new Size(80, 50);
            buttonPlus.TabIndex = 14;
            buttonPlus.Text = "+";
            buttonPlus.UseVisualStyleBackColor = true;
            buttonPlus.Click += Oper_Click;

            // ===================== Otros (., C, =) =====================
            // '.' agrega punto decimal si no existe; 'C' limpia; '=' evalúa la operación pendiente.
            buttonDot.Location = new Point(200, 245);
            buttonDot.Name = "buttonDot";
            buttonDot.Size = new Size(80, 50);
            buttonDot.TabIndex = 15;
            buttonDot.Text = ".";
            buttonDot.UseVisualStyleBackColor = true;
            buttonDot.Click += btnDot_Click;

            buttonClear.Location = new Point(20, 245);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(80, 50);
            buttonClear.TabIndex = 16;
            buttonClear.Text = "C";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += btnClear_Click;

            // El botón "=" ocupa todo el ancho para destacarlo.
            buttonEqual.Location = new Point(20, 300);
            buttonEqual.Name = "buttonEqual";
            buttonEqual.Size = new Size(355, 50);
            buttonEqual.TabIndex = 17;
            buttonEqual.Text = "=";
            buttonEqual.UseVisualStyleBackColor = true;
            buttonEqual.Click += btnEq_Click;

            // ===================== Configuración del Form =====================
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 370);

            // Agrego los controles al formulario en el orden deseado
            Controls.Add(txtDisplay);
            Controls.Add(buttonEqual);
            Controls.Add(buttonClear);
            Controls.Add(buttonDot);
            Controls.Add(buttonPlus);
            Controls.Add(buttonSub);
            Controls.Add(buttonMult);
            Controls.Add(buttonDiv);
            Controls.Add(button0);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);

            // Estética básica del formulario
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Form1";
            Text = "Calculadora";

     
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        //Use estos campos para acceder desde el código (InitializeComponent y Form1.cs).
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button0;
        private Button buttonPlus;
        private Button buttonSub;
        private Button buttonMult;
        private Button buttonDiv;
        private Button buttonDot;
        private Button buttonClear;
        private Button buttonEqual;
        private TextBox txtDisplay;
    }
}
