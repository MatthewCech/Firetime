using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TimerApp
{
  public class Line
  {
    // Const delimiters
    public const string NumStartDelimiter  = "[";
    public const string NumEndDelimiter    = "]";
    public const string NameEndDelimiter = ":";
    public const string CompletedIndicator = "*";
    public const string ActualyTimeDelimiter = ">";


    // Parameter list? in c++, it's Constructor(...) : Var(parameter)
    public Line(int timeEst, string name, string description, bool completed = false)
    {
      // Lame hard-coded character omission. This should probably be changed.
      name = name.Replace(NumStartDelimiter, "");
      name = name.Replace(NumEndDelimiter, "");
      name = name.Replace(NameEndDelimiter, "");
      name = name.Replace(ActualyTimeDelimiter, "");
      description = description.Replace(NameEndDelimiter, "");
      description = description.Replace(ActualyTimeDelimiter, "");

      // Member initializer lists, do they exist in C#?
      Name = name;
      Description = description;
      TimeEst = timeEst;
      Completed = completed;
      ActualTime = -1;
    }


    // Just use our existing constructor to do the work for us.
    public static implicit operator Line(string toParse)
    {
      return new Line(toParse);
    }


    // String constructor for line
    public Line(string toParse)
    {
      // Min string to parse: *]:
      if (toParse.Length < 3)
        throw new Exception("STORP");

      // Parse out completion.
      if (toParse[0] == CompletedIndicator[0])
        Completed = true;
      
      // Parse out time estimate.
      int timeEndindex = toParse.IndexOf(NumEndDelimiter) - 1;
      if (timeEndindex < 1)
        TimeEst = 0;
      else
      {
        string timeString = toParse.Substring(1, timeEndindex);
        if (!int.TryParse(timeString, out TimeEst))
          TimeEst = 0;
      }

      // Parse out the name
      int nameIndex = toParse.IndexOf(NameEndDelimiter);
      if (nameIndex == -1)
        throw new Exception("Non existant task delimiter! This should never happen!");
      else
      {
        int timeEnd = toParse.IndexOf(NumEndDelimiter) + 1;
        Name = toParse.Substring(timeEnd, nameIndex - timeEnd);
      }

      // Acquire description
      int descriptionEnd = toParse.IndexOf(ActualyTimeDelimiter);
      if (descriptionEnd == -1)
        Description = toParse.Substring(nameIndex + 1);
      else
        Description = toParse.Substring(nameIndex + 1, descriptionEnd - (nameIndex + 1));

      // Acquire actual time if we have one.
      if (Completed)
      {
        string actualTimeStr = toParse.Substring(toParse.IndexOf(ActualyTimeDelimiter) + 1);
        if (!int.TryParse(actualTimeStr, out ActualTime))
          ActualTime = -1;
      }
    }


    // Convert current item to string
    public override string ToString()
    {
      //Determine delimiter to add at the front.
      string line = "";
      if (Completed)
        line += CompletedIndicator;
      else
        line += NumStartDelimiter;

      // COOL STRING FORMATTING HERE
      // Add the time estimate string.
      line += $"{TimeEst,4}{NumEndDelimiter}{Name}{NameEndDelimiter}";

      // Add description.
      line += Description;

      // Add our time if we don't have it added yet.
      if (Completed)
        if (!line.Contains(ActualyTimeDelimiter))
          line += ActualyTimeDelimiter + ActualTime;

      return line;
    }


    // Mark this task as completed.
    public void CompleteTask(int actualTime)
    {
      ActualTime = actualTime;
      Completed = true;
    }



    // Variables
    public string Name;
    public string Description;
    public int    TimeEst;
    public int    ActualTime;
    public bool   Completed;
  }
}
