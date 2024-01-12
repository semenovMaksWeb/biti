using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        private List<string> error = new List<string>();
        private Dictionary<string, StatisticDiscipline> statisticDisciplineDictionary = new Dictionary<string, StatisticDiscipline>();
        private Dictionary<string, StatisticGroup> statisticGroup = new Dictionary<string, StatisticGroup>();
        private string[] itemsDiscipline = { "Физика", "Химия", "Математика", "Русский язык", "Литература" };
        private string[] itemsGroup = { "ИФСТ", "ЛРДС", "ДРПГ", "СРФ12" };
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(itemsGroup);
            group.Items.AddRange(itemsGroup);            
            discipline.Items.AddRange(itemsDiscipline);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string item in itemsDiscipline) {
                dataGridView1.Rows.Add(comboBox1.Text, item, textBox1.Text, false);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            error.Clear();
            label1.Text = "";
            statisticDisciplineDictionary = new Dictionary<string, StatisticDiscipline>();
            statisticGroup = new Dictionary<string, StatisticGroup>();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if(dataGridView1[3, i].Value == null)
                {
                    dataGridView1[3, i].Value = false;
                }
                
                if (dataGridView1[1, i].Value == null || dataGridView1[0, i].Value == null)
                {
                    continue;
                }

                Boolean check = (Boolean)dataGridView1[3, i].Value;
                string group = dataGridView1[0, i].Value.ToString();
                string discipline = dataGridView1[1, i].Value.ToString();

                if (!statisticGroup.ContainsKey(group))
                {
                    statisticGroup.Add(group, new StatisticGroup(discipline));
                }
                StatisticGroup statisticGroupItem = statisticGroup[group];

                if (!statisticGroupItem.statisticGroupDisciplineDictionary.ContainsKey(discipline))
                {
                    statisticGroupItem.statisticGroupDisciplineDictionary.Add(discipline, new StatisticGroupDiscipline());
                }            


                if (!statisticDisciplineDictionary.ContainsKey(discipline))
                {
                    statisticDisciplineDictionary.Add(discipline, new StatisticDiscipline());
                }
                StatisticDiscipline statisticDiscipline = statisticDisciplineDictionary[discipline];
                StatisticGroupDiscipline statisticGroupDisciplineDictionary = statisticGroupItem.statisticGroupDisciplineDictionary[discipline];

                if (check == true)
                {
                    statisticGroupDisciplineDictionary.addcountTrue();
                    statisticDiscipline.addcountTrue();
                }
                else
                {
                    statisticGroupDisciplineDictionary.addcountFalse();
                    statisticDiscipline.addcountFalse();
                }
            }

            foreach (KeyValuePair<string, StatisticDiscipline> entry in statisticDisciplineDictionary)
            {
                if (entry.Value.countTrue == 0)
                {
                    entry.Value.relationships = 0;
                }
                else
                {
                    entry.Value.relationships = 100 * entry.Value.countTrue / (entry.Value.countFalse + entry.Value.countTrue);
                }
                if (entry.Value.relationships <= 50)
                {
                    error.Add("успеваемость у дисциплины " + entry.Key + " состоит " + entry.Value.relationships + "%\n");
                }
            }


            foreach (KeyValuePair<string, StatisticGroup> statisticGroupItem in statisticGroup)
            {
                Dictionary<string, StatisticGroupDiscipline> StatisticGroupDiscipline =  statisticGroupItem.Value.statisticGroupDisciplineDictionary;
                foreach (KeyValuePair<string, StatisticGroupDiscipline> StatisticGroupDisciplineItem in StatisticGroupDiscipline)
                {
                    if (StatisticGroupDisciplineItem.Value.countTrue == 0)
                    {
                        StatisticGroupDisciplineItem.Value.relationships = 0;
                    } else
                    {
                        StatisticGroupDisciplineItem.Value.relationships = 100 * StatisticGroupDisciplineItem.Value.countTrue / (StatisticGroupDisciplineItem.Value.countFalse + StatisticGroupDisciplineItem.Value.countTrue);
                    }

                    if (StatisticGroupDisciplineItem.Value.relationships <= 50)
                    {
                        error.Add("успеваемость у группы " + statisticGroupItem.Key + " по дисциплине " + StatisticGroupDisciplineItem.Key + " состоит " + StatisticGroupDisciplineItem.Value.relationships + "%\n");
                    }
                }
                
            }

            foreach (string val in error)
            {
                label1.Text += val;
            }
             
        }
    }
}
