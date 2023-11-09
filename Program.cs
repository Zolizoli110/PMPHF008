namespace PMPHF007
{

  enum LogicalGates
  {
    AND,
    OR,
    NOT,
    NAND,
    NOR,
    XOR,
    XNOR,
  }

  class Program
  {
    static double[] values1;
    static double[] values2;
    static double[] output;
    static LogicalGates logicalGate;
    static void Main()
    {
      ReadIn();
      Logic();
      Console.Clear();
      for (int i = 0; i < output.Length; i++)
      {
        if (output[i] == -1)
        {
          Console.Write('E');
        }
        else
        {
          Console.Write(output[i]);
        }
      }
      Console.WriteLine();
    }

    static void ReadIn()
    {
      string[] line = Console.ReadLine().Split(' ');
      logicalGate = (LogicalGates) Enum.Parse(typeof(LogicalGates), line[0]);
      if (line.Length == 2)
      {
        ReadInValues(line[1], "");
      }
      else
      {
        ReadInValues(line[1], line[2]);
      }
    }

    static void ReadInValues(string value1, string value2)
    {
      string line = Console.ReadLine();

      while (line != "")
      {
        string[] split = line.Split(' ');

        if (split[0] == value1 )
        {
          
          values1 = new double[(split[1].Length) / 2];
          Save(values1, split[1]);
        }
        else if (split[0] == value2)
        {
          values2 = new double[(split[1].Length) / 2];
          Save(values2, split[1]);
        }
        line = Console.ReadLine();
      }
    }

    static void Logic()
    {
      output = new double[values1.Length];
      switch (logicalGate)
      {
        case LogicalGates.AND:
          for (int i = 0; i < values1.Length; i++)
          {
            if (values1[i] == values2[i])
            {
              output[i] = values1[i];
            }
            else if (values1[i] == -1 || values2[i] == -1)
            {
              output[i] = -1;
            }
            else
            {
              output[i] = 0;
            }
          }
          break;
        case  LogicalGates.OR:
          for (int i = 0; i < values1.Length; i++)
          {
            if (values1[i] == -1 || values2[i] == -1)
            {
              output[i] = -1;
            }
            else if (values1[i] == 1 || values2[i] == 1)
            {
              output[i] = 1;
            }
            else
            {
              output[i] = 0;
            }
          }
          break;
        case LogicalGates.NOT:
          for (int i = 0; i < values1.Length; i++)
          {
            if (values1[i] == 1)
            {
              output[i] = 0;
            }
            else if (values1[i] == 0)
            {
              output[i] = 1;
            }
            else
            {
              output[i] = -1;
            }
          }
          break;
        case LogicalGates.NAND:
          for (int i = 0; i < values1.Length; i++)
          {
            if (values1[i] == values2[i])
            {
              if (values1[i] == 1)
              {
                output[i] = 0;
              }
              else
              {
                output[i] = 1;
              }
            }
            else if (values1[i] == -1 || values2[i] == -1)
            {
              output[i] = -1;
            }
            else
            {
              output[i] = 1;
            }
          }
          break;
        case LogicalGates.NOR:
          for (int i = 0; i < values1.Length; i++)
          {
            if (values1[i] == 1 || values2[i] == 1)
            {
              output[i] = 0;
            }
            else if (values1[i] == -1 || values2[i] == -1)
            {
              output[i] = -1;
            }
            else
            {
              output[i] = 1;
            }
          }
          break;
        case LogicalGates.XOR:
          for (int i = 0; i < values1.Length; i++)
          {
            if (values1[i] == 0 && values2[i] == 1)
            {
              output[i] = 1;
            }
            else if (values1[i] == 1 && values2[i] == 0)
            {
              output[i] = 1;
            }
            else if (values1[i] == -1 || values2[i] == -1)
            {
              output[i] = -1;
            }
            else
            {
              output[i] = 0;
            }
          }
          break;
        case LogicalGates.XNOR:
          for (int i = 0; i < values1.Length; i++)
          {
            if (values1[i] == 0 && values2[i] == 1)
            {
              output[i] = 0;
            }
            else if (values1[i] == 1 && values2[i] == 0)
            {
              output[i] = 0;
            }
            else if (values1[i] == -1 || values2[i] == -1)
            {
              output[i] = -1;
            }
            else
            {
              output[i] = 1;
            }
          }
          break;
        default:
          break;
      }
    }

    static void Save(double[] values, string givenValue)
    {
      for (int i = 0; i < givenValue.Length; i++)
      {
        string value = Convert.ToString(givenValue[i] + "." + givenValue[++i]);
        values[(i - 1) / 2] = double.Parse(value);
      }
      Check(values);
    }

    static void Check(double[] values)
    {
      for (int i = 0; i < values.Length; i++)
      {
        if (values[i] >= 0 && values[i] <= 0.8)
          values[i] = 0;
        else if (values[i] >= 2.7 && values[i] <= 5)
          values[i] = 1;
        else
          values[i] = -1;
      }
    }
  }
}
