# BindingUI.Boost

> **Experimental extensions, integrations, and utilities for BindingUI.**

BindingUI.Boost is an optional extension package for [BindingUI](https://github.com/kou-yeung/BindingUI).

BindingUI Core focuses on a small, stable, and predictable API. BindingUI.Boost provides a separate place to explore features that depend on third-party libraries, solve more specialized use cases, or are still being evaluated through real-world use.

## Purpose

BindingUI.Boost is intended for:

- Experimental bindings and APIs
- Third-party library integrations
- Animation and tweening helpers
- Editor tooling
- Optional utility extensions
- Features that are useful, but too specialized for BindingUI Core

Potential integrations may include libraries such as DOTween, R3, Addressables, or other Unity packages.

Features that prove broadly useful and stable may eventually be promoted into BindingUI Core.

## Design Policy

BindingUI.Boost follows the same basic philosophy as BindingUI:

- Keep Unity's Prefab and Inspector workflow
- Keep UI updates explicit through `Apply(...)`
- Prefer small extension methods over large framework layers
- Avoid forcing optional dependencies into BindingUI Core
- Keep experimental APIs isolated so they can evolve safely

BindingUI.Boost is intentionally less stable than BindingUI Core. APIs may change while features are being evaluated.

## Installation

Install with Unity Package Manager using the following Git URL:

```text
https://github.com/kou-yeung/BindingUI.Boost.git?path=Assets/BindingUI.Boost
```

BindingUI.Boost requires BindingUI:

```text
https://github.com/kou-yeung/BindingUI.git?path=Assets/BindingUI
```

You can add both packages through:

```text
Window > Package Manager > + > Add package from git URL...
```

## Extensions

Available extensions will be documented here as they are added.

Each extension should clearly document:

- Required third-party packages
- Supported Unity versions
- Public extension methods
- Usage examples
- Known limitations

## Contributing

Pull Requests are welcome.

Contributions are especially welcome for:

- Bindings for third-party Unity libraries
- Experimental BindingUI APIs
- Reusable animation or tween integrations
- Editor utilities
- Documentation and samples

Please keep contributions focused and optional. Features that introduce an external dependency should remain isolated from unrelated extensions.

When proposing a new extension, include:

- The problem it solves
- Its external dependencies
- A minimal usage example
- Why it belongs in BindingUI.Boost rather than BindingUI Core

## Relationship with BindingUI Core

Use **BindingUI Core** when you want the smallest and most stable API.

Use **BindingUI.Boost** when you want optional integrations, specialized bindings, or experimental features.

```text
BindingUI
    Stable core bindings and runtime behavior

BindingUI.Boost
    Optional integrations and experimental extensions
```

## License

See the repository license for details.
