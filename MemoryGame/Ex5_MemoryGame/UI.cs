namespace Ex5_MemoryGame
{
    using System;
    using System.Windows.Forms;

    internal class UI
    {
        private Player[] m_Players = new Player[2];
        private bool m_IsSettingOk;
        private int m_RowSize;
        private int m_ColumnSize;

        public UI()
        {
            MemoryGameSettings memoryGameSettings = new MemoryGameSettings();

            memoryGameSettings.ShowDialog();

            m_IsSettingOk = memoryGameSettings.IsStart;

            Start(memoryGameSettings);
        }

        private void Start(MemoryGameSettings i_MemoryGameSettings)
        {
            if (m_IsSettingOk)
            {
                string nameOfTheWinner = string.Empty;
                string scoreOfTheWinner = string.Empty;

                m_Players[0] = i_MemoryGameSettings.PrepareFirstPlayer();
                m_Players[1] = i_MemoryGameSettings.PrepareSecondPlayer();
                i_MemoryGameSettings.GetBoardSize(out m_RowSize, out m_ColumnSize);
                MemoryGame memoryGame = new MemoryGame(m_RowSize, m_ColumnSize, m_Players);
                memoryGame.ShowDialog();

                memoryGame.GetTheWinner(out nameOfTheWinner, out scoreOfTheWinner);
                string msg = string.Format(
                    @"Congratulations you finished the Memory Game
The Winner is: {0} with {1} pairs
And the Score is:
{2} : {3} pair(s)
{4} : {5} pair(s)
Want to play another game ?", nameOfTheWinner,
                    scoreOfTheWinner,
                    m_Players[0].Name,
                    m_Players[0].Score,
                    m_Players[1].Name,
                    m_Players[1].Score);

                if (MessageBox.Show(msg, "Finish Y/N", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Start(i_MemoryGameSettings);
                }
            }
        }
    }
}
