//namespace DesignPattern.AbstractFactory
//{
//    public class AbstractFactory
//    {
//    }
//    using System;

//// Abstract Product A
//interface IDoor
//    {
//        void GetDescription();
//    }

//    // Concrete Product A1
//    class WoodenDoor : IDoor
//    {
//        public void GetDescription()
//        {
//            Console.WriteLine("I am a wooden door");
//        }
//    }

//    // Concrete Product A2
//    class IronDoor : IDoor
//    {
//        public void GetDescription()
//        {
//            Console.WriteLine("I am an iron door");
//        }
//    }

//    // Abstract Product B
//    interface IDoorFittingExpert
//    {
//        void GetDescription();
//    }

//    // Concrete Product B1
//    class Carpenter : IDoorFittingExpert
//    {
//        public void GetDescription()
//        {
//            Console.WriteLine("I can only fit wooden doors");
//        }
//    }

//    // Concrete Product B2
//    class Welder : IDoorFittingExpert
//    {
//        public void GetDescription()
//        {
//            Console.WriteLine("I can only fit iron doors");
//        }
//    }

//    // Abstract Factory
//    interface IDoorFactory
//    {
//        IDoor MakeDoor();
//        IDoorFittingExpert MakeFittingExpert();
//    }

//    // Concrete Factory 1
//    class WoodenDoorFactory : IDoorFactory
//    {
//        public IDoor MakeDoor()
//        {
//            return new WoodenDoor();
//        }

//        public IDoorFittingExpert MakeFittingExpert()
//        {
//            return new Carpenter();
//        }
//    }

//    // Concrete Factory 2
//    class IronDoorFactory : IDoorFactory
//    {
//        public IDoor MakeDoor()
//        {
//            return new IronDoor();
//        }

//        public IDoorFittingExpert MakeFittingExpert()
//        {
//            return new Welder();
//        }
//    }

//    // Client
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Wooden factory
//            IDoorFactory woodenFactory = new WoodenDoorFactory();

//            IDoor door1 = woodenFactory.MakeDoor();
//            IDoorFittingExpert expert1 = woodenFactory.MakeFittingExpert();

//            door1.GetDescription();
//            expert1.GetDescription();

//            // Iron factory
//            IDoorFactory ironFactory = new IronDoorFactory();

//            IDoor door2 = ironFactory.MakeDoor();
//            IDoorFittingExpert expert2 = ironFactory.MakeFittingExpert();

//            door2.GetDescription();
//            expert2.GetDescription();
//        }
//    }

//}
