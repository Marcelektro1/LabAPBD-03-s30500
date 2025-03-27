namespace LabAPBD_03_s30500;

public class GasContainer : Container, IHazardNotifier
{
    public sealed override string SerialNumber { get; }
    
    public double Pressure { get; set; } // atm
    
    public GasContainer(double loadMass, double height, double selfWeight, double depth, double maxLoad, double pressure) 
        : base(loadMass, height, selfWeight, depth, maxLoad)
    {
        Pressure = pressure;
        SerialNumber = $"KON-G-{Id}";
    }
    

    public override void Unload()
    {
        // W momencie kiedy opróżniamy kontener na gaz - pozostawiamy 5% jego ładunku wewnątrz kontenera.
        LoadMass *= 0.05;
    }

    public string Notify()
    {
        return $"A dangerous situation has occurred, container SN {SerialNumber}.";
    }


    public override string ToString()
    {
        return $"Container SerialNumber: {SerialNumber}, Load mass: {LoadMass}, Height: {Height}, Self weight: {SelfWeight}, Depth: {Depth}, Max load: {MaxLoad}, Pressure: {Pressure}";
    }
}