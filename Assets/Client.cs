using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;
    public bool CanFly;

    public InputField wheelsInput;
    public Toggle engineToggle;
    public InputField passengersInput;
    public Toggle cargoToggle;
    public Toggle flyToggle;
    // Start is called before the first frame update
    void Start()
    {
        /*VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        requirements.Engine = Engine;
        requirements.Passengers = Mathf.Max(Passengers);
        requirements.Engine = Cargo;
        requirements.HasCargo = Cargo;
        requirements.canFly = CanFly;

        VehicleFactory factory = new VehicleFactory(requirements);
        IVehicle v = factory.Create();
        Debug.Log(v);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateVehicle()
    {
        VehicleRequirements requirements = new VehicleRequirements();

        requirements.NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        requirements.Engine = Engine;
        requirements.Passengers = Mathf.Max(Passengers);
        if (Cargo != false)
        {
            requirements.Engine = Cargo;
        }
        requirements.HasCargo = Cargo;
        requirements.canFly = CanFly;

        VehicleFactory factory = new VehicleFactory(requirements);
        IVehicle v = factory.Create();
        Debug.Log(v);
    }

    public void SetWheels()
    {
        int.TryParse(wheelsInput.text, out NumberOfWheels);
    }
    public void SetEngine()
    {
        Engine = engineToggle.isOn;
    }
    public void SetPassengers()
    {
        int.TryParse(passengersInput.text, out Passengers);
    }
    public void SetCargo()
    {
        Cargo = cargoToggle.isOn;
    }
    public void SetFly()
    {
        CanFly = flyToggle.isOn;
    }
}
