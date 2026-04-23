using System.Threading;

namespace ImaSteg.Controllers {

    class ISBreakThreadController {

        private static CancellationTokenSource breakThread = null; // Clase que sirve para coordenar cancelaciones entre diferentes hilos, temporizadores, eventos, etc.
        private static CancellationToken token;

        public static void OnInit() {
           breakThread = new CancellationTokenSource();
           token = breakThread.Token;
        }

        public static bool Listen() {
            if (breakThread.IsCancellationRequested) {
                return true;
            }
            return false;
        }

        public static void CancelShutDown() {
            breakThread.Cancel();
            breakThread.Dispose();
        }

        public static void Cancel() {
            breakThread.Cancel();
        }

        public static CancellationToken GetCancellationToken() {
            return token;
        }

    }
}
