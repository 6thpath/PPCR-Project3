
#add @web tag to run the search tests with Selenium automation

#@automated
@web
Feature: US01 - View Project Details
	As an normal user
	I want to see the detail of the project I choose

#Background:
	#Given the following Project
	#| PropertyName                                 | Street_ID | Ward_ID | District_ID | Price  | UnitPrice | Area  | Bedroom | Bathroom | ParkingPlace | Status_ID |
	#| PIS Top Apartment                            | 748       | 2       | 2           | 10000  | USD       | 120m2 | 3       | 3        | 1            | 3         |
	#| ICON 56 – Modern Style Apartment             | 750       | 3       | 2           | 30000  | USD       | 130m2 | 2       | 4        | 1            | 3         |
	#| PIS Serviced Apartment – Boho Style          | 749       | 4       | 2           | 70000  | USD       | 120m2 | 3       | 2        | 1            | 3         |
	#| Bigroom with Riverview                       | 752       | 5       | 2           | 90000  | USD       | 200m2 | 2       | 3        | 1            | 3         |
	#| PIS Serviced Apartment – Style 3             | 755       | 33      | 3           | 30000  | USD       | 130m2 | 2       | 4        | 1            | 3         |
	#| Vinhomes Central Park L2 – Duong’s Apartment | 756       | 34      | 3           | 110000 | USD       | 150m2 | 4       | 2        | 1            | 3         |
	#| Saigon Pearl Ruby Block                      | 758       | 35      | 3           | 30000  | USD       | 130m2 | 3       | 3        | 1            | 3         |
	#| Nguyen Dinh Chinh – Duplex with Balcony      | 760       | 36      | 3           | 200000 | USD       | 120m2 | 3       | 2        | 2            | 3         |
	#| Sunshine Ben Thanh                           | 754       | 40      | 3           | 40000  | USD       | 130m2 | 2       | 2        | 1            | 3         |
	#| Cosiana Apartment with Balcony               | 716       | 41      | 3           | 990000 | USD       | 500m2 | 2       | 4        | 1            | 3         |
	


Scenario: All details should be matched
	Given I was in Projects list view 
	When I click the ViewDetail button of the project 'PIS Top Apartment'
	Then the name of project on detail page should be: 'PIS Top Apartment - 10000 USD'
	And the Street Name of project on detail page should be: 'Điền Viên Thôn'
	And the Ward Name of project on detail page should be: 'TT Tây Đằng'
	And the District Name of project on detail page should be: 'Ba Vì'
	And the Area of project on detail page should be: '120m2'
	And the number of bedroom of project on detail page should be: '3'
	And the number of bathroom of project on detail page should be: '3'
	And the number of parking place of project on detail page should be: '1'
	And the Property type of project on detail page should be: 'Apartment'
	And the Status ID of project on detail page should be: 'Đã duyệt'