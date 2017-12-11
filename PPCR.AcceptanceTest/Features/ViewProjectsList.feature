Feature: ViewProjectsList
	As a normal user
	I want to see the list of projects

@mytag
Scenario: View Projects List
	Given I was in the Homepage
	When I press View more on 'Featured' section
	Then I should be in Projects list view
