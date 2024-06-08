using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void decrypt_key()
        {
            String key = textBox2.Text;
            String text = textBox1.Text.Replace("  ", "-").Replace(" ", "");
            StringBuilder result = new StringBuilder();
            String keySort = String.Concat(key.OrderBy(keyElement => keyElement));
            decimal row = Math.Ceiling(Convert.ToDecimal(text.Length) / Convert.ToDecimal(key.Length));
            String[] result1 = new String[key.Length];
            String[] result2 = new String[key.Length];
            int n = 0;
            Boolean checkNull = false;
            for (int i = 0; i < key.Length; i++)
            {
                if (checkNull == true)
                {
                    n++;
                    checkNull = false;
                }
                for (int j = 0; j <= row; j++)
                {
                    if (n < text.Length)
                    {
                        if (checkNull || text[n] == '-')
                        {
                            checkNull = true;
                            result1[i] += "";
                        }
                        else
                        {
                            result1[i] += text[n];
                            n++;
                        }
                    }
                }
            }
            for (int keySortIndex = 0; keySortIndex < keySort.Length; keySortIndex++)
            {
                int index = keySort.IndexOf(key[keySortIndex]);
                result2[keySortIndex] = result1[index];
                StringBuilder stringBuilder = new StringBuilder(keySort);
                stringBuilder[index] = '-';
                keySort = stringBuilder.ToString();
            }
            for (int i = 0; i < result2.Length; i++)
            {
                result.Append(result2[i]);

            }
            textBox3.Text = result.ToString();
        }
        private void decrypt_no_key()
        {
            int key = int.Parse(textBox2.Text);
            int colCount = key / 10 - 1;
            int rowCount = key % 10 - 1;
            String text1 = textBox1.Text.Replace(" ", "");
            int cipher = (rowCount + 1) - ((colCount + 1) * (rowCount + 1) - text1.Length);
            StringBuilder result = new StringBuilder("");
            string[] decryptText = textBox1.Text.Split(' ');
            for (int colIndex = 0; colIndex <= colCount - 1; colIndex++)
            {
                for (int textResultIndex = 0; textResultIndex <= decryptText.Length - 1; textResultIndex++)
                {
                    if (decryptText[textResultIndex].Length - 1 >= colIndex)
                    {
                        result.Append(decryptText[textResultIndex][colIndex]);
                    }

                }
            }
            for (int cipherIndex = 0; cipherIndex < cipher; cipherIndex++)
            {
                if (decryptText[cipherIndex].Length - 1 >= colCount)
                {
                    result.Append(decryptText[cipherIndex][colCount]);
                }
            }
            textBox3.Text = result.ToString();
        }

        private void encryption_no_key()
        {
            string varchar = textBox1.Text.Replace(" ", "");
            StringBuilder result = new StringBuilder("");
            int key = int.Parse(textBox2.Text);
            int colCount = key / 10 - 1;
            int rowCount = key % 10 - 1;
            for (int x = 0; x <= rowCount; x++)
            {
                for (int y = 0; y <= colCount; y++)
                {
                    if (y * (rowCount + 1) + x < varchar.Length)
                    {
                        result.Append(varchar[y * (rowCount + 1) + x]);

                    }
                }
                result.Append(" ");
            }
            textBox3.Text = result.ToString();
        }
        private void encryption_key()
        {
            string varchar = textBox1.Text.Replace(" ", "");
            string key = textBox2.Text;
            String keySort = String.Concat(key.OrderBy(keyElement => keyElement));
            decimal row = Math.Ceiling(Convert.ToDecimal(varchar.Length) / Convert.ToDecimal(key.Length));
            String[] result1 = new String[key.Length];
            String[] result2 = new String[key.Length];
            StringBuilder resultText = new StringBuilder("");
            int n = 0;
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j <= row; j++)
                {
                    if (n < varchar.Length)
                    {
                        result1[i] += varchar[n];
                    }
                    n++;
                }
            }
            for (int keySortIndex = 0; keySortIndex < keySort.Length; keySortIndex++)
            {
                int index = key.IndexOf(keySort[keySortIndex]);
                result2[keySortIndex] = result1[index];
                StringBuilder stringBuilder = new StringBuilder(key);
                stringBuilder[index] = '-';
                key = stringBuilder.ToString();
            }
            for (int result2Index = 0; result2Index < result2.Length; result2Index++)
            {
                resultText.Append(result2[result2Index] + ' ');
            }
            textBox3.Text = resultText.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                encryption_no_key();
            }
            if (radioButton2.Checked)
            {
                encryption_key();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                decrypt_no_key();
            }
            if (radioButton2.Checked)
            {
                decrypt_key();
            }
        }
    }
}
