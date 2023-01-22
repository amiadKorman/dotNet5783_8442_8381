namespace DalApi;

public interface ICrud<T> where T : struct
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
    T Get(int id);

    /// <summary>
    /// Return item by given filter
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    T Get(Func<T?, bool>? filter);

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
