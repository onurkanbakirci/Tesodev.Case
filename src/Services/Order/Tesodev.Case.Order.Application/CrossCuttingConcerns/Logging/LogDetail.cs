﻿namespace Tesodev.Case.Order.Application.CrossCuttingConcerns.Logging;

public class LogDetail
{
    public string MethodName { get; set; }
    public string User { get; set; }
    public List<LogParameter> LogParameters { get; set; }
}