# Dependency Injection

### Dependency Injection Nedir?

Dependency Injection(Bağımlılık Enjeksiyonu); Margin Fowler'in ortaya attığı bağımlılıkların kontrolünü ve yönetimini sağlayan bir design pattern(Tasarım kalıbı)'dır. Esnek ve genişletilebilir bir proje geliştirmek için bağımlılıkların azaltılmasını, bir diğer açıdan ters bağımlılık oluşturulmasını sağlar. En büyük faydalarından biri mock yapılmasını sağlayarak, kolay unit test yazılmasına imkan sağlamasıdır. Dependency Injection tekniğinde bağımlılık oluşturacak parçalarının ayrılıp, bunların sisteme dışarıdan verilmesi (enjekte edilmesi) ile meydana gelir.

Dependency Injection’ın detaylarına girmeden önce dikkat etmemiz gereken husus şudur ki; Dependency Injection çoğu zaman Dependency Inversion ile karıştırılır. Fakat Dependency Inversion problem çözmeye yarayan bir prensip iken Dependency Injection ise bu prensibi uygulayan bir Design Pattern’dir.

Bağımlılıkların tek bir yerden yönetilmesi için çeşitli kütüphaneler mevcuttur. IoC Container olarak adlandırılan bu yapılar bağımlılıkların bir yere toplanarak oldukça kolay yönetilmesini sağlamaktadır.


### Dependency Inject Çeşitleri

Dependency injection temel olarak 3 şekilde yapılabilir.

- Constructor Injection
Class oluşturulurken constructor'a parametre ile ters bağımlılık enjekte etme yöntemi.

- Setter Injection(Property Injection)
Sınıfın public property'si yardımıyla ters bağımlılık enteje etme yönetmi.

- Method Injection
Herhangi bir fonsiyona parametre ile ters bağımlılık entekte etme yöntemi.

> Yukarıdaki biçimlerin örnek kullanımları kod üzerinde verilmiştir.

### Dependency Injection Avantajları

- Gevşek bağımlılıklı, esnek uygulamalar oluşturabiliriz(Loosely Coupled). Modüller veya companentler arasındaki bağlılığı azaltır
- Open/Closed prensibine uygunluk sağlanır. Gelişime açık ve değişime kapalılık gösterir.
- Test edilebilirliği destekler.
- Uygulamanın bakım ve geliştirme aşamasında kolaylık sağlar
- Kodun okunabilirliğini artırır.


### Dependency Injection .Net Core Lifetime

- Singleton 
Uygulama boyunca tek bir instance olarak çalışır. Static olarak düşünebilirsiniz.

- Transient
Adı üzerinde geçici. Her kullanılmak istendiğinde yeni bir instance oluşturur.

- Scoped
Request bazlı bir instance oluşturur. Yani request içerisinde ihtiyaç olunduğu anda bir instance oluşturulur ve ilgili request içerisinde aynı instance ile çalışmaya devam eder.

StartUp.cs içerisinde aşağıdaki gibi enjekte edilebilir.
```csharp
services.AddSingleton<SingletonService>();
services.AddScoped<ScopedService>();
services.AddTransient<TransientService>();
```

> Örnek kullanım LifeTime.cs üzerinde gösterilmiştir.

### Dependency Inversion Nedir?
SOLID'in sonunce sırasında yer alan Dependency Inversion prensibi türkçeye, 'bağımlılğı tersine çevirme prensibi' olarak çevirilir. 

Dependency inversiyon prensibinin kuralı;
- Üst seviye sınflar alt seviye sınıflara bağımlı olmamalıdır. Aralarındaki ilişki interface veya abstraction kullanarak sağlanmalıdır.

Durumu şöyle örneklendirebiliriz; 
<pre>
'Bilgisayar' adında üst sınıfımız olsun.
'Klavye' ve 'Mouse' adında alt sınıflarımız olsun.
Eğer kurduğumuz yapıda Bilgisayara klavye ve mouse bağımlı olarak eklenirse, mouse veya klavye değiştiğinde Bilgisayar sınıfında da değişiklik yapmamız gerekecek.
Ancak araya ara katman olarak 'BilgisayarParca' adında yeni bir interface yada abstract yapı eklenirse bağımlılık giderilecektir.
Artık klavye ya da mouse değiştiğinde bu parçalar bilgisayara bağımlı olacaktır.
</pre>

### Dependency Inversion vs Dependency Injection
Dependency inversion bir yazılım prensibi olarak, üst sınıfların alt sınıflara bağımlı olmaması kuralıdır diyebiliriz.
Dependency injection ise bir yazılım tasarım kalıbıdır. Dependency inversion prensibinin kullanıdığı tasarım desenine dependency injection denir.

### Inversion of Control Nedir?
Bağımlılıkların dependency injection tasarım deseniyle ayılması olayının, ioc container adı verilen framework'lerin yardımıyla tek bir yerden ayarlanmasıdır diyebiliriz. Bu yazımızda Autofac kütüphanesini kullanacağız.

### Autofac Nedir?
Autofac, bir ioc container olarak kullanılan bağımlılıkların tek bir yerden yönetilmesini sağlayan bir açık kaynak kütüphanedir.

### Autofac nasıl yüklenir?

> PM> Install-Package Autofac

### Autofac Entegrasyonu ve Kullanımı

```csharp
var builder = new ContainerBuilder(); // autofac konfigurasyon nesnesi tanımladık.

builder.RegisterType<Kahve>().As<IIcecek>();	// IIcecek istendiğinde Kahve verilmesini tembihledik.

IContainer container = builder.Build();	//autofac mappinglerin yapıldığı container nesnemizi hazırladık.

//IcecekMakinesine IIcecek için hazırladığımız nesneyi vermesini söyledik.
var icecekMakinesi = new IcecekMakinesi(container.Resolve<IIcecek>());	

icecekMakinesi.Olustur();	//Oluşan nesneyi çalıştırdık.
```