Feature: ProjectOpening
	In order to verify projects opening
	As an user (or tester)
	I want to validate some steps for opening
	a project that has already been opened

@mytag
Scenario: Choose a project from the list and open it
	Given I have successfully loaded the application
	And I have written the project's name into the textbox
	When I press Open
	Then the dialog box should occur
