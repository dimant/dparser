# DParser Project

## Overview

**DParser** is a simple yet powerful mathematical expression parser and evaluator designed to interpret and compute arithmetic expressions. This project demonstrates a lexer and parser for a subset of arithmetic operations, including addition, subtraction, multiplication, and division. It can handle expressions with parentheses to define operation precedence, making it an ideal example for those looking to understand or build similar parsing systems.

## Features

- **Lexical Analysis**: Tokenizes input strings into meaningful symbols for parsing.
- **Syntax Analysis**: Builds an abstract syntax tree (AST) from tokens.
- **Expression Evaluation**: Computes the result of the parsed expressions.
- **Error Handling**: Provides detailed error messages for unexpected tokens or syntax errors.
- **Test Coverage**: Includes unit tests to ensure the robustness of the lexer and parser.

## Getting Started

### Prerequisites

Ensure you have the following installed:

- **.NET Core SDK**: Version 3.1 or later.
- **Visual Studio**: Recommended for development and testing.

### Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/dimant/dparser.git
    cd dparser
    ```

2. **Build the project**:
    ```bash
    dotnet build
    ```

3. **Run the tests**:
    ```bash
    dotnet test
    ```

### Running the Application

To execute the sample program that parses and evaluates an expression, follow these steps:

1. **Navigate to the project directory**:
    ```bash
    cd DParser
    ```

2. **Run the application**:
    ```bash
    dotnet run
    ```

By default, the sample program evaluates the expression `"1+2*((23-3)/5))"` and prints the result.

### Example Output

```
(1 + (2 * ((23 - 3) / 5)))
Input: '1+2*((23-3)/5))' Result: 9
```

## Project Structure

- **DParser**: Contains the main source files for the lexer, parser, and expression evaluation.
  - `BinaryExpression.cs`: Defines binary operations (addition, subtraction, etc.).
  - `Expression.cs`: Abstract base class for expressions.
  - `Lexer.cs`: Tokenizes input strings.
  - `NumberExpression.cs`: Represents numerical values in expressions.
  - `Parser.cs`: Constructs the AST from tokens.
  - `Token.cs`: Defines token types and structures.
  - `Program.cs`: Entry point for the application.

- **DParser.Tests**: Contains unit tests for validating the functionality.
  - `LexerTests.cs`: Tests for the lexer.
  - `ParserTests.cs`: Tests for the parser.

## Key Components

### Lexer

The lexer converts an input string into a sequence of tokens. Each token represents a meaningful symbol in the language, such as numbers, operators, and parentheses.

**Example Usage**:
```cs
var lexer = new Lexer("1+2*3");
Token token;
while ((token = lexer.GetNextToken()).Type != TokenType.EOS) {
    Console.WriteLine(token);
}
```

### Parser

The parser processes tokens from the lexer to build an abstract syntax tree (AST), which represents the hierarchical structure of the expression.

**Example Usage**:
```cs
var lexer = new Lexer("1+2*(3-4)");
var parser = new Parser(lexer);
var expression = parser.Parse();
Console.WriteLine(expression);
```

### Expression Evaluation

Once the AST is built, it can be evaluated to produce the result of the expression.

**Example Usage**:
```cs
var result = expression.Evaluate();
Console.WriteLine($"Result: {result}");
```

## Contributing

We welcome contributions to improve the DParser project. Feel free to open issues or submit pull requests with enhancements or bug fixes.

## License

See the [LICENSE](LICENSE) file for details.
