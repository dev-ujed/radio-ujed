using System;
using System.Windows.Forms;

namespace RaduiUjedApp
{
    public class TextBoxTime : TextBox
    {
        public TextBoxTime()
        {
            this.Text = "0m0s";
            this.PreviewKeyDown += TiempoTextBox_PreviewKeyDown;
            this.KeyDown += TiempoTextBox_KeyDown;
            this.KeyPress += TiempoTextBox_KeyPress;
            this.Validating += TiempoTextBox_Validating;
        }

        private void TiempoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int cursorPosition = this.SelectionStart;
            if (cursorPosition == this.Text.IndexOf('m') + 1 || cursorPosition == this.Text.IndexOf('s') + 1)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TiempoTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.IsInputKey = true;
            }
        }

        private void TiempoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            int cursorPosition = this.SelectionStart;
            int indexM = this.Text.IndexOf('m');
            int indexS = this.Text.IndexOf('s');

            if (e.KeyCode == Keys.Up)
            {
                if (cursorPosition <= indexM) IncrementarMinutos();
                else if (cursorPosition > indexM && cursorPosition <= indexS) IncrementarSegundos();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (cursorPosition <= indexM) DecrementarMinutos();
                else if (cursorPosition > indexM && cursorPosition <= indexS) DecrementarSegundos();
                e.SuppressKeyPress = true;
            }
        }

        private void TiempoTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var (min, seg) = ObtenerMinutosYSegundos();
            this.Text = $"{min}m{seg}s";
        }

        private void UpdateTextBox(int? minutos, int? segundos)
        {
            var (currentMinutes, currentSeconds) = ObtenerMinutosYSegundos();

            if (minutos.HasValue) currentMinutes = minutos.Value;
            if (segundos.HasValue) currentSeconds = segundos.Value;

            int cursorPosition = this.SelectionStart;
            this.Text = $"{currentMinutes}m{currentSeconds}s";

            if (cursorPosition > this.Text.Length) cursorPosition = this.Text.Length;
            this.SelectionStart = cursorPosition;
        }

        private void IncrementarMinutos()
        {
            var (minutos, _) = ObtenerMinutosYSegundos();
            UpdateTextBox(minutos + 1, null);
        }

        private void DecrementarMinutos()
        {
            var (minutos, _) = ObtenerMinutosYSegundos();
            if (minutos > 0) minutos--;
            UpdateTextBox(minutos, null);
        }

        private void IncrementarSegundos()
        {
            var (minutos, segundos) = ObtenerMinutosYSegundos();
            if (segundos < 59) segundos++;
            else
            {
                segundos = 0;
                minutos++;
            }
            UpdateTextBox(minutos, segundos);
        }

        private void DecrementarSegundos()
        {
            var (minutos, segundos) = ObtenerMinutosYSegundos();
            if (segundos > 0) segundos--;
            else if (minutos > 0)
            {
                minutos--;
                segundos = 59;
            }
            UpdateTextBox(minutos, segundos);
        }

        private (int minutos, int segundos) ObtenerMinutosYSegundos()
        {
            string texto = this.Text;
            int indexM = texto.IndexOf('m');
            int indexS = texto.IndexOf('s');

            string minStr = indexM > 0 ? texto.Substring(0, indexM) : "0";
            string segStr = (indexM + 1 < indexS) ? texto.Substring(indexM + 1, indexS - indexM - 1) : "0";

            int.TryParse(minStr, out int minutos);
            int.TryParse(segStr, out int segundos);

            return (minutos, segundos);
        }
    }
}
