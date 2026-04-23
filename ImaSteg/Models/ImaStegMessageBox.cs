using ImaSteg.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImaSteg.Models {
    class ImaStegMessageBox {

        private Form imaStegMessageBox;
        private int functionality = Constants.CANCEL_FUNCTIONALITY_CODE;

        public ImaStegMessageBox(int height, string title, string message, bool acceptAndCancel, Icon icon) {
            // Longitud del mensaje * ancho en píxeles de una letra mayúscula.
            int messageWidth = message.Length * Constants.IMASTEG_MSG_BOX_LETTER_WIDTH;

            this.imaStegMessageBox = new Form();
            this.imaStegMessageBox.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.imaStegMessageBox.StartPosition = FormStartPosition.CenterScreen;
            this.imaStegMessageBox.Size = new Size(messageWidth + Constants.IMASTEG_MSG_BOX_RIGHT_SPACE, height);
            this.imaStegMessageBox.MinimizeBox = false;
            this.imaStegMessageBox.MaximizeBox = false;
            this.imaStegMessageBox.Text = title;
            this.imaStegMessageBox.Icon = icon;
            this.imaStegMessageBox.BackColor = Constants.GUI_COLOR_TWO;

            Color black = Color.Black;
            Color transparent = Color.Transparent;

            // Mensaje
            Label msg = new Label();
            msg.Text = message;
            msg.Width = messageWidth;
            msg.Location = new Point(Constants.IMASTEG_MSG_BOX_LABEL_X, Constants.IMASTEG_MSG_BOX_LABEL_Y);
            msg.ForeColor = black;
            this.imaStegMessageBox.Controls.Add(msg);

            string defaultButtonMessage = Constants.IMASTEG_MSG_BOX_ACCEPT_BUTTON;
            if (acceptAndCancel) {
                Button secondaryBtn = new Button();
                secondaryBtn.Click += new EventHandler(this.SecondaryBtn_Click);
                secondaryBtn.Text = Constants.IMASTEG_MSG_BOX_CANCEL_BUTTON;
                secondaryBtn.Location = new Point(messageWidth - secondaryBtn.Width * 2, Constants.IMASTEG_MSG_BOX_BUTTON_Y);
                secondaryBtn.ForeColor = black;
                secondaryBtn.BackColor = transparent;
                this.imaStegMessageBox.Controls.Add(secondaryBtn);
            }

            // Botón por defecto, aceptar o guardar.
            Button defaultBtn = new Button();
            defaultBtn.Click += new EventHandler(this.DefaultBtn_Click);
            defaultBtn.Text = defaultButtonMessage;
            defaultBtn.Location = new Point(messageWidth - defaultBtn.Width, Constants.IMASTEG_MSG_BOX_BUTTON_Y);
            defaultBtn.ForeColor = black;
            defaultBtn.BackColor = transparent;
            this.imaStegMessageBox.Controls.Add(defaultBtn);

        }

        public int ShowISMessageBox() {
            this.imaStegMessageBox.ShowDialog();
            return this.functionality;
        }

        private void SecondaryBtn_Click(object sender, EventArgs e) {
            this.functionality = Constants.SECONDARY_FUNCTIONALITY_CODE;
            this.imaStegMessageBox.Close();
        }

        private void DefaultBtn_Click(object sender, EventArgs e) {
            this.functionality = Constants.DEFAULT_COMMONS_FUNCTIONALITY_CODE;
            this.imaStegMessageBox.Close();
        }
    }
}
