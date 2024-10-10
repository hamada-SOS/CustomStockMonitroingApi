import React, { SyntheticEvent } from 'react';
import "./Card.css";
import path from 'path';
import { CompanySearch } from '../../company';
import AddPortfolio from '../Portfolio/AddPortfolio/AddPortfolio';

interface Props {
  id: string;
  result: CompanySearch;
  OnPortfolioSubmit: (e: SyntheticEvent) => void;
  

}

const Card: React.FC<Props> = ({id,result, OnPortfolioSubmit}: Props): JSX.Element => {
  return (
    <div className='Card'>
      <img alt="image" />
      <div className="details">
        <h2>{result.name} ({result.symbol})</h2>
        <p>{result.currency}</p>
        <p className="info">{result.exchangeShortName} {result.stockExchange}</p>
      </div>
      <AddPortfolio Symbol={result.symbol} OnPortfolioSubmit={OnPortfolioSubmit}/>
    </div>
  )
}

export default Card