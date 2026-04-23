using ImaSteg.Controllers;
using ImaSteg.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImaSteg.Views {
    public partial class CommonView : Form {

        private bool readFunctionality;
        private bool acceptButtonPressed = false;
        private string message;
        private int bitmapArea = 0;

        public CommonView(bool readFunctionality, string message) {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.readFunctionality = readFunctionality;
            this.message = message;
        }

        private void CommonView_Load(object sender, EventArgs e) {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Constants.GUI_COLOR_TWO;
            AcceptBtn.Enabled = false;
            string title = Constants.IMASTEG_PANEL_WRITE_TITLE;
            this.bitmapArea = ImaStegController.GetBitmapArea();
            if (this.readFunctionality) {
                title = Constants.IMASTEG_PANEL_READ_TITLE;
                IOField.ReadOnly = true;
                this.message = this.message.Replace(Constants.CONTROL_COMMAND, "").Replace(Constants.INITIAL_COMMAND, ""); // Sacar por pantalla solo lo importante
                IOField.Text = this.message;
                CancelBtn.Hide();
            } else {
                CapacityLbl.ForeColor = Color.Red;
            }
            this.Text = title;
        }

        private void AcceptBtn_Click(object sender, EventArgs e) {
            this.acceptButtonPressed = true;
            if (!this.readFunctionality) {
                ImaStegController.SetInputMessage(IOField.Text);
            }
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void IOField_TextChanged(object sender, EventArgs e) {
            string info = IOField.Text;
            // * 2 porque cada letra son 2 píxels
            int infoLengthAndExtra = (Constants.CONTROL_COMMAND.Length + Constants.INITIAL_COMMAND.Length + info.Length) * 2;
            bool isEnabled = false;
            string capacityMsg = "";
            if (info.Length > 0 && infoLengthAndExtra <= this.bitmapArea) { 
                isEnabled = true;
            } else if (infoLengthAndExtra > this.bitmapArea && !info.Equals(Constants.VOID_INFORMATION)) {
                capacityMsg = Constants.INSUFFICIENT_CAPACITY;
            }
            CapacityLbl.Text = capacityMsg;
            AcceptBtn.Enabled = isEnabled;
        }

        private void CommonView_FormClosed(object sender, FormClosedEventArgs e) {
            if (!this.acceptButtonPressed) {
                ImaStegController.SetInputMessage(Constants.END_FACE);
                ImaStegController.StopAnimationTimer();
            }
        }
    }
}
