using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonAgro
{
    public class Util
    {

        public static void OpenAndSaveProductsPath(TextBox textBox, Form form)
        {
            //Salvar diretório
            if (Properties.Settings.Default.productsPath != null)
                textBox.Text = GetProductsPath();

            form.FormClosing += delegate
            {
                Properties.Settings.Default.productsPath = textBox.Text;
                Properties.Settings.Default.Save();
            };
        }

        public static string GetProductsPath()
        {
            if (Properties.Settings.Default.productsPath != null)
                return Properties.Settings.Default.productsPath;

            return "";
        }

        public static float ReplaceNaN(float value)
        {
            if (float.IsNaN(value) || float.IsInfinity(value))
                return 0;

            return value;
        }

    }
}
