using MoqWithRefArguments.Infrastructure;
using MoqWithRefArguments.Models;

namespace MoqWithRefArguments
{
    public class PersonProcessor
    {
        private readonly IPersonDB _personDB;

        public PersonProcessor(IPersonDB personDB)
        {
            _personDB = personDB;
        }

        public bool SavePersonInfo(Person person)
        {
            int statusCode = _personDB.Save(ref person);

            return statusCode == 1;
        }
    }
}
