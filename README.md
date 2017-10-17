# GetZip

- Package with useful zipcode search

## Nuget:

- This package is hosted on Nuget under the name "Malots.GetZip".
- Current Version is 1.0.0.

## Installation:

- Package Manager -> Install-Package Malots.GetZip -Version 1.0.1
- .NET CLI -> dotnet add package Malots.GetZip --version 1.0.1

## Example:

- This package contains many differnt webservices for search CEP information
 - Correios
 - CepLivre
 - ViaCep
 - RepublicaVirtual

- For CepLivre you need to create an account and take a generate key.

- You should see Unit tests

- Obs: When you search a zip information, if response have erro you check in address.IsValid() and the error in address.ErrorMessage