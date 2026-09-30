using System;

namespace RoboticFactory
{

    public abstract class Robot
    {
        public string ModelName { get; set; }
        public double BatteryCapacity { get; set; }
        public string SoftwareVersion { get; set; }

        public Robot(string modelName, double batteryCapacity, string softwareVersion)
        {
            ModelName = modelName;
            BatteryCapacity = batteryCapacity;
            SoftwareVersion = softwareVersion;
        }


        public abstract Robot Clone();

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Model: {ModelName} | Battery: {BatteryCapacity}h | OS: {SoftwareVersion}");
        }
    }


    public class ServiceRobot : Robot
    {
        public string ServiceTask { get; set; }

        public ServiceRobot(string modelName, double batteryCapacity, string softwareVersion, string serviceTask)
            : base(modelName, batteryCapacity, softwareVersion)
        {
            ServiceTask = serviceTask;
        }

        public override Robot Clone()
        {

            return (Robot)this.MemberwiseClone();
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Task: {ServiceTask}\n");
        }
    }

    public class IndustrialRobot : Robot
    {
        public string IndustrialTask { get; set; }

        public IndustrialRobot(string modelName, double batteryCapacity, string softwareVersion, string industrialTask)
            : base(modelName, batteryCapacity, softwareVersion)
        {
            IndustrialTask = industrialTask;
        }

        public override Robot Clone()
        {
            return (Robot)this.MemberwiseClone();
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Task: {IndustrialTask}\n");
        }
    }

    public class EntertainmentRobot : Robot
    {
        public string EntertainmentFeature { get; set; }

        public EntertainmentRobot(string modelName, double batteryCapacity, string softwareVersion, string entertainmentFeature)
            : base(modelName, batteryCapacity, softwareVersion)
        {
            EntertainmentFeature = entertainmentFeature;
        }

        public override Robot Clone()
        {
            return (Robot)this.MemberwiseClone();
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Feature: {EntertainmentFeature}\n");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            ServiceRobot baseService = new ServiceRobot("SR-100", 12.0, "v1.0", "Hospitality");
            IndustrialRobot baseIndustrial = new IndustrialRobot("IR-200", 24.0, "v2.1", "Welding");
            EntertainmentRobot baseEntertainment = new EntertainmentRobot("ER-300", 8.0, "v1.5", "Interactive Dance");


            baseService.DisplayInfo();
            baseIndustrial.DisplayInfo();
            baseEntertainment.DisplayInfo();



            ServiceRobot customService = (ServiceRobot)baseService.Clone();
            customService.SoftwareVersion = "v1.2";
            customService.ServiceTask = "Healthcare";
            customService.DisplayInfo();

            IndustrialRobot customIndustrial = (IndustrialRobot)baseIndustrial.Clone();
            customIndustrial.BatteryCapacity = 36.0;
            customIndustrial.IndustrialTask = "Assembly";
            customIndustrial.DisplayInfo();
        }
    }
}