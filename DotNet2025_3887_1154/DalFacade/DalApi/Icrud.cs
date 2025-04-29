using DO;

namespace DalApi;

public interface Icrud<T>
{
    int Create(T item);
    T? Read(Func<T, bool> filter);
    T? Read(int id);
    List<T?> ReadAll(Func<T, bool>? filter = null); 
    void Update(T item);
    void Delete(int id);

}
