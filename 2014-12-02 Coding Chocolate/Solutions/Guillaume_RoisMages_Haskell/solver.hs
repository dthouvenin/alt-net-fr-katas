soluces n = [[x, y, z] | x <- [1..n], y <- [x..(n-x) `div` 2], z<-[n-y-x], x*y*(n-x-y) == n *100 * 100] 

--- How to run it ---
-- $ apt-get install ghc #On Ubuntu
-- $ brew install ghc #On Mac
-- $ ghci solver.hs #launch Haskell repl
-- > soluces 6552 #to be run in the repl prompt


--- How does it work ---
-- To avoid having the same solution several times with different permutations, we consider that x <= y <= z
-- Hence the lower bound of y is x

-- Moreover there's no point in testing values of y such that y > n - x - z, which is equivalent to saying
-- that we only want y + z <= n - x.
-- And since y <= z, it means that we only need to test values of y such that 2*y <= n - x
-- so the upper bound for y is (n-x) / 2


