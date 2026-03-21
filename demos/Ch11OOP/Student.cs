    namespace IntroCSCS
    {
        public class Student
        {
            private string studentName;     // private variables declared
            private int studentAge;         // these can only be accessed by public getter/setter

            public string Name              // getter/setter to access studentName
            {
                get { return studentName; }
                set { studentName = value; }
            }

            public int Age                  // getter/setter to access Age
            {
                get { return studentAge; }
                set { studentAge = value; }
            }
        }
    }