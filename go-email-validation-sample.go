// create a free acount at https://app.sendbridge.com/signup
// and get your own API key

// more info in integration https://sendbridge.com/email-validation-api

// This code uses the built-in net/http and encoding/json packages in Go to make the HTTP 
// request and parse the JSON response, respectively. Please make sure to import these 
// packages in your actual Go code.

package main

import (
	"encoding/json"
	"fmt"
	"net/http"
	"io/ioutil"
)

// Response represents the JSON response from the API
type Response struct {
	Email              string `json:"email"`
	Freemail           bool   `json:"freemail"`
	ValidSyntax        bool   `json:"valid_syntax"`
	AbnormalLocalPart  bool   `json:"abnormal_local_part"`
	AbnormalDomain     bool   `json:"abnormal_domain"`
	LocalPartTooLong   bool   `json:"local_part_too_long"`
	Shared             bool   `json:"shared"`
	ValidTLD           bool   `json:"valid_tld"`
	Disposable         bool   `json:"disposable"`
	MXValid            bool   `json:"mx_valid"`
	AValid             string `json:"a_valid"`
	Score              int    `json:"score"`
	TimeTaken          string `json:"time_taken"`
}

func main() {
	// Make HTTP GET request
	resp, err := http.Get("https://api.sendbridge.com/v1/validate/hLxD5h0erBiqmPRbkrjJu4WBdRJI9lMi/tested@emailabc123.com")
	if err != nil {
		fmt.Println("Error making HTTP request:", err)
		return
	}
	defer resp.Body.Close()

	// Read response body
	body, err := ioutil.ReadAll(resp.Body)
	if err != nil {
		fmt.Println("Error reading response body:", err)
		return
	}

	// Parse JSON response into struct
	var response Response
	err = json.Unmarshal(body, &response)
	if err != nil {
		fmt.Println("Error parsing JSON:", err)
		return
	}

	// Access the parsed data
	fmt.Println("Email:", response.Email)
	fmt.Println("Freemail:", response.Freemail)
	fmt.Println("Valid Syntax:", response.ValidSyntax)
	fmt.Println("Abnormal Local Part:", response.AbnormalLocalPart)
	fmt.Println("Abnormal Domain:", response.AbnormalDomain)
	fmt.Println("Local Part Too Long:", response.LocalPartTooLong)
	fmt.Println("Shared:", response.Shared)
	fmt.Println("Valid TLD:", response.ValidTLD)
	fmt.Println("Disposable:", response.Disposable)
	fmt.Println("MX Valid:", response.MXValid)
	fmt.Println("A Valid:", response.AValid)
	fmt.Println("Score:", response.Score)
	fmt.Println("Time Taken:", response.TimeTaken)
}
