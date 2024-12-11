using DO;

namespace DalApi;

public interface Icrud<T>
{
    int Create(T client);
    T? Read(Func<T, bool> filter);
    T? Read(int id);
    List<T?> ReadAll(Func<T, bool>? filter = null); 
    void Update(T client);
    void Delete(int id);

}
