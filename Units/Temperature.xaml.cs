namespace Multicalculator.Units;

public partial class Temperature : ContentPage
{
    double input = 0;
    double d = 0;
    string inputname;
    string outputname;
    int temp;
    List<string> temperaturelist = new List<string>();
    public Temperature()
    {
        InitializeComponent();
        OnClear(this, null);

        temperaturelist.Add("K");
        temperaturelist.Add("℃");
        temperaturelist.Add("℉");
        picker1.ItemsSource = temperaturelist;
        picker2.ItemsSource = temperaturelist;

    }

    void OnClear(object sender, EventArgs e)
    {
        this.result.Text = string.Empty;
        this.Nums.Text = string.Empty;
    }

    void OnDeleat(object sender, EventArgs e)
    {
        if (this.result.Text.Count() != 0)
        {
            this.result.Text = this.result.Text.Remove(this.result.Text.Count() - 1);
        }
        else return;
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



    void OnNumberSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;
        this.result.Text += btnPressed;
    }


    void onSelect(object sender, EventArgs e)
    {
        input = double.Parse(this.result.Text.ToString());
        d = Temperinputcalculate(input, inputname);
        this.Nums.Text = Temperoutputcalculate(d, outputname).ToString();
    }

    void picker1_SelectedIndexChanged(object sender, EventArgs e)
    {
        inputname = picker1.SelectedItem.ToString();
    }

    void picker2_SelectedIndexChanged(object sender, EventArgs e)
    {
        outputname = picker2.SelectedItem.ToString();
    }

    void OnInverse(object sender, EventArgs e)
    {
        temp = picker1.SelectedIndex;
        picker1.SelectedIndex = picker2.SelectedIndex;
        picker2.SelectedIndex = temp;
        temp = 0;
    }

    public static double Temperinputcalculate(double input, string inputname)
    {
        double d = 0;
        switch (inputname)
        {
            case "K":
                d = input + 273.15;
                break;
            case "℃":
                d = input;
                break;
            case "℉":
                d = (input - 32) * 5 / 9;
                break;
        }
        return d;
    }

    public static double Temperoutputcalculate(double d, string outputname)
    {
        double output = 0;
        switch (outputname)
        {
            case "K":
                output = d - 273.15;
                break;
            case "℃":
                output = d;
                break;
            case "℉":
                output = d * 9 / 5 + 32;
                break;
        }
        return output;
    }
}