# WhatsAppChatbotWithKeycloak
WhatsApp Chatbot yang dibuat dengan memanfaatkan library whatsapp client dan menggunakan keycloak.

# Server

## Step 1: Server Setup

### Prasyarat
[Node.js](https://nodejs.org/) dengan versi `15.x.x` ke atas dibutuhkan untuk menjalankan [server](#server). Untuk menginstal versi yang dibutuhkan bisa dilihat di [sini](https://nodejs.org/en/download/).

### Install module (npm)
Jalankan command berikut di command prompt pada folder `/ChatbotAPI`sebagai folder server.

```cmd
npm install
```

## Step 2: Keycloak Setup
1. Download [keycloak](https://github.com/keycloak/keycloak/releases) versi terbaru
2. Masuk ke folder `/bin` pada file hasil download
3. Jalankan file `standalone.bat`
4. Buka url http://localhost:8080/auth/ pada browser
5. Untuk setup keycloak lebih lanjut, bisa dilihat di [sini](https://medium.com/devops-dudes/securing-node-js-express-rest-apis-with-keycloak-a4946083be51)


## Step 3: Menjalankan Server
Jalankan command berikut di command prompt pada folder `/ChatbotAPI`sebagai folder server.

```cmd
npm start
```


## Step 4: Database Setup
### Prasyarat
1. Install [XAMPP](https://www.apachefriends.org/index.html) untuk MySQL server
2. Install MySQL Connector ODBC [32-bit](https://dev.mysql.com/downloads/connector/odbc/) dan [64-bit](https://dev.mysql.com/downloads/connector/odbc/)
3. ODBC Data Source Administrator

### Import database
1. Jalankan Apache dan MySQL server pada XAMPP 
2. Buka url http://localhost/phpmyadmin atau http://localhost:8080/phpmyadmin (sesuai dengan port Apache server pada XAMPP)
3. Import `<DATABASE_NAME>.sql` dan beri nama database tersebut.

### Membuat data source
1. Buka ODBC Data Source Administrator
2. Pilih `Add`
3. Pilih MySQL ODBC 8.0 Unicode Driver
4. Beri nama data source
5. Masukkan port sesuai dengan port MySQL server pada XAMPP
6. Beri nama `User` (contoh: "root")
7. Pilih database
8. Test koneksi data source dan pastikan berhasil


## Step 5: Project VB.NET Setup
### Prasyarat
1. Microsoft VIsual Studio 2019
2. .NET Framework 4.5 dan .NET 5.0 ke atas

### Membuka project
Buka file `Chatbot2.sln` pada folder Chatbot2

### Konfigurasi database pada project VB.NET
Pada file `Form1.vb` di dalam `Sub connectToDB()`, konfigurasikan `connection string` sesuai dengan database dan data source yang telah disetting sebelumnya.
Contoh:
`"Driver={MySQL ODBC 8.0 UNICODE Driver};Server=localhost;Port=3307;Database=peri;uid=root;Option=3;"`

### Menjalankan project (debugging)
Tekan F5 atau tombol Start untuk memulai debugging project


# Referensi
* https://youtu.be/TCqEsGf7i7Q
* https://youtu.be/jTEdjRtj-fs
* https://youtu.be/IRRiN2ZQDc8
* https://youtu.be/hYpRQ_FE1JI
* https://github.com/pedroslopez/whatsapp-web.js
* https://medium.com/devops-dudes/securing-node-js-express-rest-apis-with-keycloak-a4946083be51
