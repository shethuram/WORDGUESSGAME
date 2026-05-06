# Word Guess Game - C# Console Application

## Overview

Word Guess Game is a console-based word guessing application inspired by Wordle, developed using C#, Object-Oriented Programming (OOP), and Exception Handling.

The application challenges players to guess a hidden 5-letter word within limited attempts while providing intelligent feedback for every guess.

The project follows a clean layered architecture using:

* Models
* Interfaces
* Services
* Repository Pattern
* Custom Exceptions
* Utility Classes

The application demonstrates proper separation of concerns, scalable design, and maintainable code structure.

---

# Features

## Core Features

* Random hidden 5-letter word generation
* Maximum attempt limit based on difficulty
* Real-time G/Y/X feedback system
* Immediate game completion on correct guess
* Duplicate guess prevention
* Replay support
* Menu-driven application flow

---

## G / Y / X Feedback System

| Symbol | Meaning                            |
| ------ | ---------------------------------- |
| G      | Correct letter in correct position |
| Y      | Correct letter in wrong position   |
| X      | Letter not present in hidden word  |

### Example

Hidden Word:

```text
MANGO
```

User Guess:

```text
MAGIC
```

Output:

```text
G G Y X X
```

The feedback system correctly handles repeated letters using count-aware logic similar to Wordle.

---

# Exception Handling

The application uses a custom exception class:

```text
InvalidGuessException
```

Validation rules handled:

| Validation Case            | Error Message                      |
| -------------------------- | ---------------------------------- |
| Empty input                | Input cannot be empty              |
| Less than 5 letters        | Word is too short                  |
| Greater than 5 letters     | Word is too long                   |
| Numbers present            | Numbers are not allowed            |
| Special characters present | Special characters are not allowed |
| Duplicate guess            | Word already guessed               |

All validation errors are handled gracefully without crashing the application.

---

# Additional Features

## Difficulty Levels

### Easy

* 6 attempts
* Hint support enabled

### Medium

* 5 attempts
* No hints

### Hard

* 4 attempts
* No hints

---

## Hint System

Players can type:

```text
HINT
```

The system reveals one correct letter from the hidden word.

---

## Score System

The application calculates score based on:

* Number of attempts used
* Hint usage

Fewer attempts produce higher scores.

---

## Statistics Tracking

The application tracks:

* Games Played
* Games Won
* Games Lost
* Win Rate
* Average Attempts

---

## Colored Console Output

The game uses:

* Green for correct letters
* Yellow for misplaced letters
* Red for invalid/missing letters

This improves readability and user experience.

---

## Timer Support

The application measures:

* Total game completion time

using:

```text
Stopwatch
```

from:

```text
System.Diagnostics
```

---

## Rules Menu

A dedicated Rules menu explains:

* Game objective
* Feedback symbols
* Hint usage
* Gameplay instructions

---

# Project Architecture

```text
WordGuessGame/
│
├── Models/
│   ├── DifficultyLevel.cs
│   ├── GameSettings.cs
│   ├── GameState.cs
│   ├── GuessResult.cs
│   └── PlayerStatistics.cs
│
├── Interfaces/
│   ├── IFeedbackGenerator.cs
│   ├── IGuessValidator.cs
│   ├── IScoreService.cs
│   ├── IStatisticsService.cs
│   └── IWordProvider.cs
│
├── Repositories/
│   └── WordProvider.cs
│
├── Services/
│   ├── FeedbackGenerator.cs
│   ├── Game.cs
│   ├── GuessValidator.cs
│   ├── HintService.cs
│   ├── MenuService.cs
│   ├── ScoreService.cs
│   └── StatisticsService.cs
│
├── Exceptions/
│   └── InvalidGuessException.cs
│
├── Utilities/
│   ├── ConsoleHelper.cs
│   └── TimerHelper.cs
│
└── Program.cs
```

---

# OOP Concepts Used

The project demonstrates:

* Classes and Objects
* Encapsulation
* Interfaces
* Constructors
* Collections
* Loops
* Conditional Statements
* Custom Exceptions
* String Handling
* Layered Architecture
* Separation of Concerns

---

# Design Principles Followed

## Single Responsibility Principle

Each class handles only one responsibility.

Example:

* GuessValidator handles validation only
* FeedbackGenerator handles feedback logic only
* ScoreService handles score calculation only

---

## Separation of Concerns

The project separates:

* Business Logic
* Validation Logic
* Data Models
* Console Utilities
* Word Data Source

This improves maintainability and scalability.

---

## Repository Pattern

The application uses:

```text
WordProvider
```

as a repository/provider layer to manage hidden words.

This keeps word management separate from game logic.

---

# How to Run

## Create Project

```bash
dotnet new console -n WordGuessGame
```

---

## Build Project

```bash
dotnet build
```

---

## Run Application

```bash
dotnet run
```

---

# Sample Menu

```text
========================
WORD GUESS GAME
========================

1. Start New Game
2. View Rules
3. View Statistics
4. Exit
```

---

# Sample Gameplay

```text
Attempt 1: MAGIC
G G Y X X

Attempt 2: MANGO
G G G G G

You guessed correctly!
```

---

