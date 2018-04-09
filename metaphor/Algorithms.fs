namespace Metaphor

module Firefly =
  open ZipList
  
  type T = { Position : float array; Error: float; Intensity: float; }

  let internal create position errorFn =
    let error = errorFn position      // TODO: Fix this so that arguments are applied
    { Position = position; Error = error; Intensity = 1.0 / (error + 1.0) }

  let internal findBest (swarm:seq<T>) = swarm |> Seq.sortBy(fun x -> x.Error) |> Seq.head

  let internal boundedRand (rng:System.Random) min max =
    rng.NextDouble() * (max - min) + min

  let internal initSwarm size rng errorFn dimBounds =
    let initSingle _ =
      dimBounds
      |> Array.map (fun (min,max) -> boundedRand rng min max )
      |> create <| errorFn
    Array.init size initSingle

  let internal updatePosition (rng:System.Random) i j beta (min,max) =
    let a = 0.20
    match i + beta * (j - i) + (a * (-0.5 * rng.NextDouble())) with
    | pos when pos >= min && pos <= max -> pos
    | _ -> boundedRand rng min max

  let internal update (rng:System.Random) errorFn dimBounds x y =
    if x.Intensity > y.Intensity then x else
    let B0 = 1.0
    let g  = 1.0
    let r = Array.map2 (fun x y -> y - x) x.Position y.Position
            |> Array.map (fun x -> x * x)
            |> Array.reduce (+)
    let beta = B0 * -g * r * r
    let pos = updatePosition rng <!> x.Position <*> y.Position <*> (puree beta) <*> dimBounds
    create (pos |> Seq.toArray) errorFn

  let solve swarmSize maxIter tolerance errorFn dimBounds =
    let rng = new System.Random()
    let swarm0 = initSwarm swarmSize rng errorFn dimBounds
    let rec impl (swarm:T array) best currentIter =
      if (currentIter > maxIter) || (best.Error < tolerance) then best else
      let moveToBrightest x = Array.fold (update rng errorFn dimBounds) x swarm
      let newSwarm = Array.map moveToBrightest swarm
      impl newSwarm (findBest newSwarm) (currentIter + 1)
    impl swarm0 (findBest swarm0) 0