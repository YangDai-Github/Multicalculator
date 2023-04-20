namespace Multicalculator.Units;

public partial class Area : ContentPage
{
    double input = 0;
    double m = 0;
    string inputname;
    string outputname;
    int temp;
    List<string> arealist = new List<string>();
    public Area()
    {
        InitializeComponent();
        OnClear(this, null);

        arealist.Add("mm²");
        arealist.Add("cm²");
        arealist.Add("dm²");
        arealist.Add("m²");
        arealist.Add("km²");
        arealist.Add("市顷");
        arealist.Add("市亩");
        arealist.Add("ha");
        arealist.Add("mile²");
        arealist.Add("yard²");
        arealist.Add("inch²");
        arealist.Add("foot²");
        arealist.Add("nautical mile²");
        picker1.ItemsSource = arealist;
        picker2.ItemsSource = arealist;

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
        m = Areainputcalculate(input, inputname);
        this.Nums.Text = Areaoutputcalculate(m, outputname).ToString();
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

    public static double Areainputcalculate(double input, string inputname)
    {
        double m = 0;
        switch (inputname)
        {
            case "mm²":
                m = input / 1000000;
                break;
            case "cm²":
                m = input / 10000;
                break;
            case "dm²":
                m = input / 100;
                break;
            case "m²":
                m = input;
                break;
            case "km²":
                m = input * 1000000;
                break;
            case "市顷":
                m = input * 20 / 3 * 10000;
                break;
            case "市亩":
                m = input / 15 * 10000;
                break;
            case "ha":
                m = input * 10000;
                break;
            case "mile²":
                m = input * 2589988.11;
                break;
            case "yard²":
                m = input * 0.83612736;
                break;
            case "inch²":
                m = input * 0.00064516;
                break;
            case "foot²":
                m = input * 0.09290304;
                break;
            case "nautical mile²":
                m = input * 3429904;
                break;
        }
        return m;
    }

    public static double Areaoutputcalculate(double m, string outputname)
    {
        double output = 0;
        switch (outputname)
        {
            case "mm²":
                output = m * 1000000;
                break;
            case "cm²":
                output = m * 10000;
                break;
            case "dm²":
                output = m * 100;
                break;
            case "m²":
                output = m;
                break;
            case "km²":
                output = m / 1000000;
                break;
            case "市顷":
                output = m * 3 / 20 / 10000;
                break;
            case "市亩":
                output = m * 15 / 10000;
                break;
            case "ha":
                output = m / 10000;
                break;
            case "mile²":
                output = m / 2589988.11;
                break;
            case "yard²":
                output = m / 0.83612736;
                break;
            case "inch²":
                output = m / 0.00064516;
                break;
            case "foot²":
                output = m / 0.09290304;
                break;
            case "nautical mile²":
                output = m / 3429904;
                break;
        }
        return output;
    }
}