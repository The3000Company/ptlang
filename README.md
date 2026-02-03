# Peach Tea Language (PTL)
A silly, extremely primitive, high-level programming language written atop Visual Basic.

# Overview
PTL is a somewhat-ramshackle experiment from 2024 that dared to ask a question: can one man create a programming language using his favorite pre-existing programming language? The answer was, to some degree, yes.

Debatably, the closest allegory that can be provided is that PTL is to Visual Basic what TypeScript is to JavaScript, albeit on a far smaller/weaker scale.

"I've got ambitions for a legitimate crack at a robust programming language. This is just the initial self-plunge."

# Usage
Currently, PTL only possesses five basic functions: `def`, `envinfo`, `print`, `quit`, and `redef` (alias: `rdef`). The language is allergic to semicolons, opting instead to abide by a Python-esque syntax.

If you're writing a file, unilateral comments are supported using the `//` operator at the beginning of a line; inline comments are currently not implemented. To mute function feedback, include `#cond silent` as the first line (and *only* the first line) of the file.

Here's a sample program in PTL that I wrote a while ago:
```{ptl}
#cond silent

// This will define a variable x and assign it a System.String value
def(x, "Hello, world!")
print(x)
// This will define a variable y and assign it a System.String value
def(y, "Goodbye, world!")
rdef(x, y)
print(x)
quit()
```

# Compiling
You'll need the .NET 8.0 runtime to actually *use* the PTL executable, but you can use any .NET SDK from 8.0 onwards to build it.
1. `git clone https://github.com/The3000Company/ptlang`
2. `cd ptlang`
3. `dotnet build`

# Contributing
PTL is licensed under the LGPL. Do whatever you'd like with it!