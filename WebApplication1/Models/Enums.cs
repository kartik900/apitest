namespace WebApplication1.Models
{
    public enum AccountType
    {
        Savings = 1,
        Current = 2,
    }

    public enum TransactionFlow
    {
        Credited,
        Debited
    }

    public enum TransactionMode
    {
        Card,
        Cash,
        UPI,
        NEFT
    }
    public enum TransactionStatusEnum
    {
        TransactionInitiated = 1,
        TransactionInprogress,
        TransactionSuccessful,
        TransactionOnHold,
        TransactionFailed,
    }

}
