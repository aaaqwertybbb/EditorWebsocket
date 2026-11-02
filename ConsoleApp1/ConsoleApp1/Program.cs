using WatsonWebsocket;

internal class Program
{
    static WatsonWsServer server;

    private static void Main(string[] args)
    {
        // Start server on localhost port 8080
        server = new WatsonWsServer("127.0.0.1", 8080, false);

        server.ClientConnected += (sender, args) => Console.WriteLine($"JS Client connected: {args.Client.IpPort}");
        server.ClientDisconnected += (sender, args) => Console.WriteLine("JS Client disconnected");

        // Handle incoming transaction buffers (Byte Arrays)
        server.MessageReceived += (sender, args) =>
        {
            ReadOnlySpan<byte> transactionBuffer = args.Data;
            // Process your text editor sync logic here
            Console.WriteLine($"Received {transactionBuffer.Length} bytes of transaction data.");

            // Echo or broadcast back if necessary
            // server.SendAsync(args.Client.IpPort, replyBytes);
        };

        server.Start();
        Console.WriteLine("WebSocket Server started on ws://127.0.0.1:8080");
        Console.ReadLine(); // Keep console alive
    }
}