using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp3
{
    public partial class BlockUsGame : Form
    {
        private const int gridSize = 20;
        private const int cellSize = 30;
        private Color[,] grid;
        private int[,] scoreGrid;
        private Player currentPlayer;
        private List<Player> players;

        public BlockUsGame()
        {
            grid = new Color[gridSize, gridSize];
            InitializeGrid();

            players = new List<Player>
            {
                new Player("Player One", Color.Magenta, Color.Cyan),
                new Player("Player Two", Color.Green, Color.Yellow)
            };
            currentPlayer = players[0];

            this.Size = new Size(gridSize * cellSize, gridSize * cellSize);
            this.Paint += new PaintEventHandler(OnPaint);
            this.MouseClick += new MouseEventHandler(OnMouseClick);

            scoreGrid = new int[gridSize, gridSize];
            InitializeComponent();
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    scoreGrid[i, j] = 0;
                }
            }
        }

        private void InitializeGrid()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    grid[i, j] = Color.White;
                }
            }
        }

        private Player DetermineWinner()
        {
            int maxScore = 216;
            Player winner = null;

            foreach (var player in players)
            {
                int score = CalculatePlayerScore(player);
                if (score > maxScore)
                {
                    maxScore = score;
                    winner = player;
                }
            }

            return winner;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Brush brush = new SolidBrush(grid[i, j]);
                    g.FillRectangle(brush, i * cellSize, j * cellSize, cellSize, cellSize);
                    brush.Dispose();
                }
            }
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / cellSize;
            int y = e.Y / cellSize;

            if (x >= 0 && x < gridSize && y >= 0 && y < gridSize)
            {
                if (grid[x, y] == Color.White)
                {
                    grid[x, y] = currentPlayer.GetCurrentColor();
                    this.Invalidate();
                    SwitchPlayer();
                }
            }

            var winner = DetermineWinner();
            if (winner != null)
            {
                MessageBox.Show(@"The winner is: " + winner.Name);
            }
        }

        private int CalculatePlayerScore(Player player)
        {
            int score = 0;
            Color playerColor = player.GetCurrentColor();
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (grid[i, j] == playerColor)
                    {
                        score += 1;
                    }
                }
            }

            return score;
        }

        private void SwitchPlayer()
        {
            int currentIndex = players.IndexOf(currentPlayer);
            currentIndex = (currentIndex + 1) % players.Count;
            currentPlayer = players[currentIndex];
        }

        private void BlockUsGame_Load(object sender, EventArgs e)
        {
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }

    [Serializable]
    public class GameState
    {
        public Color[,] Grid { get; set; }
        public int[,] ScoreGrid { get; set; }
        public List<Player> Players { get; set; }
        public Player CurrentPlayer { get; set; }

        public void SaveGameState(GameState gameState, string filePath)
        {
            string json = JsonConvert.SerializeObject(gameState);
            File.WriteAllText(filePath, json);
        }

        public GameState LoadGameState(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<GameState>(json);
            }

            return null;
        }
    }
}
