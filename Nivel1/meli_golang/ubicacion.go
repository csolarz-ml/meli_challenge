package main

import (
    "fmt"
    "strings"
	"math"
)

func main() {
	
	var d1 float64
	var d2 float64
	var d3 float64
	fmt.Println("Ingrese Distancia 1:")
	fmt.Scanln(&d1)
	fmt.Println("Ingrese Distancia 2:")
	fmt.Scanln(&d2)
	fmt.Println("Ingrese Distancia 3:")
	fmt.Scanln(&d3)
    GetLocations(d1, d2, d3)
}

func GetLocations(d1 float64, d2 float64, d3 float64) {
	// Coordenadas satelite Kenobi
	var x1 float64 = -500
	var y1 float64 = -200
	
	// Coordenadas satelite Skywalker
	var x2 float64 = 100
	var y2 float64 = -100
	
	// Coordenadas satelite Sato
	var x3 float64 = 500
	var y3 float64 = 100
	
	//Calculo la coordenada X
	var partial1 float64 = ((math.Pow(y2, 2) - math.Pow(y1, 2)) + (math.Pow(x2, 2) - math.Pow(x1, 2)) +
				   (math.Pow(d1, 2) - math.Pow(d2, 2))) * (y2 - y3);

	var partial2 float64 = (math.Pow(y3, 2) - math.Pow(y2, 2)) + (math.Pow(x3, 2) - math.Pow(x2, 2)) +
				   (math.Pow(d2, 2) - math.Pow(d3, 2)) * (y1 - y2);

	var partial3 float64 = ((x1 - x2) * (y2 - y3)) - ((x2 - x3) * (y1 - y2));

	var finalX float64 = (partial1 - partial2) / (partial3 * 2);
	
	//Calculo la coordenada Y
	partial1 = ((math.Pow(x2, 2) - math.Pow(x1, 2)) + (math.Pow(y2, 2) - math.Pow(y1, 2)) +
					(math.Pow(d1, 2) - math.Pow(d2, 2))) * (x2 - x3);

	partial2 = (math.Pow(x3, 2) - math.Pow(x2, 2)) + (math.Pow(y3, 2) - math.Pow(y2, 2)) +
				   (math.Pow(d2, 2) - math.Pow(d3, 2)) * (x1 - x2);

	partial3 = ((y1 - y2) * (x2 - x3)) - ((y2 - y3) * (x1 - x2));

	var finalY = (partial1 - partial2) / (partial3 * 2);
	
	fmt.Println("Coordenada X:",finalX)
	fmt.Println("Coordenada Y:",finalY)
	
	return
}