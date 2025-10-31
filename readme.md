
# Erasmus Survival - Game design document

## Table of contents

1. [Overview](#overview)
2. [Characters](#characters)
3. [Core resources](#core-resources)
4. [Gameplay](#gameplay)
5. [Side quests](#side-quests)
6. [Endings](#endings)

## Overview

### Genre
- single player game 
- life simulation
- narrative strategy
- time and resource management

### Target audience
- young people
- students
- people interested in Erasmus mobilities

### Core fantasy

Live as an Erasmus student in a foreign country without knowing the language, the roommates, the classmates, the professor and the courses. 

**Missy** need to figure it out how to apply for an Erasmus experience, how to go there and how to survive in a new life managing money, new friends, old friends and the academical world.

## Characters

### Main character

**Missy** is a the default main character of the game: she is a second year Engineering student from England that wants to live her dream and study aboard for one semester.

In the first part of the game the player can change the *name*, the *age*, the *faculty*, and the *year of study* for the main characters.

### Friends

Some additional character will be added in Erasmus, people that can became friends with our main characters and send messages to it and interact to it at parties and events.

### Professors

Characters that will send email about homework and assignments to our main characters and will meet it in their office and into the exams.

### Parents and friends from home

Characters that interact just by calls and messages with the main character.

## Core resources

| Name                               | Initial value                    | Minim     | Maximum  | Description                                            |
| ---------------------------------- | -------------------------------- | --------- | -------- | ------------------------------------------------------ |
| <a id="money">Money                | Erasmus grant (around 2500 euro) | 0         | $\infty$ | Used to buy stuffs, can borrow money from family       |
| <a id="happiness">Happiness        | $0$                              | $-\infty$ | $\infty$ | If is too low can become depressed                     |
| <a id="health">Health              | $100$                            | $0(dead)$ | $100$    | Initial doesn't have any problem, but can develop some |
| <a id="credits">Academical credits | $0$                              | $0$       | $30$     | Will be obtain after the exams.                        |

## Gameplay 

## Stages of the game
1. [Before](#before)
2. [Starting](#starting)
3. [During](#during)
4. [Ending](#ending)
5. [After](#after)

## Before

### Tasks

#### 1. Making the application for Erasmus
- finding the university (and the country)
- creating the CV (by adding some things from a predefined list - work experience, volunteering, education)
- having an interview (by choosing from predefined responses)

#### 2. Online Learning Agreement
- finding the courses (one room where he need to search for them - paper sheets with the name of the course in the country language and need to match them home university courses)
- need to get the signature from the home and host universities

#### 3. Getting there
- select the transportation options
	- by plane ($\uparrow$ happiness, $\downarrow$ money)
	- by bus ($\downarrow$ happiness, $\uparrow$ money)

#### 4. Accommodation
-  dorms ($1/5$ changes to be rejected) - $\uparrow$ money, $\downarrow$ health/happiness
- private accommodation 
	- 3 changes to get it - 3 options each, can keep one option for each try and need to select one in the end
- roommate ($1/?$ changes to have a roommate)
#### 5. Luggage
- need to select object from a predefined list
- keep the $weight <= 20$

### Map
- an apartment, the home of the student

## Starting

### Tasks

#### 1. Arriving with all the luggage
- choice your luggage from the rotation band (need to remember how the luggage looks like)

#### Find the accommodation
- on the map
- select the transportation option
	- taxi
	- bus 
	- foot

#### 2. Find the faculty
- on the map (need to translate the name of the department)

#### Find the professors
- send email (some of them will not responses)
- need to find their offices on the faculty map (search on different floors)

### Map
- the accommodation
- the faculty 
- the center of the city 
## During

### Tasks

#### 1. Daily tasks
- go to class
- homework reminders
- eat 
	- cafeteria, home, in the restaurant

#### 2. Homework
- different deadlines
- reminders with skip option

#### 3. Holidays
- stay in the erasmus
- go home

#### 4. Home seek / depression
- based on happiness level, the depression will be bigger or smaller
- $\downarrow$ health
- solving with side quests

#### 5. Relationships
- need to manage mother calls and friend from home
- need to manage different group of friends (or no friends :( )

### Map
- the accommodation
- the faculty 
- the center of the city 

## Ending

### Tasks

#### 1. Exams
- need to pass most of them 
- projects or exams
- study for them (integrated in daily tasks)

#### 2. Good bye
- need to say goodbye to all the new friends 
- parties

#### 3. Luggage
- need to fit all the things that was bought
- find a way to take them home

#### 4. Transportation
- the same us before

#### 5. Gifts
- reminder in all Erasmus
- list of people you want to buy
- money spend

### Map
- the accommodation
- the faculty 
- the center of the city 

## After

### Tasks

#### 1. Credits recognition
- meeting the local coordinator to accept the Erasmus credits
#### 2. Post-Erasmus depression
- missing the parties, the people and the vibe of the another country

#### 3. Join ESN
- join the association that organize event for the Erasmus student from your city to feel the Erasmus vibe again

### Map
- home 
- home university
- ESN office

## Side quests

| Name                                 | Stage                                  | $\uparrow$ Effect                                                | $\downarrow$ Effect                                                                  |
| ------------------------------------ | -------------------------------------- | ---------------------------------------------------------------- | ------------------------------------------------------------------------------------ |
| Going to event in 1<sup>st</sup> day | [Starting](#starting)                  | $\checkmark$[Happiness](#happiness)<br>$\times$[Health](#health) | $\checkmark$[Health](#health)<br>$\times$[Happiness](#happiness)                     |
| Changing OLA                         | [Starting](#starting)                  | [Credits](#credits)                                              | [Happiness](#happiness)                                                              |
| Getting the ESN in last day          | [Starting](#starting)                  | $\checkmark$[Happiness](#happiness)                              | $\times$[Money](#money)                                                              |
| Getting student card                 | [Starting](#starting)                  | [Credits](#credits)                                              | [Happiness](#happiness)                                                              |
| Cashier not speaking English         | [Starting](#starting)                  |                                                                  | [Happiness](#happiness)                                                              |
| Making friends at the party          | [Starting](#starting)                  | $\checkmark$[Happiness](#happiness)                              | $\checkmark$[Credits](#credits)<br>$\times$[Happiness](#happiness)                   |
| Closed stores on Sunday              | [Starting](#starting)                  |                                                                  | [Happiness](#happiness), [Money](#money)                                             |
| Can't translate the course           | [Starting](#starting)                  |                                                                  | [Credits](#credits)                                                                  |
| Course without professor             | [Starting](#starting)                  |                                                                  | [Credits](#credits)                                                                  |
| Unpacking                            | [Starting](#starting)                  |                                                                  | [Happiness](#happiness)                                                              |
| Too many absents                     | [During](#during)                      |                                                                  | [Credits](#credits)                                                                  |
| Course schedule changed              | [During](#during)                      |                                                                  |                                                                                      |
| Friend visit                         | [During](#durinh)                      | [Happiness](#happiness)                                          |                                                                                      |
| Ask parents for money                | [During](#during)<br>[Ending](#ending) | $\checkmark$ [Money](#money)<br>$\times$[Happiness](#happiness)  | $\checkmark$[Happiness](#happiness)                                                  |
| Exam in different language           | [Ending](#ending)                      |                                                                  |                                                                                      |
| Maps not working                     |                                        |                                                                  | [Happiness](#happiness)                                                              |
| Dead phone                           |                                        |                                                                  | [Happiness](#happiness), [Credits](#credits)                                         |
| Lost the last bus home               |                                        |                                                                  | [Happiness](#happiness), [Health](#health)                                           |
| No hot water                         |                                        |                                                                  | [Health](#health)                                                                    |
| Busy kitchen                         |                                        |                                                                  | [Happiness](#happiness), [Health](health)                                            |
| Drink too much and miss school       |                                        |                                                                  | [Credits](#credits), [Health](#health)                                               |
| Drink too much and miss trip         |                                        |                                                                  | [Happiness](#happiness), [Health](#health)                                           |
| Recycled                             |                                        |                                                                  |                                                                                      |
| Closed stores for lunch break        |                                        |                                                                  | [Happiness](#happiness), [Money](#money)                                             |
| Email missed                         |                                        |                                                                  | [Credits](#credits)                                                                  |
| Secretary closed                     |                                        |                                                                  | [Happiness](#happiness), [Credits](#credits)                                         |
| Drink&go meeting                     |                                        | $\checkmark$[Happiness](#happiness)<br>$\times$[Money](#money)   | $\checkmark$ [Money](#money)<br>$\times$[Happiness](#happiness)                      |
| Spoiled food                         |                                        |                                                                  | [Happiness](#happiness), [Health](#health)                                           |
| No food in the fridge                |                                        |                                                                  | [Happiness](#happiness), [Health](#health)                                           |
| ESN events                           |                                        | $\checkmark$[Happiness](#happiness)<br>$\times$[Money](#money)   | $\checkmark$ [Money](#money), [Credits](#credits)<br>$\times$[Happiness](#happiness) |
| Just you awake at party              |                                        |                                                                  | [Happiness](#happiness)                                                              |
| Pay for bus                          |                                        |                                                                  | [Money](#money)                                                                      |
| Pay for rent                         |                                        |                                                                  | [Money](#money)                                                                      |
| Forget umbrella at home              |                                        |                                                                  | [Health](#health)                                                                    |
| Being hangover                       |                                        |                                                                  | [Health](#health)                                                                    |


## Endings

### 1. Perfect Erasmus
- all credits
- new friends
### 2. No Erasmus
- drop out before going 
- no accommodation
### 3. Dropout
- failed course
- no more money
### 4. Happy Erasmus
- many friends, a lot an fun
- almost all credits