import Header from "./Header/Header.jsx";
import Main from "./Main/Main.jsx";

const MonitoringService = (props) =>{
  const {
    statistics,
    onLoadStatisticsButton,
    onClickSendForm,
    onClickDelete,
    devices,
    statisticsDevice,
    onChangeDevice,
    selectedDevice,
  } = props

  return(
    <>
      <div className="statistic">
        <Header />
        <Main
          statistics={statistics}
          onLoadStatisticsButton={onLoadStatisticsButton}
          onClickSendForm={onClickSendForm}
          onClickDelete={onClickDelete}
          devices={devices}
          statisticsDevice={statisticsDevice}
          onChangeDevice={onChangeDevice}
          selectedDevice={selectedDevice}
        />
      </div>
    </>
  )
}

export default MonitoringService