Feature: Register
	as a normal user
	I want to register the Agency account

@mytag
Scenario: Register
	Given I was in register page
	And I want to register with my infomation
	| title            | input            |
	| Email            | xPaths@gmail.com |
	| Password         | 123456           |
	| ConfirmPassword  | 123456           |
	| FullName         | Phat             |
	| Phone            | 0123456789       |
	| Address          | abcd             |
	When I press 'Sign up'
	Then There should be a success message show up
