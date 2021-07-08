Feature: RegristrationTravel
	Registration of travel test users

@travel
Scenario Outline: Register travel users
	Given user has navigated to website
	And clicks on register link
	When enters regisration data <firstName>, <lastName>, <phone>, <email>, <address>, <city>, <state>, <postalcode>, <country>, <username>, <password>, <confirmpassword>
	And click on submit
	Then user should be registered
	
	Examples: 
	| emailid            | title | firstName | lastName | password | dob        | address        | city  | state | country       | postalcode | mobilephone |
	| testuserr1@test212.com | Mr    | jack      | jones    | test1234 | 20/12/1990 | abc 5th street | texas | Texas | United States | 13453      | 1122334455  |
	| testuserr2@test212.com | Mr    | james     | kyles    | test1234 | 20/12/1991 | xyz 5th street | texas | Texas | United States | 13453      | 1122334488  |
	| testuserr4@test212.com | Mr    | kyles     | mores    | test1234 | 20/12/1992 | xyz 9th street | texas | Texas | United States | 13453      | 1122334477  |	