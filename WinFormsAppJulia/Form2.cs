namespace WinFormsAppJulia
{
    public partial class Form2 : Form
    {
        bool isXTurn;
        int turnCount;
        bool gameOver;

        public Form2()
        {
            InitializeComponent();
        }

        private void btn_Click(object? sender, EventArgs e)
        {
            if (gameOver) { return; }

            Button btn = (Button)sender;

            if (btn != null && string.IsNullOrEmpty(btn.Text))
            {
                btn.Text = isXTurn ? "X" : "O";
                turnCount++;
                isXTurn = !isXTurn;

                if (CheckForWinner())
                {
                    lblStatus.Text = $"Jogador {(isXTurn ? "O" : "X")} ganhou!";
                    gameOver = true;
                }
                else if (turnCount == 9)
                {
                    lblStatus.Text = "Deu velha!";
                    gameOver = true;
                }
                else
                {
                    lblStatus.Text = $"É a vez do jogador {(isXTurn ? "X" : "O")}";
                }
            }
        }

        private bool CheckForWinner()
        {
            string[,] matriz = new string[3, 3]
            {
                { btn1.Text, btn2.Text, btn3.Text },
                { btn4.Text, btn5.Text, btn6.Text },
                { btn7.Text, btn8.Text, btn9.Text }
            };
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(matriz[i, 0]) && matriz[i, 0] == matriz[i, 1] && matriz[i, 1] == matriz[i, 2]) return true;
                if (!string.IsNullOrEmpty(matriz[0, i]) && matriz[0, i] == matriz[1, i] && matriz[1, i] == matriz[2, i]) return true;
            }
            if (!string.IsNullOrEmpty(matriz[0, 0]) && matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2]) return true;
            if (!string.IsNullOrEmpty(matriz[0, 2]) && matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0]) return true;
            return false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control is Button btn && btn != btnReset)
                {
                    btn.Text = string.Empty;
                }
            }

            isXTurn = false;
            turnCount = 0;
            gameOver = false;
            lblStatus.Text = "É a vez do jogador O";
        }
    }
}