namespace Multicalculator.Units;

public partial class Time : ContentPage
{
    double input = 0;
    double m = 0;
    string inputname;
    string outputname;
    int temp;
    List<string> timelist = new List<string>();
    public Time()
    {
        InitializeComponent();
        OnClear(this, null);

        timelist.Add("second");
        timelist.Add("minute");
        timelist.Add("quarter");
        timelist.Add("hour");
        timelist.Add("day");
        picker1.ItemsSource = timelist;
        picker2.ItemsSource = timelist;

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
        m = Lengthinputcalculate(input, inputname);
        this.Nums.Text = Lengthoutputcalculate(m, outputname).ToString();
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

    public static double Lengthinputcalculate(double input, string inputname)
    {
        double m = 0;
        switch (inputname)
        {
            case "second":
                m = input / 60;
                break;
            case "minute":
                m = input;
                break;
            case "quarter":
                m = input * 15;
                break;
            case "hour":
                m = input * 60;
                break;
            case "day":
                m = input * 1440;
                break;
        }
        return m;
    }

    public static double Lengthoutputcalculate(double m, string outputname)
    {
        double output = 0;
        switch (outputname)
        {
            case "second":
                output = m * 60;
                break;
            case "minute":
                output = m;
                break;
            case "quarter":
                output = m / 15;
                break;
            case "hour":
                output = m / 60;
                break;
            case "day":
                output = m / 1440;
                break;
        }
        return output;
    }
}