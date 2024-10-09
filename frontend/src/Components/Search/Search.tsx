import { Console } from 'console';
import React,{ChangeEvent, SyntheticEvent, useState} from 'react'

interface Props {
    onClick: (e:SyntheticEvent) => void;
    search: string | undefined;
    handleChange: (e:ChangeEvent<HTMLInputElement>) => void;
}

const Search: React.FC<Props> = ({onClick, handleChange, search}: Props): JSX.Element => {

  return (
    <div>
        <input value={search} onChange={(e) => handleChange(e)}></input>
        <button onClick={(e) => onClick(e)}></button>
    </div>
  );
}

export default Search;