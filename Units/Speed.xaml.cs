namespace Multicalculator.Units;

public partial class Speed : ContentPage
{
    double input = 0;
    double m = 0;
    string inputname;
    string outputname;
    int temp;
    List<string> speedlist = new List<string>();
    public Speed()
    {
        InitializeComponent();
        OnClear(this, null);

        speedlist.Add("m/s");
        speedlist.Add("km/h");
        speedlist.Add("km/s");
        speedlist.Add("knot");
        speedlist.Add("mi/h");
        speedlist.Add("mi/s");
        picker1.ItemsSource = speedlist;
        picker2.ItemsSource = speedlist;

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
        m = Speedinputcalculate(input, inputname);
        this.Nums.Text = Speedoutputcalculate(m, outputname).ToString();
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

    public static double Speedinputcalculate(double input, string inputname)
    {
        double m = 0;
        switch (inputname)
        {
            case "m/s":
                m = input;
                break;
            case "km/h":
                m = input / 3.6;
                break;
            case "km/s":
                m = input * 1000;
                break;
            case "knot":
                m = input / 1.852;
                break;
            case "mi/h":
                m = input * 0.44704;
                break;
            case "mi/s":
                m = input * 1609.344;
                break;
        }
        return m;
    }

    public static double Speedoutputcalculate(double m, string outputname)
    {
        double output = 0;
        switch (outputname)
        {
            case "m/s":
                output = m;
                break;
            case "km/h":
                output = m * 3.6;
                break;
            case "km/s":
                output = m / 1000;
                break;
            case "knot":
                output = m * 1.852;
                break;
            case "mi/h":
                output = m / 0.44704;
                break;
            case "mi/s":
                output = m / 1609.344;
                break;
        }
        return output;
    }
}