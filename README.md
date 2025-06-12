# 🛒 EShop Microservices

**EShopMicroservices**, mikroservis mimarisi ile geliştirilmiş bir örnek e-ticaret sistemidir. Her servis birbirinden bağımsız çalışabilir şekilde tasarlanmıştır. Proje, gerçek dünyadaki büyük ölçekli sistemlerin temel yapı taşlarını öğrenmek, denemek ve göstermek amacıyla oluşturulmuştur.

> 🎯 Amaç: Mikroservis mimarisinin temel kavramlarını öğrenmek ve uygulamak  
> 📚 İçerik: Servisler arası iletişim, API gateway, gRPC, Docker, RabbitMQ, veritabanı çeşitliliği, CI/CD altyapısı

---

## 📦 Proje Mimarisi

Bu proje şu servisleri içerir:

| Servis | Açıklama |
|--------|----------|
| **Catalog.API** | Ürün bilgilerini MongoDB'den alan servis |
| **Basket.API** | Kullanıcının sepetini yöneten servis (Redis kullanır) |
| **Discount.Grpc** | Sepet ürünleri için indirim hesaplayan gRPC servisi |
| **Ordering.API** | Sipariş oluşturma ve sipariş listesini yönetir (PostgreSQL) |
| **Identity.API** | JWT tabanlı kullanıcı kimlik doğrulaması ve yönetimi |
| **Ocelot API Gateway** | Tüm servisleri dış dünyaya açan, yönlendirme sağlayan ağ geçidi |

---

## 🧰 Kullanılan Teknolojiler

- [.NET 7](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7)
- **Docker & Docker Compose**
- **MongoDB**, **PostgreSQL**, **Redis**
- **RabbitMQ** – Asenkron mesajlaşma
- **gRPC** – Performanslı servisler arası iletişim
- **Ocelot API Gateway** – Servis yönlendirme ve güvenlik
- **Swagger** – API dokümantasyonu
- **JWT** – Kimlik doğrulama

---

## 🗺️ Katmanlı Yapı

EShopMicroservices/
├── src/
│   ├── Services/
│   │   ├── Catalog/
│   │   ├── Basket/
│   │   ├── Discount/
│   │   ├── Ordering/
│   │   └── Identity/
│   ├── BuildingBlocks/
│   └── ApiGateways/
│       └── OcelotGateway/
├── docker-compose.yml
└── README.md

---

## 🚀 Başlarken

### Gereksinimler

- Docker ve Docker Compose
- .NET 7 SDK (sadece lokal geliştirme yapacaksan)

### Kurulum

\`\`\`bash
# Projeyi klonlayın
git clone https://github.com/emrekilc/EShopMicroservices.git
cd EShopMicroservices

# Docker ile tüm servisleri ayağa kaldırın
docker-compose -f docker-compose.yml up --build
\`\`\`

- [http://localhost:8000](http://localhost:8000) → Ocelot Gateway
- [http://localhost:8001/swagger](http://localhost:8001/swagger) → Catalog API
- [http://localhost:8002/swagger](http://localhost:8002/swagger) → Basket API
- [http://localhost:8003/swagger](http://localhost:8003/swagger) → Ordering API
- [http://localhost:8004/swagger](http://localhost:8004/swagger) → Identity API

---

## 🔗 Servisler Arası İletişim

- 🟠 **HTTP REST** → Gateway ve dış servisler arası iletişim
- 🟡 **gRPC** → Discount servisinin kullanımı
- 🔵 **RabbitMQ** → Sipariş oluşturulduğunda mesajlaşma
- 🟣 **Redis** → Kullanıcı sepeti saklama

---

## 🧪 Test ve Geliştirme

Her serviste ayrı Swagger arayüzü bulunmaktadır. Ayrıca, Swagger üzerinden JWT token girerek yetkili kullanıcı gibi test yapabilirsin.

---

## 🧠 Öğrenim Notları

- API Gateway sayesinde servislerin dış dünya ile temas noktası merkezi hale gelir.
- gRPC, düşük gecikmeli servis içi iletişim için güçlü bir alternatiftir.
- RabbitMQ gibi mesajlaşma sistemleri, servisler arası bağımlılığı azaltır.

---

## 📸 Ekran Görüntüleri

![Catalog Swagger](assets/catalog-swagger.png)
\`\`\`

---

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.
