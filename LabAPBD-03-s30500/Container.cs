namespace LabAPBD_03_s30500;

public abstract class Container
{
    protected string Id { get; }
    
    public double LoadMass { get; set; } // kg
    public double Height { get; set; } // cm
    public double SelfWeight { get; set; } // kg
    public double Depth { get; set; } // cm
    public abstract string SerialNumber { get; }
    public double MaxLoad { get; set; }
    
    protected Container(double loadMass, double height, double selfWeight, double depth, double maxLoad)
    {
        LoadMass = loadMass;
        Height = height;
        SelfWeight = selfWeight;
        Depth = depth;
        MaxLoad = maxLoad;
        
        Id = SerialNumberHandler.NextAutoIncrement().ToString();
    }


    public abstract void Unload();

    public virtual void Load(Load load)
    {
        
        if (LoadMass + load.Mass > MaxLoad)
            throw new OverfillException($"The load mass ({LoadMass + load.Mass}) would exceed the maximum load mass ("+MaxLoad+")");
    }
    
    
    public override string ToString()
    {
        return $"Container SerialNumber: {SerialNumber}, Load mass: {LoadMass}, Height: {Height}, Self weight: {SelfWeight}, Depth: {Depth}, Max load: {MaxLoad}";
    }


}