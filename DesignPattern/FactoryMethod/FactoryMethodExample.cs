namespace DesignPatterns.FactoryMethod
{
    public class FactoryMethodExample
    {
        private static LogisticsFactory logisticsFactory;

        public string Run()
        {
            string result = string.Empty;
            result += "=======================================\n";
            result += "========Factory method example:========\n";
            result += "=======================================\n\n";
            //Create object for road transport
            logisticsFactory = new RoadLogistics();
            ITransport roadTransport = logisticsFactory.FactoryMethod();
            result += "Calling 'Road' transport Deliver method using ITransport Factory object.\n";
            result += roadTransport.Deliver();

            //Create object for sea transport
            logisticsFactory = new SeaLogistics();
            ITransport seaTransport = logisticsFactory.FactoryMethod();
            result += "Calling 'Sea' transport Deliver method using ITransport Factory object.\n";
            result += seaTransport.Deliver();

            result += "\n================END===================\n";

            return result;
        }

    }
    public interface ITransport
    {
        public string Deliver();
    }

    public class Ship : ITransport
    {
        public string Deliver()
        {
            return "Deliver via sea \n";
        }
    }

    public class Truck : ITransport
    {
        public string Deliver()
        {
            return "Deliver via road \n";
        }
    }

    public abstract class LogisticsFactory
    {
        public abstract ITransport FactoryMethod();

        public ITransport PlanDelivery()
        {
            return FactoryMethod();
        }
    }

    public class RoadLogistics : LogisticsFactory
    {
        public override ITransport FactoryMethod()
        {
            return new Truck();
        }
    }

    public class SeaLogistics : LogisticsFactory
    {
        public override ITransport FactoryMethod()
        {
            return new Ship();
        }
    }


}
