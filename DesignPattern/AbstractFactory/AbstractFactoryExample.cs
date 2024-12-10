namespace DesignPatterns.AbstractFactory
{

    //References:
    //https://dotnettutorials.net/lesson/abstract-factory-design-pattern-csharp/

    #region 1. Abstract - Factory
    public interface IVehicleFactory
    {
        //Regular/Sport/Luxury
        IBike CreateBikeProduct();
        ICar CreateCarProduct();
    }
    #endregion

    #region 2. Abstract - Product

    public interface IBike
    {
        string GetDetails();
    }
    public interface ICar
    {
        string GetDetails();
    }
    #endregion

    #region 3.1 Creating Concrete Product 2: Bike - Sports/Regular/Luxury
    public class LuxuryBike : IBike
    {
        public string GetDetails()
        {
            return "Fetching 'Luxury bike' details.\n";
        }
    }

    public class RegularBike : IBike
    {
        public string GetDetails()
        {
            return "Fetching 'Regular bike' details.\n";
        }
    }
    #endregion


    #region 3.2 Creating Concrete Product 2: Car - Sports/Regular/Luxury
    //Product 2
    public class LuxuryCar : ICar
    {
        public string GetDetails()
        {
            return "Fetching 'Luxury Car' details.\n";
        }
    }

    public class RegularCar : ICar
    {
        public string GetDetails()
        {
            return "Fetching 'Regular car' details.\n";
        }
    }
    #endregion

    #region 4.1 Creating Concrete Factory 

    public class RegularVehicleFactory : IVehicleFactory
    {
        public IBike CreateBikeProduct()
        {
            return new RegularBike();
        }

        public ICar CreateCarProduct()
        {
            return new RegularCar();
        }
    }
    //Luxury Vehicle
    public class LuxuryVehicleFactory : IVehicleFactory
    {
        public IBike CreateBikeProduct()
        {
            return new LuxuryBike();
        }

        public ICar CreateCarProduct()
        {
            return new RegularCar();
        }
    }
    #endregion

    #region Client/Consumer

    public class AbstractFactoryExample
    {
        private IVehicleFactory _vehicleFactory;
        public string Run()
        {
            string result = string.Empty;
            //Regular vehicles
            _vehicleFactory = new RegularVehicleFactory();
            ICar car = _vehicleFactory.CreateCarProduct();
            result += car.GetDetails();

            IBike bike = _vehicleFactory.CreateBikeProduct();
            result += bike.GetDetails();
            result += "Regualr Vehicle - Ends.\n\n";

            //Luxury vehicles
            _vehicleFactory = new LuxuryVehicleFactory();
            car = _vehicleFactory.CreateCarProduct();
            result += car.GetDetails();

            bike = _vehicleFactory.CreateBikeProduct();
            result += bike.GetDetails();
            result += "Luxury Vehicle - Ends.\n\n";
            return result;
        }
    }
   
    #endregion

}
