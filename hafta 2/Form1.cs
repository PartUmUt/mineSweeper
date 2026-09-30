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

        private int mineAround(int row, int col)
        {
            int count = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int k = col - 1; k <= col + 1; k++)
                {
                    if (i >= 0 && i < 10 && k >= 0 && k < 10)
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



        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Point position = (Point)btn.Tag;

            bool isMine = mines[position.X, position.Y];

            if (isMine)
            {
                btn.Text = "BOOM";
                btn.BackColor = Color.Red;
                MessageBox.Show("Game Over!");
            }
            else
            {
                btn.Text = "" + mineAround;
                btn.BackColor = Color.LightGreen;
            }

        }

        bool[,] mines = new bool[10, 10];

        void mineSet()
        {
            Random random = new Random();
            int mineCount = 0;
            while (mineCount < 10)
            {
                int randomRow = random.Next(0, 10);
                int randomCol = random.Next(0, 10);
                if (!mines[randomRow, randomCol])
                {
                    mines[randomRow, randomCol] = true;
                    mineCount++;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mineSet();

            //int c = 1;
            int y = 50;
            for (int k = 0; k < 10; k++)
            {
                int x = 50;
                for (int i = 0; i < 10; i++)
                {
                    //string buttonName = "Cell" + c;
                    Button btn = new Button();
                    btn.Name = "Cell";
                    btn.Text = ""; //buttonName;
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    btn.Tag = new Point(k, i);

                    btn.Click += btn_Click;

                    this.Controls.Add(btn);

                    x += 50;
                    //c += 1;
                }
                y += 50;
                //c += 1;
            }
        }
    }
}