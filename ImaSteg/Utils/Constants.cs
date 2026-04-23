
using System.Drawing;

namespace ImaSteg.Utils {
    class Constants {
        public const int N_BITS = 8;
        public const int MAX_LIMIT_BYTE = 255;
        public const int MIN_TEXT_LENGTH = 5;
        public const int MAX_READ_STEP = 16;
        public const string ONLY_NUMBERS_REGEX = @"\d+";
        public const string OPEN_SAVE_FILE_DIALOG_FILTER = "PNG|*.png";
        public const string OPEN_FILE_DIALOG_TITLE = "Abrir imagen";
        public const string SAVE_FILE_DIALOG_TITLE = "Guardar imagen";
        public const string SAVE_FILE_NAME = "\\EditedImage.png";
        public const string DISABLED_STATE_ACTION_BUTTON = "# # #";
        public const string ENABLED_ACTION_BUTTON_TEXT = "ACCIÓN";
        public const string SCREEN_CLICK = "MODO: CLIC EN LA PANTALLA";
        public const string END_FACE = "☺";
        public const string INITIAL_COMMAND = "#StArT#";
        public const string CONTROL_COMMAND = "#EOFEnDoFfIlE#";
        public const string VOID_INFORMATION = "<IMAGEN_SIN_TEXTO>";

        // MessageBox
        public const int IMASTEG_MSG_BOX_LETTER_WIDTH = 6;
        public const int IMASTEG_MSG_BOX_RIGHT_SPACE = 27;
        public const int IMASTEG_MSG_BOX_HEIGHT = 110;
        public const int IMASTEG_MSG_BOX_LABEL_X = 10;
        public const int IMASTEG_MSG_BOX_LABEL_Y = 15;
        public const int IMASTEG_MSG_BOX_BUTTON_Y = 40;
        public const int DEFAULT_COMMONS_FUNCTIONALITY_CODE = 2;
        public const int CANCEL_FUNCTIONALITY_CODE = 0;
        public const int SECONDARY_FUNCTIONALITY_CODE = 1;
        public const string IMASTEG_MSG_BOX_ACCEPT_BUTTON = "Aceptar";
        public const string IMASTEG_MSG_BOX_CANCEL_BUTTON = "Cancelar";
        public const string IMASTEG_MSG_BOX_INFO_TITLE = "Información";
        public const string IMASTEG_MSG_BOX_ERROR_TITLE = "Error";
        public const string CANCEL_OPERATION = "Se ha cancelado la operación";
        public const string UNCONTROLLED_COMMAND = "Comando no controlado";
        public const string INSUFFICIENT_CAPACITY = "CAPACIDAD DE LA IMAGEN\n           SUPERADA";
        public const string PROCESS_GENERIC_ERROR = "Error genérico del sistema";
        public const string SMALL_IMAGE = "Imagen de tamaño insuficiente";
        public const string BAD_TOKEN = "Token incorrecto";

        // Panel
        public const string IMASTEG_PANEL_WRITE = "ESCRIBIR";
        public const string IMASTEG_PANEL_READ = "LEER";
        public const string IMASTEG_PANEL_WRITE_TITLE = "Escribir información";
        public const string IMASTEG_PANEL_READ_TITLE = "Leer información";

        // Contraseña
        public const int PASSWORD_MIN_LENGTH = 10;
        public const string ACCEPT = "ACEPTAR";

        // Token
        public const string TOKEN_CHARACTERS = " \n\t0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz.,;:-_¿?!¡'\"()=/&%$·#@ºª<>*+[]{}áéíóúàèìòùÁÉÍÓÚÀÈÌÒÙ";
        public const string EXTRA_EOL = "\n";

        // ProgressIndicator
        public const int PROGRESS_INDICATOR_INTERVAL = 100;

        // Color de interfaz
        public static Color GUI_COLOR_ONE = Color.FromArgb(255, 123, 153, 134);
        public static Color GUI_COLOR_TWO = Color.FromArgb(255, 143, 188, 145);

    }
}
