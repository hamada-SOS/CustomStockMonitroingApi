
import { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';
import { CompanySearch } from './company';
import { searchCompanies } from './api';

function App() {
  const [search, setsearch] = useState<string>("");
  const [seaarchResult, setseaarchResult] = useState<CompanySearch[]>([]);
  const [serverError, setserverError] = useState<string>("");

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setsearch(e.target.value);
    console.log(search);
  }

  const onClick = async (e: SyntheticEvent) => {
    const result = await searchCompanies(search)
    if (typeof result === "string") {
      setserverError(result)
    } else if(Array.isArray(result)){
      setseaarchResult(result)
    }
    console.log(seaarchResult);
  };


  return (
    <div className="App">
      <Search search={search} onClick={onClick} handleChange={handleChange} />
      <CardList />
    </div>
  );
}

export default App;
