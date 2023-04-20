namespace Multicalculator;

public partial class Kgv : ContentPage
{
    List<int> ints = new List<int>();

    public Kgv()
    {
        InitializeComponent();
        OnClear(this, null);
    }

    void OnClear(object sender, EventArgs e)
    {
        ints.Clear();
        this.result.Text = string.Empty;
        this.Nums.Text = string.Empty;
    }

    void OnDeleat(object sender, EventArgs e)
    {
        this.result.Text = string.Empty;
    }

    void OnAM(object sender, EventArgs e)
    {
        int sum = ints.Sum();
        int count = ints.Count();
        double AM = (double)sum / count;
        this.result.Text = AM.ToString();
    }

    void OnGM(object sender, EventArgs e)
    {
        int mal = 1;
        foreach (var item in ints)
        {
            mal *= item;
        }
        this.result.Text = Math.Pow(mal, 1.0 / ints.Count).ToString();
    }

    void OnNumberSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;
        this.result.Text += btnPressed;
    }

    void onLCM(object sender, EventArgs e)
    {
        ints.Sort();
        for (int i = 0; i < ints.Count; i++)
        {
            for (int j = ints.Count - 1; i < j; j--)
            {
                if (ints[i] == ints[j])
                {
                    ints.RemoveAt(j);
                }
            }
        }
        int kgv = 0;
        int produkt1 = 0;
        int zahl1 = ints[0];
        for (int i = 0; i < ints.Count - 1; i++)
        {

            int zahl2 = ints[i + 1];
            produkt1 = zahl1 * zahl2;
            int rest = zahl1 % zahl2;
            do
            {
                zahl1 = zahl2;
                zahl2 = rest;
                rest = zahl1 % zahl2;
            } while (rest != 0);
            kgv = produkt1 / zahl2;
            zahl1 = kgv;
        }
        this.result.Text = kgv.ToString();
    }

    void onGCD(object sender, EventArgs e)
    {
        ints.Sort();
        for (int i = 0; i < ints.Count; i++)
        {
            for (int j = ints.Count - 1; i < j; j--)
            {
                if (ints[i] == ints[j])
                {
                    ints.RemoveAt(j);
                }
            }
        }
        List<int> commens = new List<int>();
        int zahl1 = ints[0];
        for (int i = 0; i < ints.Count - 1; i++)
        {

            int zahl2 = ints[i + 1];
            int rest = zahl1 % zahl2;
            do
            {
                zahl1 = zahl2;
                zahl2 = rest;
                rest = zahl1 % zahl2;
            } while (rest != 0);
            commens.Add(zahl2);
        }
        this.result.Text = commens.Min().ToString();
    }

    void onSelect(object sender, EventArgs e)
    {
        ints.Add(int.Parse(this.result.Text));
        this.Nums.Text += this.result.Text + " ";
        this.result.Text = string.Empty;
    }
}