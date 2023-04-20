namespace Multicalculator.Units;

public partial class Mass : ContentPage
{
    double input = 0;
    double g = 0;
    string inputname;
    string outputname;
    int temp;
    List<string> masslist = new List<string>();
    public Mass()
    {
        InitializeComponent();
        OnClear(this, null);

        masslist.Add("µg");
        masslist.Add("mg");
        masslist.Add("g");
        masslist.Add("kg");
        masslist.Add("short ton");
        masslist.Add("long ton");
        masslist.Add("ton");
        masslist.Add("市斤");
        masslist.Add("台斤");
        masslist.Add("两");
        masslist.Add("台两");
        picker1.ItemsSource = masslist;
        picker2.ItemsSource = masslist;

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
        g = Massinputcalculate(input, inputname);
        this.Nums.Text = Massoutputcalculate(g, outputname).ToString();
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

    public static double Massinputcalculate(double input, string inputname)
    {
        double g = 0;
        switch (inputname)
        {
            case "µg":
                g = input / 1000000;
                break;
            case "mg":
                g = input / 1000;
                break;
            case "g":
                g = input;
                break;
            case "kg":
                g = input * 1000;
                break;
            case "short ton":
                g = input * 907184.74;
                break;
            case "long ton":
                g = input * 1016046.91;
                break;
            case "ton":
                g = input * 1000000;
                break;
            case "市斤":
                g = input * 500;
                break;
            case "台斤":
                g = input * 600;
                break;
            case "两":
                g = input * 50;
                break;
            case "台两":
                g = input * 37.5;
                break;
        }
        return g;
    }

    public static double Massoutputcalculate(double g, string outputname)
    {
        double output = 0;
        switch (outputname)
        {
            case "µg":
                output = g * 1000000;
                break;
            case "mg":
                output = g * 1000;
                break;
            case "g":
                output = g;
                break;
            case "kg":
                output = g / 1000;
                break;
            case "short ton":
                output = g / 907184.74;
                break;
            case "long ton":
                output = g / 1016046.91;
                break;
            case "ton":
                output = g / 1000000;
                break;
            case "市斤":
                output = g / 500;
                break;
            case "台斤":
                output = g / 600;
                break;
            case "两":
                output = g / 50;
                break;
            case "台两":
                output = g / 37.5;
                break;
        }
        return output;
    }
}