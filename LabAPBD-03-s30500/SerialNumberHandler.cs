namespace LabAPBD_03_s30500;

public class SerialNumberHandler
{
    
    private static int _autoIncrement = 1;


    public static int NextAutoIncrement()
    {
        return _autoIncrement++;
    }
    
}