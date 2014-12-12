
#time

let total = 6552

for x in  [1..total] do
    for y in  [1..total-x]  do
        let z = total - (x + y) 
        if x * y * z  = total * 100 * 100 then (printfn "%A %A %A" x y z)
        
    