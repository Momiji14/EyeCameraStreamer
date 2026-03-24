using System.Net;

namespace EyeCameraStreamer
{
    internal class Streamer
    {
        public void StartHttpServer(int port, Func<byte[]> frameProvider, CancellationToken token, AutoResetEvent signal)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add($"http://localhost:{port}/");

            try
            {
                listener.Start();
                token.Register(() => { try { listener.Stop(); } catch { } });

                Task.Run(async () => {
                    while (!token.IsCancellationRequested)
                    {
                        try
                        {
                            var context = await listener.GetContextAsync();
                            _ = HandleClientAsync(context, frameProvider, token, signal);
                        }
                        catch { if (token.IsCancellationRequested) break; }
                    }
                }, token);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Port {port} 起動失敗: {ex.Message}");
            }
        }

        private async Task HandleClientAsync(HttpListenerContext context, Func<byte[]> provider, CancellationToken token, AutoResetEvent signal)
        {
            using var res = context.Response;
            res.ContentType = "multipart/x-mixed-replace; boundary=--frame";
            try
            {
                while (!token.IsCancellationRequested)
                {
                    signal.WaitOne(1000);

                    byte[] img = provider();
                    if (img != null)
                    {
                        byte[] head = System.Text.Encoding.ASCII.GetBytes($"\r\n--frame\r\nContent-Type: image/jpeg\r\nContent-Length: {img.Length}\r\n\r\n");
                        await res.OutputStream.WriteAsync(head, 0, head.Length);
                        await res.OutputStream.WriteAsync(img, 0, img.Length);
                        await res.OutputStream.FlushAsync();
                    }
                }
            }
            catch { /* 切断 */ }
        }
    }
}
