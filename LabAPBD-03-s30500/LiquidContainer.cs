namespace LabAPBD_03_s30500;

public class LiquidContainer : Container, IHazardNotifier
{
    public sealed override string SerialNumber { get; }


    public LiquidContainer(double loadMass, double height, double selfWeight, double depth, double maxLoad) 
        : base(loadMass, height, selfWeight, depth, maxLoad)
    {
        SerialNumber = $"KON-L-{Id}";
    }

    public override void Load(Load load)
    {
        base.Load(load);
        
        // calculate container capacity
        var loadAfterLoad = (LoadMass + load.Mass) / MaxLoad;

        if (load.Dangerous && loadAfterLoad > 0.5)
        {
            throw new OverfillException(
                "Dangerous load can only be loaded while keeping the container at < 50% load.");
        }

        if (loadAfterLoad > 0.9)
        {
            throw new OverfillException("Liquid container can only be loaded up to 90% capacity.");
        }
        
    }

    
    public override void Unload()
    {
        LoadMass = 0;
    }
    
    public string Notify()
    {
        return $"A dangerous situation has occurred, container ID {Id}.";
    }
    
    
    public override string ToString()
    {
        return $"Container SerialNumber: {SerialNumber}, Load mass: {LoadMass}, Height: {Height}, Self weight: {SelfWeight}, Depth: {Depth}, Max load: {MaxLoad}";
    }
}
