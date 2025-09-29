# SignalR-Restaurant-System
🍽️ **Restoran Sipariş ve Yönetim Sistemi (Real-Time)**

---

## 🌟 Proje Tanıtımı
Bu proje, bir restoran veya kafe için **uçtan uca sipariş, rezervasyon ve yönetim süreçlerini kapsayan**, **gerçek zamanlı (Real-Time)** özelliklere sahip modern bir otomasyon sistemidir.

ASP.NET Core Web API kullanılarak **çok katmanlı (N-Layered) mimari** ile geliştirilmiş olup, kullanıcı arayüzü (UI) bu API'yi tüketerek tam entegre bir yapı sunar. Projenin temel gücü, **SignalR** ile anlık istatistikler ve interaktif kullanıcı deneyimi sağlamasıdır.  
Geliştirme sürecinde **SOLID Prensipleri** ve **Clean Code** standartlarına sadık kalınmıştır.

---

## 💻 Kullanılan Teknolojiler

| Kategori            | Teknoloji                   | Açıklama                                                                 |
|--------------------|-----------------------------|-------------------------------------------------------------------------|
| **Backend & Core**  | C# & ASP.NET Core Web API    | Platformlar arası web servisleri ve uygulamalar için ana altyapı.       |
| **Real-Time İletişim** | SignalR                  | Anlık bildirim, mesajlaşma ve anlık sepet yönetimi gibi real-time özellikler. |
| **Veritabanı (DB)** | Microsoft SQL Server (MSSQL) | Güçlü ilişkisel veritabanı yönetim sistemi.                             |
| **ORM Aracı**       | Entity Framework Core        | Veritabanı işlemlerini nesne tabanlı yöneten ORM.                      |
| **UI/Frontend**     | ASP.NET Core MVC             | API'yi tüketen kullanıcı arayüzü katmanı.                              |
| **Diğer Araçlar**   | AutoMapper, HttpClientFactory, QRCoder | DTO-Entity eşlemesi, API tüketimi ve QR kod üretimi için.         |

---

## 🏗️ Mimari ve Tasarım Kalıpları

1. **Çok Katmanlı Mimari (N-Layered Architecture)**  
   Proje; **Entity, DataAccess, Business, Dto, API ve WebUI** katmanlarına ayrılarak sürdürülebilirlik ve yönetilebilirlik sağlanmıştır.

2. **Tasarım Prensipleri**  
   - ✅ **SOLID Prensipleri**: Uygulama esnekliğini ve anlaşılırlığını artırmak için uygulandı.  
   - 🔄 **Repository Pattern**: Veri erişim işlemlerinin soyutlanması ve Generic yapı ile yönetilmesi.  
   - 💉 **Dependency Injection (DI)**: Bağımlılık yönetiminde kullanıldı.  

---

## ✨ Temel Özellikler ve Modüller

- 📊 **Real-Time İstatistikler:** SignalR ile kategori sayısı, aktif siparişler, kasa tutarı ve günlük kazanç gibi kritik verilerin anlık takibi.
- 🧑‍💻 **Yönetici (Admin) Paneli:** Ürün, Kategori, İndirim (Discount) ve Öne Çıkanlar (Feature) gibi tüm yönetimsel CRUD işlemlerinin merkezi.
- 🧾 **Sipariş Yönetimi:** Aktif ve toplam siparişlerin takibi, sipariş durumuna göre kasa tutarını güncelleyen Trigger yapısı.
- 🗓️ **Rezervasyon & E-posta:** Müşteri rezervasyon talepleri, yönetici onay/iptal süreci ve onaylanan rezervasyonlar için otomatik e-posta gönderimi.
- 🛒 **Sepet Yönetimi:** Menüden ürün seçimi, sepete ekleme/çıkarma, KDV dahil hesaplama ve masaya özel sepet takibi.
- 🔐 **Güvenlik:** ASP.NET Core Identity ile kullanıcı kayıt, giriş, rol ve yetkilendirme (Authorize/AllowAnonymous) işlemleri.
- 🔗 **Dış API Entegrasyonu:** Rapid API (Tasty API) kullanılarak harici yemek tariflerinin çekilmesi.

---
