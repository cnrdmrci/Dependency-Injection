using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.SetterInjection
{
    public class SetterInjection
    {
        public static void Run()
        {
            IcecekMakinesi icecekMakinesi = new IcecekMakinesi();
            icecekMakinesi.Icecek = new Kahve();
            icecekMakinesi.Olustur();
        }
    }

    public interface IIcecek
    {
        void Hazirla();
    }
    public class Kahve : IIcecek
    {
        public void Hazirla()
        {
            Console.WriteLine("Kahve hazırlanıyor.");
        }
    }
    public class IcecekMakinesi
    {
        public IIcecek Icecek { get; set; }

        public IcecekMakinesi()
        {
        }

        public void Olustur()
        {
            Icecek.Hazirla();
        }
    }
}
