namespace Rentacar.Admin
{
    public class ComboBoxItem
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
