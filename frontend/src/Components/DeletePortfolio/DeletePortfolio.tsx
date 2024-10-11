import React, { SyntheticEvent } from 'react'

interface Props {
    OnPortfolioDelete: (e:SyntheticEvent) => void;
    portfolioValue:string;
}

const DeletePortfolio = ({OnPortfolioDelete, portfolioValue}: Props) => {
  return (
    <div>
        <form onSubmit={OnPortfolioDelete}>
            <input hidden={true} value={portfolioValue}/>
            <button>X</button>
        </form>
    </div>
  )
}

export default DeletePortfolio