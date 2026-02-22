<img width="1271" height="628" alt="image" src="https://github.com/user-attachments/assets/fd579af6-496e-40ca-afd9-f74ff037fbb6" />


<img width="1220" height="621" alt="image" src="https://github.com/user-attachments/assets/4593d9b7-efb8-4709-9a1b-ff2896f7dcab" />


<img width="1233" height="566" alt="image" src="https://github.com/user-attachments/assets/7eb13307-d80c-4063-9f03-b46ef88a832d" />




# 📚 Kütüphane Yönetim Sistemi

ASP.NET Core MVC (.NET 8) kullanılarak geliştirilmiş, katmanlı mimariye sahip bir **Kütüphane Yönetim Sistemi** projesidir.

Bu projede kitaplar; yazar, kategori ve yayınevi bilgileriyle birlikte yönetilebilmektedir.



## 🚀 Kullanılan Teknolojiler

* **Backend:** ASP.NET Core MVC (.NET 8)
* **ORM:** Entity Framework Core
* **Veritabanı:** SQLite
* **Frontend:** HTML, CSS, JavaScript
* **Tasarım:** Bootstrap (Bootswatch – Lux Tema)



## 📊 Veritabanı Yapısı

Proje toplam 4 ana tablodan oluşmaktadır:

* Books (Kitaplar)
* Authors (Yazarlar)
* Categories (Kategoriler)
* Publishers (Yayınevleri)

### 🔗 İlişkiler (1-M)

* Her kitabın:

  * 1 yazarı
  * 1 kategorisi
  * 1 yayınevi vardır.
* Bir yazar, kategori veya yayınevine birden fazla kitap bağlı olabilir.

Foreign Key ilişkileri kullanılarak veri bütünlüğü sağlanmıştır.



## 🛠️ Özellikler

✔ Full CRUD işlemleri (Ekle, Listele, Güncelle, Sil)
✔ Dashboard ekranında toplam kayıt sayıları
✔ Dropdown listeler ile güvenli veri seçimi
✔ Restrict silme kuralı ile veri bütünlüğü
✔ BookVM kullanımı (ViewModel yapısı)
✔ Katmanlı ve Clean Code mimarisi



## 🖼️ Resim Yükleme

* Kitaplara kapak resmi eklenebilmektedir.
* Resimler `wwwroot/images/books` klasöründe saklanmaktadır.
* Dosya isimleri GUID ile oluşturulur (çakışmayı önlemek için).



## 📌 Dashboard

Dashboard ekranı üzerinden sistemde bulunan:

* Toplam Kitap Sayısı
* Toplam Yazar Sayısı
* Toplam Kategori Sayısı
* Toplam Yayınevi Sayısı

anlık olarak görüntülenebilmektedir.



## 🧱 Mimari Yapı

* MVC mimarisi kullanılmıştır.
* Dependency Injection uygulanmıştır.
* Ortak tasarım `_Layout.cshtml` içerisinde toplanmıştır.
* Kod yapısı temiz ve düzenlidir.



## 🎯 Proje Amacı

Bu proje, ASP.NET Core MVC mimarisini öğrenmek,
Entity Framework ile ilişkili veritabanı yapısı kurmak ve
Full CRUD işlemlerini uygulamalı olarak geliştirmek amacıyla hazırlanmıştır.
