namespace Multicalculator.Units;

public partial class Volume : ContentPage
{
    double input = 0;
    double l = 0;
    string inputname;
    string outputname;
    int temp;
    List<string> volumelist = new List<string>();
    public Volume()
    {
        InitializeComponent();
        OnClear(this, null);

        volumelist.Add("mm³");
        volumelist.Add("mL");
        volumelist.Add("L");
        volumelist.Add("m³");
        volumelist.Add("gal(us)");
        volumelist.Add("gal(uk)");
        picker1.ItemsSource = volumelist;
        picker2.ItemsSource = volumelist;

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
        l = Volumeinputcalculate(input, inputname);
        this.Nums.Text = Volumeoutputcalculate(l, outputname).ToString();
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

    public static double Volumeinputcalculate(double input, string inputname)
    {
        double l = 0;
        switch (inputname)
        {
            case "mm³":
                l = input / 1000000;
                break;
            case "mL":
                l = input / 1000;
                break;
            case "L":
                l = input;
                break;
            case "m³":
                l = input * 1000;
                break;
            case "gal(us)":
                l = input * 3.785411784;
                break;
            case "gal(uk)":
                l = input * 4.54609;
                break;
        }
        return l;
    }

    public static double Volumeoutputcalculate(double l, string outputname)
    {
        double output = 0;
        switch (outputname)
        {
            case "mm³":
                output = l * 1000000;
                break;
            case "mL":
                output = l * 1000;
                break;
            case "L":
                output = l;
                break;
            case "m³":
                output = l / 1000;
                break;
            case "gal(us)":
                output = l / 3.785411784;
                break;
            case "gal(uk)":
                output = l / 4.54609;
                break;
        }
        return output;
    }
}