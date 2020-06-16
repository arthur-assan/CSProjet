using System;
using System.Collections.Generic;
using System.IO;

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

    class Admin : Staff
    {
        //Fields
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30f;

        //Propery
        public float Overtime { get; private set; }

        //constructor
        public Admin(string name) : base(name, adminHourlyRate) { }

        //Method
        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
            }
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
            + "\nadminHourlyRate = " + adminHourlyRate + "\nHoursWorked = " + HoursWorked
            + "\nBasicPay = " + BasicPay + "\nOvertime = " + Overtime
            + "\n\nTotalPay = " + TotalPay;
        }
    }

    class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if(result[1] == "Manager")
                            myStaff.Add(new Manager(result[0]));
                        else if(result[1] == "Admin")
                            myStaff.Add(new Manager(result[0]));
                    }

                    sr.Close();
                }

            }
            else
            {
                Console.WriteLine("Error: File doesnot exit");
            }

            return myStaff;
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
