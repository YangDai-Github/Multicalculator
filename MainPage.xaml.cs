namespace Multicalculator;

public partial class MainPage : ContentPage
{
    int currentState = 1;
    string operatorMath;
    double firstNum, secondNum;
    int count = 0;
    public MainPage()
    {
        InitializeComponent();
        OnClear(this, null);
    }

    void OnClear(object sender, EventArgs e)
    {
        firstNum = 0;
        secondNum = 0;
        currentState = 1;
        this.result.Text = "0";
        count += 1;
        if (count == 6)
        {
            this.result.Text = "Yang Dai 666";
            count = 0;
        }
    }

    void OnSquare(object sender, EventArgs e)
    {
        if (firstNum == 0)
            return;
        firstNum = Math.Pow(firstNum, 2.0);
        this.result.Text = firstNum.ToString();
    }

    void OnSquareRoot(object sender, EventArgs e)
    {
        firstNum = Math.Sqrt(firstNum);
        this.result.Text = firstNum.ToString();
    }

    void OnNumberSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;

        if (this.result.Text == "0" || currentState < 0)
        {
            this.result.Text = string.Empty;
            if (currentState < 0)
                currentState *= -1;
        }

        this.result.Text += btnPressed;

        double number;
        if (double.TryParse(this.result.Text, out number))
        {
            this.result.Text = number.ToString("G");
            if (currentState == 1)
            {
                firstNum = number;
            }
            else
            {
                secondNum = number;
            }
        }
    }

    void onOperatorSelection(object sender, EventArgs e)
    {
        currentState = -2;
        Button button = (Button)sender;
        string btnPressed = button.Text;
        operatorMath = btnPressed;
    }

    void onPointSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;
        if (this.result.Text.IndexOf(".") < 0)
        {
            this.result.Text += btnPressed;
        }

    }

    void onCalculate(object sender, EventArgs e)
    {
        count = 0;
        if (currentState == 2)
        {
            double result = Calculate.DoCalculation(firstNum, secondNum, operatorMath);

            this.result.Text = result.ToString();
            firstNum = result;
            currentState = -1;
        }
    }

}

