import axios from "axios";

import { CompanySearch } from "./company";

interface SearchResponse {
    data: CompanySearch[];
}

export const searchCompanies = async (query:string) => {
    try{
        const data = await axios.get<SearchResponse>(
            `https://financialmodelingprep.com/api/v3/search?query=${query}&apikey=${process.env.REACT_APP_API_KEY}`
        );
        return data.data;
    } catch (error) {
        if(axios.isAxiosError(error)){
            console.log("error massage: ", error.message)
            return error.message;
        }else{
            console.log("Uncxpeted error: ", error)
            return"fatel error";
        }
    }
};