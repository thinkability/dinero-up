# dinero-up [![Build status](https://ci.appveyor.com/api/projects/status/dkwjjjs0fjkmm1l0?svg=true)](https://ci.appveyor.com/project/thinkability/dinero-up)
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

## Roadmap
Nedenstående er på to-do listen:
* Pæn installer
* Upload-dialogbox
* Proxy-løsning til at omgå behovet for client-id og client-secret i koden. Dette er nødvendigt så længe Dinero's API kræver en klient-identifikation. 

## Send mig dit forslag
Skriv til mig på [think@thinkability.dk](mailto:think@thinkability.dk) hvis du har spørgsmål eller forslag til forbedringer.
