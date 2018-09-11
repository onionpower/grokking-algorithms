package main

import (
	"fmt"
)

func Sqrt(x, prec float64) float64 {
	i := x/2
	for seg := i; subAbs(x, i*i) > prec ; seg = seg/2 {
		if i*i < x {
			i += seg
		} else {
			i -= seg
		}
	}
	return i
}

func subAbs(m, s float64) float64{
	r := m - s
	if r < 0 {
		return r * -1
	}
	return r
}

func main() {
	fmt.Println(Sqrt(2, 0.000000001))
}
