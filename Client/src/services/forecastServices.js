import axios from "axios";
import {GET_FORCAST} from './constants'


export const GetForecastByAddress = async (address) => {

    try {
      const result = await axios.post("https://localhost:44339"+GET_FORCAST,{ address });
      // do an SDK, DB call or API endpoint axios call here and return the promise.
      return result.data
    
    } catch (error) {
      console.error("in services > updateLastCwkId, Err===", error);
      return null;
    }
};

