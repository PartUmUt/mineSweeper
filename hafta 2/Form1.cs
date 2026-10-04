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

        // Board boyutları
        int rowCount;
        int colCount;

        // Mayınların bulunduğu alan
        bool[,] mines;

        // Açılmış hücreleri takip eder
        bool[,] opened;

        // Bayrak konmuş hücreleri takip eder
        bool[,] flagged;


        // Bir hücrenin çevresindeki mayınları sayar
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
                        // Hücrenin kendisini sayma
                        if (!(i == row && k == col) && mines[i, k])
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }


        // Hücreyi açar
        private void openCell(int row, int col)
        {
            // Alanın dışına çıkma
            if (row < 0 || row >= rowCount ||
                col < 0 || col >= colCount)
            {
                return;
            }

            // Daha önce açılmışsa
            if (opened[row, col])
            {
                return;
            }

            // Bayraklı hücreyi açma
            if (flagged[row, col])
            {
                return;
            }

            // Hücreyi açılmış olarak işaretle
            opened[row, col] = true;

            // Bu koordinata sahip butonu bul
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


            // Mayın varsa
            if (mines[row, col])
            {
                btn.Text = "👾";
                btn.BackColor = Color.Red;

                btnReset.Text = ":(";

                MessageBox.Show("Game Over!");

                return;
            }


            // Çevredeki mayın sayısını bul
            int mineCount = mineAround(row, col);

            btn.Text = mineCount.ToString();
            btn.BackColor = Color.White;


            // Çevresinde mayın varsa burada dur
            if (mineCount > 0)
            {
                return;
            }


            // Çevresinde 0 mayın varsa
            // komşu hücreleri otomatik aç
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


        // Sol tık
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            Point position = (Point)btn.Tag;

            openCell(position.X, position.Y);
        }


        // Sağ tık = Bayrak
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            Button btn = (Button)sender;
            Point position = (Point)btn.Tag;

            // Hücre açıldıysa bayrak koyma
            if (opened[position.X, position.Y])
            {
                return;
            }

            // Bayrağı aç/kapat
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

            // Kalan mayın sayısını hesapla
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


        // Mayınları rastgele dağıtır
        void mineSet()
        {
            Random random = new Random();

            int totalCells = rowCount * colCount;

            // Hücrelerin %10'u kadar mayın
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


        // START
        private void btnStart_Click(object sender, EventArgs e)
        {
            // TextBox'lardan değerleri al
            colCount = Convert.ToInt32(txtX.Text);
            rowCount = Convert.ToInt32(txtY.Text);


            // Yeni board oluştur
            mines = new bool[rowCount, colCount];
            opened = new bool[rowCount, colCount];
            flagged = new bool[rowCount, colCount];


            // Mayınları dağıt
            mineSet();


            // Butonları oluştur
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

                    // Satır ve sütun bilgisini sakla
                    btn.Tag = new Point(k, i);

                    // Sol tık
                    btn.Click += btn_Click;

                    // Sağ tık
                    btn.MouseDown += btn_MouseDown;

                    // Forma ekle
                    this.Controls.Add(btn);

                    x += 50;
                }

                y += 50;
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            // Oluşturulmuş mayın tarlası butonlarını sil
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Button btn &&
                    btn.Name == "Cell")
                {
                    this.Controls.Remove(btn);
                    btn.Dispose();
                }
            }

            // Oyun alanını sıfırla
            mines = null;
            opened = null;
            flagged = null;

            rowCount = 0;
            colCount = 0;

            btnReset.Text = ":)";
        }
    }
}