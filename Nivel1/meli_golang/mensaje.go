package main

import (
    "fmt"
    "strings"
)

func main() {
	
	mensaje1 := [5]string{"este", "", "", "mensaje", ""}
	mensaje2 := [5]string{"", "es", "", "", "secreto"}
	mensaje3 := [5]string{"este", "", "un", "", ""}
	mensajeFinal := GetMessage(mensaje1, mensaje2, mensaje3)
	fmt.Println(mensajeFinal)
}

func GetMessage(m1 [5]string, m2 [5]string, m3 [5]string) string {
	mensajeArray := [5]string{"", "", "", "", ""}
	
	for i, s := range m1 {
		if s != "" {
			mensajeArray[i] = s
		}
	}
	
	for i, s := range m2 {
		if s != "" {
			mensajeArray[i] = s
		}
	}
	
	for i, s := range m3 {
		if s != "" {
			mensajeArray[i] = s
		}
	}
	
	var mensaje string
	mensaje = strings.Join(mensajeArray[:], " ")
	
	return mensaje
}

