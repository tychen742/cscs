class Interview
{

  int age = 35;

  public void display()
  {
    Console.WriteLine(age);
  }


  static void Main()  // basic prompt/read/write example
  {

    Interview inter = new Interview();
    inter.display();


    //	Console.WriteLine("age = {0} ", age);
    Console.Write("Enter the interviewee's name: ");
    string name = Console.ReadLine();
    Console.Write("Enter the appointment time: ");
    string time = Console.ReadLine();
    string sentence = InterviewSentence(name, time);
    Console.WriteLine(sentence);
  }

  static string InterviewSentence(string name, string time)
  {

    return string.Format("{0} has an interview at {1}.", name, time);

  }

}