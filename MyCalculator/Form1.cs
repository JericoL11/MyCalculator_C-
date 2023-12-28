using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //property
        string Selected_Operator { get; set; }

        double? result { get; set; }



        #region == Clear and BackSpace Functions == 
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            lbl_operand.Text = ".";

            txt_numbers.Text = "0";
        }

        public void Refresh()
        {

            txt_numbers.Clear();
        }

        private void btn_cLast_Click(object sender, EventArgs e)

        {
            //auto-fill 0 if true
            if (txt_numbers.Text.Length == 1)
            {
                txt_numbers.Text = "0";
            }
            else
            {
                try
                {
                    if (txt_numbers.Text == "0")
                    {
                        txt_numbers.Text = "0";
                    }
                    else
                    {
                        string x = txt_numbers.Text;

                        //exclude the last index
                        txt_numbers.Text = x.Substring(0, x.Length - 1);

                    }

                }
                catch
                {
                    txt_numbers.Text = "0";
                }

            }


        }
        #endregion

        #region == Common Function ==
        //if result has value, it will set as null
        public void result_Checker()
        {
            if (!(string.IsNullOrEmpty(result.ToString())))
            {
                result = null;
                txt_numbers.Clear();
            }
        }

        //removed the displayed zero
        public void Default_removeZero()
        {
            if (txt_numbers.Text == "0")
            {
                txt_numbers.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txt_numbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit
            if (char.IsDigit(e.KeyChar))
            {
                // Allow the digit to be entered
                e.Handled = false;
            }
            else
            {
                // Ignore the key press
                e.Handled = true;
            }

        }
        #endregion

        #region == number Inputs == 
        private void btn_0_Click(object sender, EventArgs e)
        {
            Default_removeZero();
            result_Checker();
            txt_numbers.Text += "0";
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            Default_removeZero();
            result_Checker();
            txt_numbers.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            Default_removeZero();
            result_Checker();
            txt_numbers.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            Default_removeZero();
            result_Checker();
            txt_numbers.Text += "3";
        }
        private void btn_4_Click(object sender, EventArgs e)
        {
            Default_removeZero();
            result_Checker();
            txt_numbers.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            Default_removeZero();
            result_Checker();
            txt_numbers.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            Default_removeZero();
            result_Checker();
            txt_numbers.Text += "6";
        }
        private void btn_7_Click(object sender, EventArgs e)
        {
            Default_removeZero();
            result_Checker();

            txt_numbers.Text += "7";

        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            Default_removeZero();
            result_Checker();
            txt_numbers.Text += "8";

        }
        private void btn_9_Click(object sender, EventArgs e)
        {
            result_Checker();
            txt_numbers.Text += "9";
        }



        private void btn_point_Click(object sender, EventArgs e)
        {
            //text box must only contain 1 point/dot
            if (!(txt_numbers.Text.Contains(".")))
            {
                txt_numbers.Text += ".";
            }

        }
        #endregion

        #region == Operators ==
        private void btn_sum_Click(object sender, EventArgs e)
        {
      
            //for auto compute if both data are not null
            if (!(lbl_operand.Text == "." && !(string.IsNullOrEmpty(txt_numbers.Text))))
            {
             
                Compute_Now();
               
            }
      
            lbl_operand.Text = txt_numbers.Text;
            Selected_Operator = "Add";
            Refresh();


        }


        private void btn_subtract_Click(object sender, EventArgs e)
        {
            //for auto compute if both data are not null
            if (!(lbl_operand.Text == "." && !(string.IsNullOrEmpty(txt_numbers.Text))))
            {
                Compute_Now();
            }

            lbl_operand.Text = txt_numbers.Text;
            Refresh();
            Selected_Operator = "Subtract";

        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            if (!(lbl_operand.Text == "." && !(string.IsNullOrEmpty(txt_numbers.Text))))
            {
                Compute_Now();
            }


            lbl_operand.Text = txt_numbers.Text;
            Refresh();
            Selected_Operator = "Multiply";
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            if (!(lbl_operand.Text == "." && !(string.IsNullOrEmpty(txt_numbers.Text))))
            {
                Compute_Now();
            }

            lbl_operand.Text = txt_numbers.Text;
            Refresh();
            Selected_Operator = "Divide";
        }

        private void btn_modulo_Click(object sender, EventArgs e)
        {
            if (!(lbl_operand.Text == "." && !(string.IsNullOrEmpty(txt_numbers.Text))))
            {
                Compute_Now();
            }

            lbl_operand.Text = txt_numbers.Text;
            Refresh();
            Selected_Operator = "Modulus";
        }
        private void btn_equals_Click(object sender, EventArgs e)
        {
            Compute_Now();

        }
        #endregion

        #region == Calculation and Enum == 
        public enum Operator
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Modulus,
        }


        //funtion with parameters. 
        // this is the main source of the "Calculation_Now Function"

        //num1 represent as the x
        //builderNumbers represent as the y
        public double Calculation(double num1, Form1.Operator op = Operator.Add, double builderNumbers = 0)
        {

            switch (op)
            {
                case Operator.Add: return num1 + builderNumbers;
                case Operator.Subtract: return num1 - builderNumbers;
                case Operator.Multiply: return num1 * builderNumbers;
                case Operator.Divide: return num1 / builderNumbers;
                case Operator.Modulus: return num1 % builderNumbers;
                default: return 0;
            }
        }

        //Computation Function
        public void Compute_Now()
        {
            try
            {
                double x = Convert.ToDouble(lbl_operand.Text);
                double y = Convert.ToDouble(txt_numbers.Text);

                switch (Selected_Operator)
                {
                    case "Add":
                        {
                            //uses Calculation function that returns the result

                            result = Calculation(x, Operator.Add, y);
                            lbl_operand.Text = ".";
                            txt_numbers.Text = result.ToString();
                            break;
                        }
                    case "Subtract":
                        {

                            result = Calculation(x, Operator.Subtract, y);
                            lbl_operand.Text = ".";
                            txt_numbers.Text = result.ToString();
                            break;
                        }
                    case "Multiply":
                        {

                            result = Calculation(x, Operator.Multiply, y);
                            lbl_operand.Text = ".";
                            txt_numbers.Text = result.ToString();
                            break;
                        }
                    case "Divide":
                        {

                            result = Calculation(x, Operator.Divide, y);
                            lbl_operand.Text = ".";
                            txt_numbers.Text = result.ToString();
                            break;
                        }
                    case "Modulus":
                        {

                            result = Calculation(x, Operator.Modulus, y);
                            lbl_operand.Text = ".";
                            txt_numbers.Text = result.ToString();
                            break;
                        }
                }
            }
            catch
            {
                txt_numbers.Text = "0";

            }
        } 
        #endregion


        
    }
}