# Metaphor

Metaphor is an F# project implementing metaphor-based algorithms. Currently,
only the Firefly variant of Particle Swarm Optimization is implemented. More
algorithms will be implemented in the near future.

## Installation

This project will be made into a NuGet package in the near future. For now,
cloning this repo and building the binaries will be necessary.

```
git clone https://github.com/jdsteinhauser/metaphor-fs
```

## Inspiration

A data analysis team I supported was having issues with a deterministic solver
(specifically, Nelder-Mead) taking an incredibly long time to run to completion
for a specific problem. I began looking into non-deterministic solvers as an
alternative, and ran across [an MSDN article](https://msdn.microsoft.com/en-us/magazine/mt147244.aspx)
with an implementation of the Firefly algorithm. I noticed an issue with the
implementation (updating w/ partially updated state), and decided to fix the
issues I saw and write

## Future Work
I plan on incorporating additional metaphor-based algorithms such as:
- Simulated annealing
- Hill climbing
- Particle swarm optimization
- Ant colony optimization
- Cuckoo search

I also plan to write tests and optimization functions in a variety of languages
so that these algorithms are available on multiple platforms. I plan to target:
- Rust
- Clojure (or Scala)
- Elixir

## License

Metaphor is licensed under the MIT License.