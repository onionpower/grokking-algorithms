package main

import "fmt"

type Node struct {
	value int
	next  *Node
}

func main() {
	shared := &Node{544, nil}
	fmt.Printf("%p: %v\n", shared, shared)
	lp1 := initListWithShared(shared, 9)
	lp2 := initListWithShared(shared, 5)
	printList(lp1)
	printList(lp2)

	n1 := getListLength(lp1)
	n2 := getListLength(lp2)
	fmt.Println(n1)
	fmt.Println(n2)

	found := findSharedNode(n1, n2, lp1, lp2)
	fmt.Printf("%p: %v\n", found, found)
	fmt.Println("Shared eqauls found: ", found == shared)
}

func findSharedNode(n1 int, n2 int, lp1 *Node, lp2 *Node) *Node {
	var p1, p2 *Node
	var skip int
	if n1 > n2 {
		p1 = lp1
		p2 = lp2
		skip = n1 - n2
	} else {
		p1 = lp2
		p2 = lp1
		skip = n2 - n1
	}
	for i := 0; i < skip; i++ {
		p1 = p1.next
	}
	for p1.next != nil && p2.next != nil {
		if p1 == p2 {
			return p1
		}
		p1 = p1.next
		p2 = p2.next
	}
	return nil
}
func getListLength(first *Node) int {
	if first == nil {
		return 0
	}
	for node, i := first, 1; ; i++ {
		if node.next == nil {
			return i
		}
		node = node.next
	}
	return 0
}

func initListWithShared(shared *Node, length int) *Node {
	first := &Node{0, nil}
	var last *Node
	for i, node := 1, first; i < length/2; i++ {
		node.next = &Node{i, nil}
		node = node.next
		last = node
	}
	last.next = shared
	for i, node := length/2, shared; i < length-1; i++ {
		node.next = &Node{i, nil}
		node = node.next
	}
	return first
}

func printList(first *Node) {
	for node := first; node != nil; node = node.next {
		fmt.Printf("%v, ", node.value)
	}
	fmt.Println()
}
