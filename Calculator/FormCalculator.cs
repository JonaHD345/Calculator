using System;
using System.Windows.Forms;

namespace Taschenrechner
{
  public partial class Tachenrechner : Form
  {

    //Status ob man die Rechnung beendet wurde
    private bool finish;

    //Status ob ein Komma gesetzt wurde
    private bool comma;
    public Tachenrechner()
    {
      InitializeComponent();
      finish = false;
      comma = false;
    }

    #region "Button Click Events"
    //Resetet das Label
    private void CmdReset_Click(object sender, EventArgs e)
    {
      LblResultShow.Text = "0";
      finish = false;
    }

    //Eingabe der Zahlen, Rechenoperation
    private void CmdNumber1_Click(object sender, EventArgs e)
    {
      enterNumber(1);
    }

    private void CmdNumber2_Click(object sender, EventArgs e)
    {
      enterNumber(2);
    }

    private void CmdNumber3_Click(object sender, EventArgs e)
    {
      enterNumber(3);
    }

    private void CmdNumber4_Click(object sender, EventArgs e)
    {
      enterNumber(4);
    }

    private void CmdNumber5_Click(object sender, EventArgs e)
    {
      enterNumber(5);
    }

    private void CmdNumber6_Click(object sender, EventArgs e)
    {
      enterNumber(6);
    }

    private void CmdNumber7_Click(object sender, EventArgs e)
    {
      enterNumber(7);
    }

    private void CmdNumber8_Click(object sender, EventArgs e)
    {
      enterNumber(8);
    }

    private void CmdNumber9_Click(object sender, EventArgs e)
    {
      enterNumber(9);
    }

    private void CmdNumber0_Click(object sender, EventArgs e)
    {
      if (!(firstNumber()))
      {
        if (finish)
        {
          LblResultShow.Text = "0";
          finish = false;
        }
        else
        {
          LblResultShow.Text = LblResultShow.Text + "0";
        }
      }
    }
    
    private void CmdOperationComma_Click(object sender, EventArgs e)
    {
      enterOperation(",");
    }

    private void CmdOperationPlus_Click(object sender, EventArgs e)
    {
      enterOperation("+");
    }

    private void CmdOperationMinus_Click(object sender, EventArgs e)
    {
      enterOperation("-");
    }

    private void CmdOperationMultiply_Click(object sender, EventArgs e)
    {
      enterOperation("*");
    }

    private void CmdOperationDivide_Click(object sender, EventArgs e)
    {
      enterOperation("/");
    }

    private void CmdOperationRoot_Click(object sender, EventArgs e)
    {
      enterOperation("?");
    }

    //Befehl zum Ausgabe des Ergebnisses
    private void CmdOperationResult_Click(object sender, EventArgs e)
    {
      if (!(finish))
      {
        string all;
        all = LblResultShow.Text;


        if (all.Contains("+"))
        {
          printResult("+");
        }
        else if (all.Contains("-"))
        {
          printResult("-");
        }
        else if (all.Contains("/"))
        {
          printResult("/");
        }
        else if (all.Contains("*"))
        {
          printResult("*");
        }
        else if (all.Contains("?"))
        {
          printResult("?");
        }
      }
    }
    #endregion

    #region "Basis Logik"
   
    //Eingabe einer Zahl
    private void enterNumber(double x)
    {
      if (firstNumber())
      {
        LblResultShow.Text = x.ToString();
      }
      else
      {
        if (finish)
        {
          LblResultShow.Text = x.ToString();
          finish = false;
        }
        else
        {
          LblResultShow.Text = LblResultShow.Text + x.ToString();
        }
      }
    }

    //Eingabe einer Recheoperation
    private void enterOperation(string operation)
    {
      //Überprüfung ob noch keine Rechenoperation schon angeben wurde
      if (!(LblResultShow.Text.Contains("+") || LblResultShow.Text.Contains("-") || LblResultShow.Text.Contains("/") || LblResultShow.Text.Contains("*") || LblResultShow.Text.Contains("?")))
      {
        if (!(firstNumber()))
        {
          if (operation == ",")
          {
            if (!(comma))
            {
              LblResultShow.Text = LblResultShow.Text + operation;
              comma = true;
            }
          }
          else
          {
            LblResultShow.Text = LblResultShow.Text + " " + operation + " ";
          }
        }
        else
        {
          if (operation == "?")
          {
            LblResultShow.Text = operation;
          }
        }
      }
      //Überprüfung ob eine Rechenoperation schon angeben wurde
      else if (LblResultShow.Text.Contains("+") || LblResultShow.Text.Contains("-") || LblResultShow.Text.Contains("/") || LblResultShow.Text.Contains("*") || LblResultShow.Text.Contains("?"))
      {
        if (operation == ",")
        {
          if (comma)
          {
            LblResultShow.Text = LblResultShow.Text + operation;
            comma = false;
          }
        }
      }
    }

    //Augabe eines Ergebnisses
    private void printResult(string operation)
    {
      double firstNumber;
      double secondNumber;
      string all;
      char op;
      op = operation.ToCharArray()[0];
      all = LblResultShow.Text;

      //Ausgabe und zusammen Rechnung des Ergebnisses vom Wurzel rechnen
      if (operation == "?")
      {
        long number;
        number = long.Parse(all.Replace("?", " "));

        LblResultShow.Text = $"?{number} = {Math.Round(Math.Sqrt(number), 5)}";
        finish = true;
        return;
      }

      string[] st = all.Split(op);
      firstNumber = double.Parse(st[0]);
      secondNumber = double.Parse(st[1].TrimEnd('='));
      //Ausgabe und zusammen Rechnung des Ergebnisses der vier Grundrechenarten
      if (operation == "+")
      {
        LblResultShow.Text = $"{firstNumber} + {secondNumber} = {(firstNumber + secondNumber)}";
      }
      else if (operation == "-")
      {
        LblResultShow.Text = $"{firstNumber} - {secondNumber} = {(firstNumber - secondNumber)}";
      }
      else if (operation == "/")
      {
        LblResultShow.Text = $"{firstNumber} / {secondNumber} = {(firstNumber / secondNumber)}";
      }
      else if (operation == "*")
      {
        LblResultShow.Text = $"{firstNumber} * {secondNumber} = {(firstNumber * secondNumber)}";
      }
      finish = true;
    }
    #endregion

    #region "Key Press Event
    //Eingabe der Zahlen und Rechenoperationen durch die Tastatur.
    private void Tachenrechner_KeyDown(object sender, KeyEventArgs e)
    {
      //Zahlen
      if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
      {
        enterNumber(1);
      }
      else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
      {
        enterNumber(2);
      }
      else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
      {
        enterNumber(3);
      }
      else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
      {
        enterNumber(4);
      }
      else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
      {
        enterNumber(5);
      }
      else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
      {
        enterNumber(6);
      }
      else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
      {
        enterNumber(7);
      }
      else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
      {
        enterNumber(8);
      }
      else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
      {
        enterNumber(9);
      }
      else if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
      {
        enterNumber(0);
      }
      else if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
      {
        enterOperation("+");
      }
      else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
      {
        enterOperation("-");
      }
      else if (e.KeyCode == Keys.Multiply)
      {
        enterOperation("*");
      }
      else if (e.KeyCode == Keys.Divide)
      {
        enterOperation("/");
      }
      else if (e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Decimal)
      {
        enterOperation(",");
      }
      else if (e.KeyCode == Keys.Enter)
      {
        string all;
        all = LblResultShow.Text;


        if (all.Contains("+"))
        {
          printResult("+");
        }
        else if (all.Contains("-"))
        {
          printResult("-");
        }
        else if (all.Contains("/"))
        {
          printResult("/");
        }
        else if (all.Contains("*"))
        {
          printResult("*");
        }
        else if (all.Contains("?"))
        {
          printResult("?");
        }
      }
    }
    #endregion

    #region "Checks"
    //Überprüfung ob es die erste Zahl ist.
    private bool firstNumber()
    {
      bool status;
      if (LblResultShow.Text == "0")
      {
        status = true;
      }
      else
      {
        status = false;
      }
      return status;
    }
    #endregion
  }
}
