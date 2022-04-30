Feature: Owner Registration

In order to manage my tasks
As an Owner
John wants to register an account

@OwnerScenarios
Scenario: Registering online for a new owner account
	Given John is not a registered member
	When John registers for new account
	Then Joun can login
	And John can see the dashboard data
