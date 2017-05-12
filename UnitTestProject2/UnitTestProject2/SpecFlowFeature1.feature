Feature: ApiTesting
	In order to be sure that the project was correctly modified
	I want to check the project's information

@mytag
Scenario: Modify the due date and the description programatically
	Given I have changed the due date and the description
	Then the project's information should be updated
