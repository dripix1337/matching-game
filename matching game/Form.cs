using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matching_game
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Random random = new Random();
        private List<string> lIcons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        private Label pFirstClicked = null;

        private void RestartGame()
        {
            List<string> icons = new List<string>(lIcons);

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = (Label)control;
                if (iconLabel != null)
                {
                    iconLabel.ForeColor = Color.Black;

                    int iRandomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[iRandomNumber];
                    icons.RemoveAt(iRandomNumber);
                }
            }
        }

        private int getIconsCount()
        {
            int i = 0;

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = (Label)control;
                if (iconLabel != null)
                    if (iconLabel.ForeColor != iconLabel.BackColor)
                        i++;
            }

            return i;
        }

        public Form()
        {
            InitializeComponent();
            RestartGame();
        }

        private void onLabelClick(object pSender, EventArgs e)
        {
            Label pClickedLabel = (Label)pSender;
            if (pClickedLabel != null)
            {
                if (pClickedLabel.ForeColor == pClickedLabel.BackColor)
                    return;

                if (pFirstClicked != null)
                {
                    if (pFirstClicked.Text == pClickedLabel.Text)
                    {
                        pClickedLabel.ForeColor = pClickedLabel.BackColor;
                        pFirstClicked = null;

                        if (getIconsCount() == 0)
                        {
                            MessageBox.Show("Вы угадали все картинки!", "Matching game");
                            RestartGame();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не угадали", "Matching game");
                    }
                }
                else
                {
                    pFirstClicked = pClickedLabel;
                    pClickedLabel.ForeColor = pClickedLabel.BackColor;
                }
            }
        }
    }
}
