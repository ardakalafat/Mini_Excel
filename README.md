# 📊 Mini_Excel (Console Spreadsheet)

[![Language](https://img.shields.io/badge/Language-English-blue)](#english) [![Dil](https://img.shields.io/badge/Dil-T%C3%BCrk%C3%A7e-red)](#türkçe)

A dynamic spreadsheet application developed in C#. It runs on the console and supports cell assignments, row/column operations, advanced mathematical/string operators, and file saving.

---

<a name="english"></a>
## 🇬🇧 English Description

**Mini_Excel** is a simulation of a spreadsheet software (like Excel) running in a command-line interface. It handles a 2D grid where users can manipulate data using specific commands.

### 🚀 Key Features
* **Dynamic Grid:** Starts with an 8x5 grid, expandable up to 15x10 using commands.
* **Data Types:** Supports `Integer` and `String` types in cells.
* **File I/O:** Automatically saves the table to `spreadsheet.txt` upon exit.
* **Manipulation:** Copy, Cut (X), and Clear operations for single cells, entire rows, or columns.
* **Advanced Operators:** Handles mixed operations between Integers and Strings (e.g., repeating a string by multiplying it with a number).

### 🛠️ Commands & Usage

Enter commands in the format `Function(Parameter1, Parameter2, ...)`.

#### 1. Basic Operations
| Command | Usage Example | Description |
| :--- | :--- | :--- |
| **AssignValue** | `AssignValue(A1, integer, 100)` | Sets value '100' to cell A1. |
| **AssignValue** | `AssignValue(B2, string, hello)` | Sets value 'hello' to cell B2. |
| **ClearCell** | `ClearCell(A1)` | Clears the content of cell A1. |
| **ClearAll** | `ClearAll()` | Clears the entire table. |
| **exit** | `exit` | **Saves** the table to a file and closes the program. |

#### 2. Structure Operations
| Command | Usage Example | Description |
| :--- | :--- | :--- |
| **AddRow** | `AddRow(3, down)` | Adds a new row below row 3. |
| **AddColumn** | `AddColumn(B, right)` | Adds a new column to the right of column B. |
| **Copy** | `Copy(A1, B1)` | Copies content from A1 to B1. |
| **X** | `X(A1, B1)` | **Cuts** A1 and moves it to B1 (A1 becomes empty). |
| **CopyRow** | `CopyRow(1, 2)` | Copies entire Row 1 to Row 2. |
| **XColumn** | `XColumn(A, B)` | Cuts Column A and moves it to Column B. |

#### 3. Mathematical & String Operators
Unique operators that change behavior based on cell types.

| Op | Function | Logic |
| :---: | :--- | :--- |
| **\*** | `*(A1, B1, C1)` | **Int*Int:** Multiply.<br>**String*Int:** Repeats the string `Int` times. (If negative, reverses string first). |
| **+** | `+(A1, B1, C1)` | **Int+Int:** Sum.<br>**String+String:** Concatenates strings (User is asked for Uppercase/Lowercase). |
| **/** | `/(A1, B1, C1)` | **Int/Int:** Division.<br>**String/Int:** Takes a substring/part of the text. |
| **-** | `-(A1, B1, C1)` | **Int-Int:** Subtraction.<br>**String-Int:** Removes specific character by ASCII code. |
| **#** | `#(A1, B1, C1)` | **Encryption:** Shifts the ASCII characters of the string by the given integer value. |

---

<a name="türkçe"></a>
## 🇹🇷 Türkçe Açıklama

**Mini_Excel**, C# ile geliştirilmiş, konsol üzerinde çalışan dinamik bir hesap tablosu uygulamasıdır. Hücre atama, satır/sütun ekleme, kopyalama ve gelişmiş operatör işlemlerini destekler.

### 🚀 Özellikler
* **Dinamik Tablo:** Başlangıçta 8x5 olan tablo, komutlarla 15x10 boyutuna kadar genişletilebilir.
* **Veri Tipleri:** Hücrelerde `Tamsayı (Integer)` ve `Metin (String)` verileri tutulabilir.
* **Dosya İşlemleri:** `exit` komutu ile tablo `spreadsheet.txt` dosyasına kaydedilir.
* **Manipülasyon:** Hücre, satır veya sütun bazlı Kopyalama (Copy), Kesme (X) ve Temizleme işlemleri.
* **Gelişmiş Operatörler:** Sayı ve Metin arasında özel işlemler (Örn: Bir metni sayı ile çarparak tekrar ettirme veya ters çevirme).

### 🛠️ Komutlar ve Kullanım

Komutlar `Fonksiyon(Parametre1, Parametre2, ...)` formatında girilir.

#### 1. Temel İşlemler
| Komut | Örnek Kullanım | Açıklama |
| :--- | :--- | :--- |
| **AssignValue** | `AssignValue(A1, integer, 100)` | A1 hücresine 100 değerini atar. |
| **AssignValue** | `AssignValue(B2, string, selam)` | B2 hücresine "selam" yazar. |
| **ClearCell** | `ClearCell(A1)` | A1 hücresini temizler. |
| **ClearAll** | `ClearAll()` | Tüm tabloyu temizler. |
| **exit** | `exit` | Tabloyu **Kaydeder** ve programdan çıkar. |

#### 2. Yapısal İşlemler
| Komut | Örnek Kullanım | Açıklama |
| :--- | :--- | :--- |
| **AddRow** | `AddRow(3, down)` | 3. satırın altına yeni satır ekler (Mevcutları kaydırır). |
| **AddColumn** | `AddColumn(B, right)` | B sütununun sağına yeni sütun ekler. |
| **Copy** | `Copy(A1, B1)` | A1'i B1'e kopyalar. |
| **X** | `X(A1, B1)` | A1'i B1'e **Keser/Taşır** (A1 boşalır). |
| **CopyRow** | `CopyRow(1, 2)` | 1. Satırı komple 2. Satıra kopyalar. |
| **XColumn** | `XColumn(A, B)` | A Sütununu B Sütununa kesip taşır. |

#### 3. Matematiksel ve Metinsel Operatörler
Hücrelerin tipine (String/Int) göre farklı çalışan özel operatörler.

| Op | Fonksiyon | Mantık |
| :---: | :--- | :--- |
| **\*** | `*(A1, B1, C1)` | **Int*Int:** Çarpma.<br>**String*Int:** Metni sayı kadar tekrar eder. (Sayı negatifse metni ters çevirip tekrar eder). |
| **+** | `+(A1, B1, C1)` | **Int+Int:** Toplama (3 hücreye kadar).<br>**String+String:** Metinleri birleştirir (Kullanıcıya Büyük/Küçük harf sorulur). |
| **/** | `/(A1, B1, C1)` | **Int/Int:** Bölme.<br>**String/Int:** Metni parçalar (Substring mantığı). |
| **-** | `-(A1, B1, C1)` | **Int-Int:** Çıkarma.<br>**String-Int:** Girilen ASCII koduna karşılık gelen karakteri metinden siler. |
| **#** | `#(A1, B1, C1)` | **Şifreleme:** Metindeki karakterleri, verilen sayı kadar ASCII tablosunda kaydırır. |

---

### 👨‍💻 Developer / Geliştirici
Developed by Mehmet Arda Kalafat as a C# Project.