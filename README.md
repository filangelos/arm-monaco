# ARM Monaco Editor

> High Level Programming 2018 - Monaco Editor Starter Code

## Dependencies

1. [`dotnet core`](https://www.microsoft.com/net/learn/get-started/)

2. [`nodejs`](https://nodejs.org/en/download/)

3. [`yarn`](https://yarnpkg.com/en/docs/install)

4. (**non-Windows only**) [`mono`](http://www.mono-project.com/docs/getting-started/install/)

5. [`fsharp`](http://fsharp.org/use/)

## Getting Started

1. Fetch `npm` packages by executing `yarn install`

2. Restore `dotnet` packages by running `dotnet restore`

3. Compile `fsharp` code to `javascript` using `webpack` by executing `yarn run start`

4. Open `electron` application at a new terminal tab by running `yarn run launch`

## TODO

- [ ] Text statistics
- [ ] Mode state (on/off)

## Warning: Beta

The code is **not** complete:

1. Windows & Linux support is not guaranteed yet

2. `Monaco.fs` interface from [fable-repl](https://github.com/fable-compiler/repl) has not been fully completed
