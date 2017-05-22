Feature: ApiTesting
	In order to be sure that the translation memory works correctly
	I want to check the confirmation statistics of the document

@mytag
Scenario: Run a pre-translation task automatically
	Given I have a document without translated segments and a TM with translation units
	Then the number of translated words should be 0 in the confirmation statistics

	Given I run a pre-translation task using the TM
	When I retrieve the confirmation statistics
	Then the number of translated words should be updated
