namespace Ex5_MemoryGame
{
    using System;
    using System.Windows.Forms;

    internal class MemoryGame : Form
    {
        private Label m_NameFirstPlayer;
        private Label m_NameSecondPlayer;
        private Label m_PlayingNow;
        private Logic m_Game;
        private Player[] m_PlayersOfTheGame;
        private Button m_FirstButtonClicked = null;
        private Button m_SecondButtonClicked = null;
        private Button[,] m_Buttons;
        private Random m_RandomNumberForComputerTurn;
        private Timer m_CheckIfTheChoicesAreCorrect;
        private Timer m_CheckIfTheGameIsFinished;
        private bool m_FirstClick = false;
        private bool m_SecondClick = false;

        public MemoryGame(int i_RowSize, int i_ColumnSize, Player[] i_Players)
        {
            m_RandomNumberForComputerTurn = new Random();
            m_Buttons = new Button[i_ColumnSize, i_RowSize];
            m_Game = new Logic(i_RowSize, i_ColumnSize);
            m_CheckIfTheChoicesAreCorrect = new Timer();
            m_CheckIfTheChoicesAreCorrect.Tick += m_CheckIfTheChoicesAreCorrect_Tick;
            m_CheckIfTheGameIsFinished = new Timer();
            m_CheckIfTheGameIsFinished.Tick += m_checkIfTheGameIsFinished_Tick;

            m_PlayersOfTheGame = i_Players;
            MyInitializeComponent(i_RowSize, i_ColumnSize);
        }

        public void GetTheWinner(out string o_Name, out string o_Score)
        {
            o_Name = m_PlayersOfTheGame[0].CalculateWinner(m_PlayersOfTheGame[1]);
            uint scoresOfThePlayers = m_PlayersOfTheGame[0].Score > m_PlayersOfTheGame[1].Score ? m_PlayersOfTheGame[0].Score : m_PlayersOfTheGame[1].Score;

            if (o_Name == "Tie")
            {
                o_Score = "Tie";
            }
            else
            {
                o_Score = scoresOfThePlayers.ToString();
            }
        }

        private void MyInitializeComponent(int i_rowSize, int i_columnSize)
        {
            this.m_NameFirstPlayer = new Label();
            this.m_NameSecondPlayer = new Label();
            this.m_PlayingNow = new Label();
            this.SuspendLayout();

            for (int i = 0; i < i_columnSize; i++)
            {
                for (int j = 0; j < i_rowSize; j++)
                {
                    m_Buttons[i, j] = new Button();
                    m_Buttons[i, j].Size = new System.Drawing.Size(87, 66);
                    m_Buttons[i, j].Name = string.Format("{0}{1}", i, j);
                    m_Buttons[i, j].Top = (m_Buttons[i, j].Height * j) + (10 * j) + 20;
                    m_Buttons[i, j].Left = (m_Buttons[i, j].Width * i) + (10 * i) + 20;
                    m_Buttons[i, j].UseVisualStyleBackColor = true;
                    m_Buttons[i, j].Click += Button_Click;
                    this.Controls.Add(m_Buttons[i, j]);
                }
            }

            this.m_PlayingNow.AutoSize = true;

            this.m_PlayingNow.Top = (m_Buttons[i_columnSize - 1, i_rowSize - 1].Height * i_rowSize) + (10 * i_rowSize) + m_PlayingNow.Height + 10;
            this.m_PlayingNow.Left = 20;
            this.m_PlayingNow.Name = "currentPlayer";
            this.m_PlayingNow.Size = new System.Drawing.Size(50, 20);

            this.m_NameFirstPlayer.AutoSize = true;
            this.m_NameFirstPlayer.Top = this.m_PlayingNow.Top + 30;
            this.m_NameFirstPlayer.Left = 20;
            this.m_NameFirstPlayer.Name = "FirstPlayer";
            this.m_NameFirstPlayer.BackColor = System.Drawing.Color.GreenYellow;
            this.m_NameFirstPlayer.Size = new System.Drawing.Size(50, 20);
            this.m_NameFirstPlayer.Text = string.Format("{0} : {1} pairs", m_PlayersOfTheGame[0].Name, m_PlayersOfTheGame[0].Score);

            this.m_NameSecondPlayer.AutoSize = true;
            this.m_NameSecondPlayer.Top = this.m_NameFirstPlayer.Top + 30;
            this.m_NameSecondPlayer.Left = 20;
            this.m_NameSecondPlayer.Name = "SecondPlayer";
            this.m_NameSecondPlayer.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.m_NameSecondPlayer.Size = new System.Drawing.Size(50, 20);
            this.m_NameSecondPlayer.Text = string.Format("{0} : {1} pairs", m_PlayersOfTheGame[1].Name, m_PlayersOfTheGame[1].Score);

            this.m_PlayingNow.Text = string.Format("Current Player : {0} ", m_PlayersOfTheGame[0].Name);
            this.m_PlayingNow.Name = m_PlayersOfTheGame[0].Name;
            this.m_PlayingNow.BackColor = System.Drawing.Color.GreenYellow;

            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size((m_Buttons[i_columnSize - 1, i_rowSize - 1].Width * i_columnSize) + (10 * i_columnSize) + 30, m_NameSecondPlayer.Top + m_NameSecondPlayer.Height + 20);
            this.Controls.Add(this.m_PlayingNow);
            this.Controls.Add(this.m_NameSecondPlayer);
            this.Controls.Add(this.m_NameFirstPlayer);
            this.Name = "MemoryGame";
            this.Text = "Memory Game";
            this.ResumeLayout(false);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.PerformLayout();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            const bool v_IsButtonClicked = true;

            activateButtonInTheGame(v_IsButtonClicked, sender as Button);
        }

        private void activateButtonInTheGame(bool v_IsButtonClicked, Button i_ClickedButton)
        {
            if (m_FirstButtonClicked != null && m_SecondButtonClicked != null)
            {
                return;
            }

            if (m_Game.CheckIfChoiseIsValid(int.Parse(i_ClickedButton.Name[1].ToString()), int.Parse(i_ClickedButton.Name[0].ToString())) && !m_Game.CheckIfTheGameIsOver())
            {
                if (!m_FirstClick)
                {
                    firstMove(v_IsButtonClicked, i_ClickedButton);
                }
                else if (!m_SecondClick)
                {
                    secondMove(v_IsButtonClicked, i_ClickedButton);
                }
            }
        }
        
        private void firstMove(bool v_IsButtonClicked, Button i_ClickedButton)
        {
            clickOnButton(i_ClickedButton, m_FirstButtonClicked);
            m_FirstButtonClicked = i_ClickedButton;
            m_FirstClick = v_IsButtonClicked;
        }

        private void secondMove(bool v_IsButtonClicked, Button i_ClickedButton)
        {
            clickOnButton(i_ClickedButton, m_SecondButtonClicked);
            m_SecondButtonClicked = i_ClickedButton;
            m_SecondClick = v_IsButtonClicked;
            m_CheckIfTheChoicesAreCorrect.Start();
        }

        private void clickOnButton(Button i_ClickedButton, Button i_WhichButtonWasClicked)
        {
            i_WhichButtonWasClicked = i_ClickedButton;
            i_WhichButtonWasClicked.Text = m_Game.GetCharToPrint(int.Parse(i_WhichButtonWasClicked.Name[1].ToString()), int.Parse(i_WhichButtonWasClicked.Name[0].ToString()));
            i_WhichButtonWasClicked.UseVisualStyleBackColor = true;
            i_WhichButtonWasClicked.BackColor = m_PlayingNow.BackColor;
        }

        private void m_CheckIfTheChoicesAreCorrect_Tick(object sender, EventArgs e)
        {
            const bool v_IsButtonClicked = true;

            m_CheckIfTheChoicesAreCorrect.Stop();
            if (m_Game.CheckIfTheChoisesAreCorrect(int.Parse(m_FirstButtonClicked.Name[1].ToString()), int.Parse(m_FirstButtonClicked.Name[0].ToString()), int.Parse(m_SecondButtonClicked.Name[1].ToString()), int.Parse(m_SecondButtonClicked.Name[0].ToString())))
            {
                choosingIsRight();
            }
            else
            {
                choosingIsNotRight();
            }

            m_SecondClick = !v_IsButtonClicked;
            m_FirstClick = !v_IsButtonClicked;
            m_CheckIfTheGameIsFinished.Start();
        }

        private void choosingIsNotRight()
        {
            System.Threading.Thread.Sleep(1000);
            initilizeButtons(m_FirstButtonClicked, m_SecondButtonClicked);
            changePlayerTurn();
        }

        private void choosingIsRight()
        {
            m_FirstButtonClicked = null;
            m_SecondButtonClicked = null;
            updateScore();
            checkIfComputerTurn();
        }

        private void checkIfComputerTurn()
        {
            if (m_PlayersOfTheGame[1].Type == Player.eType.Computer && m_PlayersOfTheGame[1].IsMyTurn && !m_Game.CheckIfTheGameIsOver())
            {
                System.Threading.Thread.Sleep(1000);
                computerTurn();
            }
        }

        private void m_checkIfTheGameIsFinished_Tick(object sender, EventArgs e)
        {
            m_CheckIfTheGameIsFinished.Stop();
            if (m_Game.CheckIfTheGameIsOver())
            {
                finishGame();
            }
        }

        private void finishGame()
        {
            System.Threading.Thread.Sleep(1000);
            this.Close();
        }

        private void updateScore()
        {
            if (m_PlayingNow.Name == m_PlayersOfTheGame[0].Name)
            {
                updateScoreOfPlayer(0, m_NameFirstPlayer);
            }
            else
            {
                updateScoreOfPlayer(1, m_NameSecondPlayer);
            }
        }

        private void updateScoreOfPlayer(int i_NumberOfPlayer, Label i_PlayerName)
        {
            m_PlayersOfTheGame[i_NumberOfPlayer].Score++;
            i_PlayerName.Text = string.Format("{0} : {1} pairs", m_PlayersOfTheGame[i_NumberOfPlayer].Name, m_PlayersOfTheGame[i_NumberOfPlayer].Score);
        }

        private void initilizeButtons(Button i_FirstButtonClicked, Button i_SecondButtonClicked)
        {
            i_FirstButtonClicked.BackColor = System.Drawing.SystemColors.ButtonFace;
            i_FirstButtonClicked.Text = string.Empty;
            i_SecondButtonClicked.BackColor = System.Drawing.SystemColors.ButtonFace;
            i_SecondButtonClicked.Text = string.Empty;
            m_FirstButtonClicked = null;
            m_SecondButtonClicked = null;
        }

        private void changePlayerTurn()
        {
            const bool v_IsMyTurn = true;

            if (m_PlayingNow.Name == m_PlayersOfTheGame[0].Name)
            {
                m_PlayersOfTheGame[0].IsMyTurn = !v_IsMyTurn;
                updateWhichPlayerIsPlayingNow(1, m_NameSecondPlayer);

                if (m_PlayersOfTheGame[1].Type == Player.eType.Computer)
                {
                    computerTurn();
                }
            }
            else
            {
                m_PlayersOfTheGame[1].IsMyTurn = !v_IsMyTurn;
                updateWhichPlayerIsPlayingNow(0, m_NameFirstPlayer);
            }
        }

        private void computerTurn()
        {
            const bool v_IsButtonClicked = true;
            Button chosenButton;

            m_SecondClick = !v_IsButtonClicked;
            m_FirstClick = !v_IsButtonClicked;

            if (!m_FirstClick)
            {
                chosenButton = firstComputerMove(v_IsButtonClicked);
            }

            if (!m_SecondClick)
            {
                chosenButton = secondComputerMove(v_IsButtonClicked);
            }
        }

        private Button secondComputerMove(bool v_IsButtonClicked)
        {
            Button chosenButton = checkIfTheChoiceOfTheComputerIsValid();
            clickOnButton(chosenButton, m_SecondButtonClicked);
            m_SecondButtonClicked = chosenButton;
            m_SecondClick = v_IsButtonClicked;
            m_CheckIfTheChoicesAreCorrect.Start();
            return chosenButton;
        }

        private Button firstComputerMove(bool v_IsButtonClicked)
        {
            Button chosenButton = checkIfTheChoiceOfTheComputerIsValid();
            clickOnButton(chosenButton, m_FirstButtonClicked);
            m_FirstButtonClicked = chosenButton;
            m_FirstClick = v_IsButtonClicked;
            return chosenButton;
        }

        private Button checkIfTheChoiceOfTheComputerIsValid()
        {
            int randomNumberForColumn = m_RandomNumberForComputerTurn.Next(m_Game.SizeOfColumn);
            int randomNumberForRow = m_RandomNumberForComputerTurn.Next(m_Game.SizeOfRow);

            while (!m_Game.CheckIfChoiseIsValid(int.Parse(m_Buttons[randomNumberForColumn, randomNumberForRow].Name[1].ToString()), int.Parse(m_Buttons[randomNumberForColumn, randomNumberForRow].Name[0].ToString())))
            {
                randomNumberForColumn = m_RandomNumberForComputerTurn.Next(m_Game.SizeOfColumn);
                randomNumberForRow = m_RandomNumberForComputerTurn.Next(m_Game.SizeOfRow);
            }

            return m_Buttons[randomNumberForColumn, randomNumberForRow];
        }

        private void updateWhichPlayerIsPlayingNow(int i_PlayerOfNumber, Label i_PlayerName)
        {
            const bool v_IsMyTurn = true;

            m_PlayingNow.Name = m_PlayersOfTheGame[i_PlayerOfNumber].Name;
            m_PlayingNow.Text = string.Format("Current Player : {0} ", m_PlayersOfTheGame[i_PlayerOfNumber].Name);
            m_PlayingNow.BackColor = i_PlayerName.BackColor;
            m_PlayersOfTheGame[i_PlayerOfNumber].IsMyTurn = v_IsMyTurn;
        }

        
    }
}