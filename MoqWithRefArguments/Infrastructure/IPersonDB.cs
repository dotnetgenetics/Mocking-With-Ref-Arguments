using MoqWithRefArguments.Models;

namespace MoqWithRefArguments.Infrastructure
{
    public interface IPersonDB
    {
        int Save(ref Person person);
    }
}
