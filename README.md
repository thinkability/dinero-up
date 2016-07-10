# dinero-up
Højreklik og upload dine bilag til [Dinero](http://www.dinero.dk).

Dette projekt installerer en højrekliks-menu i Windows, som gør det muligt at uploade bilag direkte til Dinero fra Stifinder.

## Installation
Koden bruger [SharpShell](https://github.com/dwmkerr/sharpshell) til at registrere en højre-kliks menu i Windows Stifinder via COM.

Inden installation skal værdierne i ClientConfiguration.cs erstattes med dine egne værdier:

```csharp
public static string ClientId => "[client-id]";
public static string ClientSecret => "[client-secret]";
public static string ApiKey => "[api key]";
public static int CompanyId => 000000; //company ID
```

*dinero-up* installeres ved at køre **ServerManager.exe**.

## Dinero API'et
Læs mere om Dinero's API her: [Dinero API documentation](https://api.dinero.dk/docs).

## Send mig dit forslag
Skriv til mig på [think@thinkability.dk](mailto:think@thinkability.dk) hvis du har spørgsmål eller forslag til forbedringer. Forslag til andre apps modtages også gerne :) 
