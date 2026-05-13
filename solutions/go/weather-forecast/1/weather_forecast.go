/*
Package weather is for weather forcasting. The valuable CurrentCondition is the condition of weather and the valuable CurrentLocation is the location now.
*/
package weather

var (
    //CurrentCondition stores the value of condition of weather information now.
	CurrentCondition string 
    // CurrentLocation stores the value of location now.
	CurrentLocation  string
)

/*Forecast is used to forecast the weather in the future when you import CurrentCondition and CurrentLocation.*/
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
