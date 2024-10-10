import { Console } from 'console';
import React,{ChangeEvent, SyntheticEvent, useState} from 'react'

interface Props {
    onSearchSubmit: (e:SyntheticEvent) => void;
    search: string | undefined;
    handleSearchChange: (e:ChangeEvent<HTMLInputElement>) => void;
}

const Search: React.FC<Props> = ({onSearchSubmit, handleSearchChange, search}: Props): JSX.Element => {

  return (
    <>
      <form onSubmit={onSearchSubmit}>
          <input value={search} onChange={(e) => handleSearchChange(e)}></input>
      </form>
    </>
  );
}

export default Search;