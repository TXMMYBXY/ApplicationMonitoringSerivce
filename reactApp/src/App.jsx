import { useEffect, useState } from 'react';
import MonitoringService from "./public/Components/MonitoringService.jsx";
import { statisticsApi } from "./client/ApiClient.js";

function App() {
  const [statistics, setStatistics] = useState([]);
  const [devices, setDevices] = useState([]);
  const [statisticsDevice, setStatisticsDevice] = useState([])
  const [selectedDevice, setSelectedDevice] = useState([]);
  console.log('VITE ENV:', import.meta.env);
  const loadStatistics = async () => {
    try {
      const data = await statisticsApi.getAllStatistics();
      setStatistics(data);
    }
    catch (error) {
      console.log(error);
    }
  };

  const loadDevices = async () => {
    try{
      const date = await statisticsApi.getAllDevices();
      setDevices(date);
    }
    catch(error){
      console.log(error);
    }
  }

  const loadStatisticsByDevice = async (deviceId) => {
    try{
      setSelectedDevice(deviceId);
      const date = await statisticsApi.getStatisticsByDevice(deviceId);
      setStatisticsDevice(date);
    }
    catch(error){
      console.log(error);
    }
  }

  const onClickSendForm = async (form) =>{
    await statisticsApi.addStatistic(form)
    await loadStatistics()
  }

  const onClickDelete = async (id) => {
    await statisticsApi.deleteStatistic(id)
    await loadStatistics()
  }

  useEffect(() => {
    loadStatistics();
  }, []);

  useEffect(() => {
    loadDevices()
  }, []);

  return (
    <>
      <MonitoringService
        statistics={statistics}
        onLoadStatisticsButton = {loadStatistics}
        onClickSendForm={onClickSendForm}
        onClickDelete={onClickDelete}
        devices={devices}
        statisticsDevice={statisticsDevice}
        onChangeDevice={loadStatisticsByDevice}
        selectedDevice={selectedDevice}
      />
    </>
  )
}

export default App
