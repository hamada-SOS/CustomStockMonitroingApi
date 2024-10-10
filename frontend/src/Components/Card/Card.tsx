import React from 'react';
import "./Card.css";
import path from 'path';
import { CompanySearch } from '../../company';

interface Props {
  id: string;
  result: CompanySearch;
  

}

const Card: React.FC<Props> = ({id,result}: Props): JSX.Element => {
  return (
    <div className='Card'>
      <img alt="image" />
      <div className="details">
        <h2>{result.name} ({result.symbol})</h2>
        <p>{result.currency}</p>
        <p className="info">{result.exchangeShortName} {result.stockExchange}</p>
      </div>
    </div>
  )
}

export default Card