import React from 'react'
import Card from '../Card/Card';
import CardPortfolio from '../CardPortfolio/CardPortfolio';

interface Props {
    portfolioValue: string[];
}

const ListPortfolio = ({portfolioValue}: Props) => {
  return (
    <>
        <h3>My Portfolio</h3>
        <ul>
            {portfolioValue && portfolioValue.map((values) => {
                return <CardPortfolio portfolioValue={values} />
            })}
        </ul>
    </>

  )
}

export default ListPortfolio