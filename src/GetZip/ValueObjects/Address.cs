using SmartValidations.ValueObjects;

namespace GetZip.ValueObjects
{
    public sealed class Address
    {
        public Address(CEP cEP, string publicPlaceType, string publicPlace, string complement, 
            string neighborhood, string city, UF uF, string iBGECity, string iBGEState)
        {
            CEP = cEP;
            PublicPlaceType = publicPlaceType;
            PublicPlace = publicPlace;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            UF = uF;
            IBGECity = iBGECity;
            IBGEState = iBGEState;
        }

        public CEP CEP { get; private set; }
        public string PublicPlaceType { get; private set; }
        public string PublicPlace { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; set; }
        public string City { get; private set; }
        public UF UF { get; private set; }
        public string IBGECity { get; private set; }
        public string IBGEState { get; set; }
    }
}
