namespace Metaphor.Tests

module Michalewicz =
    let private impl x i =
        let a = sin x
        let b = (x ** 2.0 * (float i)) / System.Math.PI |> sin
        let c = b ** 20.0
        a * c
    let private func xs =
        xs 
        |> Array.mapi (fun i x -> impl x (i+1))
        |> Array.reduce (+)
        |> (~-)
    let error xs =
        let min = 
            match Seq.length xs with
            | 2 -> -1.8013
            | 5 -> -4.687658
            | 10 -> -9.66015
            | _ -> 0.0
        let calc = func xs
        (min - calc) ** 2.0

module Sphere =
    let private func (xs : float array) =
        xs
        |> Array.map (fun x -> x * x)
        |> Array.reduce (+)

    let error xs = (func xs) * (func xs)