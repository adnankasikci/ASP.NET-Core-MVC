# .NET Uygulaması

Bu proje, .NET platformunda geliştirilmiş bir admin paneli, ön yüz ve API içerir. Modern, duyarlı ve kullanıcı dostu bir tasarıma sahip olan bu uygulama, genişletilebilir yapısıyla işlerinizi yönetmek için kolay bir yol sunar.

**Özellikler**

- Admin ve standart layout düzeni ve semantik elementler kullanılmıştır.
- API üzerinden veri çekme, görüntüleme, veri silme ve sayfa yükleme özellikleri sunulmuştur.
- Kullanıcılar oturum açabilir, güvenli şekilde işlem yapabilir.
- Admin paneli üzerinden veri ekleme, düzenleme ve silme işlemleri yapılabilir.
- AJAX ve API entegrasyonu ile hızlı veri alışverişi sağlanmıştır.
- Token tabanlı kimlik doğrulama (JWT) ile güvenli giriş sağlanmaktadır.
- Tüm işlemler API ile yapılmaktadır; veriler frontend ile backend arasında sorunsuz bir şekilde iletilmektedir.

**Kullanılan Teknolojiler**

- **Backend**:
  - .NET Core (C#)
  - ASP.NET Core MVC
  - JWT Token (JSON Web Token) ile güvenli kimlik doğrulama
  - Entity Framework Core (ORM)
  - SQL Server (Veritabanı)

- **Frontend**:
  - HTML5
  - CSS3
  - JavaScript (ES6+)
  - Tailwind CSS (Modern ve duyarlı tasarım için)
  - AJAX (Veri çekme ve güncelleme işlemleri için)

- **API Entegrasyonu**:
  - RESTful API'ler (CRUD işlemleri için)
  - ASP.NET Core API

- **Bağımlılık Yönetimi**:
  - NPM Paket Yönetimi (Frontend bağımlılıkları için)
  - NuGet Paket Yönetimi (Backend bağımlılıkları için)

**Proje Görselleri**

<br>
<img src="/wwwroot/img/others/Ekran.png">
<br>

## Nasıl Kullanılır

Proje yerel bir geliştirme sunucusunda çalıştırılmak üzere tasarlanmıştır.

1. Proje deposunu klonlayın.
2. Backend bağımlılıklarını yükleyin:
   - `dotnet restore`
3. Frontend bağımlılıklarını yükleyin:
   - `npm install`
4. Projeyi başlatın:
   - Backend için: `dotnet watch run`
   - Frontend için: `npm start dev`
5. Tarayıcınızda `http://localhost:5284` adresine giderek uygulamayı görüntüleyebilirsiniz.

**Veritabanı Yapılandırması**:
Projede veritabanı yönetimi için SQL Server kullanılmaktadır. Veritabanı bağlantı dizisini `appsettings.json` dosyasına eklemeniz gerekmektedir. Ayrıca, Entity Framework Core ile veritabanı migrasyonu yapılmıştır.


## İletişim

Herhangi bir öneriniz veya geri bildiriminiz varsa, lütfen göndermekten çekinmeyin. Teşekkürler!
