Feature: Regiser Owner

In order to manage the tasks
As an Owner
John wants to register an account

@OwnerScenarios
@UI-Level
Scenario: Registering online for a new owner account
	Given John is not a registered member
	When John registers for a new account
		| DisplayName | Email          | Password |
		| John        | John@email.com | John123  |
	And John attempts to login
	Then John login successfully
	And John has access to his profile


@OwnerScenarios
@UI-Level
Scenario: Preventing registration with duplicate email

	Given John is a registered member
		| DisplayName | Email                  | Password |
		| John        | John.NewMail@email.com | abc123   |
	And Jane is not a registered member
	When Jane registers for a new account with John's email
		| DisplayName | Email                  | Password |
		| Jane        | John.NewMail@email.com | Jane458  |
	Then Jane can not register


