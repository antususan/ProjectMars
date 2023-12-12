Feature: LanguageFeature

As a Mars portal admin
I would like to create ,edit and delete language records
So that I can able to show what lanaguages I know and 
it helps people who seeking for languages can look at what details I hold.


	@regression
	Scenario Outline: Create a new lanaguge record with Valid details 
	Given I logged into Mars portal sucessfully
	And I navigate to Profile page
	When I add new '<Language>' and '<Level>'
	Then the record should have new '<Language>' and '<Level>'

	Examples: 
	| Language                                | Level          |
	| English                                 | Basic          |
	| 123@#$                                  | Fluent         |
	| Iam adding a new language as a sentence | Conversational |

	@regression
	Scenario Outline: Create a new lanaguge record with InValid details 
	Given I logged into Mars portal sucessfully
	And I navigate to Profile page
	When I add invalid '<InValidLanguage>' and valid '<ValidLevel>'
	Then the record should  not be added '<InValidLanguage1>' sucessfully
	
	Examples: 
	| InValidLanguage | ValidLevel | InValidLanguage1                | 
	|                 | Fluent     | Please enter language and level | 


	@regression
	Scenario Outline: Create an existing lanaguge to the list 
	Given I logged into Mars portal sucessfully
	And I navigate to Profile page
	When I add new a '<Language1>' and '<Level1>'
	When I add an existing language'<ExistingLanguage>' and '<ExistingLevel>'
	Then the record should not be added '<ExistingLanguage1>' 

	Examples: 
| Language1 | Level1 | ExistingLanguage | ExistingLevel | ExistingLanguage1                                     |
| Italian   | Basic  | Italian          | Basic         | This language is already exist in your language list. |

	@regression
	Scenario Outline: Edit a lanaguge record with Valid details 
	Given I logged into Mars portal sucessfully
	And I navigate to Profile page
	And I create  '<CreateLanguage>' and '<CreateLevel>'
	When I update '<EditLanguage>' and '<EditLevel>'
	Then the record should be updated as new'<EditLanguage>' and '<EditLevel>'

	Examples: 
	| CreateLanguage| CreateLevel      | EditLanguage  | EditLevel   |
	| Spanish		| Conversational   | Tamil		   | Basic       |
	
	
	@regression
	Scenario Outline:Delete language record 
	Given I logged into Mars portal sucessfully
	And I navigate to Profile page
	And I create a '<CreateLanguage1>' and '<CreateLevel1>'
	When I delete a language
	Then the '<DeleteLanguage>'  should be deleted sucessfully 

	Examples: 
	| CreateLanguage1 | CreateLevel1 | DeleteLanguage                              |
	| German          | Fluent       | German has been deleted from your languages | 
	