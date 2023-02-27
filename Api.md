# Scripting API

All methods are declared in `GigaCreation.Tools.UndoExtensions` namespace.

## `GameObjectExtensions.AddComponentAsUndoable<T>(GameObject)`

Adds a component to the GameObject. If in editor and not play mode, registers an undo operation for this action.

### Declaration

```cs
public static T AddComponentAsUndoable<T>(this GameObject self) where T : Component
```

### Parameters

| Type                   | Name | Description                                      |
| ---------------------- | ---- | ------------------------------------------------ |
| UnityEngine.GameObject | self | The GameObject you want to add the component to. |

### Returns

| Type | Description                          |
| ---- | ------------------------------------ |
| T    | Component The newly added component. |

### Type Parameters

| Name | Description                            |
| ---- | -------------------------------------- |
| T    | The type of component you want to add. |

## `ObjectExtensions.DestroyAsUndoable(Object)`

Destroys the object. If in editor and not play mode, records an undo operation so that it can be recreated.

### Declaration

```cs
public static void DestroyAsUndoable(this Object self)
```

### Parameters

| Type               | Name | Description                        |
| ------------------ | ---- | ---------------------------------- |
| UnityEngine.Object | self | The object that will be destroyed. |

## `ObjectExtensions.DoActionAsUndoable<T>(T, string, Action<T>)`

Execute the action. If in editor and not play mode, records any changes done on the object.

### Declaration

```cs
public static void DoActionAsUndoable<T>(this T self, string name, Action<T> undoableAction) where T : Object
```

### Parameters

| Type                | Name           | Description                                                                            |
| ------------------- | -------------- | -------------------------------------------------------------------------------------- |
| T                   | self           | The reference to the object you will be modifying.                                     |
| string              | name           | The title of the action to appear in the undo history (i.e. visible in the undo menu). |
| System.Action<T><T> | undoableAction | The action you want to register an undo operation.                                     |

### Type Parameters

| Name | Description                                                    |
| ---- | -------------------------------------------------------------- |
| T    | The type of the reference to the object you will be modifying. |
