namespace CaseMgmtPortal.Models
{
    public class Value
    {
        public int id { get; set; }
        public Child child { get; set; }
        public Reporter reporter { get; set; }
        public DateTime date { get; set; }
    }
}
