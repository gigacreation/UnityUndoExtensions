# Unity Undo Extensions

This package provides extensions to do actions as undoable.

## 日本語による説明 / Explanation in Japanese

[Unity エディターでの Undo 操作の登録を便利するツールを公開しました](https://blog.gigacreation.jp/entry/2023/02/28/015659)

## Why use Unity Undo Extensions?

Normally, methods such as `GameObject.AddComponent` do not register undo operations, nor mark objects as dirty.

If you want to do them, you have to use methods such as `Undo.AddComponent`, but since they are in the `UnityEditor` namespace, they will cause build errors.

Unity Undo Extensions checks the current context and registers undo operations and marks objects as dirty only when in editor and not in play mode.

This package is especially useful to make editor extensions.

## Usage

```cs
using GigaCreation.Tools.UndoExtensions;
using UnityEngine;

public class ExampleMonoBehaviour : MonoBehaviour
{
    public int Counter;

    public void Example01()
    {
        // Adds a component to the GameObject.
        // If in editor and not play mode, registers an undo operation for this action.
        gameObject.AddComponentAsUndoable<SpriteRenderer>();
    }

    public void Example02()
    {
        if (TryGetComponent(out SpriteRenderer spriteRenderer))
        {
            // Destroys the object.
            // If in editor and not play mode, records an undo operation so that it can be recreated.
            spriteRenderer.DestroyAsUndoable();
        }
    }

    public void Example03()
    {
        // Execute the action. If in editor and not play mode, records any changes done on the object.
        this.DoActionAsUndoable("Increment Counter", x =>
        {
            x.Counter++;
        });
    }
}
```

## API References

- [The API reference is here.](Api.md)

## Installation

### Package Manager

- `https://github.com/gigacreation/UnityUndoExtensions.git?path=Assets/UndoExtensions`

### Manual

- Copy `Assets/UndoExtensions/` to your project.
