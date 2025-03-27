namespace LabAPBD_03_s30500;

public class OverfillException(string message) : Exception
{
    public override string Message { get; } = message;
}