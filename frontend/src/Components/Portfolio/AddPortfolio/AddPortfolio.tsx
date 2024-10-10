import React, { SyntheticEvent } from 'react'

interface Props {
    Symbol: string
    OnPortfolioSubmit: (e: SyntheticEvent) => void;
}

const AddPortfolio = ({Symbol, OnPortfolioSubmit}: Props) => {
  return (
    <form onSubmit={OnPortfolioSubmit}>
        <input readOnly={true} hidden={true} value={Symbol}></input>
        <button type='submit'>Add</button>
    </form>
  )
}

export default AddPortfolio