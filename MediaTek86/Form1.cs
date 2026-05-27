using System;
using System.Windows.Forms;

namespace MediaTek86
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Action quand on clique sur le bouton
        private void button1_Click(object sender, EventArgs e)
        {
            // On ouvre la fenêtre des absences en simulant l'employé n°1
            MediaTek86.vue.FrmAbsence fenetreAbsence = new MediaTek86.vue.FrmAbsence(1);
            fenetreAbsence.ShowDialog();
        }
    }
}