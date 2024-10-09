import { Console } from 'console';
import React,{SyntheticEvent, useState} from 'react'

type Props = {}

const Search: React.FC<Props> = (props: Props): JSX.Element => {
    const [search, setsearch] = useState<string>("");
    const handleChange = (e:any) => {
        setsearch(e.target.value);
        console.log(search);
        
    }

    const onclick = (e: SyntheticEvent) => {
        console.log(e);
    }
  return (
    <div>
        <input value={search} onChange={(e) => handleChange(e)}></input>
        <button onClick={(e) => onclick(e)}></button>
    </div>
  );
}

export default Search;