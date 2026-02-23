const Field = (props) => {
  const {
    children,
    type,
    classNameForLabel,
    classNameForInput,
    onChange,
    value,
  } = props

  return(
    <>
      <label
        className={classNameForLabel}
      ></label>
      <input
        type={type}
        className={classNameForInput}
        placeholder={children}
        onChange={onChange}
        value={value}
      ></input>
    </>
  )
}

export default Field