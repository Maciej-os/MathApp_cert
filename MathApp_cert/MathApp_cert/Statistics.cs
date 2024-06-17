namespace MathApp_cert
{
    public class Statistics
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public float Sum { get; private set; }

        public int Count { get; private set; }

        public float Avg
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        public char AvgLetter
        {
            get
            {
                switch (this.Avg)
                {
                    case var avg when avg >= 80:
                        return 'A';
                    case var avg when avg >= 60:
                        return 'B';
                    case var avg when avg >= 40:
                        return 'C';
                    case var avg when avg >= 20:
                        return 'D';
                    default:
                        return 'E';
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Min = float.MaxValue;
            this.Max = float.MinValue;
        }

        public void AddGrade(float grade)
        {
            this.Count++;
            this.Sum += grade;
            this.Min = Math.Min(grade, this.Min);
            this.Max = Math.Max(grade, this.Max);

        }

    }
}
