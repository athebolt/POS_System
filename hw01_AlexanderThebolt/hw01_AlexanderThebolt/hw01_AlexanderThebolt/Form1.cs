//================================
//Name: Alexander Thebolt
//Date: 02-17-2024
//Desc: Point Of Sale (POS) System
//================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw01_AlexanderThebolt
{
    public partial class form1 : Form
    {
        //global variables used by the class only
        private int bAmt;
        private int wmAmt;
        private int wAmt;
        private int cAmt;
        private int dAmt;
        private int sAmt;

        public form1()
        {
            InitializeComponent();

            //here to set up the buttons and labels text
            InitFormLabelsAndButtons();
        }

        private void InitFormLabelsAndButtons()
        {
            //creating a DateTime variable of time now
            DateTime dt = DateTime.Now;

            //turning the DateTime into a custom string to be displayed in the form
            lbl_Date.Text = dt.ToString("MMMM d, yyyy   h:mm tt");

            //random number gen
            Random r = new Random();

            //next random number of min 0 and max 999 stored into order
            int order = r.Next(999);

            //setting order text to random order number
            lbl_order.Text = order.ToString();

            //setting everything to 0 or blank as the program is initalized
            lbl_items.Text = "";
            lbl_total.Text = "";

            bAmt = 0;
            wmAmt = 0;
            wAmt = 0;
            cAmt = 0;
            dAmt = 0;
            sAmt = 0;

            lbl_butterCnt.Text = "0";
            lbl_melonCnt.Text = "0";
            lbl_waterCnt.Text = "0";
            lbl_capeCnt.Text = "0";
            lbl_dirtCnt.Text = "0";
            lbl_superCnt.Text = "0";

            //subtract buttons cannot be used since all the labels are 0
            btn_butterSub.Enabled = false;
            btn_melonSub.Enabled = false;
            btn_waterSub.Enabled = false;
            btn_capeSub.Enabled = false;
            btn_dirtSub.Enabled = false;
            btn_superSub.Enabled = false;
        }

        private void SetupTotal(double total)
        {
            //calculates michigan sales tax
            double tax = total * .06;

            //displays subtotal, tax, and total using PadRight function to line up properly
            lbl_total.Text = String.Format("=========================================\n" +
                                           "Subtotal".PadRight(65) + " $" + total.ToString("0.00") + "\n" +
                                           "Tax".PadRight(70) + "$" + tax.ToString("0.00") + "\n" +
                                           "Total".PadRight(69) + "$" + (tax + total).ToString("0.00"));
        }

        private void UpdateItemDisplay()
        {
            //item names
            string b = "Butter";
            string wm = "Watermelon";
            string w = "Water";
            string c = "Cape";
            string d = "Dirt";
            string s = "Superpower";

            //item costs
            double bTot = bAmt * 5;
            double wmTot = wmAmt * 1.5;
            double wTot = wAmt * .07;
            double cTot = cAmt * 15;
            double dTot = dAmt * .03;
            double sTot = sAmt * 900;

            //creating what is displayed for the items
            string display = "";

            if(bAmt != 0)
            {
                display += b + bAmt.ToString().PadLeft(35) + "$".PadLeft(30) + bTot.ToString("0.00") + "\n";
            }

            if (wmAmt != 0)
            {
                display += wm + wmAmt.ToString().PadLeft(24) + "$".PadLeft(30) + wmTot.ToString("0.00") + "\n";
            }

            if (wAmt != 0)
            {
                display += w + wAmt.ToString().PadLeft(35) + "$".PadLeft(30) + wTot.ToString("0.00") + "\n";
            }

            if (cAmt != 0)
            {
                display += c + cAmt.ToString().PadLeft(36) + "$".PadLeft(30) + cTot.ToString("0.00") + "\n";
            }

            if (dAmt != 0)
            {
                display += d + dAmt.ToString().PadLeft(39) + "$".PadLeft(30) + dTot.ToString("0.00") + "\n";
            }

            if (sAmt != 0)
            {
                display += s + sAmt.ToString().PadLeft(24) + "$".PadLeft(30) + sTot.ToString("0.00") + "\n";
            }

            //setting the display for the label text
            lbl_items.Text = display;

            //total is all the subtotals added
            double total = bTot + wmTot + wTot + cTot + dTot + sTot;

            //if there is nothing in the display string, then there is no total
            if (display.Equals(""))
            {
                lbl_total.Text = "";
            }
            else
            {
                SetupTotal(total);
            }
        }

        private void Btn_newOrder_Click(object sender, EventArgs e)
        {
            //reset form with updated time and new order number
            InitFormLabelsAndButtons();
        }

        private void Btn_AddEventHandler(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(sender, btn_butterAdd))
            {
                bAmt++;

                lbl_butterCnt.Text = bAmt.ToString();

                btn_butterSub.Enabled = true;
            }
            else if (Object.ReferenceEquals(sender, btn_melonAdd))
            {
                wmAmt++;

                lbl_melonCnt.Text = wmAmt.ToString();

                btn_melonSub.Enabled = true;
            }
            else if (Object.ReferenceEquals(sender, btn_waterAdd))
            {
                wAmt++;

                lbl_waterCnt.Text = wAmt.ToString();

                btn_waterSub.Enabled = true;
            }
            else if (Object.ReferenceEquals(sender, btn_capeAdd))
            {
                cAmt++;

                lbl_capeCnt.Text = cAmt.ToString();

                btn_capeSub.Enabled = true;
            }
            else if (Object.ReferenceEquals(sender, btn_dirtAdd))
            {
                dAmt++;

                lbl_dirtCnt.Text = dAmt.ToString();

                btn_dirtSub.Enabled = true;
            }
            else if (Object.ReferenceEquals(sender, btn_superAdd))
            {
                sAmt++;

                lbl_superCnt.Text = sAmt.ToString();

                btn_superSub.Enabled = true;
            }

            UpdateItemDisplay();
        }

        private void Btn_SubEventHandler(object sender, EventArgs e)
        {
            if (Object.ReferenceEquals(sender, btn_butterSub))
            {
                bAmt--;

                lbl_butterCnt.Text = bAmt.ToString();

                if(bAmt <= 0)
                    btn_butterSub.Enabled = false;
            }
            else if (Object.ReferenceEquals(sender, btn_melonSub))
            {
                wmAmt--;

                lbl_melonCnt.Text = wmAmt.ToString();
                
                if(wmAmt <= 0)
                    btn_melonSub.Enabled = false;
            }
            else if (Object.ReferenceEquals(sender, btn_waterSub))
            {
                wAmt--;

                lbl_waterCnt.Text = wAmt.ToString();

                if (wAmt <= 0)
                    btn_waterSub.Enabled = false;
            }
            else if (Object.ReferenceEquals(sender, btn_capeSub))
            {
                cAmt--;

                lbl_capeCnt.Text = cAmt.ToString();

                if (cAmt <= 0)
                    btn_capeSub.Enabled = false;
            }
            else if (Object.ReferenceEquals(sender, btn_dirtSub))
            {
                dAmt--;

                lbl_dirtCnt.Text = dAmt.ToString();

                if (dAmt <= 0)
                    btn_dirtSub.Enabled = false;
            }
            else if (Object.ReferenceEquals(sender, btn_superSub))
            {
                sAmt--;

                lbl_superCnt.Text = sAmt.ToString();

                if (sAmt <= 0)
                    btn_superSub.Enabled = false;
            }

            UpdateItemDisplay();
        }
    }
}
