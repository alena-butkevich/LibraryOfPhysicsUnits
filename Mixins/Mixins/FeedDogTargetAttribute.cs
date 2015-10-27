using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class FeedDogAttribute : Attribute
    {
        public Type BoundClass { get; private set; }

        public FeedDogAttribute(Type boundClass)
        {
            if(boundClass != typeof(Dog) && !boundClass.IsSubclassOf(typeof(Dog)))
                throw new ApplicationException("Bound class must be subclass of Dog");
            BoundClass = boundClass;
        }

    }
}
