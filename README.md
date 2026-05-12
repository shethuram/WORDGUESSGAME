# Word Guess Game - C# Console Application with PostgreSQL and ADO.NET

## Overview

Word Guess Game is a console-based word guessing application inspired by Wordle, developed using C#, Object-Oriented Programming (OOP), Exception Handling, PostgreSQL, and ADO.NET.

The application challenges players to guess a hidden 5-letter word within limited attempts while providing intelligent feedback for every guess.

The project follows a clean layered architecture using:

* Models
* Interfaces
* Services
* Repository Pattern
* Data Access Layer
* Custom Exceptions
* Utility Classes
* PostgreSQL Database Integration
* ADO.NET

The application demonstrates:

* clean architecture
* layered application design
* separation of concerns
* repository pattern
* database integration using ADO.NET
* authentication flow
* scalable and maintainable code structure
* enterprise-style console application development.

---

# Features

## Authentication System

The application includes a complete login and registration system using PostgreSQL.

### Features

* User Registration
* User Login
* Session-based gameplay
* Database-persisted users
* User-linked game sessions

### Authentication Flow

```text
Application Starts
    ↓
Register / Login
    ↓
User Authentication
    ↓
Main Menu
    ↓
Gameplay
```

---

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

# Database Integration

The application integrates PostgreSQL using:

* ADO.NET
* Npgsql
* Repository Pattern
* Connection Factory Pattern

---

## Database Name

```text
wordguessdb
```

---

## Database Tables

### users

Stores registered users.

| Column   | Type               |
| -------- | ------------------ |
| id       | SERIAL PRIMARY KEY |
| username | VARCHAR(50)        |
| password | VARCHAR(100)       |

---

### game_sessions

Stores every completed game session.

| Column        | Type               |
| ------------- | ------------------ |
| id            | SERIAL PRIMARY KEY |
| user_id       | INT                |
| difficulty    | VARCHAR(20)        |
| attempts_used | INT                |
| score         | INT                |
| time_taken    | INT                |
| is_won        | BOOLEAN            |
| played_at     | TIMESTAMP          |

---

### player_statistics

Stores cumulative game statistics.

| Column         | Type               |
| -------------- | ------------------ |
| id             | SERIAL PRIMARY KEY |
| games_played   | INT                |
| games_won      | INT                |
| games_lost     | INT                |
| total_attempts | INT                |

---

## Database Flow

```text
Game Ends
    ↓
Services
    ↓
Repositories
    ↓
ADO.NET
    ↓
PostgreSQL
```

---

## ADO.NET Components Used

* NpgsqlConnection
* NpgsqlCommand
* ExecuteNonQuery()
* ExecuteReader()
* Parameterized Queries

---

## Database Initialization

The application automatically creates tables during startup using:

```text
DatabaseInitializer.cs
```

This acts similar to migrations in Entity Framework.

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
├── Data/
│   ├── DatabaseInitializer.cs
│   └── DbConnectionFactory.cs
│
└── Program.cs
```

---

## Additional Architecture Components

### Repository Pattern

The application uses repositories to separate database operations from business logic.

Repositories used:

* WordRepository
* UserRepository
* StatisticsRepository
* GameSessionRepository

This improves:

* scalability
* maintainability
* testability
* clean architecture

---

## Data Access Layer

The project uses a dedicated Data layer for:

* connection management
* database initialization
* centralized database configuration

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

