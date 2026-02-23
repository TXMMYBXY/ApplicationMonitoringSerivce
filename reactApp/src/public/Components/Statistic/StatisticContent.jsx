import Table from "../Table/Table.jsx";
import Button from "../Button/Button.jsx";

const StatisticContent = (props) => {
  const{
    statistics,
    onLoadStatisticsButton,
    onClickDelete,
  } = props;

  return (
    <>
      <div className="content-container">
        <Table
          statistics={statistics}
          className="statistic-table"
          onClickDelete={onClickDelete}
        />

        <div className="content-container-button">
          <Button
            type="button"
            onClick={onLoadStatisticsButton}
            children="Обновить"
            className="statistic-load-button"
          />
        </div>
      </div>
    </>
  )
}

export default StatisticContent;