namespace Ex5_MemoryGame
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    internal partial class MemoryGameSettings : Form
    {
        private readonly List<string> r_OptionsOfSize = new List<string>();
        private int m_IndexOfList;
        private bool m_IsStart = false;

        public MemoryGameSettings()
        {
            m_IndexOfList = 1;
            initilizeOptionsOfSize();
            InitializeComponent();
        }

        public string ButtonSize
        {
            get { return buttonSize.Text; }
        }

        public string TextBoxFirstPlayerName
        {
            get { return textBoxFirstPlayerName.Text; }
        }

        public string TextBoxSecondPlayerName
        {
            get { return textBoxSecondPlayerName.Text; }
        }

        public bool IsStart
        {
            get { return m_IsStart; }
            set { m_IsStart = value; }
        }

        public Player PrepareFirstPlayer()
        {
            return new Player(TextBoxFirstPlayerName, Player.eType.Human, Player.eOrder.First);
        }

        public Player PrepareSecondPlayer()
        {
            return textBoxSecondPlayerName.Enabled == false ? new Player("Computer", Player.eType.Computer, Player.eOrder.Second) : new Player(TextBoxSecondPlayerName, Player.eType.Human, Player.eOrder.Second);
        }

        public void GetBoardSize(out int o_RowSize, out int o_ColumnSize)
        {
            string boardSize = this.ButtonSize;
            o_RowSize = int.Parse(boardSize[0].ToString());
            o_ColumnSize = int.Parse(boardSize[4].ToString());
        }

        private void initilizeOptionsOfSize()
        {
            for (int i = 4; i < 7; i++)
            {
                for (int j = 4; j < 7; j++)
                {
                    if (j != 5 || i != 5)
                    {
                        r_OptionsOfSize.Add(string.Format("{0} x {1}", i, j));
                    }
                }
            }
        }

        private void buttonSize_Click(object sender, EventArgs e)
        {
            if (m_IndexOfList < r_OptionsOfSize.Count)
            {
                buttonSize.Text = r_OptionsOfSize[m_IndexOfList];
            }
            else
            {
                m_IndexOfList = 0;
                buttonSize.Text = r_OptionsOfSize[m_IndexOfList];
            }

            m_IndexOfList++;
        }

        private void buttonChoiceWhoToPlayAgaints_Click(object sender, EventArgs e)
        {
            const bool v_IsTheTextBoxIsEnalbed = true;

            if (!textBoxSecondPlayerName.Enabled)
            {
                textBoxSecondPlayerName.Enabled = v_IsTheTextBoxIsEnalbed;
                buttonChoiceWhoToPlayAgaints.Text = "Againts Computer";
            }
            else
            {
                textBoxSecondPlayerName.Enabled = !v_IsTheTextBoxIsEnalbed;
                buttonChoiceWhoToPlayAgaints.Text = "Againts a Friend";
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            IsStart = true;
            this.Close();
        }
    }
}
