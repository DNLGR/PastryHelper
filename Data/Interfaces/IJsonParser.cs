namespace Data.Interfaces
{
    public interface IJsonParser
    {
        public void Write(IPastryTable _pastryTable, string _path);

        public IPastryTable Read(string _path);
    }
}
