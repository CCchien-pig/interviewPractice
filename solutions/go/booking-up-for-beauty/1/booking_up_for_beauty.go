package booking

import ("fmt"
    	"time")      

// Schedule returns a time.Time from a string containing a date.
func Schedule(date string) time.Time {
	layout := "1/2/2006 15:04:05"
	t, err := time.Parse(layout, date)
	if err != nil {
		panic(err) 
	}
	return t
}

// HasPassed returns whether a date has passed.
func HasPassed(date string) bool {
	layout := "January 2, 2006 15:04:05"
	
	t, err := time.Parse(layout, date)
	if err != nil {
		panic(err)
	}
	
	// 比較是否在現在時間之前
	return t.Before(time.Now())
}

// IsAfternoonAppointment returns whether a time is in the afternoon.
func IsAfternoonAppointment(date string) bool {
	layout := "Monday, January 2, 2006 15:04:05"
    t,err := time.Parse(layout,date)
    if err != nil {
		panic(err)
	}
	if t.Hour()>=12 && t.Hour()<=18{
        return true
    }
    return false
}

// Description returns a formatted string of the appointment time.
func Description(date string) string {
	// 1. 先把輸入的字串解析成 time.Time 物件
	parseLayout := "1/2/2006 15:04:05"
	t, err := time.Parse(parseLayout, date)
	if err != nil {
		panic(err)
	}

	// 2. 將時間格式化為目標長相
	formatLayout := "Monday, January 2, 2006, at 15:04"
	formattedTime := t.Format(formatLayout)

	// 3. 組合出最終的完整句子
	return fmt.Sprintf("You have an appointment on %s.", formattedTime)
}

// AnniversaryDate returns a Time with this year's anniversary.
func AnniversaryDate() time.Time {
	annivesaryDate := "09/15/2020, 00:00"
    layout := "01/02/2006, 15:04"
    t,err := time.Parse(layout,annivesaryDate)
    
    if err != nil {
		panic(err)
	}
	currentyear := time.Now().Year()
    startYear := t.Year()
	yearsToAdd :=   currentyear - startYear;
    return t.AddDate(yearsToAdd,0,0)
}
