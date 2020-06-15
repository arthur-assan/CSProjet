using System;

namespace CSProject
{
    class Staff
    {
        //Fields
        private float hourlyRate;
        private int hWorked;

        //Properties
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (hWorked > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }

        // Constructors
        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        // Method
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "Name of Staff = " + NameOfStaff + "Total Pay =" + TotalPay + "Basic Pay" + BasicPay + "Hourly-Rate = " + hourlyRate + "Hours Worked = " + hWorked;
        }

    }

    class Manager : Staff
    {
        // Fields
        private const float managerHourlyRate = 50;

        // Properites
        public int Allowance { get; private set; }

        // Constructors
        public Manager(string name) : base(name, managerHourlyRate) { }

        //Method
        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
                TotalPay = BasicPay + Allowance;
        }
        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nmanagerHourlyRate = "
            + managerHourlyRate + "\nHoursWorked = " + HoursWorked + "\nBasicPay = "
            + BasicPay + "\nAllowance = " + Allowance + "\n\nTotalPay = " + TotalPay;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
