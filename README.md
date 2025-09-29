# SignalR-Restaurant-System

🍽️ Restoran Sipariş ve Yönetim Sistemi (Real-Time)
🌟 Proje Tanıtımı
Bu proje, bir restoran veya kafe için uçtan uca sipariş, rezervasyon ve yönetim süreçlerini kapsayan, gerçek zamanlı (Real-Time) özelliklere sahip modern bir otomasyon sistemidir.

ASP.NET Core Web API kullanılarak çok katmanlı (N-Layered) mimariyle geliştirilmiş olup, arayüz (UI) bu API'yi tüketerek tam entegre bir yapı sunar. Projenin temel gücü, SignalR ile anlık istatistikler ve interaktif kullanıcı deneyimi sağlamasıdır. Geliştirme sürecinde SOLID Prensipleri ve Clean Code standartlarına sadık kalınmıştır.

💻 Kullanılan Teknolojiler
Kategori	Teknoloji	Açıklama
Backend & Core	C# & ASP.NET Core Web API	Platformlar arası web servisleri ve uygulamalar için ana altyapı.
Real-Time İletişim	SignalR	Anlık bildirim, mesajlaşma ve anlık sepet yönetimi gibi real-time özellikler.
Veritabanı (DB)	Microsoft SQL Server (MSSQL)	Güçlü ilişkisel veritabanı yönetim sistemi.
ORM Aracı	Entity Framework Core	Veritabanı işlemlerini nesne tabanlı yöneten ORM.
UI/Frontend	ASP.NET Core MVC	API'yi tüketen kullanıcı arayüzü katmanı.
Diğer Araçlar	AutoMapper, HttpClientFactory, QRCoder	DTO-Entity eşlemesi, API tüketimi ve QR kod üretimi için.

Export to Sheets
🏗️ Mimari ve Tasarım Kalıpları
1. Çok Katmanlı Mimari (N-Layered Architecture)
Proje; Entity, DataAccess, Business, Dto, API ve WebUI katmanlarına ayrılarak sürdürülebilirlik ve yönetilebilirlik sağlanmıştır.

2. Tasarım Prensipleri
✅ SOLID Prensipleri: Uygulama esnekliğini ve anlaşılırlığını artırmak için uygulandı.

🔄 Repository Pattern: Veri erişim işlemlerinin soyutlanması ve Generic yapı ile yönetilmesi.

💉 Dependency Injection (DI): Bağımlılık yönetiminde kullanıldı.

✨ Temel Özellikler ve Modüller
📊 Real-Time İstatistikler: SignalR ile kategori sayısı, aktif siparişler, kasa tutarı ve günlük kazanç gibi kritik verilerin anlık takibi.

🧑‍💻 Yönetici (Admin) Paneli: Ürün, Kategori, İndirim (Discount) ve Öne Çıkanlar (Feature) gibi tüm yönetimsel CRUD işlemlerinin merkezi.

🧾 Sipariş Yönetimi: Aktif ve toplam siparişlerin takibi, sipariş durumuna göre kasa tutarını güncelleyen Trigger yapısı.

🗓️ Rezervasyon & E-posta: Müşteri rezervasyon talepleri, yönetici onay/iptal süreci ve onaylanan rezervasyonlar için otomatik e-posta gönderimi.

🛒 Sepet Yönetimi: Menüden ürün seçimi, sepete ekleme/çıkarma, KDV dahil hesaplama ve masaya özel sepet takibi.

🔐 Güvenlik: ASP.NET Core Identity ile kullanıcı kayıt, giriş, rol ve yetkilendirme (Authorize/AllowAnonymous) işlemleri.

🔗 Dış API Entegrasyonu: Rapid API (Tasty API) kullanılarak harici yemek tariflerinin çekilmesi.

🚀 Kurulum ve Çalıştırma
Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları takip edin:

⚙️ Ön Koşullar
.NET SDK

MSSQL Server

Visual Studio 2022+

🛠️ Adımlar
Projeyi Klonlayın:

Bash

git clone [PROJE_REPO_ADRESİNİZ]
Veritabanı Ayarları:

SignalRApi projesindeki appsettings.json dosyasında MSSQL bağlantı dizenizi güncelleyin.

⚠️ Önemli: Yerel geliştirme için bağlantı dizesine Encrypt=False eklemeyi unutmayın.

Migration İşlemleri:

Package Manager Console'da varsayılan projeyi SignalR.DataAccessLayer olarak ayarlayın.

Migration'ları çalıştırın:

Bash

Add-Migration InitialCreate
Update-Database
Projeleri Başlatma:

Visual Studio'da SignalRApi ve SignalRWebUI projelerini aynı anda başlayacak şekilde ayarlayın (Multiple Startup Projects).

Projeyi çalıştırın. CORS ayarları API tarafında yapılmıştır.

🗺️ İleriki Geliştirme Planları
📱 Mobil Entegrasyon: Mobil cihazlar üzerinden sipariş takibi ve mobil uygulama entegrasyonu.

🔗 QR Kod Optimizasyonu: Her masa için kalıcı QR kod entegrasyonu ile müşteriyi doğrudan masasına özel sipariş ekranına yönlendirme.
