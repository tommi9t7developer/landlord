using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace LandLord
{
    public class IMieterConverter : JsonConverter<IMieter>
    {
        public override IMieter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonObject = JsonDocument.ParseValue(ref reader).RootElement;
            var mieter = JsonSerializer.Deserialize<Mieter>(jsonObject.ToString(), options);
            if (mieter == null)
            {
                MessageBox.Show("MieterConverter Mieter ist null, Read");
            }
            return mieter;
        }

        public override void Write(Utf8JsonWriter writer, IMieter value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (Mieter)value, options);
        }
    }

}
