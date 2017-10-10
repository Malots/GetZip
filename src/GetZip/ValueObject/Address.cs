using System;
using System.Text;

namespace GetZip.ValueObject
{
    public sealed class Address
    {
        public Address(string cep, string publicPlaceType, string publicPlace, string complement, 
            string neighborhood, string city, string uf, string ibge)
        {
            CEP = cep;
            PublicPlaceType = publicPlaceType;
            PublicPlace = publicPlace;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            UF = uf;
            IBGE = ibge;
        }

        public string CEP { get; private set; }
        public string PublicPlaceType { get; private set; }
        public string PublicPlace { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; set; }
        public string City { get; private set; }
        public string UF { get; private set; }
        public string IBGE { get; private set; }

        public override string ToString() 
            => new StringBuilder()
                  .Append(nameof(CEP)).Append(" : ").Append(CEP).Append(Environment.NewLine)
                  .Append(nameof(PublicPlaceType)).Append(" : ").Append(PublicPlaceType).Append(Environment.NewLine)
                  .Append(nameof(PublicPlace)).Append(" : ").Append(PublicPlace).Append(Environment.NewLine)
                  .Append(nameof(Complement)).Append(" : ").Append(Complement).Append(Environment.NewLine)
                  .Append(nameof(Neighborhood)).Append(" : ").Append(Neighborhood).Append(Environment.NewLine)
                  .Append(nameof(City)).Append(" : ").Append(City).Append(Environment.NewLine)
                  .Append(nameof(UF)).Append(" : ").Append(UF).Append(Environment.NewLine)
                  .Append(nameof(IBGE)).Append(" : ").Append(IBGE).Append(Environment.NewLine)
                  .ToString();
    }
}
