namespace Ex5_MemoryGame
{
    using System;
    using System.Windows.Forms;

    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UI startTheGame = new UI();
        }
    }
}
