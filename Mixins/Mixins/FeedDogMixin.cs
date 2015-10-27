using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    static class FeedDogMixin
    {
       private static Dictionary<Type, Func<IFeedDog>> myDelegate;

       private static Exception exception;

       static FeedDogMixin()
       {
            try
            {
                var assembly = Assembly.GetExecutingAssembly()
                                     .GetTypes()
                                     .Select(t => new { Type = t, Attribute = (FeedDogAttribute)t.GetCustomAttributes(typeof(FeedDogAttribute), false).SingleOrDefault() })
                                     .Where(obj => obj.Attribute != null).ToArray();

                foreach (var type in assembly.Select(obj => obj.Attribute.BoundClass).Distinct())
                    if (assembly.Count(obj => obj.Attribute.BoundClass == type) > 1)
                        throw new ApplicationException(string.Format("{ 0} have more then one binding", type.FullName));

                myDelegate = assembly.ToDictionary(obj => obj.Attribute.BoundClass, obj => new Func<IFeedDog>(() => (IFeedDog)Activator.CreateInstance(obj.Type)));
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        public static void Feed(this Dog dog)
        {
            GetMixinFor(dog.GetType()).Feed(dog);
        }

        private static IFeedDog GetMixinFor(Type docType)
        {
            if (exception != null)
                throw new ApplicationException(string.Format("Exception: { 0}", exception.Message), exception);

            if (!myDelegate.ContainsKey(docType))
                throw new ApplicationException(string.Format("Exception: { 0} have no binding", docType.FullName));
            return myDelegate[docType]();
        }
    }
}
