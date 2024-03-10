﻿namespace Tesodev.Case.Customer.Application.Utilities.Results;

public class SuccessResult<T> : Result<T>
{
    public SuccessResult(T message)
        : base(true, message)
    {
    }

    public SuccessResult()
        : base(true)
    {
    }
}