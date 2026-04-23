using ImaSteg.Controllers;
using ImaSteg.Utils;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImaSteg {
    public partial class MainView : Form {

        private string imagePath;
        private bool activatedOnlyStegStripBtn = false;
        private bool activatedStegAndCryptoStripBtn = false;
        private bool activateMouseDown = false;
        private bool panelFirstTime = false;
        private bool panelOptions = true;
        private bool changeColorOnProgressIndicator = true;
        private bool isSaveDialogEnabled = true;
        private Icon icon;

        private static SynchronizationContext context; // Clase para la comunicación de información entre hilos
        

        public MainView() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainView_Load(object sender, EventArgs e) {
            context = SynchronizationContext.Current ?? new SynchronizationContext();
            ISBreakThreadController.OnInit(); // Iniciar la clase que parará los hilos para que no de NPE.
            this.icon = ImaStegController.GetIcon();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Constants.GUI_COLOR_TWO;
            ImaStegStrip.BackColor = Constants.GUI_COLOR_ONE;
            this.ProgressIndicator.BorderStyle = BorderStyle.Fixed3D;
            //ImaStegStrip.ForeColor = Color.Black;
            this.Reset();
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e) {
            ISBreakThreadController.CancelShutDown(); // Cancelar hilo de ejecución antes de terminar.
        }

        private void OpenImageBtn_Click(object sender, EventArgs e) {
            ImaStegOpenFileDialog.Filter = Constants.OPEN_SAVE_FILE_DIALOG_FILTER;
            ImaStegOpenFileDialog.Title = Constants.OPEN_FILE_DIALOG_TITLE;
            this.imagePath = "";

            if (ImaStegOpenFileDialog.ShowDialog() == DialogResult.OK) {
                this.imagePath = ImaStegOpenFileDialog.FileName;
                using (Bitmap test = new Bitmap(this.imagePath)) {
                    if (!ImaStegController.IsValidImage(test.Width * test.Height)) {
                        ImaStegController.CallImaStegMessageBox(Constants.IMASTEG_MSG_BOX_HEIGHT, Constants.IMASTEG_MSG_BOX_ERROR_TITLE, Constants.SMALL_IMAGE, false, this.icon);
                        return;
                    }
                }
                OpenImageBtn.Enabled = false;
                OnlyStegBtn.Enabled = true;
                CryptoAndStegBtn.Enabled = true;
                CancelBtn.Enabled = true;
                this.activateMouseDown = true;
            } else {
                ImaStegController.CallImaStegMessageBox(Constants.IMASTEG_MSG_BOX_HEIGHT, Constants.IMASTEG_MSG_BOX_INFO_TITLE, Constants.CANCEL_OPERATION, false, this.icon);
            }
        }

        private void OnlyStegBtn_Click(object sender, EventArgs e) {
            OnlyStegBtn.Enabled = false;
            CryptoAndStegBtn.Enabled = false;
            this.activatedOnlyStegStripBtn = true;
            ImaStegStripLbl.Text = Constants.SCREEN_CLICK;
        }

        private void CryptoAndStegBtn_Click(object sender, EventArgs e) {
            OnlyStegBtn.Enabled = false;
            CryptoAndStegBtn.Enabled = false;
            this.activatedStegAndCryptoStripBtn = true;
            ImaStegStripLbl.Text = Constants.SCREEN_CLICK;
        }

        private void MainView_MouseDown(object sender, MouseEventArgs e) {
            if (!this.activateMouseDown) return;
            if (this.activatedOnlyStegStripBtn || this.activatedStegAndCryptoStripBtn) {
                this.activatedOnlyStegStripBtn = false;
                ImaStegStripLbl.Text = "";
                ActionBtn.Enabled = true;
                ActionBtn.Text = Constants.ENABLED_ACTION_BUTTON_TEXT;
                this.panelFirstTime = true;
            }
            if (this.panelFirstTime) {
                if (this.panelOptions) {
                    this.panelOptions = false;
                    ImaStegStripLbl.Text = Constants.IMASTEG_PANEL_WRITE;
                } else {
                    this.panelOptions = true;
                    ImaStegStripLbl.Text = Constants.IMASTEG_PANEL_READ;
                }
            }
        }

        private async void ActionBtn_Click(object sender, EventArgs e) {
            ISBreakThreadController.OnInit(); // Se crea una nueva instancia aquí para que no sea deshechado.
            ImaStegController.SetTheImageIsWritten(false);
            this.activateMouseDown = false;
            ActionBtn.Enabled = false;
            string password;
            string message;

            try {
                using (Bitmap bitmap = new Bitmap(this.imagePath)) {
                    ImaStegController.SetBitmapArea(bitmap.Width * bitmap.Height);
                    if (!this.panelOptions) { // Si es escribir
                        ImaStegController.CallCommonView(false, null);
                        message = ImaStegController.GetInputMessage(); // Poner aquí el mensaje que venga de la vista de escritura.
                        if (message.Equals(Constants.END_FACE)) { // Si se ha pulsado el botón de cancelar se resetea y se hace return early.
                            this.Reset();
                            return;
                        } else if (message.Contains(Constants.CONTROL_COMMAND) || message.Contains(Constants.INITIAL_COMMAND) || ImaStegController.HasNotAsciiCharacters(message)) {
                            ImaStegController.CallImaStegMessageBox(Constants.IMASTEG_MSG_BOX_HEIGHT, Constants.IMASTEG_MSG_BOX_ERROR_TITLE, Constants.UNCONTROLLED_COMMAND, false, this.icon);
                            this.Reset();
                            return;
                        }

                        // Adición del carácter reservado para el inicio y del carácter de control (Final):
                        message = Constants.INITIAL_COMMAND + message + Constants.CONTROL_COMMAND;
                        
                        password = this.OpenPasswordDialog(true);
                        if (password.Length >= Constants.PASSWORD_MIN_LENGTH) {
                            this.ProgressIndicatorTimer();
                            await ImaStegController.GetEncryptedMessage(message, password);
                            message = ImaStegController.GetEncryptPayload();
                        } else if (password.Equals(Constants.END_FACE)) {
                            this.Reset();
                            return;
                        } else { // si la contraseña está vacía (Solo esteganografía)
                            this.ProgressIndicatorTimer();
                        }

                        if (message.Length == 0) { // Si el valor devuelto es "" entonces significará que se ha cancelado la operación del getencryptedmessage.
                            return;
                        }

                        await ImaStegController.WriteTextInsideImage(bitmap, message);
                        this.Reset();

                        if (this.isSaveDialogEnabled) {
                            ImaStegSaveFileDialog.Title = Constants.SAVE_FILE_DIALOG_TITLE;
                            ImaStegSaveFileDialog.Filter = Constants.OPEN_SAVE_FILE_DIALOG_FILTER;
                            if (ImaStegSaveFileDialog.ShowDialog() == DialogResult.OK) {
                                ImaStegController.SaveEditedImage(bitmap, ImaStegSaveFileDialog.FileName);
                            } else {
                                ImaStegController.CallImaStegMessageBox(Constants.IMASTEG_MSG_BOX_HEIGHT, Constants.IMASTEG_MSG_BOX_INFO_TITLE, Constants.CANCEL_OPERATION, false, this.icon);
                            }
                        }
                        this.isSaveDialogEnabled = true;
                    } else { // Si es leer.
                        this.ProgressIndicatorTimer();
                        await ImaStegController.ReadTextInsideImage(bitmap); // Pasos siguientes en ProgressIndicatorTimer
                    }
                }
            } catch (Exception) {
                ImaStegController.StopAnimationTimer();
                this.Reset();
                ImaStegController.CallImaStegMessageBox(Constants.IMASTEG_MSG_BOX_HEIGHT, Constants.IMASTEG_MSG_BOX_ERROR_TITLE, Constants.PROCESS_GENERIC_ERROR, false, this.icon);
            }
        }

        private void AboutBtn_Click(object sender, EventArgs e) {
            ImaStegController.CallAboutView();
        }

        private void CancelBtn_Click(object sender, EventArgs e) {
            ImaStegController.StopAnimationTimer();
            ISBreakThreadController.Cancel(); // Cancelar el hilo de ejecución.
            this.isSaveDialogEnabled = false;
            this.Reset();
        }

        private void ProgressIndicatorTimer() {
            TimerCallback callback = new TimerCallback((object state) => {
                if (ImaStegController.GetEncryptPayload().Length == 0 && ImaStegController.GetDecryptPayload().Length == 0 && ImaStegController.GetReadPayload().Length == 0 && !ImaStegController.GetTheImageIsWritten()) { // GetEDPayload: Escribir, GetCleanPayload: Leer
                    this.ProgressAnimation();
                } else {
                    ImaStegController.StopAnimationTimer(); // Parar el temporizador desde la callback porque se opera desde la callback.
                    this.ProgressIndicator.BackColor = Color.Blue;
                    
                    if ((bool)state) { // Solo entra si es lectura.
                        string payload = ImaStegController.GetDecryptPayload().Length > 0 ? ImaStegController.GetDecryptPayload() : ImaStegController.GetReadPayload();
                        context.Post(_ => { // Esto envía el payload creado dentro del callback al hilo principal
                            Task.Run(async () => {
                                await this.StartProcessReadView(payload);
                            }, ISBreakThreadController.GetCancellationToken()).ContinueWith(x => { // Se llama al método Reset() para refrescar, al hacerse desde dentro de una operación asíncrona se debe hacer con invoke ya que toca la UI.
                                Invoke((Action)(() => { // Invoke para que permita llamar a la UI desde el context.Post().
                                    this.Reset();
                                }));
                            });
                        }, null);
                    }
                }
            });// Se ejecuta cada vez que el timer itera. (Hace tick).
            ImaStegController.StartAnimationTimer(callback, this.panelOptions);
        }

        private async Task StartProcessReadView(string payload) {
            string password = "";
            if (!payload.Equals(Constants.VOID_INFORMATION)) {
                var tcs = new TaskCompletionSource<string>(); // Esta clase sirve para devolver valores dentro de un hilo síncrono a uno asíncrono.
                context.Post(_ => {
                    tcs.SetResult(this.OpenPasswordDialog(false));
                }, null);
                password = tcs.Task.Result;
            }

            if (password.Length >= Constants.PASSWORD_MIN_LENGTH) {
                TimerCallback callback = new TimerCallback((object state) => { // Timer de desencriptado (Va a parte) No se puede reactivar el otro
                    if (ImaStegController.GetDecryptPayload().Length == 0) {
                        this.ProgressAnimation();
                    }
                });
                ImaStegController.StartAnimationTimer(callback, true);

                await ImaStegController.GetDecryptedMessage(payload, password);
                payload = ImaStegController.GetDecryptPayload();

                ImaStegController.StopAnimationTimer(); // Aquí está la parada, esta no se hace desde callback. (No se opera desde la callback)

                if (payload.Length == 0) return;

                context.Post(_ => { // El método callCommonView ejecuta ShowDialog (que es un método que no debe ejecutarse en un hilo extra, por eso uso el context) 
                    ImaStegController.CallCommonView(true, payload);
                }, null);
            } else if (!password.Equals(Constants.END_FACE)) {
                context.Post(_ => {
                    ImaStegController.CallCommonView(true, payload);
                }, null);
            }
        }

        private void Reset() {
            OpenImageBtn.Enabled = true;
            OnlyStegBtn.Enabled = false;
            CryptoAndStegBtn.Enabled = false;
            ActionBtn.Enabled = false;
            ActionBtn.Text = Constants.DISABLED_STATE_ACTION_BUTTON;
            ImaStegStripLbl.Text = "";
            CancelBtn.Enabled = false;
            this.activatedOnlyStegStripBtn = false;
            this.activatedStegAndCryptoStripBtn = false;
            this.panelFirstTime = false;
            this.panelOptions = true;
            this.ProgressIndicator.BackColor = Color.Blue;
            this.imagePath = "";

            ImaStegController.SetReadPayload(""); // Reset
            ImaStegController.SetEncryptPayload(""); // Reset
            ImaStegController.SetDecryptPayload("");  
        }

        private string OpenPasswordDialog(bool encrypt) {
            string password;
            if (this.activatedStegAndCryptoStripBtn) {
                this.activatedStegAndCryptoStripBtn = false;
                ImaStegController.CallSetPasswordView(encrypt);
                password = ImaStegController.GetPassword();
                if (password.Length == 0) {
                    this.Reset();
                    return password;
                }
                return password;
            }
            return "";
        }

        private void ProgressAnimation() {
            if (this.changeColorOnProgressIndicator) {
                this.changeColorOnProgressIndicator = false;
                this.ProgressIndicator.BackColor = Color.Red;
            } else {
                this.changeColorOnProgressIndicator = true;
                this.ProgressIndicator.BackColor = Color.Yellow;
            }
        }

    }
}
