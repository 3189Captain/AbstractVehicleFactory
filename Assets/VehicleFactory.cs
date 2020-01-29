using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements requirements);
}

public class VehicleFactory
{
    private readonly IVehicleFactory _factory;
    private readonly VehicleRequirements _requirements;
    
    public VehicleFactory(VehicleRequirements requirements)
    {
        //_factory = requirements.Engine ? (IVehicleFactory)new MotorVehicleFactory() : new Cyclefactory();
        //_requirements = requirements;
        if (requirements.canFly)
        {
            _factory = (IVehicleFactory)new PlaneFactory();
            _requirements = requirements;
        }
        else if (requirements.Engine)
        {
            _factory = (IVehicleFactory)new MotorVehicleFactory();
            _requirements = requirements;
        }
        else
        {
            _factory = (IVehicleFactory)new Cyclefactory();
            _requirements = requirements;
        }
    }

    public IVehicle Create()
    {
        return _factory.Create(_requirements);
    }
}

public class Cyclefactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.NumberOfWheels == 1) return new Unicycle();
                return new Bicycle();
            case 2:
                return new Tandem();
            case 3:
                return new Tricycle();
            case 4:
                if (requirements.HasCargo) return new GoKart();
                return new FamilyBike();
            default:
                return new Bicycle();
        }
    }
}

public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
           case 2:
                return new Motorbike();
            default:
                return new Truck();
        }
    }
}

public class PlaneFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        if (requirements.HasCargo)
        {
            return new C130();
        }
        else if(requirements.Passengers > 2)
        {
            return new Boeing747();
        }
        else
        {
            return new Cessna();
        }
    }
}