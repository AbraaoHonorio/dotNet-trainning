	private DateTime NextMonth(DateTime date)
	{

			if (date.Day != DateTime.DaysInMonth(date.Year, date.Month))
					return date.AddMonths(1);
			else
					return date.AddDays(1).AddMonths(1).AddDays(-1);
	}

	private DateTime PrevMonth(DateTime date)
	{
			if (date.Day != DateTime.DaysInMonth(date.Year, date.Month))
					return date.AddMonths(1);
			else
					return date.AddDays(1).AddMonths(-1).AddDays(-1);
	}
