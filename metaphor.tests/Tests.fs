namespace Metaphor.Tests

open Xunit
open Metaphor

module UnitTests =

    [<Fact>]
    let ``2-D Michalewicz w/ Firefly``() =
        let tolerance = 1.0e-5
        let result = Firefly.solve 40 1000 tolerance (Michalewicz.error) (Array.init 2 (fun _ -> (0.0, 3.2)))
        Assert.InRange(result.Error, 0.0, tolerance)
    [<Fact>]
    let ``Sphere w/ Firefly``() =
        let tolerance = 1.0e-5
        let result = Firefly.solve 40 1000 tolerance (Sphere.error) [| (-10.0, 10.0) ; (-10.0, 10.0) |]
        Assert.InRange(result.Error, 0.0, tolerance)
