namespace MathApp_cert
{
    public abstract class StudentBase : IStudent
    {
        public static string version = "2024_06_24";

        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public abstract event GradeAddedDelegate GradeAdded;

        protected StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; private set; }

        public string Surname { get; private set; }

        public abstract void AddGrade(float grade);

        public virtual void AddGrade(string grade)
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

        public virtual void AddGrade(char grade)
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

        public virtual void AddGrade(double grade)
        {
            var value = (float)grade;
            this.AddGrade(value);
        }

        public virtual void AddGrade(long grade)
        {
            var value = (float)grade;
            this.AddGrade(value);
        }

        public virtual void AddGrade(decimal grade)
        {
            var value = (float)grade;
            this.AddGrade(value);
        }

        public abstract Statistics GetStatistics();
    }

}
