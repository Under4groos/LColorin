using System.Text;

namespace LColorin
{
    public class Logger
    {
        private StringBuilder sb = new StringBuilder();
        private StringBuilder all_sb = new StringBuilder();
        private string TimeNow
            => DateTime.Now.ToString("dd MMM HH:mm:ss");

        public Dictionary<Marker, ConsoleColor> LogConores = new Dictionary<Marker, ConsoleColor>();
        public void UseDefault()
        {


            foreach (Marker item in Enum.GetValues(typeof(Marker)))
            {
                LogConores.Add(item, ConsoleColor.White);
            }

            LogConores[Marker.Warning] = ConsoleColor.Yellow;
            LogConores[Marker.Error] = ConsoleColor.Red;
            LogConores[Marker.Information] = ConsoleColor.White;
            LogConores[Marker.Debug] = ConsoleColor.Green;
        }
        public string GetAll => all_sb.ToString();

        //[DllImport("kernel32.dll")]
        //static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, int wAttributes);
        //[DllImport("kernel32.dll")]
        //static extern IntPtr GetStdHandle(uint nStdHandle);
        public Logger()
        {

        }
        public void Clear()
        {
            sb.Clear();
            all_sb.Clear();
        }


        private void __log_append(string data, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            string time_ = $"[{TimeNow}]: ";
            Console.Write(time_);


            Console.ForegroundColor = color;
            string data_ = $"{data}\n";
            Console.Write(data_);
            Console.ForegroundColor = ConsoleColor.White;

            all_sb.AppendLine($"{time_}{data_}");

        }

        public string Log(string Text, Marker Status = Marker.Information)
        {

            if (LogConores.TryGetValue(Status, out ConsoleColor color))
            {
                __log_append(Text, color);

            }
            else
            {
                __log_append(Text);
            }

            return sb.ToString();
        }

    }
}
