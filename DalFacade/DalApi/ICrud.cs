﻿namespace DalApi;

public interface ICrud<T> where T : struct
{
    int Add(T item);
    T GetById(int id);
    IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);
    void Update(T item);
    void Delete(int id);
}