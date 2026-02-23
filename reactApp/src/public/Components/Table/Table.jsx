import Button from "../Button/Button.jsx";

const Table = (props) => {
  const {
    statistics,
    className,
    onClickDelete,
  } = props

  return (
      <table className={className}>
        <thead>
        <tr>
          <th>ID устройства</th>
          <th>Имя</th>
          <th>Время начала</th>
          <th>Время окончания</th>
          <th>Версия</th>
          <th>Действия</th>
        </tr>
        </thead>
        <tbody>
        {statistics.length > 0 ? (
          statistics.map((stat, index) => (
            <tr key={stat.id || index}>
              <td>{stat._id}</td>
              <td>{stat.name}</td>
              <td>{stat.startTime}</td>
              <td>{stat.endTime}</td>
              <td>
                <span>{stat.version || '-'}</span>
              </td>
              <td>
                <Button
                  children="Удалить"
                  type="button"
                  onClick={() => onClickDelete(stat.id)}
                />
              </td>
            </tr>
          ))
        ) : (
          <tr>
            <td colSpan="6" style={{ textAlign: 'center', padding: '20px' }}>
              Нет данных для отображения
            </td>
          </tr>
        )}
        </tbody>
      </table>
  )
}

export default Table;