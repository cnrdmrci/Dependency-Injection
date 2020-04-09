using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.MethodInjection
{
    public class MethodInjection
    {
        public static void Run()
        {
            IcecekMakinesi icecekMakinesi = new IcecekMakinesi();
            icecekMakinesi.IcecekSec(new Kahve());
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
        public IcecekMakinesi()
        {
        }

        public void IcecekSec(IIcecek icecek)
        {
            _icecek = icecek;
        }

        public void Olustur()
        {
            _icecek.Hazirla();
        }
    }
}
