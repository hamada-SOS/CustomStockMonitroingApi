import React, { SyntheticEvent } from 'react'
import Card from '../Card/Card';
import CardPortfolio from '../CardPortfolio/CardPortfolio';

interface Props {
    portfolioValue: string[];
    OnPortfolioDelete: (e:SyntheticEvent) => void
}

const ListPortfolio = ({portfolioValue, OnPortfolioDelete}: Props) => {
  return (
    <>
        <h3>My Portfolio</h3>
        <ul>
            {portfolioValue && portfolioValue.map((values) => {
                return <CardPortfolio portfolioValue={values} OnPortfolioDelete={OnPortfolioDelete} />
            })}
        </ul>
    </>

  )
}

export default ListPortfolio