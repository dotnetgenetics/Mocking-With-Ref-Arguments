using MoqWithRefArguments.Models;

namespace MoqWithRefArguments.Infrastructure
{
    public class PersonDB : IPersonDB
    {
        public int Save(ref Person person)
        {
            person.StatusUpdate = "Person saved successfully.";
            return 1;
        }
    }
}
