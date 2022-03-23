import { ClearDay, ClearNight, DayPartialCloud, NightPartialCloud, Cloudy, DayRain, NightRain, Rain, RainThunder, Day, Night } from '../assets/index'



export function getIconByType(type, isDay) {
  switch (type) {
    case "Mostly Clear":
    case "Partly Cloudy":
      if (isDay)
        return DayPartialCloud;
      return NightPartialCloud;
    case "Slight Chance Rain Showers then Partly Sunny":
    case "Chance Rain Showers":
      if (isDay)
        return DayRain;
      return NightRain;
    case "Rain Showers Likely":
      return Rain;
    case "Showers And Thunderstorms Likely":
      return RainThunder;
    case "Cloudy":
      return Cloudy;
    default:
      if (isDay)
        return ClearDay;
      return ClearNight;
  }
}
export function getBackground(isDay){
  if(isDay)
    return Day;
  return Night;
}