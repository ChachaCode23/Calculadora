using System;
using System.Windows.Forms;
// Alias para evitar ambigüedad con Button si coincidiera con otros tipos.
using Button = System.Windows.Forms.Button;

namespace Calculadora
{
    /// Form principal de la calculadora (Windows Forms).
    /// Maneja la interfaz y la lógica básica de operaciones.
    public partial class Form1 : Form
    {
        // ===================== Estado interno de la calculadora =====================
        // Guarda el resultado parcial entre operaciones.
        decimal acumulado = 0;

        // Guarda el operador actual seleccionado: "+", "-", "*", "/"
        string operacion = "";

        // Indica si el siguiente dígito debe reemplazar el display (true) o concatenarse (false)
        bool nuevaEntrada = true;


        /// Este constructor inicializa los controles y deja el display listo.
  
        public Form1()
        {
            InitializeComponent();

            // Aqui se configura el display (TextBox):
            // - Mostrar "0" al inicio
            // - Solo lectura (así el usuario no escribe con el teclado)
            // - Texto alineado a la derecha como las calculadoras reales
            txtDisplay.Text = "0";
            txtDisplay.ReadOnly = true;
            txtDisplay.TextAlign = HorizontalAlignment.Right;

            // Nota: los eventos Click de botones se conectaron en el Designer.
            // (También se podrían conectar aquí por código si se quisiera).
        }

        /// <summary>
        /// Handler general para TODOS los botones numéricos (0–9).
        /// Usa 'sender' para saber qué botón se pulsó y toma su Text (el dígito).
        /// </summary>
        private void Digit_Click(object sender, EventArgs e)
        {
            // Verifico que el sender sea un Button para poder leer su Text con seguridad.
            if (sender is Button b)
            {
                // Si es una nueva entrada (ej. después de un operador o al inicio) o el display es "0",
                // reemplazo el contenido. En caso contrario, concateno el dígito al final.
                if (nuevaEntrada || txtDisplay.Text == "0")
                    txtDisplay.Text = b.Text;
                else
                    txtDisplay.Text += b.Text;

                // A partir de aquí ya no es una nueva entrada hasta que se presione un operador, "=" o "C".
                nuevaEntrada = false;
            }
        }

        /// <summary>
        /// Handler para el botón del punto decimal (.).
        /// Evita agregar dos puntos en el mismo número.
        /// </summary>
        private void btnDot_Click(object sender, EventArgs e)
        {
            // Si es nueva entrada, empiezo con "0" para terminar teniendo "0."
            if (nuevaEntrada)
                txtDisplay.Text = "0";

            // Solo agrego el punto si no existe ya en el número actual (evito "12.3.4").
            if (!txtDisplay.Text.Contains("."))
                txtDisplay.Text += ".";

            // Ya estoy escribiendo un número.
            nuevaEntrada = false;
        }

        /// <summary>
        /// Handler para los operadores (+, -, *, /).
        /// Al pulsar un operador, primero resuelvo lo que esté pendiente y luego guardo el nuevo operador.
        /// </summary>
        private void Oper_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                // Aplico la operación pendiente con el número que está en pantalla.
                CalcularPendiente();

                // Guardo el operador seleccionado para el próximo cálculo.
                operacion = b.Text; // "+", "-", "*", "/"

                // La próxima vez que se escriba un dígito, debe reemplazar el display (no concatenar).
                nuevaEntrada = true;
            }
        }

        /// <summary>
        /// Handler del botón "=" (igual).
        /// Ejecuta la operación pendiente y muestra el resultado final.
        /// </summary>
        private void btnEq_Click(object sender, EventArgs e)
        {
            CalcularPendiente(); // Resuelve con el número actual.
            operacion = "";      // Limpio el operador para no repetirlo.
            nuevaEntrada = true; // El siguiente dígito debe reemplazar el display.
        }

        /// <summary>
        /// Handler del botón "C" (Clear).
        /// Restablece el estado inicial de la calculadora.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            acumulado = 0;
            operacion = "";
            txtDisplay.Text = "0";
            nuevaEntrada = true;
        }

        // ============================ Lógica de cálculo =============================
        /// <summary>
        /// Aplica la operación pendiente entre 'acumulado' y el número que está en el display.
        /// Si no hay operación aún, guarda el número del display en 'acumulado'.
        /// </summary>
        private void CalcularPendiente()
        {
            // Intento convertir el texto del display a decimal. Si falla, aviso y salgo.
            if (!decimal.TryParse(txtDisplay.Text, out var entrada))
            {
                MessageBox.Show("Entrada no válida");
                return;
            }

            // Si no tengo operador, significa que es el primer número introducido:
            // lo guardo en 'acumulado'.
            if (operacion == "")
            {
                acumulado = entrada;
            }
            else
            {
                // Si ya había un operador, aplico la operación con el valor actual.
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
                        // Valido división por cero: no está permitida.
                        if (entrada == 0)
                        {
                            MessageBox.Show("No se puede dividir entre cero");
                            // Marco nuevaEntrada para que el próximo dígito reemplace el display.
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
