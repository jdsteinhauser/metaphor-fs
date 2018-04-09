namespace Metaphor

module Option = 
  let puree f = Some f
  let (<*>) f x =
    match (f, x) with
    | (Some f', Some x') -> Some (f' x')
    | _ -> None

  let (<!>) f x = (puree f) <*> x

module ZipList =
  let puree f = Seq.initInfinite (fun _ -> f)
  let (<*>) f x = Seq.map2 (fun f' x' -> f' x') f x
  let (<!>) f x = (puree f) <*> x