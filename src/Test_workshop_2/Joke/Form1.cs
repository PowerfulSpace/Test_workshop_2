namespace Joke
{
    public partial class Form1 : Form
    {
        private Button closeButton;
        private Random random;
        public Form1()
        {

            InitializeComponent(); // Оставляем инициализацию формы

            // Создаем метку с предупреждением
            Label warningLabel = new Label();
            warningLabel.Text = "Обнаружен вирус! Закройте окно, чтобы удалить вирус.";
            warningLabel.AutoSize = true;
            warningLabel.Location = new Point(50, 50);
            this.Controls.Add(warningLabel);

            // Создаем кнопку "Закрыть"
            closeButton = new Button();
            closeButton.Text = "Закрыть";
            closeButton.Location = new Point(150, 150);
            closeButton.MouseEnter += new EventHandler(OnMouseEnterButton); // Добавляем обработчик наведения мыши

            this.Controls.Add(closeButton);

            // Инициализируем объект Random для случайных координат
            random = new Random();
        }

        // Функция, которая будет перемещать кнопку при наведении мыши
        private void OnMouseEnterButton(object sender, EventArgs e)
        {
            // Случайные координаты для перемещения кнопки
            int newX = random.Next(0, this.ClientSize.Width - closeButton.Width);
            int newY = random.Next(0, this.ClientSize.Height - closeButton.Height);

            // Перемещаем кнопку в новое место
            closeButton.Location = new Point(newX, newY);
        }
    }
}
