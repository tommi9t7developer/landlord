using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;
using System.Windows;
using LandLord.ViewModels;

namespace LandLord.Converter
{

    public class IWohnungConverter : JsonConverter<IWohnung>
    {

        public override IWohnung Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Deserialize as the concrete type
            var wohnung = JsonSerializer.Deserialize<Wohnung>(ref reader, options);
            if (wohnung == null)
            {
                MessageBox.Show("MieterConverter Wohnung ist null, Read");
            }

            return wohnung;
        }

        public override void Write(Utf8JsonWriter writer, IWohnung value, JsonSerializerOptions options)
        {
            // Serialize as the concrete type
            JsonSerializer.Serialize(writer, (Wohnung)value, options);
        }
    }

}
