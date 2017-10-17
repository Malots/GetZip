using System;
using System.Text;

namespace GetZip.ValueObject
{
    /// <summary>
    /// Address value object
    /// </summary>
    public sealed class Address
    {
        public Address()
        {
            ErrorMessage = null;
        }

        #region Properties
        public string CEP { get; set; }
        public string PublicPlaceType { get; set; }
        public string PublicPlace { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string IBGE { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Convert address to string
        /// </summary>
        /// <returns>string value</returns>
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

        /// <summary>
        /// Check if address contains any error
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return ErrorMessage is null;
        }
        #endregion
    }
}
