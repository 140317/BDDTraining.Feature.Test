Feature: Login funtionality
	

@Login_Function
Scenario Outline: Authenticate user and login to the home page
	Given the correct username as '<username>'
	And the correct password is '<password>'
	When I click on the submit button
	Then I will be redirected to the Home page

	Examples:
		| username | password |
		| 140317     | 1234   |