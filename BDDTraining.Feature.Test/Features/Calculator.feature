Feature: Calculator
	Two numbers to be added and produce the correct result

@Add_TwoNumbers_Function
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@Add_TwoNumbers_Iterations_Function
Scenario Outline: Add two numbers having iterations
	Given the first number is <number1>
	And the second number is <number2>
	When the two numbers are added
	Then the result should be <sum>

	Examples:
		| number1 | number2 | sum |
		| 20      | 30      | 50  |
		| 12      | 6       | 18  |
		| 45      | 25      | 70  |
		| 20      | 40      | 60  |