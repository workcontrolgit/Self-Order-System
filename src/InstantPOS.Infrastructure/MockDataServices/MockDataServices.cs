using InstantPOS.Application.MockDataServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstantPOS.Infrastructure.MockDataServices
{
    public class MockDataServices<T> : IMockDataService<T>
        where T : class, new()
    {
        /// <summary>
        /// Generates a collection of type T based on the properties in T
        /// </summary>
        /// <returns>List<T></returns>
        public async Task<IEnumerable<T>> Collection() => GenFu.GenFu.ListOf<T>();

        /// <summary>
        /// Generates the collection of type T of size = length 
        /// </summary>
        /// <param name="length">The size of the collection to be passed</param>
        /// <returns>A collection of type T based on the length passed</returns>
        public async Task<IEnumerable<T>> Collection(int length) => GenFu.GenFu.ListOf<T>(length);

        /// <summary>
        /// Generates an object of type T with data
        /// </summary>
        /// <returns>T with data based on the properties in T</returns>
        public T Instance() => GenFu.GenFu.New<T>();
    }
}
