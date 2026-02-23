import AddForm from "../Form/AddForm.jsx";
import StatisticContent from "../Statistic/StatisticContent.jsx";
import { useState } from "react";
import Button from "../Button/Button.jsx";
import Devices from "../Devices/Devices.jsx";

const Main =(props) =>{
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

  const [modalIsOpen, setModalIsOpen] = useState(false)

  return (
    <>
      <main>
        <Button
          children="Новая статистика"
          onClick={() => setModalIsOpen(true)}
          className="statistic-load-button"
        />

        <AddForm
          onClickSendForm={onClickSendForm}
          onClickCloseModal={() => setModalIsOpen(false)}
          isOpen={modalIsOpen}
        />

        <StatisticContent
          statistics={statistics}
          onLoadStatisticsButton={onLoadStatisticsButton}
          onClickDelete={onClickDelete}
        />

        <Devices
          devices={devices}
          statistics={statisticsDevice}
          onChangeDevice={onChangeDevice}
          value={selectedDevice}
        />
      </main>
    </>
  )
}

export default Main;