import Field from "../Field/Field.jsx";
import Button from "../Button/Button.jsx";
import { useState } from "react";

const AddForm = (props) => {
  const {
    onClickSendForm,
    onClickCloseModal,
    isOpen
  } = props;

  const [formData, setFormData] = useState({
    _id: "", name: "", startTime: "", endTime: "", version: ""
  });

  if (!isOpen) return null;

  return (
    <div className="popup-wrapper">
      <form className="popup-form">
        <Field
          children="ID устройства"
          type="text"
          classNameForLabel="form-add-field-label"
          classNameForInput="form-add-field-input"
          value={formData._id}
          onChange={(event) => setFormData({...formData, _id: event.target.value})}
        />
        <Field
          children="Имя"
          type="text"
          classNameForLabel="form-add-field-label"
          classNameForInput="form-add-field-input"
          value={formData.name}
          onChange={(event) => setFormData({...formData, name: event.target.value})}
        />
        <Field
          children="Время начала"
          type="text"
          classNameForLabel="form-add-field-label"
          classNameForInput="form-add-field-input"
          value={formData.startTime}
          onChange={(event) => setFormData({...formData, startTime: event.target.value})}
        />
        <Field
          children="Время окончания"
          type="text"
          classNameForLabel="form-add-field-label"
          classNameForInput="form-add-field-input"
          value={formData.endTime}
          onChange={(event) => setFormData({...formData, endTime: event.target.value})}
        />
        <Field
          children="Версия"
          type="text"
          classNameForLabel="form-add-field-label"
          classNameForInput="form-add-field-input"
          value={formData.version}
          onChange={(event) => setFormData({...formData, version: event.target.value})}
        />
        <div className="form-add-actions">
          <Button
            type="button"
            children="Отправить форму"
            className="form-add-button"
            onClick={() => {
              try {
                onClickSendForm(formData);
                setFormData({_id: "", name: "", startTime: "", endTime: "", version: ""});
              }
              catch (error) {
                alert(error);
              }
            }}
          />
          <Button
            type="button"
            children="Очистить форму"
            className="form-add-button"
            onClick={() => setFormData({_id: "", name: "", startTime: "", endTime: "", version: ""})}
          />
          <Button
            children="Закрыть окно"
            className="form-add-button"
            onClick={onClickCloseModal}
          />
        </div>
      </form>
    </div>
  );
};

export default AddForm;