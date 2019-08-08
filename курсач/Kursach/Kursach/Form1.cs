using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Form1 : Form
    {


        OpenFileDialog openFileDialog;
        SaveFileDialog saveFileDialog;

        List<Patient> patients = new List<Patient>();

        public Form1()
        {
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            InitializeComponent();
        }
        bool InputIsPositiveDigit(string st)
        {
            bool check = false;
            int temp;
            if (int.TryParse(st, out temp) == true && temp >= 0)
                check = true;

            return check;
        }
        void UpdateT()
        {

            dataGridView1.Rows.Clear();
            foreach (var patient in patients)
            {
                dataGridView1.Rows.Add(patient.Name, patient.AccountNumber, patient.TypeOfWork, patient.Cost, patient.PaymentStamp,patient.Debt);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (InputIsPositiveDigit(textBox1.Text) && InputIsPositiveDigit(textBox3.Text) && InputIsPositiveDigit(textBox6.Text))
            {
                patients.Add(new Patient()
                {
                    Name =textBox2.Text,
                    AccountNumber = Convert.ToInt32(textBox1.Text),
                    TypeOfWork = comboBox1.Text,
                    Cost = Convert.ToInt32(textBox3.Text),
                    PaymentStamp = comboBox2.Text,
                    Debt = Convert.ToInt32(textBox6.Text)
                });
            }
            else
            {
                MessageBox.Show("Введите положительное число!");
            }
            

            UpdateT();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.SelectedRows[0].Index != this.dataGridView1.Rows.Count - 1)
            {
                int row = this.dataGridView1.SelectedRows[0].Index;
                this.dataGridView1.Rows.RemoveAt(row);
                patients.RemoveAt(row);
            }
            UpdateT();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.SelectedRows[0].Index != this.dataGridView1.Rows.Count - 1)
            {

                int index = this.dataGridView1.SelectedRows[0].Index;
                if (InputIsPositiveDigit(textBox1.Text) && InputIsPositiveDigit(textBox3.Text) && InputIsPositiveDigit(textBox6.Text))
                {
                    patients[index].Name = textBox2.Text;
                    patients[index].AccountNumber = Convert.ToInt32(textBox1.Text);
                    patients[index].TypeOfWork = comboBox1.Text;
                    patients[index].Cost = Convert.ToInt32(textBox3.Text);
                    patients[index].PaymentStamp = comboBox2.Text;
                    patients[index].Debt = Convert.ToInt32(textBox6.Text);
                }
                else
                {
                    MessageBox.Show("Введите положительное число!");
                }
               
            }
            UpdateT();
        }



        private void ОчиститьВсеЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patients.Clear();
            UpdateT();
        }

      

        private void Button6_Click(object sender, EventArgs e)
        {
            patients = patients.Where(x => x.Debt != 0).ToList();
            UpdateT();

        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog.FileName;

            FileStream fsR = new FileStream(filename, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fsR, Encoding.UTF8);


            int length = br.ReadInt32();


            for (int i = 0; i < length; i++)
            {
                patients.Add(Patient.Read(br));
            }

            dataGridView1.Rows.Clear();

            UpdateT();

            // Закрываем потоки
            br.Close();
            fsR.Close();
        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog.FileName;



            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);

            int length = patients.Count;
            bw.Write(length);

            foreach (var patient in patients)
                patient.Write(bw);


            
            bw.Close();
            fs.Close();
            MessageBox.Show("Файл сохранен");
        }

        private void ПоказатьВсеЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateT();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string keyWord = textBox5.Text;

            bool flag = false;

            switch (comboBox3.Text)
            {
                case "ФИО пациента":
                    foreach (var patient in patients)
                    {
                        if (patient.Name ==keyWord)
                        {
                            dataGridView1.Rows.Add(patient.Name, patient.AccountNumber, patient.TypeOfWork, patient.Cost, patient.PaymentStamp, patient.Debt);
                            flag = true;
                        }
                    }
                    break;
                case "№ учёт.карточки":
                    foreach (var patient in patients)
                    {
                        if (patient.AccountNumber == Convert.ToInt32(keyWord))
                        {
                            dataGridView1.Rows.Add(patient.Name, patient.AccountNumber, patient.TypeOfWork, patient.Cost, patient.PaymentStamp, patient.Debt);
                            flag = true;
                        }
                    }
                    break;
                case "Стоимость выполнения":
                    foreach (var patient in patients)
                    {
                        if (patient.Cost == Convert.ToInt32(keyWord))
                        {
                            dataGridView1.Rows.Add(patient.Name, patient.AccountNumber, patient.TypeOfWork, patient.Cost, patient.PaymentStamp, patient.Debt);
                            flag = true;
                        }
                    }
                    break;
                case "Задолженность":
                    foreach (var patient in patients)
                    {
                        if (patient.Debt == Convert.ToInt32(keyWord))
                        {
                            dataGridView1.Rows.Add(patient.Name, patient.AccountNumber, patient.TypeOfWork, patient.Cost, patient.PaymentStamp, patient.Debt);
                            flag = true;
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Вы не выбрали поле!");
                    break;
            }
            if(flag == false)
            {
                MessageBox.Show("Записи не найдены!");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string keyWord = textBox4.Text;

            bool flag = false;

            foreach (var patient in patients)
            {
                if (patient.Name == keyWord)
                {
                    dataGridView1.Rows.Add(patient.Name, patient.AccountNumber, patient.TypeOfWork, patient.Cost, patient.PaymentStamp, patient.Debt);
                    flag = true;
                }
            }

            if (flag == false)
            {
                MessageBox.Show("Записи не найдены!");
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
           

            bool flag = false;

            switch (comboBox4.Text)
            {
                case "Протезирование":
                    foreach (var patient in patients)
                    {
                        if (patient.TypeOfWork == "Протезирование" && patient.Debt > 0)
                            dataGridView1.Rows.Add(patient.Name, patient.AccountNumber, patient.TypeOfWork, patient.Cost, patient.PaymentStamp, patient.Debt);

                        flag = true;
                        
                    }
                    break;
                case "Пломбирование":
                    foreach (var patient in patients)
                    {
                        if (patient.TypeOfWork == "Пломбирование" && patient.Debt > 0)
                            dataGridView1.Rows.Add(patient.Name, patient.AccountNumber, patient.TypeOfWork, patient.Cost, patient.PaymentStamp, patient.Debt);

                        flag = true;
                       
                    }
                    break;
                case "Имплантация":
                    foreach (var patient in patients)
                    {
                        if (patient.TypeOfWork == "Имплантация" && patient.Debt > 0)
                            dataGridView1.Rows.Add(patient.Name, patient.AccountNumber, patient.TypeOfWork, patient.Cost, patient.PaymentStamp, patient.Debt);

                        flag = true;
                        
                    }
                    break;
               
                default:
                    MessageBox.Show("Вы не выбрали поле!");
                    break;
            }
            if (flag == false)
            {
                MessageBox.Show("Записи не найдены!");
            }
        }
    }
}
