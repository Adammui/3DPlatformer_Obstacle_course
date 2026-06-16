using System.Threading;

namespace Installers
{
    public class ContextLifetime
    {
        private readonly CancellationTokenSource _cts= new();
        public CancellationToken Token => _cts.Token;

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}