import React from 'react'
import Card from '../Card/Card'
import { CompanySearch } from '../../company';
import {v4 as uuid} from "uuid";
interface Props {
  searchReasult: CompanySearch[];
}

const CardList: React.FC<Props> = ({searchReasult}: Props): JSX.Element => {
  return (
    <>
      {searchReasult.length > 0 ? (
        searchReasult.map((result) => {
          return <Card id={result.symbol} key={uuid()} result={result}/>
        })
      ) : <h1>No results</h1>}
    </>
  )
}

export default CardList