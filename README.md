# Football Tripadvisor
Det här projektet är ett grupparbete i kursen *Agil utvecklingskultur, projektledning och kommunikation*.

## Så här kör du programmet:
### Starta projektet

Öppna projektet i terminalen och kör:
```bash
dotnet run
```
När servern startar visas i terminalen vilken port som används, till exempel:

``http://localhost:5000 ``

Använd den port som din server körs på.

## Återställ databas

Metod: DELETE  
URL: ``/db ``

*Denna endpoint återställer databasen.*

## Users

### Hämta alla users

Metod: GET  
URL: ``/users`` 

*Returnerar alla users i databasen.*

### Skapa user

Metod: POST  
URL: ``/users `` 

Body (raw JSON):

```json
{
  "email": "test@test.com",
  "password": "123"
}
```
### Hämta users via ID

Metod: GET  
URL: ``/users/{id}``

Exempel: ``/users/1``


## Logga in

Metod: POST  
URL: ``/login``

Body (raw JSON):
```json
{
  "email": "test@test.com",
  "password": "123"
}
```
*Returnerar true eller false.*

### Kontrollera inloggning

Metod: GET  
URL: ``/login``

*Returnerar email om du är inloggad, annars null.*

## Hotels

### Hämta alla hotell

Metod: GET  
URL: ``/hotels``

*Returnerar en lista med hotellid, namn, stad, land.*

### Hämta hotell med index
Metod: GET  
URL: ``/hotels/{hotelId}``

Exempel: ``/hotels/1``

*Returnerar detaljerad information om hotellet, inklusive adress, amenities, rum och närliggande attractions*


### Hämta rum för ett hotell

Metod: GET   
URL: /hotels/{hotelId}/rooms

Exempel:  ``/hotels/1/rooms``

## Sök hotell 

### Sökendpoint
Metod: GET  
URL: ``/hotels/search``

### Sök på stad
Exempel: `` /hotels/search?city=Manchester``

### Sök på stadium
Exempel: ``/hotels/search?stadium=Old%20Trafford``

### Sök på stad + amenities
Exempel: `` /hotels/search?city=Manchester&amenity=Wi-fi&amenity=Breakfast``

*Amenities search kräver att city skickas med.*

## Attractions
### Hämta alla attractions
Metod: GET  
URL: ``/attractions``

*(Returnerar attractions med typ, namn, adress och stad)*

## Bookings

**Bokningar kräver att användaren är inloggad!**

### Räkna pris (ingen bokning skapas)

Metod: POST  
URL: ``/hotels/{hotelId}/rooms/{roomId}/price``

Body (raw JSON):
```json
{
  "checkIn": "2026-01-10",
  "checkOut": "2026-01-12",
  "numberOfGuests": 2
}
```
*Granskar datum, kapacitet och returnerar total kostnad.*

### Skapa bokning

Metod: POST  
URL: ``/hotels/{hotelId}/rooms/{roomId}/bookings``

Body (raw JSON):
```json
{
  "checkIn": "2026-01-10",
  "checkOut": "2026-01-12",
  "numberOfGuests": 2
}
```
*Skapar en bokning i databasen. Checkin sätts till 15:00 och checkout till 11:00.*

---
### GitHub repository
[Football Tripadvisor](https://github.com/andymalm-ux/football_tripadvisor)

#### Gruppmedlemmar
- Andreas: [andymalm-ux](https://github.com/andymalm-ux) 
- Hugo: [hugoerkelius](https://github.com/hugoerkelius) 
- Malin: [malinkytta](https://github.com/malinkytta) 
- Stefan: [Steff-hub-max](https://github.com/Steff-hub-max) 
- Thea: [theazukanovic](https://github.com/theazukanovic)
