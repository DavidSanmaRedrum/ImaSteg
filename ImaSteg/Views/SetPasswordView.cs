using ImaSteg.Controllers;
using ImaSteg.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImaSteg.Views {
    public partial class SetPasswordView : Form {

        private string password = "";
        private bool isAcceptButtonPressed = false;
        private bool encrypt;
        private Icon icon;

        public SetPasswordView(bool encrypt) {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.encrypt = encrypt;
        }

        private void SetPasswordView_Load(object sender, EventArgs e) {
            this.BackColor = Constants.GUI_COLOR_TWO;
            this.isAcceptButtonPressed = false;
            this.icon = ImaStegController.GetIcon();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptBtn.Enabled = false;
            this.AcceptBtn.Text = Constants.DISABLED_STATE_ACTION_BUTTON;
            this.PasswordTextBox.PasswordChar = '*';
            // this.TokenBox.MaxLength = Constants.TOKEN_CHARACTERS.Length;
            this.TokenBox.Multiline = true;
            this.TokenBox.AcceptsTab = true;
            //this.TokenBox.AcceptsReturn = true;
            this.CreateTokenBtn.Enabled = this.encrypt;
            this.TabStopAllControls();
            this.WarningLbl.Hide();
        }

        private void AcceptBtn_Click(object sender, EventArgs e) {
            string token = this.TokenBox.Text;
            if (token.Length == Constants.TOKEN_CHARACTERS.Length && ImaStegController.CheckToken(token)) {
                ImaStegController.SetPassword(this.password);
                ImaStegController.SetToken(token);
                this.isAcceptButtonPressed = true;
                this.Close();
            } else {
                ImaStegController.CallImaStegMessageBox(Constants.IMASTEG_MSG_BOX_HEIGHT, Constants.IMASTEG_MSG_BOX_ERROR_TITLE, Constants.BAD_TOKEN, false, this.icon);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e) {
            string pass = this.PasswordTextBox.Text;
            int passwordMinLen = Constants.PASSWORD_MIN_LENGTH;

            this.AcceptBtn.ForeColor = Color.Black;
            this.AcceptBtn.Enabled = false;
            string textButton = "#" + pass.Length + "#";
            if (pass.Length == 0) {
                textButton = Constants.DISABLED_STATE_ACTION_BUTTON;
            }
            
            this.AcceptBtn.Text = textButton;
            if (pass.Length >= passwordMinLen) {
                this.password = pass;
                this.AcceptBtn.ForeColor = Color.DarkGreen;
                this.AcceptBtn.Text = Constants.ACCEPT;
                this.AcceptBtn.Enabled = true;
            }
        }

        private void TokenBox_TextChanged(object sender, EventArgs e) {
            string token = this.TokenBox.Text;
            if (token.EndsWith(Constants.EXTRA_EOL) && token.Length > Constants.TOKEN_CHARACTERS.Length) {
                token = token.Substring(0, token.Length - 1);
                this.TokenBox.Text = token;
            }
        }

        private void SetPasswordView_FormClosed(object sender, FormClosedEventArgs e) {
            if (!this.isAcceptButtonPressed) { // Si no se ha pulsado el botón de aceptar se settea la contraseña a "#";
                this.password = Constants.END_FACE;
                ImaStegController.SetPassword(this.password);
                ISBreakThreadController.Cancel();
                ImaStegController.StopAnimationTimer();
            }
        }

        private void CreateTokenBtn_Click(object sender, EventArgs e) {
            WarningLbl.Show();
            this.TokenBox.Text = ImaStegController.CreateToken();
        }

        private void TabStopAllControls() {
            foreach (Control control in generalBox.Controls) {
                control.TabStop = false;
            }
        }

    }
}

