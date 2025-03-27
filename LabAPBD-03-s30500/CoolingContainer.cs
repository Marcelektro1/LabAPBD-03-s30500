namespace LabAPBD_03_s30500;

public class CoolingContainer : Container
{
    public sealed override string SerialNumber { get; }
    
    public string StoredProductType { get; }
    
    public double ContainerTemperature { get; }
    
    public CoolingContainer(double loadMass, double height, double selfWeight, double depth, double maxLoad,
        string storedProductType,
        double containerTemperature) 
        : base(loadMass, height, selfWeight, depth, maxLoad)
    {
        SerialNumber = $"KON-C-{Id}";
        
        StoredProductType = storedProductType;
        ContainerTemperature = containerTemperature;
    }
    
    public override void Load(Load load)
    {

        if (load.TypeName == null)
            throw new ArgumentException("The load type is null.");
        
        base.Load(load);
        
        if (!load.TypeName.Equals(StoredProductType))
            throw new ProductTypeMismatchException("The load type does not match the stored product type.");
        
        if (ContainerTemperature < load.StorageTemperature) 
            throw new OverfillException("Current temperature of this container is lower than the required storage temperature of the load.");
        
    }
    
    
    public override void Unload()
    {
        LoadMass = 0;
    }
    
    
    public override string ToString()
    {
        return $"Container SerialNumber: {SerialNumber}, Load mass: {LoadMass}, Height: {Height}, Self weight: {SelfWeight}, Depth: {Depth}, Max load: {MaxLoad}, Stored product type: {StoredProductType}, Container temperature: {ContainerTemperature}";
    }
    
}