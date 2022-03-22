import axios from "axios";
import {GET_FORCAST} from './constants'


export const GetForecastByAddress = async (address) => {

    try {
      const params = new URLSearchParams([['address', address]]);
      const result = await axios.get("https://localhost:44339"+GET_FORCAST,{ params });
      return result.data
    
    } catch (error) {
      console.error("Request Err===", error);
      return null;
    }
};

