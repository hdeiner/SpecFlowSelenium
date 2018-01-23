Feature: As a Google consumer, I want to learn to trust Google results, 
		 because I get what I need without clicking through URL results.

Scenario Outline: Spot check quick results
	When I use Google
	Then I should see "<result>" when I search for "<query>"

	Examples: 
	| query                                 | result                          |
	| Abraham Lincoln assisination date     | April 14, 1865                  |
	| first man on the moon                 | Neil Armstrong                  |
	| first man on the moon                 | Apollo 11                       |
	| pattern altitude lincoln park airport | 1201 MSL                        |
	| Kakistocracy                          | government by the worst persons |