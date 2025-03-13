namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        private TextBox txtPassword;
        private Button btnGenerate, btnCopy;
        private NumericUpDown numLength;
        private CheckBox chkUpper, chkLower, chkNumbers, chkSymbols;

        public Form1()
        {
            InitializeComponent();

            // Название 
            this.Text = "Генератор паролей";
            this.Width = 350;
            this.Height = 250;

            // Динамическое создание элементов
            txtPassword = new TextBox { Left = 20, Top = 20, Width = 250, ReadOnly = true };

            btnGenerate = new Button { Text = "Сгенерировать", Left = 20, Top = 60, Width = 150 };

            btnCopy = new Button { Text = "Копировать", Left = 180, Top = 60, Width = 100 };

            numLength = new NumericUpDown { Left = 20, Top = 100, Width = 60, Minimum = 6, Maximum = 32, Value = 12 };

            chkUpper = new CheckBox { Text = "A-Z", Left = 100, Top = 100, Checked = true };

            chkLower = new CheckBox { Text = "a-z", Left = 160, Top = 100, Checked = true };

            chkNumbers = new CheckBox { Text = "0-9", Left = 220, Top = 100, Checked = true };

            chkSymbols = new CheckBox { Text = "!@#$%", Left = 280, Top = 100, Checked = true };

            // Обработка событий кнопки
            btnGenerate.Click += (sender, e) => txtPassword.Text = GeneratePassword((int)numLength.Value);
            btnCopy.Click += (sender, e) => Clipboard.SetText(txtPassword.Text);

            this.Controls.AddRange(new Control[] { txtPassword, btnGenerate, btnCopy, numLength, chkUpper, chkLower, chkNumbers, chkSymbols });


        }

        private string GeneratePassword(int length)
        {
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string symbols = "!@#$%^&*";
            string chars = "";

            if (chkUpper.Checked) chars += upper;
            if (chkLower.Checked) chars += lower;
            if (chkNumbers.Checked) chars += numbers;
            if (chkSymbols.Checked) chars += symbols;

            if (string.IsNullOrEmpty(chars)) return "Необходимо выбрать параметры";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }
}
