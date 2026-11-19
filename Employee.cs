namespace Employee.Models
{
    public static class Validators
    {
        public static void ThrowIfNegative(decimal value, string paramName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, "Value cannot be negative.");
            }
        }

        public static void ThrowIfNullOrWhiteSpace(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(paramName, "Value Can Not Be Empty Or Whitespace.");
            }
        }
    }

    internal abstract class Employee
    {
        private string name;
        private decimal baseSalary;
        private int overtimeHours;
        private int overtimeMinutes;
        private decimal overtimeHourlyRate;

        public string Name
        {
            get => name;
            set
            {
                Validators.ThrowIfNullOrWhiteSpace(value, nameof(Name));
                name = value;
            }
        }

        public decimal BaseSalary
        {
            get => baseSalary;
            set
            {
                Validators.ThrowIfNegative(value, nameof(BaseSalary));
                baseSalary = value;
            }
        }

        public int OvertimeHours
        {
            get => overtimeHours;
            set
            {
                Validators.ThrowIfNegative(value, nameof(OvertimeHours));
                overtimeHours = value;
            }
        }

        public int OvertimeMinutes
        {
            get => overtimeMinutes;
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Overtime minutes must be between 0 and 59.");
                }
                overtimeMinutes = value;
            }
        }

        public decimal OvertimeHourlyRate
        {
            get => overtimeHourlyRate;
            set
            {
                Validators.ThrowIfNegative(value, nameof(OvertimeHourlyRate));
                overtimeHourlyRate = value;
            }
        }

        protected Employee(string name, decimal baseSalary, int overtimeHours, int overtimeMinutes, decimal overtimeHourlyRate)
        {
            Name = name;
            BaseSalary = baseSalary;
            OvertimeHours = overtimeHours;
            OvertimeMinutes = overtimeMinutes;
            OvertimeHourlyRate = overtimeHourlyRate;
        }

        public abstract decimal CalculateSalary();
    }


    class Technician : Employee
    {
        public Technician(string name, decimal baseSalary, int overtimeHours, int overtimeMinutes, decimal overtimeHourlyRate)
            : base(name, baseSalary, overtimeHours, overtimeMinutes, overtimeHourlyRate)
        {
        }

        public override decimal CalculateSalary()
        {
            int totalMinutes = (OvertimeHours * 60) + OvertimeMinutes;
            decimal overtimePay = (totalMinutes * OvertimeHourlyRate) / 60;

            return overtimePay + BaseSalary;
        }
    }


    class Receptionist : Employee
    {
        public int HandledOrders { get; set; }
        public decimal BonusPerOrder { get; set; }

        public Receptionist(string name, decimal baseSalary, int overtimeHours, int overtimeMinutes, decimal overtimeHourlyRate, int handledOrders, decimal bonusPerOrder)
            : base(name, baseSalary, overtimeHours, overtimeMinutes, overtimeHourlyRate)
        {
            HandledOrders = handledOrders;
            BonusPerOrder = bonusPerOrder;
        }

        public override decimal CalculateSalary()
        {
            int totalMinutes = (OvertimeHours * 60) + OvertimeMinutes;
            decimal overtimePay = (totalMinutes * OvertimeHourlyRate) / 60;
            decimal bonusPay = BonusPerOrder * HandledOrders;
            decimal finalPay = overtimePay + bonusPay + BaseSalary;

            return finalPay;
        }
    }
}