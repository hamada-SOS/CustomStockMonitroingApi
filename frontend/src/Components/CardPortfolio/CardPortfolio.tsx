import React, { SyntheticEvent } from 'react'
import DeletePortfolio from '../DeletePortfolio/DeletePortfolio';

interface Props {
    portfolioValue: string
    OnPortfolioDelete: (e:SyntheticEvent) => void;
}

const CardPortfolio = ({portfolioValue, OnPortfolioDelete}: Props) => {
  return (
    <>
        <h3>{portfolioValue}</h3>
        <DeletePortfolio portfolioValue={portfolioValue} OnPortfolioDelete={OnPortfolioDelete} />
    </>
  )
}

export default CardPortfolio