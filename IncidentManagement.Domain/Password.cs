namespace IncidentManagement.Domain
{
    public class Password
    {
        public string Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}
