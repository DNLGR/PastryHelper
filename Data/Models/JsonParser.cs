using System.Text.Json;

namespace Data.Models
{
    public class JsonParser : IJsonParser
    {
        private StreamReader? _streamReader;

        private StreamWriter? _streamWriter;

        public IPastryTable? Read(string _path)
        {
            string results = string.Empty;

            using (_streamReader = new StreamReader(_path))
            {
                results = _streamReader.ReadToEndAsync().Result;
            }

            if (string.IsNullOrEmpty(results) || string.IsNullOrWhiteSpace(results))
            {
                return null;
            }

            return JsonSerializer.Deserialize<IPastryTable>(results) ?? null;
        }

        public void Write(IPastryTable _pastryTable, string _path)
        {
            if (_pastryTable == null)
            {
                return;
            }

            using (_streamWriter = new StreamWriter(_path))
            {
                _streamWriter.Write(JsonSerializer.Serialize(_pastryTable));
            }
        }
    }
}
