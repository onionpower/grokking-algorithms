package main

import (
	"fmt"
	"math/rand"
)

func main() {
	var a [100]int
	for i := 0; i < 100; i++ {
		a[i] = i
	}
	sum := 0
	for _, v := range a {
		sum += v
	}
	fmt.Println(a)
	b, removed := remove(a[:], rand.Intn(len(a)))
	fmt.Printf("%v is removed\n", removed)
	fmt.Println(b)

	fmt.Printf("inital sum is %v\n", sum)

	sumAfterCut := 0
	for i := range b {
		sumAfterCut += b[i]
	}

	fmt.Printf("sum after cut is %v\n", sumAfterCut)
	fmt.Printf("missed values is %v", sum-sumAfterCut)
}

func remove(a []int, pos int) ([]int, int) {
	tmp := a[pos]
	a[pos] = a[(len(a) - 1)]
	return append(a[:len(a)-1]), tmp
	// in a case the order matters
	// return append(a[0:pos], a[pos+1:len(a)]...), tmp
}
