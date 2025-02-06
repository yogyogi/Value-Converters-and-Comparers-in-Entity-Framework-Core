using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace VCC.Models
{
    public class ToUpperConverter : ValueConverter<string, string>
    {
        public ToUpperConverter() : base(
            v => v.Trim().ToUpper(),
            v => v)
        {
        }
    }
}
