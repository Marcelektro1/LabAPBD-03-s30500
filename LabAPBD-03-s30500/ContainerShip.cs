namespace LabAPBD_03_s30500;

public class ContainerShip
{
    
    public List<Container> Containers { get; }
    public double MaxSpeed { get; } // in knots
    public int MaxNumberOfContainers { get; }
    public double MaxWeight { get; } // in kg
    
    public ContainerShip(double maxSpeed, int maxNumberOfContainers, double maxWeight)
    {
        this.MaxSpeed = maxSpeed;
        this.MaxNumberOfContainers = maxNumberOfContainers;
        this.MaxWeight = maxWeight;
        this.Containers = new List<Container>();
    }


    public void AddContainer(Container container)
    {
        if (this.Containers.Count >= this.MaxNumberOfContainers)
        {
            throw new OverfillException("Cannot add more containers to the ship.");
        }
        
        if (this.Containers.Sum(c => c.LoadMass) + container.LoadMass > this.MaxWeight)
        {
            throw new OverfillException("Cannot add container to the ship, it would exceed the maximum weight.");
        }
        
        this.Containers.Add(container);
    }
    
    
    public void AddContainers(List<Container> containers)
    {
        if (this.Containers.Count + containers.Count > this.MaxNumberOfContainers)
        {
            throw new OverfillException("Cannot add more containers to the ship.");
        }
        
        if (this.Containers.Sum(c => c.LoadMass) + containers.Sum(c => c.LoadMass) > this.MaxWeight)
        {
            throw new OverfillException("Cannot add containers to the ship, it would exceed the maximum weight.");
        }
        
        this.Containers.AddRange(containers);
    }
    
    
    public void RemoveContainer(Container container)
    {
        if (!this.Containers.Contains(container))
        {
            throw new ArgumentException("The container is not on the ship.");
        }
        
        this.Containers.Remove(container);
    }
    
    
    public void ReplaceContainer(string oldSerialNumber, Container newContainer)
    {
        var oldContainer = this.Containers.FirstOrDefault(c => c.SerialNumber == oldSerialNumber);
        
        if (oldContainer == null)
        {
            throw new ArgumentException("The old container is not on the ship.");
        }
        
        if (this.Containers.Contains(newContainer))
        {
            throw new ArgumentException("The new container is already on the ship.");
        }
        
        if (this.Containers.Sum(c => c.LoadMass) - oldContainer.LoadMass + newContainer.LoadMass > this.MaxWeight)
        {
            throw new OverfillException("Cannot replace container on the ship, it would exceed the maximum weight.");
        }
        
        this.Containers.Remove(oldContainer);
        this.Containers.Add(newContainer);
    }
    
    
    public void MoveTo(Container container, ContainerShip otherShip)
    {
        if (!this.Containers.Contains(container))
        {
            throw new ArgumentException("The container is not on this ship.");
        }
        
        if (otherShip.Containers.Count >= otherShip.MaxNumberOfContainers)
        {
            throw new OverfillException("Cannot move container to the other ship, it would exceed the maximum number of containers.");
        }
        
        if (otherShip.Containers.Sum(c => c.LoadMass) + container.LoadMass > otherShip.MaxWeight)
        {
            throw new OverfillException("Cannot move container to the other ship, it would exceed the maximum weight.");
        }
        
        this.Containers.Remove(container);
        otherShip.Containers.Add(container);
    }


    public override string ToString()
    {
        return $"ContainerShip: MaxSpeed: {MaxSpeed}, MaxNumberOfContainers: {MaxNumberOfContainers}, MaxWeight: {MaxWeight}, Containers: {Containers.Count}";
    }
    
    
    
}