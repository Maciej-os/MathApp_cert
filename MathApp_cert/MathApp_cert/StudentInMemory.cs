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
            base.AddGrade(grade);
        }

   

        public override void AddGrade(char grade)
        {
            base.AddGrade(grade);
        }

      

        public override void AddGrade(double grade)
        {
            base.AddGrade(grade);
        }

        public override void AddGrade(long grade)
        {
            base.AddGrade(grade);
        }
        public override void AddGrade(decimal grade)
        {
            base.AddGrade(grade);
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
