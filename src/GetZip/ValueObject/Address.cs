namespace GetZip.ValueObject
{
    public sealed class Address
    {
        public Address(string cep, string publicPlaceType, string publicPlace, string complement, 
            string neighborhood, string city, string uf)
        {
            CEP = cep;
            PublicPlaceType = publicPlaceType;
            PublicPlace = publicPlace;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            UF = uf;
        }

        public string CEP { get; private set; }
        public string PublicPlaceType { get; private set; }
        public string PublicPlace { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; set; }
        public string City { get; private set; }
        public string UF { get; private set; }
    }
}
