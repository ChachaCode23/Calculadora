using System;
using System.Windows.Forms;
// Alias para evitar ambig�edad con Button si coincidiera con otros tipos.
using Button = System.Windows.Forms.Button;

namespace Calculadora
{
    /// Form principal de la calculadora (Windows Forms).
    /// Maneja la interfaz y la l�gica b�sica de operaciones.
    public partial class Form1 : Form
    {
        // ===================== Estado interno de la calculadora =====================
        // Guarda el resultado parcial entre operaciones.
        decimal acumulado = 0;

        // Guarda el operador actual seleccionado: "+", "-", "*", "/"
        string operacion = "";

        // Indica si el siguiente d�gito debe reemplazar el display (true) o concatenarse (false)
        bool nuevaEntrada = true;


        /// Este constructor inicializa los controles y deja el display listo.
  
        public Form1()
        {
            InitializeComponent();

            // Aqui se configura el display (TextBox):
            // - Mostrar "0" al inicio
            // - Solo lectura (as� el usuario no escribe con el teclado)
            // - Texto alineado a la derecha como las calculadoras reales
            txtDisplay.Text = "0";
            txtDisplay.ReadOnly = true;
            txtDisplay.TextAlign = HorizontalAlignment.Right;

            // Nota: los eventos Click de botones se conectaron en el Designer.
            // (Tambi�n se podr�an conectar aqu� por c�digo si se quisiera).
        }

        /// <summary>
        /// Handler general para TODOS los botones num�ricos (0�9).
        /// Usa 'sender' para saber qu� bot�n se puls� y toma su Text (el d�gito).
        /// </summary>
        private void Digit_Click(object sender, EventArgs e)
        {
            // Verifico que el sender sea un Button para poder leer su Text con seguridad.
            if (sender is Button b)
            {
                // Si es una nueva entrada (ej. despu�s de un operador o al inicio) o el display es "0",
                // reemplazo el contenido. En caso contrario, concateno el d�gito al final.
                if (nuevaEntrada || txtDisplay.Text == "0")
                    txtDisplay.Text = b.Text;
                else
                    txtDisplay.Text += b.Text;

                // A partir de aqu� ya no es una nueva entrada hasta que se presione un operador, "=" o "C".
                nuevaEntrada = false;
            }
        }

        /// <summary>
        /// Handler para el bot�n del punto decimal (.).
        /// Evita agregar dos puntos en el mismo n�mero.
        /// </summary>
        private void btnDot_Click(object sender, EventArgs e)
        {
            // Si es nueva entrada, empiezo con "0" para terminar teniendo "0."
            if (nuevaEntrada)
                txtDisplay.Text = "0";

            // Solo agrego el punto si no existe ya en el n�mero actual (evito "12.3.4").
            if (!txtDisplay.Text.Contains("."))
                txtDisplay.Text += ".";

            // Ya estoy escribiendo un n�mero.
            nuevaEntrada = false;
        }

        /// <summary>
        /// Handler para los operadores (+, -, *, /).
        /// Al pulsar un operador, primero resuelvo lo que est� pendiente y luego guardo el nuevo operador.
        /// </summary>
        private void Oper_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                // Aplico la operaci�n pendiente con el n�mero que est� en pantalla.
                CalcularPendiente();

                // Guardo el operador seleccionado para el pr�ximo c�lculo.
                operacion = b.Text; // "+", "-", "*", "/"

                // La pr�xima vez que se escriba un d�gito, debe reemplazar el display (no concatenar).
                nuevaEntrada = true;
            }
        }

        /// <summary>
        /// Handler del bot�n "=" (igual).
        /// Ejecuta la operaci�n pendiente y muestra el resultado final.
        /// </summary>
        private void btnEq_Click(object sender, EventArgs e)
        {
            CalcularPendiente(); // Resuelve con el n�mero actual.
            operacion = "";      // Limpio el operador para no repetirlo.
            nuevaEntrada = true; // El siguiente d�gito debe reemplazar el display.
        }

        /// <summary>
        /// Handler del bot�n "C" (Clear).
        /// Restablece el estado inicial de la calculadora.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            acumulado = 0;
            operacion = "";
            txtDisplay.Text = "0";
            nuevaEntrada = true;
        }

        // ============================ L�gica de c�lculo =============================
        /// <summary>
        /// Aplica la operaci�n pendiente entre 'acumulado' y el n�mero que est� en el display.
        /// Si no hay operaci�n a�n, guarda el n�mero del display en 'acumulado'.
        /// </summary>
        private void CalcularPendiente()
        {
            // Intento convertir el texto del display a decimal. Si falla, aviso y salgo.
            if (!decimal.TryParse(txtDisplay.Text, out var entrada))
            {
                MessageBox.Show("Entrada no v�lida");
                return;
            }

            // Si no tengo operador, significa que es el primer n�mero introducido:
            // lo guardo en 'acumulado'.
            if (operacion == "")
            {
                acumulado = entrada;
            }
            else
            {
                // Si ya hab�a un operador, aplico la operaci�n con el valor actual.
                switch (operacion)
                {
                    case "+":
                        acumulado += entrada;
                        break;

                    case "-":
                        acumulado -= entrada;
                        break;

                    case "*":
                        acumulado *= entrada;
                        break;

                    case "/":
                        // Valido divisi�n por cero: no est� permitida.
                        if (entrada == 0)
                        {
                            MessageBox.Show("No se puede dividir entre cero");
                            // Marco nuevaEntrada para que el pr�ximo d�gito reemplace el display.
                            nuevaEntrada = true;
                            return;
                        }
                        acumulado /= entrada;
                        break;
                }
            }

            // Actualizo el display con el resultado parcial/final.
            txtDisplay.Text = acumulado.ToString();
        }
    }
}
