namespace Ex5_MemoryGame
{
    using System;
    using System.Text;

    internal class Player
    {
        private string m_Name;
        private uint m_Score;
        private eType m_Type;
        private eOrder m_Order;
        private bool m_IsMyTurn;

        public Player(string i_NameOfUser, eType i_TypeOfUser, eOrder i_OrderOfUser)
        {
            m_Name = i_NameOfUser;
            m_Type = i_TypeOfUser;
            m_Score = 0;
            m_Order = i_OrderOfUser;
            m_IsMyTurn = false;
        }

        public enum eType
        {
            Computer,
            Human,
        }

        public enum eOrder
        {
            First,
            Second,
        }

        public bool IsMyTurn
        {
            get
            {
                return m_IsMyTurn;
            }

            set
            {
                m_IsMyTurn = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public uint Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public eType Type
        {
            get
            {
                return m_Type;
            }

            set
            {
                m_Type = value;
            }
        }

        public eOrder Order
        {
            get
            {
                return m_Order;
            }
        }

        public string CalculateWinner(Player i_SecondPlayer)
        {
            string nameOfTheWinner;

            if (m_Score > i_SecondPlayer.Score)
            {
                nameOfTheWinner = m_Name;
            }
            else if (m_Score < i_SecondPlayer.Score)
            {
                nameOfTheWinner = i_SecondPlayer.Name;
            }
            else
            {
                nameOfTheWinner = "Tie";
            }

            return nameOfTheWinner;
        }
    }
}
