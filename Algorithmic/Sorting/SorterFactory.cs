using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithmic.Sorting
{
    public class SorterFactory
    {
        private ISorter[] _sorters;

        public SorterFactory()
        {
            var sorterType = typeof(ISorter);
            _sorters = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => sorterType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(s => Activator.CreateInstance(s) as ISorter).ToArray();
        }

        public IEnumerable<ISorter> GetAllSorters()
        {
            return _sorters;
        }
    }
}
