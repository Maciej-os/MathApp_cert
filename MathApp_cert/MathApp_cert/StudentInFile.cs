namespace MathApp_cert
{
    public class StudentInFile : StudentBase
    {
        public override event GradeAddedDelegate GradeAdded;

        public string FileName => $"{this.Name}_{this.Surname}_grades.txt";

        public StudentInFile(string name, string surname) : base(name, surname)
        {

        }
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using (var writer = File.AppendText(FileName))
                {
                    writer.WriteLine(grade);
                }

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

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(FileName))
            {
                int lineCounter = 0;
                using (var reader = File.OpenText(FileName))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        lineCounter++;
                        if (float.TryParse(line, out float number))
                        {


                            if (number >= 0)
                            {
                                if (number > 100)
                                {
                                    Console.WriteLine($"Line nr {lineCounter} was omitted : number is too high");
                                }
                                else
                                {
                                    statistics.AddGrade(number);
                                }
                            }

                        }
                        else

                        {
                            Console.WriteLine($"Line nr {lineCounter} was omitted : line does not contain number");
                        }

                        line = reader.ReadLine();

                    }
                }
            }
            return statistics;
        }
    }



}
