Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the answer to calculations


Scenario: Sum total of two numbers
	Given I have entered 1
	And an addition is required
	And I have entered 3
	When total is calculated
	Then the result will be 4

Scenario: Takeaway Total of two numbers
	Given I have entered 7
	And a deduction is required
	And I have entered 4
	When total is calculated
	Then the result will be 3

Scenario: Sum total of two big numbers
	Given I have entered 10
	And an addition is required
	And I have entered 15
	When total is calculated
	Then the result will be 25

Scenario: Sum total of two multiplied numbers
	Given I have entered 2
	And a multiplication is required
	And I have entered 3
	When total is calculated
	Then the result will be 6

