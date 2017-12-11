Feature: Logout
	As an user of website
	I want to Logout when i'm done my work on website 

@mytag
Scenario: Logout
	Given I was logged in the website
	And I was in Homepage
	When I press Logout
	Then I should be Logged out and arrive at Login Page
