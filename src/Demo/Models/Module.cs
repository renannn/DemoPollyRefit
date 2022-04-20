using Demo.Interfaces;

namespace Demo.Models
{
    public class Module : IHasId<int>, IHasName
    {
        public int Id { get; }

        public string Nome { get; set; }
    }
}
