using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface ICrud<T> where T : class
    {
        /// <summary>
        /// Add item to list of items
        /// </summary>
        /// <param name="item"></param>
        /// <returns> item id </returns>
        int Add(T item);
        /// <summary>
        /// Return item by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> item </returns>
        T GetById(int id);
        /// <summary>
        /// Return all items in DataSource by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);
        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
