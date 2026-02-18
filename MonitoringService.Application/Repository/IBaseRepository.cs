namespace MonitoringService.Application.Repository;

public interface IBaseRepository<T> where T : class
{
    /// <summary>
    /// Возврат всех записей
    /// </summary>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Возврат записи по id
    /// </summary>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Добавление записи
    /// </summary>
    Task AddAsync(T entity);

    /// <summary>
    /// Обновление записи
    /// </summary>
    void Update(T entity);

    /// <summary>
    /// Удаление записи
    /// </summary>
    void Delete(T entity);

    /// <summary>
    /// Сохранение изменений в таблицах
    /// </summary>
    Task SaveChangesAsync();
}