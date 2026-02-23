const Devices = (props) => {
  const {
    className,
    onChangeDevice,
    value,
    devices = [],
    statistics = [],
  } = props;

  // Гарантируем, что selectValue — всегда строка
  const selectValue = typeof value === "string" ? value : "";

  const handleChange = (event) => {
    const deviceId = event.target.value;
    onChangeDevice(deviceId);
  };

  return (
    <div className="content-container">
      <h3>Статистика по устройству</h3>

      <select
        value={selectValue}
        onChange={handleChange}
        className="select-device"
      >
        <option value="">Выберите устройство</option>
        {Array.isArray(devices) && devices.map((device, index) => (
          <option
            key={`device-${device._id || device.id || index}`}
            value={String(device._id || device.id || "")}
          >
            {device.name || device._id || device.id}
          </option>
        ))}
      </select>

      <div>
        <table className="statistic-table">
          <thead>
          <tr>
            <th>Имя</th>
            <th>Время начала</th>
            <th>Время окончания</th>
            <th>Версия</th>
          </tr>
          </thead>
          <tbody>
          {Array.isArray(statistics) && statistics.length > 0 ? (
            statistics.map((stat, index) => (
              <tr key={`stat-${index}-${stat._id || stat.id}`}>
                <td>{stat.name}</td>
                <td>{stat.startTime}</td>
                <td>{stat.endTime}</td>
                <td>{stat.version || '-'}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="5" style={{ textAlign: 'center', padding: '20px' }}>
                {selectValue
                  ? "Нет данных для выбранного устройства"
                  : "Выберите устройство для отображения данных"
                }
              </td>
            </tr>
          )}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default Devices;