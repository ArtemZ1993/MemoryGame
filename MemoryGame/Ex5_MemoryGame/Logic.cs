namespace Ex5_MemoryGame
{
    using System;
    using System.Text;

    internal class Logic
    {
        private readonly char[,] r_GameBoard;
        private readonly int r_SizeOfRow;
        private readonly int r_SizeOfColumn;
        private uint m_CounterToCheckIfGameIsOver;
        private bool[,] m_IsCardsAreFlipped;

        public Logic(int i_SizeOfRow, int i_SizeOfColumn)
        {
            r_SizeOfRow = i_SizeOfRow;
            r_SizeOfColumn = i_SizeOfColumn;
            m_CounterToCheckIfGameIsOver = 0;
            r_GameBoard = new char[r_SizeOfRow, r_SizeOfColumn];
            r_GameBoard = generateShuffleMatrix();
            m_IsCardsAreFlipped = new bool[r_SizeOfRow, r_SizeOfColumn];
        }

        public int SizeOfRow
        {
            get
            {
                return r_SizeOfRow;
            }
        }

        public int SizeOfColumn
        {
            get
            {
                return r_SizeOfColumn;
            }
        }

        public uint CounterToCheckIfGameIsOver
        {
            get
            {
                return m_CounterToCheckIfGameIsOver;
            }
        }

        public char[,] GameBoard
        {
            get
            {
                return r_GameBoard;
            }
        }

        public bool[,] IsCardsAreFlipped
        {
            get
            {
                return m_IsCardsAreFlipped;
            }
        }

        public string GetCharToPrint(int i_RowChoise, int i_ColumnChoise)
        {
            const bool v_IsFlipped = true;

            return m_IsCardsAreFlipped[i_RowChoise, i_ColumnChoise] == v_IsFlipped ? r_GameBoard[i_RowChoise, i_ColumnChoise].ToString() : string.Empty;
        }

        public bool CheckIfTheChoisesAreCorrect(int i_FirstRowChoise, int i_FirstColumnChoise, int i_SecondRowChoise, int i_SecondColumnChoise)
        {
            const bool v_IsCorrect = true;
            bool isChoisesAreCorrect = v_IsCorrect;

            if (r_GameBoard[i_FirstRowChoise, i_FirstColumnChoise] != r_GameBoard[i_SecondRowChoise, i_SecondColumnChoise])
            {
                isChoisesAreCorrect = !v_IsCorrect;
                m_IsCardsAreFlipped[i_FirstRowChoise, i_FirstColumnChoise] = !v_IsCorrect;
                m_IsCardsAreFlipped[i_SecondRowChoise, i_SecondColumnChoise] = !v_IsCorrect;
            }
            else
            {
                m_CounterToCheckIfGameIsOver++;
            }

            return isChoisesAreCorrect;
        }

        public bool CheckIfChoiseIsValid(int i_RowChoise, int i_ColumnChoise)
        {
            const bool v_IsValid = true;
            bool isChoiseIsValid = !v_IsValid;

            if (m_IsCardsAreFlipped[i_RowChoise, i_ColumnChoise] != v_IsValid)
            {
                m_IsCardsAreFlipped[i_RowChoise, i_ColumnChoise] = v_IsValid;
                isChoiseIsValid = v_IsValid;
            }

            return isChoiseIsValid;
        }

        public bool CheckIfTheGameIsOver()
        {
            const bool v_IsGameOver = true;
            bool isGameOver = !v_IsGameOver;

            if (m_CounterToCheckIfGameIsOver == (r_SizeOfColumn * r_SizeOfRow) / 2)
            {
                isGameOver = v_IsGameOver;
            }

            return isGameOver;
        }

        private static void swapTwoIcons(ref char io_FirstIcon, ref char io_SecondIcon)
        {
            char temporaryForSwap = io_FirstIcon;

            io_FirstIcon = io_SecondIcon;
            io_SecondIcon = temporaryForSwap;
        }

        private void fillMatrixWithIcons()
        {
            for (int i = 0; i < r_SizeOfRow; i++)
            {
                for (int j = 0; j < r_SizeOfColumn; j++)
                {
                    r_GameBoard[i, j] = (char)('A' + (((i * r_SizeOfColumn) + j) / 2));
                }
            }
        }

        private char[,] generateShuffleMatrix()
        {
            Random random = new Random();

            fillMatrixWithIcons();
            for (int i = 0; i < r_SizeOfRow; i++)
            {
                for (int j = 0; j < r_SizeOfColumn; j++)
                {
                    int randomNumberForColumn = random.Next(0, r_SizeOfColumn);
                    int randomNumberForRow = random.Next(0, r_SizeOfRow);

                    swapTwoIcons(ref r_GameBoard[i, j], ref r_GameBoard[randomNumberForRow, randomNumberForColumn]);
                }
            }

            return r_GameBoard;
        }
    }
}