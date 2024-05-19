using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dz.cistKod
{
    //strukturni obrazac dekorater
    public interface Coffee
    {
        double GetCost();
        String GetDescription();
    }

    public class Espresso : Coffee
    {

        public double GetCost()
        {
            return 1.99;
        }

        public String GetDescription()
        {
            return "Espresso";
        }
    }

    public abstract class CoffeeDecorator : Coffee
    {
        protected Coffee coffee;

        public CoffeeDecorator(Coffee coffee)
        {
            this.coffee = coffee;
        }
        public double GetCost()
        { 
            return coffee.GetCost();
        }
        public String GetDescription()
        { 
            return coffee.GetDescription();
        }
    }

    public class Milk : CoffeeDecorator
    {
        public Milk(Coffee coffee) : base(coffee) { }
        public override double GetCost()
        {
            return base.GetCost()+0.50;

        }
        public override String GetDescription()
        {
            return base.GetDescription() + "with Milk";
        }

    }
    public static class ClientCode
    {
        public static void Run()
        { 
            Coffee coffee = new Milk(new Espresso());
            Console.WriteLine("Description:" + coffee.GetDescription());
            Console.WriteLine("Cost:$" + coffee.GetCost());
        }
    }
}
