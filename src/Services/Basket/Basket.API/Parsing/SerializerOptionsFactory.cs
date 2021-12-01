using NodaTime;
using NodaTime.Serialization.SystemTextJson;
using NodaTime.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Basket.API.Parsing
{
    public static class SerializerOptionsFactory
    {
        public static JsonSerializerOptions GetSerializerOptions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var localTimeConverter = new NodaPatternConverter<LocalTime>(
                LocalTimePattern.CreateWithInvariantCulture("HH:mm"));

            var localDateConverter = new NodaPatternConverter<LocalDate>(
                LocalDatePattern.CreateWithInvariantCulture("yyyy-MM-dd"));

            options.Converters.Add(localTimeConverter);
            options.Converters.Add(localDateConverter);

            options.Converters.Add(new JsonStringEnumConverter());

            return options;
        }
    }
}
