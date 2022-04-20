using Demo.Interfaces;
using System.Collections.Generic;

namespace Demo.Models
{
    public class User : IHasId<int>, IHasName
    {
        public int Id { get; }

        public string Nome { get; set; }

        public IEnumerable<int> Modules { get; set; }
    }
}
