using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.ConstrutorInjection
{
    public class ConstructorInjection
    {
        public static void Run()
        {
            IcecekMakinesi icecekMakinesi = new IcecekMakinesi(new Kahve());
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
        IIcecek _icecek;
        public IcecekMakinesi(IIcecek icecek)
        {
            _icecek = icecek;
        }
        public void Olustur()
        {
            _icecek.Hazirla();
        }
    }
}
