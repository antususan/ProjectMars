Feature: SkillFeature

A shorAs a Mars portal admin
I would like to create,edit, and delete skill records
So that I can able to show what skills I know and 
it helps people seeking skills to look at what details I hold.

@regression
Scenario Outline: Create a new skill record with Valid details 
	Given I logged into Mars website sucessfully
	And I navigate to Skill page
	When I add a new '<Skill>' and '<Level>'
	Then table should have the new '<Skill>' and  '<Level>' 

	Examples: 
	| Skill  | Level        |
	| Dance  | Beginner     |
	| @#&^*  | Expert       |
	| 234567 | Intermediate |
	
	@regression 
	Scenario Outline:Adding an invalid skill rcord 
	Given I logged into Mars website sucessfully
	And I navigate to Skill page
	When I add an invalid skill'<InValidSkill>' and valid '<ValidLevel>'
	Then the record has not be added as '<InvalidSkill1>' sucessfully

	Examples: 
	| InValidSkill | ValidLevel | InvalidSkill1                           |
	|              | Beginner   | Please enter skill and experience level |


		@regression
	Scenario Outline: Create an existing skill to the list 
	Given I logged into Mars portal sucessfully
	And I navigate to Skill page
	When I add new an '<Skill1>' and '<Level1>'
	When I add an existing skill'<ExistingSkill>' and '<ExistingLevel>'
	Then the record has not be added '<ExistingSkill1>' Sucessfully

	Examples: 
| Skill1   | Level1 | ExistingSkill | ExistingLevel | ExistingSkill1                                  |
| Painting | Expert | Painting      | Expert        | This skill is already exist in your skill list. |



	@regression
	Scenario Outline: Edit the skill record with valid details
	Given I logged into Mars website sucessfully
	And I navigate to Skill page
	When I creates '<CreateSkill>' and '<CreateLevel>'
	When I updates '<EditSkill>' and '<EditLevel>'
	Then the record should be updated as new '<EditSkill>' and '<EditLevel>'
	

	Examples: 
	
| CreateSkill     | CreateLevel    | EditSkill | EditLevel |
| Gardening       | Beginner       | Fishing   | Expert    |

@regression
Scenario Outline:Delete the skill record 
Given I logged into Mars website sucessfully
And I navigate to Skill page
When I create a '<CreateSkill1>' and '<CreateLevel1>'
When I delete the skill record
Then the '<DeleteSkill>' should be deleted sucessfully
Examples: 
| CreateSkill1 | CreateLevel1 | DeleteSkill              |
| Cooking      | Expert       | Cooking has been deleted |

