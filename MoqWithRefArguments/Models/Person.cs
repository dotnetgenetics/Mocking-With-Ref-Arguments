namespace MoqWithRefArguments.Models
{
    public class Person
    {
        public int SocialSecurityID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public  string StatusUpdate { get; set; }

        public Person()
        {
            SocialSecurityID = 0;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            StatusUpdate = string.Empty;
        }
    }
}
