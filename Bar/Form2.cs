using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bar.DataModel;

namespace Bar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
            {
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                textBox2.BackColor = Color.Gray;
                textBox4.BackColor = Color.Gray;
                textBox2.Text = "";
                textBox4.Text = "";
            }
            if (checkBox1.Checked == true)
            {
                textBox2.Enabled = true;
                textBox4.Enabled = true;
                textBox2.BackColor = Color.White;
                textBox4.BackColor = Color.White;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0) { label2.Text = "Название продукта:"; label3.Text = "Тип:"; }
            if(comboBox1.SelectedIndex == 1) { label2.Text = "Тип тары :"; label3.Text = "Время повт. испол.:"; textBox4.Text = ""; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool chek=true;
            if(checkBox1.Checked==true)
            {
                if(textBox1.Text!="" && textBox2.Text != ""&& textBox3.Text != "" && textBox4.Text != "")
                {
                    using (BarContext context = new BarContext())
                    {
                       if(comboBox1.SelectedIndex == 0)
                        {
                            var query = from b in context.Products select b;
                            foreach (var item in query)
                            {
                                if (item.Name == textBox1.Text) { chek = false;
                                    MessageBox.Show("Такой продукт уже есть на складе. Пожалуйста уберите галочку 'Новый продукт'!");
                                    textBox2.Text = "";  textBox4.Text = "";
                                }
                            }
                            if (chek)
                            {
                                Product a = new Product();
                                a.Name = textBox1.Text;
                                a.Price = Convert.ToDouble(textBox2.Text);
                                a.Quantity = Convert.ToDouble(textBox3.Text);
                                a.Type = textBox4.Text;
                                context.Products.Add(a);
                                MessageBox.Show("Продукт успешно добавлен!");
                                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
                            }
                        }
                        if (comboBox1.SelectedIndex == 1)
                        {
                            var query = from b in context.Tars select b;
                            foreach (var item in query)
                            {
                                if (item.Type == textBox1.Text)
                                {
                                    chek = false;
                                    MessageBox.Show("Тара этого типа уже есть на складе. Пожалуйста уберите галочку 'Новая тара'!");
                                    textBox2.Text = ""; textBox4.Text = "";
                                }
                            }
                            if (chek)
                            {
                                Tara a = new Tara();
                                a.Type = textBox1.Text;
                                a.Price = Convert.ToDouble(textBox2.Text);
                                a.Quantity = Convert.ToDouble(textBox3.Text);
                                a.ReUse_time = Convert.ToDouble(textBox4.Text);
                                context.Tars.Add(a);
                                MessageBox.Show("Тара успешно добавлена!");
                                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
                            }
                        }

                        
                        context.SaveChanges();
                    }
                }
            } else
            {
                if (textBox1.Text != "" &&  textBox3.Text != "" )
                {
                    using (BarContext context = new BarContext())
                    {
                        if (comboBox1.SelectedIndex == 0)
                        {
                            var query = from b in context.Products
                                        where (b.Name==textBox1.Text)
                                        select b;
                            foreach (var item in query)
                            {
                                item.Quantity += Convert.ToDouble(textBox3.Text);
                                MessageBox.Show("Количество продукта:-"+item.Name+"- увеличено на:"+textBox3.Text);
                            }
                        }
                        if (comboBox1.SelectedIndex == 1)
                        {
                            var query = from b in context.Tars
                                        where (b.Type == textBox1.Text)
                                        select b;
                            foreach (var item in query)
                            {
                                item.Quantity += Convert.ToDouble(textBox3.Text);
                                MessageBox.Show("Количество тар, типа:-" + item.Type + "- увеличено на:" + textBox3.Text);
                            }
                        }
                        textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
                        context.SaveChanges();
                    }
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) ||
            (!string.IsNullOrEmpty(textBox2.Text) && e.KeyChar == ','))
            {
                return;
            }

            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) ||
           (!string.IsNullOrEmpty(textBox3.Text) && e.KeyChar == ','))
            {
                return;
            }

            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                if (Char.IsNumber(e.KeyChar) ||
               (!string.IsNullOrEmpty(textBox2.Text) && e.KeyChar == ','))
                {
                    return;
                }

                e.Handled = true;
            }
        }
    }
}
