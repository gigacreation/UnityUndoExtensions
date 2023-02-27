# Unity Undo Extensions

This package provides extensions to do actions as undoable.

## Why use Unity Undo Extensions?

Normally, methods such as `GameObject.AddComponent` do not register undo operations. You need to use methods such as `Undo.AddComponent` to register undo operations, but since they are in the `UnityEditor` namespace, they cause build errors.

Unity Undo Extensions checks the current context and registers undo operations only in editor and not play mode.

This package is especially useful to make editor extensions.

## API

## Installation

### Package Manager

- `https://github.com/gigacreation/UnityUndoExtensions.git?path=Assets/UndoExtensions`

### Manual

- Copy `Assets/UndoExtensions/` to your project.
