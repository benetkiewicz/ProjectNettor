namespace Projectnettor
{
    using System.Windows.Forms;

    public class EnterTextBox : TextBox
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                return true;
            }
            return base.IsInputKey(keyData);
        }
    }
}
