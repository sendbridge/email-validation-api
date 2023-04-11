import requests

# create a free acount at https://app.sendbridge.com/signup
# and get your own API key

# more info in integration https://sendbridge.com/email-validation-api

# Make sure you have the requests library installed in your Python environment. 
# You can install it using pip by running pip install requests before running the above code.

# API endpoint URL
url = "https://api.sendbridge.com/v1/validate/hLxD5h0erBiqmPRbkrjJu4WBdRJI9lMi/tested@emailabc123.com"

# Send GET request to the API
response = requests.get(url)

# Check if the request was successful (status code 200)
if response.status_code == 200:
    # Retrieve the JSON response
    json_response = response.json()

    # Extract the values from the JSON response
    email = json_response["email"]
    freemail = json_response["freemail"]
    valid_syntax = json_response["valid_syntax"]
    abnormal_local_part = json_response["abnormal_local_part"]
    abnormal_domain = json_response["abnormal_domain"]
    local_part_too_long = json_response["local_part_too_long"]
    shared = json_response["shared"]
    valid_tld = json_response["valid_tld"]
    disposable = json_response["disposable"]
    mx_valid = json_response["mx_valid"]
    a_valid = json_response["a_valid"]
    score = json_response["score"]
    time_taken = json_response["time_taken"]

    # Print the extracted values
    print("Email:", email)
    print("Freemail:", freemail)
    print("Valid Syntax:", valid_syntax)
    print("Abnormal Local Part:", abnormal_local_part)
    print("Abnormal Domain:", abnormal_domain)
    print("Local Part Too Long:", local_part_too_long)
    print("Shared:", shared)
    print("Valid TLD:", valid_tld)
    print("Disposable:", disposable)
    print("MX Valid:", mx_valid)
    print("A Valid:", a_valid)
    print("Score:", score)
    print("Time Taken:", time_taken)
else:
    print("Error:", response.status_code)
