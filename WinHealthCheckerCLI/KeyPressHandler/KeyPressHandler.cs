namespace WinHealthCheckerCLI.KeyPressHandler;

    public sealed class KeyboardMonitor
    {
        public Task MonitorTask { get; private set; }
        private readonly int _responseTime;
        
        /// <summary>
        /// Gets the last key that was pressed from the registered keys.
        /// </summary>
        private ConsoleKey? LastKeyPressed { get; set; }
        
        /// <summary>
        /// Event that fires when any key is pressed.
        /// </summary>
        public event EventHandler<ConsoleKeyEventArgs>? KeyPressed;

        /// <summary>
        /// Creates a new instance of KeyboardMonitor to track specific keys.
        /// </summary>
        /// <param name="responseTime">
        /// The number of ms that the thread will pause to allow
        /// for other tasks to run.
        /// </param>
        public KeyboardMonitor(int responseTime)
        {
            _responseTime = responseTime;
            MonitorTask = Task.Run(MonitorKeyPresses);
        }

        private async Task MonitorKeyPresses()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(true);
                    
                    LastKeyPressed = keyInfo.Key;
                    OnKeyPressed(new ConsoleKeyEventArgs(keyInfo));
                }
                
                await Task.Delay(_responseTime); // Free up the thread for other tasks.
            }
        }

        /// <summary>
        /// Checks if a specific key is currently pressed.
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>True if the specified key was the last key pressed</returns>
        public bool IsKeyPressed(ConsoleKey key)
        {
            return LastKeyPressed == key;
        }

        /// <summary>
        /// Resets the last key pressed state to null.
        /// </summary>
        public void ResetKeyState()
        {
            LastKeyPressed = null;
        } 

        private void OnKeyPressed(ConsoleKeyEventArgs e)
        {
            KeyPressed?.Invoke(this, e);
        }
    }