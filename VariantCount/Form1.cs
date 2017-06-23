using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace VariantCount
{
    public partial class Form1 : Form
    {

        private List<Item> Items;
        /// <summary>
        /// Кількість одночасно натиснених кнопок для створення події
        /// </summary>
        public int trueItemsCount { get; private set; } = 5;
        /// <summary>
        /// Кількість кнопок
        /// </summary>
        public int ItemsCount { get; private set; } = 10;

        public Form1()
        {
            InitializeComponent();
            /*
            Items = new List<Item>()
            {
                new Item("Вечеря", 120),
                new Item("Алкоголь", 58),
                new Item("Сніданок", 17),
                new Item("Нічліг", 50),
                new Item("Трансфер", 125),
                new Item("Чайові", 125),
            };
            */
            Items = new List<Item>();
            for (int i = 0; i < ItemsCount; i++)
            {
                Items.Add(new Item(i.ToString(), 1));
            }
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            MyRows result = new MyRows();
            for (int i = 0; i < Items.Count; i++)
            {
                result.Fields.Add(Items[i].Name);
            }
            result.Fields.Add("Сума");
            List<KeyValuePair<string, IComparer>> gridHeaders = new List<KeyValuePair<string, IComparer>>();
            for (int i = 0; i < result.Fields.Count; i++)
            {
                gridHeaders.Add(new KeyValuePair<string, IComparer>(result.Fields[i], null));
            }
            Fill fill = new Fill(result.Fields);

            string bVariantCount = "";
            for (int i = 0; i < Items.Count; i++)
            {
                bVariantCount += "1";
            }

            int count = Convert.ToInt32(bVariantCount, 2);            
            for (int i = 0; i <= count; i++)
            {
                //https://stackoverflow.com/questions/6758196/convert-int-to-a-bit-array-in-net
                string s = Convert.ToString(i, 2); //Convert to binary in a string
                int[] bits = s.PadLeft(Items.Count, '0') // Add 0's from left
                             .Select(c => int.Parse(c.ToString())) // convert each char to int
                             .ToArray(); // Convert IEnumerable from select to Array

                MyRow row = new MyRow();
                double sum = 0;
                int trueCount = 0;
                
                for (int j = 0; j < Items.Count; j++)
                {
                    double price;
                    int cell = bits[j];
                    if (cell != 0)
                    {
                        trueCount++;
                        price = Items[j].Price;
                    }
                    else
                    {
                        price = 0;
                    }
                    price = (cell == 0 ? 0 : Items[j].Price);
                    sum += price;
                    row.Add(result.Fields[j], price);
                }
                row.Add("Сума", sum);
                if (trueItemsCount == 0 || trueCount == trueItemsCount)
                {
                    result.Rows.Add(row);
                }
            }
            tssl_Count.Text = result.Rows.Count.ToString();

            fill.GridFill(sg_Result, result.Rows, null, gridHeaders);
        }

        MyRows getVariants()
        {
            return null;
        }
    }
}