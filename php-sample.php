<?php

// create a free acount at https://app.sendbridge.com/signup
// and get your own API key

// more info in integration https://sendbridge.com/email-validation-api

$url = "https://api.sendbridge.com/v1/validate/hLxD5h0erBiqmPRbkrjJu4WBdRJI9lMi/tested@emailabc123.com";

// Initialize cURL
$curl = curl_init($url);

// Set cURL options
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);

// Execute cURL request
$response = curl_exec($curl);

// Check for errors
if(curl_errno($curl)){
    echo 'Error: ' . curl_error($curl);
    exit;
}

// Close cURL
curl_close($curl);

// Decode JSON response
$json = json_decode($response, true);

// Check if JSON decoding was successful
if(json_last_error() !== JSON_ERROR_NONE){
    echo 'Error: Failed to decode JSON response';
    exit;
}

// Extract data from JSON response
$email = $json['email'];
$freemail = $json['freemail'];
$valid_syntax = $json['valid_syntax'];
$abnormal_local_part = $json['abnormal_local_part'];
$abnormal_domain = $json['abnormal_domain'];
$local_part_too_long = $json['local_part_too_long'];
$shared = $json['shared'];
$valid_tld = $json['valid_tld'];
$disposable = $json['disposable'];
$mx_valid = $json['mx_valid'];
$a_valid = $json['a_valid'];
$score = $json['score'];
$time_taken = $json['time_taken'];

// Print extracted data
echo "Email: " . $email . PHP_EOL;
echo "Free Email: " . ($freemail ? 'true' : 'false') . PHP_EOL;
echo "Valid Syntax: " . ($valid_syntax ? 'true' : 'false') . PHP_EOL;
echo "Abnormal Local Part: " . ($abnormal_local_part ? 'true' : 'false') . PHP_EOL;
echo "Abnormal Domain: " . ($abnormal_domain ? 'true' : 'false') . PHP_EOL;
echo "Local Part Too Long: " . ($local_part_too_long ? 'true' : 'false') . PHP_EOL;
echo "Shared: " . ($shared ? 'true' : 'false') . PHP_EOL;
echo "Valid TLD: " . ($valid_tld ? 'true' : 'false') . PHP_EOL;
echo "Disposable: " . ($disposable ? 'true' : 'false') . PHP_EOL;
echo "MX Valid: " . ($mx_valid ? 'true' : 'false') . PHP_EOL;
echo "A Valid: " . $a_valid . PHP_EOL;
echo "Score: " . $score . PHP_EOL;
echo "Time Taken: " . $time_taken . PHP_EOL;

?>
