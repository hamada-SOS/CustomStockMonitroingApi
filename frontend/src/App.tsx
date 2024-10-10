
import { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';
import { CompanySearch } from './company';
import { searchCompanies } from './api';
import ListPortfolio from './Components/ListPortfolio/ListPortfolio';

function App() {

  const [search, setsearch] = useState<string>("");
  const [portfolioValue, setportfolioValue] = useState<string[]>([])
  const [seaarchResult, setseaarchResult] = useState<CompanySearch[]>([]);
  const [serverError, setserverError] = useState<string>("");

  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
    setsearch(e.target.value);
    console.log(search);
  }

  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(search)
    if (typeof result === "string") {
      setserverError(result)
    } 
    else if(Array.isArray(result)){
      setseaarchResult(result)
    }
    console.log(seaarchResult);
  };


  const OnPortfolioSubmit = (e: any) =>{
    e.preventDefault();
    const exist = portfolioValue.find((value) => value === e.target[0].value)
    if(exist) return;
    const updatedPortfolio = [...portfolioValue, e.target[0].value]
    setportfolioValue(updatedPortfolio)
    console.log(e);
  }


  return (
    <div className="App">
      <Search search={search} onSearchSubmit={onSearchSubmit} handleSearchChange={handleSearchChange} />
      <ListPortfolio portfolioValue={portfolioValue}/>
      <CardList searchReasult={seaarchResult} OnPortfolioSubmit={OnPortfolioSubmit} />
    </div>
  );
}

export default App;
