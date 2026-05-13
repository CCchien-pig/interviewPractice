package blackjack

// ParseCard returns the integer value of a card following blackjack ruleset.
func ParseCard(card string) int {
	var value int
    switch card{
        case "ace" : value = 11
        case "two" : value = 2
        case "three" : value = 3
        case "four" : value = 4
        case "five" : value = 5
        case "six" : value =6
        case "seven" : value = 7
        case "eight" : value = 8
        case "nine" : value = 9
        case "ten" : value = 10
        case "jack" : value = 10
        case "queen" : value = 10
        case "king" : value = 10
        default : value = 0
    }
    return value
}

// FirstTurn returns the decision for the first turn, given two cards of the
// player and one card of the dealer.
func FirstTurn(card1, card2, dealerCard string) string {
    var option string
    var dealerFaceCard bool
    var card1Value = ParseCard(card1)
    var card2Value = ParseCard(card2)
    var dealerCardValue = ParseCard(dealerCard)

	if dealerCard == "jack" || dealerCard == "queen" || dealerCard == "king"{
        dealerFaceCard = true
    }
    
	switch{
        case card1 == "ace" && card2 == "ace" : option = "P"
        case card1Value+card2Value==21 && (dealerCard=="ace" || dealerFaceCard == true || dealerCard == "ten") : option = "S"
        case card1Value+card2Value==21 && dealerCard!="ace" &&  dealerFaceCard == false && dealerCard != "ten" : option = "W"
        case card1Value+card2Value>=17 && card1Value+card2Value<=20 : option = "S"
        case card1Value+card2Value>=12 && card1Value+card2Value<=16 && dealerCardValue>=7 : option = "H"
        case card1Value+card2Value>=12 && card1Value+card2Value<=16 : option = "S"
        case card1Value+card2Value<=11 : option = "H"
        default : option = ""
    }
    return option
}
