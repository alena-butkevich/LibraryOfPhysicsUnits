using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    [FeedDog(typeof(Dog))]
    class OwnerOfDog : IFeedDog
    {
        public string name = "Owner of the dog";
        public void Feed(Dog dog)
        {
            Console.WriteLine("{0} feeds {1}", name, dog.name);
        }
    }
}
