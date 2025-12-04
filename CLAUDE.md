# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is an ASP.NET Core 9.0 MVC tutorial application built for Linean. It demonstrates MVC concepts through a two-tab interface:
- **Tutorial tab**: Installation guides for .NET SDK and Claude Code CLI
- **Finished Product tab**: A working todo list application

## Build and Run Commands

```bash
# Build the project
dotnet build

# Run the application (default: https://localhost:5001)
dotnet run

# Run with hot reload for development
dotnet watch run

# Run on specific port
dotnet run --urls="http://localhost:5000"
```

## Architecture

### MVC Pattern
- **Models** (`Models/`): Data classes like `TodoItem.cs`
- **Views** (`Views/`): Razor templates (.cshtml files)
- **Controllers** (`Controllers/`): Handle HTTP requests and return views

### Key Components

**TodoService** (`Services/TodoService.cs`): Singleton service with in-memory storage using a static list. Provides CRUD operations for todo items.

**HomeController** (`Controllers/HomeController.cs`): Main controller with actions:
- `Index()` - Returns main page with todo list
- `AddTodo(string title)` - POST action to add items
- `ToggleTodo(int id)` - POST action to toggle completion
- `DeleteTodo(int id)` - POST action to remove items

### View Structure
- `Views/Home/Index.cshtml` - Main page with Bootstrap tabs
- `Views/Shared/_Layout.cshtml` - Base layout with navbar and dark mode toggle
- `Views/Shared/_TutorialContent.cshtml` - Tutorial documentation partial
- `Views/Shared/_TodoApp.cshtml` - Todo list UI partial

### Frontend Features
- Dark/light mode toggle (persisted to localStorage)
- Tab persistence (remembers active tab across page reloads)
- Bootstrap 5 styling with custom CSS
- Highlight.js for code syntax highlighting

### Static Assets (`wwwroot/`)
- `css/site.css` - Custom styles including dark mode
- `js/site.js` - Theme toggle and tab persistence logic
- `images/` - Linean logo
