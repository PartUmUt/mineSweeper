using System.Drawing.Text;

namespace hafta_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button21_Click(object sender, EventArgs e)
        {
        }

        private void button21_MouseHover(object sender, EventArgs e)
        {
        }

        private void button21_MouseLeave(object sender, EventArgs e)
        {
        }
        int rowCount;
        int colCount;

        bool[,] mines;
        bool[,] opened;
        bool[,] flagged;
        private int mineAround(int row, int col)
        {
            int count = 0;

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int k = col - 1; k <= col + 1; k++)
                {
                    if (i >= 0 && i < rowCount &&
                        k >= 0 && k < colCount)
                    {
                        if (!(i == row && k == col) && mines[i, k])
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        private void openCell(int row, int col)
        {
            if (row < 0 || row >= rowCount ||
                col < 0 || col >= colCount)
            {
                return;
            }

            if (opened[row, col])
            {
                return;
            }

            if (flagged[row, col])
            {
                return;
            }

            opened[row, col] = true;

            Button btn = null;

            foreach (Control control in this.Controls)
            {
                if (control is Button button &&
                    button.Tag is Point position)
                {
                    if (position.X == row &&
                        position.Y == col)
                    {
                        btn = button;
                        break;
                    }
                }
            }

            if (btn == null)
            {
                return;
            }

            if (mines[row, col])
            {
                btn.Text = "👾";
                btn.BackColor = Color.Red;

                btnReset.Text = ":(";

                MessageBox.Show("Game Over!");

                return;
            }

            int mineCount = mineAround(row, col);

            btn.Text = mineCount.ToString();
            btn.BackColor = Color.White;

            if (mineCount > 0)
            {
                return;
            }

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int k = col - 1; k <= col + 1; k++)
                {
                    if (i >= 0 && i < rowCount &&
                        k >= 0 && k < colCount)
                    {
                        if (!(i == row && k == col))
                        {
                            openCell(i, k);
                        }
                    }
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            Point position = (Point)btn.Tag;

            openCell(position.X, position.Y);
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            Button btn = (Button)sender;
            Point position = (Point)btn.Tag;

            if (opened[position.X, position.Y])
            {
                return;
            }

            flagged[position.X, position.Y] =
                !flagged[position.X, position.Y];

            if (flagged[position.X, position.Y])
            {
                btn.Text = "🚩";
            }
            else
            {
                btn.Text = "";
            }

            int totalMines = (rowCount * colCount) / 10;
            int flagCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                for (int k = 0; k < colCount; k++)
                {
                    if (flagged[i, k])
                    {
                        flagCount++;
                    }
                }
            }

            int remainingMines = totalMines - flagCount;

            lblMine.Text = "Mines: " + remainingMines;
        }

        void mineSet()
        {
            Random random = new Random();

            int totalCells = rowCount * colCount;

            int mineCount = totalCells / 10;

            int placedMines = 0;

            while (placedMines < mineCount)
            {
                int randomRow = random.Next(0, rowCount);
                int randomCol = random.Next(0, colCount);

                if (!mines[randomRow, randomCol])
                {
                    mines[randomRow, randomCol] = true;
                    placedMines++;
                }
            }
            lblMine.Text = "Mines: " + mineCount;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            colCount = Convert.ToInt32(txtX.Text);
            rowCount = Convert.ToInt32(txtY.Text);

            mines = new bool[rowCount, colCount];
            opened = new bool[rowCount, colCount];
            flagged = new bool[rowCount, colCount];

            mineSet();

            int y = 150;

            for (int k = 0; k < rowCount; k++)
            {
                int x = 50;

                for (int i = 0; i < colCount; i++)
                {
                    Button btn = new Button();

                    btn.Name = "Cell";
                    btn.Text = "";

                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);

                    btn.Tag = new Point(k, i);

                    btn.Click += btn_Click;

                    btn.MouseDown += btn_MouseDown;

                    this.Controls.Add(btn);

                    x += 50;
                }

                y += 50;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Button btn &&
                    btn.Name == "Cell")
                {
                    this.Controls.Remove(btn);
                    btn.Dispose();
                }
            }

            mines = null;
            opened = null;
            flagged = null;

            rowCount = 0;
            colCount = 0;

            btnReset.Text = ":)";
        }
    }
}