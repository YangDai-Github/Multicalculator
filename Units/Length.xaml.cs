namespace Multicalculator.Units;

public partial class Length : ContentPage
{
    double input = 0;
    double m = 0;
    string inputname;
    string outputname;
    int temp;
    List<string> lengthlist = new List<string>();
    public Length()
    {
        InitializeComponent();
        OnClear(this, null);

        lengthlist.Add("mm");
        lengthlist.Add("cm");
        lengthlist.Add("dm");
        lengthlist.Add("m");
        lengthlist.Add("km");
        lengthlist.Add("里");
        lengthlist.Add("丈");
        lengthlist.Add("尺");
        lengthlist.Add("寸");
        lengthlist.Add("分");
        lengthlist.Add("厘");
        lengthlist.Add("mile");
        lengthlist.Add("yard");
        lengthlist.Add("inch");
        lengthlist.Add("foot");
        lengthlist.Add("nautical mile");
        picker1.ItemsSource = lengthlist;
        picker2.ItemsSource = lengthlist;

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
            case "mm":m = input / 1000;
                break;
            case "cm":m = input / 100;
                break;
            case "dm":m = input / 10;
                break;
            case "m":m = input;
                break;
            case "km":m = input * 1000;
                break;
            case "里":m = input * 500;
                break;
            case "丈":m = input * 10 / 3;
                break;
            case "尺":m = input * 10 / 3 / 10;
                break;
            case "寸":m = input * 10 / 3 / 10 / 10;
                break;
            case "分":m = input * 10 / 3 / 10 / 10 / 10;
                break;
            case "厘":m = input * 10 / 3 / 10 / 10 / 10 / 10;
                break;
            case "mile":m = input * 1609.344;
                break;
            case "yard":m = input * 0.914383;
                break;
            case "inch":m = input * 0.025399;
                break;
            case "foot":m = input * 0.304794;
                break;
            case "nautical mile":m = input * 1852;
                break;
        }
        return m;
    }

    public static double Lengthoutputcalculate(double m, string outputname)
    {
        double output = 0;
        switch (outputname)
        {
            case "mm":output = m * 1000;
                break;
            case "cm":output = m * 100;
                break;
            case "dm":output = m * 10;
                break;
            case "m":output = m;
                break;
            case "km":output = m / 1000;
                break;
            case "里":output = m / 500;
                break;
            case "丈":output = m * 3 / 10;
                break;
            case "尺":output = m * 3;
                break;
            case "寸":output = m * 30;
                break;
            case "分":output = m * 300;
                break;
            case "厘":output = m * 3000;
                break;
            case "mile":output = m / 1609.344;
                break;
            case "yard":output = m / 0.914383; 
                break;
            case "inch":output = m / 0.025399;
                break;
            case "foot":output = m / 0.304794;
                break;
            case "nautical mile":output = m / 1852;
                break;
        }
        return output;
    }
}