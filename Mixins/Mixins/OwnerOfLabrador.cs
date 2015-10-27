using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    [FeedDog(typeof(Labrador))]
    class OwnerOfLabrador : IFeedDog
    {
        public string name = "Owner of the labrador";
        public void Feed(Dog dog)
        {
            Console.WriteLine("{0} feeds {1}", name, dog.name);
        }
    }
}
