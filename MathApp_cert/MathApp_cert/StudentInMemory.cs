namespace MathApp_cert
{
    public class StudentInMemory: StudentBase
    {
        public override event GradeAddedDelegate GradeAdded;

        private List<float> grades = new List<float>();

        public StudentInMemory(string name, string surname) : base(name, surname)
        {

        }
                
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }

            else
            {
                throw new Exception("Invalid grade value");
            }

        }

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else
            {
                if (grade.Length == 1)
                {
                    AddGrade((char)grade[0]);
                }
                else
                {
                    throw new Exception("String is not float");
                }


            }
        }

        public override void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                case 'a':
                    AddGrade(100f);
                    break;
                case 'B':
                case 'b':
                    AddGrade(80f);
                    break;
                case 'C':
                case 'c':
                    AddGrade(60f);
                    break;
                case 'D':
                case 'd':
                    AddGrade(40f);
                    break;
                case 'E':
                case 'e':
                    AddGrade(20f);
                    break;
                default:
                    throw new Exception("Wrong Letter");
            }
        }

        public override void AddGrade(double grade)
        {
            var value = (float)grade;
            this.AddGrade(value);
        }

        public override void AddGrade(long grade)
        {
            var value = (float)grade;
            this.AddGrade(value);
        }
        public override void AddGrade(decimal grade)
        {
            var value = (float)grade;
            this.AddGrade(value);
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }


    }
}
