Feature: Login
	As an user of website
	I want to login to website by my account

@mytag
Scenario: Login
	Given I was in the Login View
	And I filled the username and password field 
	When I press Login
	Then I should be Logged in and arrive at homepage
