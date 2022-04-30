Feature: Owner Registration

In order to manage my tasks
As an Owner
John wants to register an account

@OwnerScenarios
Scenario: Registering online for a new owner account
	Given John is not a registered member
	When John registers for a new account
	| DisplayName	|Email			| Password	 |
	| John			|John@email.com | John123	 |
	And John attempts to Log in
	Then John log in successfully


@OwnerScenarios
Scenario: Preventing registration with duplicate email
	Given Jane is not a registered member
	When Jane registers for a new account with John's email
	| DisplayName	|Email			| Password	 |
	| Jane			|John@email.com | Jane458	 |
	Then Jane can not register


