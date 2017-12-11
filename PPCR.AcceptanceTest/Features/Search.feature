Feature: Search
	As a normal user
	I want to search for project by keyword.

@mytag
Scenario: Search
	Given I was in Projects-list view 
	When I typed keyword i want to search for, Ex: 'PIS'
	And I press Search button
	Then There should be a list contains only: 'PIS Top Apartment', 'PIS Serviced Apartment – Boho Style', 'PIS Serviced Apartment – Style 3'
