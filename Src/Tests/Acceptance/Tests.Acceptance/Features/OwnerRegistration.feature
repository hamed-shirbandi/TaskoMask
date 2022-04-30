Feature: Owner Registration

In order to manage my tasks
As an Owner
John wants to register an account

@OwnerScenarios
Scenario: Registering online for a new owner account
	Given John is not a registered member
	When John registers for a new account with his email
	Then Joun can login
	And John can see the dashboard data

@OwnerScenarios
Scenario: Preventing registration with duplicate email
	Given Jane is not a registered member
	When Jane registers for a new account with john's email
	Then Jane can not register
