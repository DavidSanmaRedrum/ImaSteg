using ImaSteg.Functionalities;
using ImaSteg.Models;
using ImaSteg.Utils;
using ImaSteg.Views;
using System.Drawing;
using System.Threading.Tasks;

namespace ImaSteg.Controllers {
    class ImaStegController {

        private static string imaStegPassword = "";
        private static string inputMessage = "";
        private static string token = "";
        private static string outputEncryptPayload = "";
        private static string outputDecryptPayload = "";
        private static string readPayload = "";
        private static bool theImageIsWritten = false;
        private static Icon icon = Properties.Resources.Icon;
        private static int bitmapArea = 0;

        private static System.Threading.Timer timer = null;
        
        public static void StartAnimationTimer(System.Threading.TimerCallback callback, bool read) {
            timer = new System.Threading.Timer(callback, read, 0, Constants.PROGRESS_INDICATOR_INTERVAL);
        }

        public static void StopAnimationTimer() {
            if (timer != null) timer.Dispose(); // Parar el temporizador de la animación si está inicializado.
        }

        public static async Task GetEncryptedMessage(string message, string password) {
            outputEncryptPayload = await Task.Run(() => EncryptDecryptFunctionality.GetPreparedMessage(true, message, password), ISBreakThreadController.GetCancellationToken());
        }

        public static async Task GetDecryptedMessage(string message, string password) {
            outputDecryptPayload = await Task.Run(() => EncryptDecryptFunctionality.GetPreparedMessage(false, message, password), ISBreakThreadController.GetCancellationToken());
        }

        public static async Task WriteTextInsideImage(Bitmap bitmap, string message) {
            await Task.Run(() => ImageEditionFunctionality.WriteTextInsideImage(bitmap, message), ISBreakThreadController.GetCancellationToken());
            theImageIsWritten = true;
        }

        public static async Task ReadTextInsideImage(Bitmap bitmap) {
            readPayload = await Task.Run(() => ImageEditionFunctionality.ReadTextInsideImage(bitmap), ISBreakThreadController.GetCancellationToken());
        }

        public static void SetPassword(string password) {
            imaStegPassword = password;
        }

        public static string GetPassword() {
            return imaStegPassword;
        }

        public static void SetInputMessage(string message) {
            inputMessage = message;
        }

        public static string GetInputMessage() {
            return inputMessage;
        }

        public static void SetToken(string newToken) {
            token = newToken;
        }

        public static string GetToken() {
            return token;
        }

        public static string CreateToken() {
            return EncryptDecryptFunctionality.CreateToken();
        }

        public static bool CheckToken(string token) {
            return EncryptDecryptFunctionality.CheckToken(token);
        }

        public static void SaveEditedImage(Bitmap bitmap, string path) {
            FileFunctionality.SaveEditedImage(bitmap, path);
        }

        public static Icon GetIcon() {
            return icon;
        }

        public static int GetBitmapArea() {
            return bitmapArea;
        }

        public static void SetBitmapArea(int area) {
            bitmapArea = area;
        }

        public static void SetEncryptPayload(string payload) {
            outputEncryptPayload = payload;
        }

        public static string GetEncryptPayload() {
            return outputEncryptPayload;
        }

        public static void SetDecryptPayload(string payload) {
            outputDecryptPayload = payload;
        }

        public static string GetDecryptPayload() {
            return outputDecryptPayload;
        }

        public static void SetReadPayload(string readPayloadParam) {
            readPayload = readPayloadParam;
        }

        public static string GetReadPayload() {
            return readPayload;
        }

        public static void SetTheImageIsWritten(bool mode) {
            theImageIsWritten = mode;
        }

        public static bool GetTheImageIsWritten() {
            return theImageIsWritten;
        }

        public static bool IsValidImage(int area) {
            return ImageEditionFunctionality.CheckImageSize(area);
        }

        public static bool HasNotAsciiCharacters(string msg) {
            return CommonsFuntionality.HasNotAsciiCharacters(msg);
        }

        public static int CallImaStegMessageBox(int height, string title, string message, bool acceptAndCancel, Icon icon) {
            ImaStegMessageBox messageBox = new ImaStegMessageBox(height, title, message, acceptAndCancel, icon);
            return messageBox.ShowISMessageBox();
        }

        public static void CallSetPasswordView(bool encrypt) {
            SetPasswordView view = new SetPasswordView(encrypt);
            view.ShowDialog();
        }

        public static void CallCommonView(bool readFunctionality, string message) {
            CommonView view = new CommonView(readFunctionality, message);
            view.ShowDialog();
        }

        public static void CallAboutView() {
            AboutView about = new AboutView();
            about.ShowDialog();
        }
    }
}
